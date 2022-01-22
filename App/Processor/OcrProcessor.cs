﻿#if DEBUG
#define DEBUGOCR
#endif
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml;
using FreeImageAPI;
using iTextSharp.text.pdf;
using PDFPatcher.Common;
using PDFPatcher.Model;
using PDFPatcher.Processor.Imaging;
using Rectangle = iTextSharp.text.Rectangle;

namespace PDFPatcher.Processor;

internal sealed class OcrProcessor
{
	private const int OpenWorkload = 1;
	private const string __punctuations = @"·．“”，,\.－""～∼。:：\p{P}";

	private static readonly AutoBookmarkOptions __MergeOptions =
		new() { MergeAdjacentTitles = true, MergeDifferentSizeTitles = true };

	private static readonly Regex __ContentPunctuationExpression =
		new(@"[" + __punctuations + @"][" + __punctuations + @"0一\s]+[" + __punctuations + @"]\s*",
			RegexOptions.Compiled);

	private static readonly Regex __ContinuousWhiteSpaceExpression = new(@"[ 　]{3,}", RegexOptions.Compiled);

	private static readonly Regex __WhiteSpaceBetweenChineseCharacters =
		new(@"([\u4E00-\u9FFF\u3400-\u4DBF])[ 　]+(?=[\u4E00-\u9FFF\u3400-\u4DBF])", RegexOptions.Compiled);

	private readonly ModiOcr _Ocr;
	private readonly ImageExtractor _ocrImageExp;
	private readonly float _OcrQuantitativeFactor;
	private readonly OcrOptions _options;
	private readonly PdfReader _reader;
	private IResultWriter _resultWriter;

	public OcrProcessor(PdfReader reader, OcrOptions options) : this(options) {
		ImageExtracterOptions expOptions = new() {
			OutputPath = Path.GetTempPath(),
			FileMask = "\"ocr-" + DateTime.Now.ToString("yyMMddHHmmss") + "-\"0000",
			MergeImages = true,
			MergeJpgToPng = true,
			MinHeight = 100,
			MinWidth = 100
		};
		CleanUpTempFiles(expOptions.OutputPath);
		_reader = reader;
		_ocrImageExp = new ImageExtractor(expOptions, reader) { PrintImageLocation = false };
	}

	private OcrProcessor(OcrOptions options) {
		_Ocr = new ModiOcr {
			LangID = options.OcrLangID,
			StretchPage = options.StretchPage,
			OrientPage = options.OrientPage,
			WritingDirection = options.WritingDirection
		};
		_OcrQuantitativeFactor = options.QuantitativeFactor;
		_options = options;
	}

	private static void CleanUpTempFiles(string folderPath) {
		string[] tf = Directory.GetFiles(folderPath, "ocr-*.tif");
		foreach (string file in tf) {
			try {
				File.Delete(file);
			}
			catch (Exception) {
			}
		}
	}

	internal int EstimateWorkload() {
		int n = _reader.NumberOfPages;
		int load = 0;
		load += OpenWorkload;
		int t = PageRangeCollection.Parse(_options.PageRanges, 1, n, true).TotalPages;
		load += t > 0 ? t : n;
		return load;
	}

	internal void SetWriter(XmlWriter writer) {
		_resultWriter = new XmlResultWriter(writer);
	}

	internal void SetWriter(TextWriter writer) {
		_resultWriter = new TextResultWriter(writer);
	}

	internal void PerformOcr() {
		Tracker.IncrementProgress(OpenWorkload);
		PageRangeCollection ranges = PageRangeCollection.Parse(_options.PageRanges, 1, _reader.NumberOfPages, true);
		__MergeOptions.DetectColumns = _options.DetectColumns;
		__MergeOptions.WritingDirection = _options.WritingDirection;
		TextLine.DefaultDirection = _options.WritingDirection;
		if (FileHelper.IsPathValid(_options.SaveOcredImagePath)) {
			File.Delete(_options.SaveOcredImagePath);
		}

		List<int> el = new();
		foreach (PageRange r in ranges) {
			for (int i = r.StartValue; i <= r.EndValue; i++) {
				Tracker.TraceMessage("正在识别第 " + i + " 页。");
				IList<Result> or = OcrPage(i, el);
				if (or.Count > 0) {
					_resultWriter?.BeginWritePage(i);

					foreach (Result result in or) {
						_resultWriter?.BeginWriteImage(result.Image);
						if (_options.OutputOriginalOcrResult) {
							if (_resultWriter != null) {
								foreach (TextLine item in result.Texts) {
									_resultWriter.WriteText(item, null);
								}
							}
						}
						else {
							WriteOcrResult(i, result);
						}

						_resultWriter?.EndWriteImage();
					}

					_resultWriter?.EndWritePage();
				}

				Tracker.IncrementProgress(1);
			}
		}

		if (el.Count > 0) {
			Tracker.TraceMessage(Tracker.Category.Alert,
				string.Concat("有 ", el.Count, " 页在识别过程中出现错误，页码为：", string.Join(", ", el)));
		}
	}

	private void WriteOcrResult(int i, Result result) {
		SortRecognizedText(result.Texts, _options);
		Rectangle pr = _reader.GetPageNRelease(i).GetPageVisibleRectangle();
		List<TextLine> tl = _options.WritingDirection != WritingDirection.Unknown
			? AutoBookmarkCreator.MergeTextInfoList(pr,
				result.Texts.ConvertAll(l => GetMergedTextInfo(result.Image, l)), __MergeOptions) // 按照书写方向重组识别文本
			: result.Texts;
		foreach (TextLine item in tl) {
			string t = item.Text;
			Bound ir = item.Region;

			t = CleanUpText(t, _options);
			if (_options.PrintOcrResult) {
#if DEBUG
				Tracker.TraceMessage(string.Concat(item.Direction.ToString()[0], ir.Top.ToString(" 0000"), ',',
					ir.Left.ToString("0000"), "(", ir.Width.ToString("0000"), ',', ir.Height.ToString("0000"), ")\t",
					t));
#else
					Tracker.TraceMessage (t);
#endif
			}

			_resultWriter?.WriteText(item, t);
		}
	}

	/// <summary>
	///     根据识别选项优化输出结果。
	/// </summary>
	/// <param name="text">文本内容。</param>
	/// <param name="options">识别选项。</param>
	/// <returns>优化后的文本。</returns>
	internal static string CleanUpText(string text, OcrOptions options) {
		if (options.DetectContentPunctuations) {
			text = __ContentPunctuationExpression.Replace(text, " .... ");
		}

		if (options.CompressWhiteSpaces) {
			text = __ContinuousWhiteSpaceExpression.Replace(text, "  ");
		}

		if (options.RemoveWhiteSpacesBetweenChineseCharacters) {
			text = __WhiteSpaceBetweenChineseCharacters.Replace(text, "$1");
		}

		return text;
	}

	private IList<Result> OcrPage(int i, ICollection<int> errorList) {
#if DEBUGOCR
		Tracker.TraceMessage("导出第 " + i + " 页的图片。");
#endif
		_ocrImageExp.ExtractPageImages(_reader, i);
#if DEBUGOCR
		Tracker.TraceMessage("完成导出第 " + i + " 页的图片。");
#endif
		List<Result> or = new();
		try {
			foreach (ImageDisposition item in _ocrImageExp.PosList) {
				Result r = new(item);
				OcrPage(r);
				or.Add(r);
			}
		}
		catch (COMException ex) {
			string err = null;
			switch (ex.ErrorCode) {
				case -959967087:
					err = "页面的图片不包含可识别的文本。";
					goto default;
				default:
					Tracker.TraceMessage(Tracker.Category.Error, "在执行第 " + i + " 页的光学字符识别时出错：");
					if (err != null) {
						Tracker.TraceMessage(err);
					}
					else {
						Tracker.TraceMessage("错误编号：" + ex.ErrorCode);
						Tracker.TraceMessage(ex);
						errorList.Add(i);
					}

					break;
			}
		}
		catch (Exception ex) {
			Tracker.TraceMessage(Tracker.Category.Error, "在执行第 " + i + " 页的光学字符识别时出错：");
			Tracker.TraceMessage(ex);
			errorList.Add(i);
		}
		finally {
			foreach (var item in _ocrImageExp.InfoList.Where(item => !string.IsNullOrEmpty(item.FileName))) {
				try {
					File.Delete(item.FileName);
				}
				catch (Exception ex) {
					Tracker.TraceMessage(Tracker.Category.Error, ex.Message);
					Tracker.TraceMessage(Tracker.Category.Error, "无法删除识别过程中产生的临时文件：" + item.FileName);
				}
			}
		}

		return or;
	}

	private void OcrPage(Result result) {
		ImageDisposition image = result.Image;
		string p = image.Image.FileName;
		if (string.IsNullOrEmpty(p)) {
			return;
		}
#if DEBUGOCR
		Tracker.TraceMessage("识别图片：" + p);
#endif
#if DEBUG
		Tracker.TraceMessage(p);
#endif
		result.Texts.Clear();
		OcrImageFile(result.Texts, p);

		#region Legacy code

		//            var ll = new List<TextLine> ();
		//            // 同行合并宽度最小值
		//            var cw = image.Image.Width / 4;

		//            // 遍历识别所得的各 TextInfo，使用最小距离聚类方法将其聚类为行
		//            foreach (var item in or) {
		//                var ir = item.Region;
		//                DistanceInfo cd = null; // TextInfo 到 TextLine 的距离
		//                DistanceInfo md = new DistanceInfo (DistanceInfo.Placement.Unknown, float.MaxValue); // 最小距离
		//                TextLine ml = null; // 最小距离的 TextLine

		//if (item.Text == "哉") {
		//    var lxx = 1;
		//}
		//                // 求最小距离的 TextLine
		//                foreach (var li in ll) {
		//                    cd = li.GetDistance (ir);
		//                    if ((cd.Location == DistanceInfo.Placement.Overlapping // 当前项与文本行交叠
		//                            && (md.Location != DistanceInfo.Placement.Overlapping // 最小距离不是交叠
		//                                || cd.Distance < md.Distance) // 当前项与文本行的交叠中心距离小于最小距离
		//                            )
		//                        || ((md.Location == DistanceInfo.Placement.Unknown // 未知最小距离
		//                            || (cd.Location != DistanceInfo.Placement.Overlapping
		//                                && md.Location != DistanceInfo.Placement.Overlapping
		//                                && cd.Distance < md.Distance) // 当前项与文本行的距离小于最小距离
		//                            )
		//                            && (((cd.Location == DistanceInfo.Placement.Left || cd.Location == DistanceInfo.Placement.Right) // 相对位置为水平
		//                                    && li.Direction != TextLine.WritingDirection.Vertical // 文本行方向不为纵向
		//                                    )
		//                                || ((cd.Location == DistanceInfo.Placement.Up || cd.Location == DistanceInfo.Placement.Down) // 相对位置为垂直
		//                                    && li.Direction != TextLine.WritingDirection.Horizontal // 文本行方向不为横向
		//                                    )
		//                                )
		//                            && cd.Distance < cw
		//                        )
		//                        ) {
		//                        md = cd;
		//                        ml = li;
		//                    }
		//                }

		//                if (ml != null) {
		//                    // 若存在最小距离的 TextLine 且可合并，则将 item 归入 TextLine
		//                    if (md.Location == DistanceInfo.Placement.Overlapping) {
		//                        // 检查是否存在交叠重复的文本
		//                        foreach (var t in ml.Texts) {
		//                            if (t.Region.IntersectWith (item.Region) // item 与 TextLine 中某项交叠
		//                                && (t.Text.Contains (item.Text) || item.Text.Contains (t.Text) // 交叠的项文本和 item 的文本相同
		//                                )
		//                                ) {
		//                                goto Next; // 忽略此项目
		//                            }
		//                        }
		//                    }
		//                    ml.AddText (item);
		//                }
		//                else {
		//                    // 否则，用 item 创建新的 TextLine
		//                    ll.Add (new TextLine (item));
		//                }
		//            Next:
		//                continue;
		//            }

		//if (or.Count > 0) {
		//    float size = 0, size2 = 0, avgSize, maxSize = 0;
		//    float top = or[0].Region.Top, bottom = or[0].Region.Bottom, left = or[0].Region.Left, right = 0;
		//    var sb = new System.Text.StringBuilder ();
		//    int letterCount = 0;
		//    var rr = new List<TextInfo> ();
		//    Bound r;
		//    var end = or.Count - 1;
		//    for (var i = 0; i <= end; i++) {
		//        var item = or[i];
		//        r = item.Region;
		//        avgSize = letterCount > 0 ? size / letterCount : maxSize;
		//    AddLine:
		//        if (r.Top > bottom + 0.2f * (avgSize) || i > end) { // 新行
		//            size = image.YScale * avgSize;
		//            if (_OcrQuatitiveFactor > 0) {
		//                var a = Math.IEEERemainder (size, _OcrQuatitiveFactor);
		//                var b = Math.IEEERemainder (size + _OcrQuatitiveFactor, _OcrQuatitiveFactor);
		//                if (a < b) {
		//                    size -= (float)a;
		//                }
		//                else {
		//                    size += _OcrQuatitiveFactor - (float)b;
		//                }
		//            }
		//            if (size >= _fontSizeThreshold) {
		//                var ni = new TextInfo ()
		//                {
		//                    Text = sb.ToString (),
		//                    Size = size,
		//                    Region = new Bound (
		//                        image.X + image.XScale * left,
		//                        image.Y + image.YScale * (image.Image.Height - bottom),
		//                        image.X + image.XScale * right,
		//                        image.Y + image.YScale * (image.Image.Height - top)),
		//                    Font = -1
		//                };
		//                rr.Add (ni);
		//            }
		//            maxSize = size = size2 = 0;
		//            left = r.Left;
		//            right = r.Right;
		//            top = r.Top;
		//            bottom = r.Bottom;
		//            sb.Length = 0;
		//            letterCount = 0;
		//            if (i > end) {
		//                break;
		//            }
		//        }
		//        if (Char.IsLetter (item.Text[0])) {
		//            size += item.Size;
		//            size2 += item.Size * item.Size;
		//            letterCount++;
		//        }
		//        if (item.Size > maxSize) {
		//            maxSize = item.Size;
		//        }
		//        if (r.Top < top) {
		//            top = r.Top;
		//        }
		//        if (r.Bottom > bottom) {
		//            bottom = r.Bottom;
		//        }
		//        if (r.Right > right) {
		//            right = r.Right;
		//        }
		//        sb.Append (item.Text);
		//        if (i == end) {
		//            i++;
		//            goto AddLine;
		//        }
		//    }
		//    this._TextList.AddRange (rr);
		//}

		#endregion
	}

	private void OcrImageFile(List<TextLine> result, string p) {
		string sp = _options.SaveOcredImagePath;
		if (FileHelper.HasExtension(p, Constants.FileExtensions.Tif) == false) {
			using FreeImageBitmap fi = new(p);
#if !DEBUG
					var t = Path.GetDirectoryName (p) + "\\ocr-" + new Random ().Next ().ToText () +".tif";
#else
			const string t = "m:\\ocr.tif";
#endif
			if (_options.PreserveColor) {
				fi.Save(t, FREE_IMAGE_FORMAT.FIF_TIFF);
			}
			else {
				using FreeImageBitmap ti =
					fi.GetColorConvertedInstance(FREE_IMAGE_COLOR_DEPTH.FICD_01_BPP_THRESHOLD);
				ti.Save(t, FREE_IMAGE_FORMAT.FIF_TIFF);
			}

			_Ocr.Ocr(t, sp, result);
#if !DEBUG
					try {
						File.Delete (t);
					}
					catch (Exception) {
						Tracker.TraceMessage (Tracker.Category.Notice, "无法删除临时文件：" + t);
					}
#endif
		}
		else {
			_Ocr.Ocr(p, sp, result);
		}
#if DEBUGOCR
		Tracker.TraceMessage("完成识别图片：" + p);
#endif
	}

	/// <summary>
	///     调用图像处理引擎识别位图。如图片中的文本量太少，将无法识别，并会抛出异常。
	/// </summary>
	/// <param name="bmp">需要识别的图片。</param>
	/// <param name="options">识别选项。</param>
	/// <exception cref="System.Runtime.InteropServices.COMException">在识别时发生的错误。</exception>
	/// <returns>识别后的文本。</returns>
	internal static List<TextLine> OcrBitmap(Bitmap bmp, OcrOptions options) {
		const int minSize = 500;
		OcrProcessor ocr = new(options);
		List<TextLine> r = new();
		string p;
		using (FreeImageBitmap fi = new(bmp)) {
			if (fi.Width < minSize || fi.Height < minSize) {
				fi.EnlargeCanvas<RGBQUAD>(0, 0, fi.Width < minSize ? minSize : fi.Width,
					fi.Height < minSize ? minSize : fi.Height, new RGBQUAD(fi.GetPixel(0, 0)));
			}

			p = FileHelper.CombinePath(Path.GetTempPath(),
				new Random().Next(int.MaxValue).ToText() + Constants.FileExtensions.Tif);
			fi.Save(p, FREE_IMAGE_FORMAT.FIF_TIFF);
		}

		ocr._Ocr.Ocr(p, null, r);
		File.Delete(p);
		return r;
	}

	private static TextInfo GetMergedTextInfo(ImageDisposition image, TextLine item) {
		TextInfo ti = new() {
			Font = null,
			Region = item.Region,
			Text = item.Text,
			Size = (float)Math.Round(item.Direction == WritingDirection.Vertical
				? item.Region.Width /* * image.XScale*/
				: item.Region.Height /* * image.YScale*/),
			LetterWidth = item.GetAverageCharSize()
		};
		//if (item.Texts.Count > 0) {
		//    float aw = 0;
		//    foreach (var t in item.Texts) {
		//        aw += t.LetterWidth;
		//    }
		//    aw /= item.Texts.Count;
		//    ti.LetterWidth = aw;
		//}
		return ti;
	}

	private static void SortRecognizedText(List<TextLine> list, OcrOptions ocrOptions) {
		switch (ocrOptions.WritingDirection) {
			case WritingDirection.Horizontal:
				list.Sort((a, b) => {
					Bound ra = a.Region;
					Bound rb = b.Region;
					if (ra.Bottom > rb.Top) {
						return 1;
					}

					if (ra.Top < rb.Bottom) {
						return -1;
					}

					if (ra.IsAlignedWith(rb, WritingDirection.Horizontal)) {
						return ra.Center < rb.Center ? -1 : 1;
					}

					return ra.Middle < rb.Middle ? -1 : 1;
				});
				break;
			case WritingDirection.Vertical:
				list.Sort((a, b) => {
					Bound ra = a.Region;
					Bound rb = b.Region;
					if (ra.Left > rb.Right) {
						return -1;
					}

					if (ra.Right < rb.Left) {
						return 1;
					}

					if (ra.IsAlignedWith(rb, WritingDirection.Vertical)) {
						return ra.Middle > rb.Middle ? -1 : 1;
					}

					return ra.Center > rb.Center ? -1 : 1;
				});
				break;
		}
	}

	internal sealed class Result
	{
		public Result(ImageDisposition image) {
			Image = image;
			Texts = new List<TextLine>();
		}

		public ImageDisposition Image { get; }
		public List<TextLine> Texts { get; }
	}

	private interface IResultWriter
	{
		void BeginWritePage(int i);
		void BeginWriteImage(ImageDisposition image);
		void WriteText(TextLine text, string optimizedText);
		void EndWriteImage();
		void EndWritePage();
	}

	private sealed class XmlResultWriter : IResultWriter
	{
		private readonly XmlWriter _writer;

		public XmlResultWriter(XmlWriter writer) {
			_writer = writer;
		}

		#region IResultWriter 成员

		public void BeginWritePage(int i) {
			_writer.WriteStartElement(Constants.Ocr.Result);
			_writer.WriteAttributeString(Constants.Content.PageNumber, i.ToText());
		}

		public void WriteText(TextLine text, string optimizedText) {
			if (optimizedText != null) {
				WriteTextItem(optimizedText, text.Region, text.Direction);
				return;
			}

			_writer.WriteComment(text.Text);
			foreach (TextInfo item in text.Texts) {
				WriteTextItem(item.Text, item.Region, WritingDirection.Unknown);
			}
		}

		private void WriteTextItem(string text, Bound ir, WritingDirection direction) {
			_writer.WriteStartElement(Constants.Ocr.Content);
			_writer.WriteAttributeString(Constants.Ocr.Text, text);
			switch (direction) {
				case WritingDirection.Horizontal:
					_writer.WriteAttributeString(Constants.Coordinates.Direction, Constants.Coordinates.Horizontal);
					break;
				case WritingDirection.Vertical:
					_writer.WriteAttributeString(Constants.Coordinates.Direction, Constants.Coordinates.Vertical);
					break;
			}

			_writer.WriteAttributeString(Constants.Coordinates.Top, Math.Round(ir.Top).ToText());
			_writer.WriteAttributeString(Constants.Coordinates.Left, Math.Round(ir.Left).ToText());
			_writer.WriteAttributeString(Constants.Coordinates.Bottom, Math.Round(ir.Bottom).ToText());
			_writer.WriteAttributeString(Constants.Coordinates.Right, Math.Round(ir.Right).ToText());
			_writer.WriteEndElement();
		}

		public void EndWritePage() {
			_writer.WriteEndElement();
		}

		public void BeginWriteImage(ImageDisposition image) {
			_writer.WriteStartElement(Constants.Ocr.Image);
			_writer.WriteAttributeString(Constants.Coordinates.Width, image.Image.Width.ToText());
			_writer.WriteAttributeString(Constants.Coordinates.Height, image.Image.Height.ToText());
			_writer.WriteAttributeString(Constants.Content.OperandNames.Matrix, PdfHelper.MatrixToString(image.Ctm));
		}

		public void EndWriteImage() {
			_writer.WriteEndElement();
		}

		#endregion
	}

	private sealed class TextResultWriter : IResultWriter
	{
		private readonly TextWriter _writer;

		public TextResultWriter(TextWriter writer) {
			_writer = writer;
		}

		#region IResultWriter 成员

		public void BeginWritePage(int i) {
			_writer.WriteLine("#识别页码=" + i);
		}

		public void WriteText(TextLine text, string optimizedText) {
			_writer.WriteLine(optimizedText ?? text.Text);
		}

		public void EndWritePage() {
			_writer.WriteLine();
		}

		public void BeginWriteImage(ImageDisposition image) {
			_writer.WriteLine("#识别图片=" + PdfHelper.MatrixToString(image.Ctm));
		}

		public void EndWriteImage() { }

		#endregion
	}
}