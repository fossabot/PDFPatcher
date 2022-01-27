namespace PDFPatcher.Functions
{
	partial class OcrControl
	{
		/// <summary>
		/// Required designer variables.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up all resources in use.
		/// </summary>
		/// <param name="disposing">true if the managed resource should be released; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Component Designer Generated Code

		/// <summary>
		/// Designer supports required methods - Don't
		/// use a code editor to modify the content of this method.
		/// </summary>
		private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OcrControl));
            this.label3 = new System.Windows.Forms.Label();
            this._PageRangeBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._PrintOcrResultBox = new System.Windows.Forms.CheckBox();
            this._OutputOriginalOcrResultBox = new System.Windows.Forms.CheckBox();
            this._ConvertToMonoColorBox = new System.Windows.Forms.CheckBox();
            this._RemoveSpaceBetweenChineseBox = new System.Windows.Forms.CheckBox();
            this._SaveOcredImageBox = new System.Windows.Forms.CheckBox();
            this._CompressWhiteSpaceBox = new System.Windows.Forms.CheckBox();
            this._DetectContentPunctuationsBox = new System.Windows.Forms.CheckBox();
            this._DetectColumnsBox = new System.Windows.Forms.CheckBox();
            this._StretchBox = new System.Windows.Forms.CheckBox();
            this._OrientBox = new System.Windows.Forms.CheckBox();
            this._OcrLangBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._WritingDirectionBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this._QuantitiveFactorBox = new System.Windows.Forms.NumericUpDown();
            this._SourceFileControl = new PDFPatcher.SourceFileControl();
            this._BookmarkControl = new PDFPatcher.BookmarkControl();
            this._TargetFileControl = new PDFPatcher.TargetFileControl();
            this._ExportBookmarkButton = new System.Windows.Forms.Button();
            this._ImportOcrResultButton = new EnhancedGlassButton.GlassButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._QuantitiveFactorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _PageRangeBox
            // 
            resources.ApplyResources(this._PageRangeBox, "_PageRangeBox");
            this._PageRangeBox.Name = "_PageRangeBox";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._PrintOcrResultBox);
            this.tabPage1.Controls.Add(this._OutputOriginalOcrResultBox);
            this.tabPage1.Controls.Add(this._ConvertToMonoColorBox);
            this.tabPage1.Controls.Add(this._RemoveSpaceBetweenChineseBox);
            this.tabPage1.Controls.Add(this._SaveOcredImageBox);
            this.tabPage1.Controls.Add(this._CompressWhiteSpaceBox);
            this.tabPage1.Controls.Add(this._DetectContentPunctuationsBox);
            this.tabPage1.Controls.Add(this._DetectColumnsBox);
            this.tabPage1.Controls.Add(this._StretchBox);
            this.tabPage1.Controls.Add(this._OrientBox);
            this.tabPage1.Controls.Add(this._OcrLangBox);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this._WritingDirectionBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this._PageRangeBox);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _PrintOcrResultBox
            // 
            resources.ApplyResources(this._PrintOcrResultBox, "_PrintOcrResultBox");
            this._PrintOcrResultBox.Name = "_PrintOcrResultBox";
            this._PrintOcrResultBox.UseVisualStyleBackColor = true;
            // 
            // _OutputOriginalOcrResultBox
            // 
            resources.ApplyResources(this._OutputOriginalOcrResultBox, "_OutputOriginalOcrResultBox");
            this._OutputOriginalOcrResultBox.Name = "_OutputOriginalOcrResultBox";
            this._OutputOriginalOcrResultBox.UseVisualStyleBackColor = true;
            this._OutputOriginalOcrResultBox.CheckedChanged += new System.EventHandler(this.ControlEvent);
            // 
            // _ConvertToMonoColorBox
            // 
            resources.ApplyResources(this._ConvertToMonoColorBox, "_ConvertToMonoColorBox");
            this._ConvertToMonoColorBox.Name = "_ConvertToMonoColorBox";
            this._ConvertToMonoColorBox.UseVisualStyleBackColor = true;
            // 
            // _RemoveSpaceBetweenChineseBox
            // 
            resources.ApplyResources(this._RemoveSpaceBetweenChineseBox, "_RemoveSpaceBetweenChineseBox");
            this._RemoveSpaceBetweenChineseBox.Name = "_RemoveSpaceBetweenChineseBox";
            this._RemoveSpaceBetweenChineseBox.UseVisualStyleBackColor = true;
            // 
            // _SaveOcredImageBox
            // 
            resources.ApplyResources(this._SaveOcredImageBox, "_SaveOcredImageBox");
            this._SaveOcredImageBox.Name = "_SaveOcredImageBox";
            this._SaveOcredImageBox.UseVisualStyleBackColor = true;
            // 
            // _CompressWhiteSpaceBox
            // 
            resources.ApplyResources(this._CompressWhiteSpaceBox, "_CompressWhiteSpaceBox");
            this._CompressWhiteSpaceBox.Name = "_CompressWhiteSpaceBox";
            this._CompressWhiteSpaceBox.UseVisualStyleBackColor = true;
            // 
            // _DetectContentPunctuationsBox
            // 
            resources.ApplyResources(this._DetectContentPunctuationsBox, "_DetectContentPunctuationsBox");
            this._DetectContentPunctuationsBox.Name = "_DetectContentPunctuationsBox";
            this._DetectContentPunctuationsBox.UseVisualStyleBackColor = true;
            // 
            // _DetectColumnsBox
            // 
            resources.ApplyResources(this._DetectColumnsBox, "_DetectColumnsBox");
            this._DetectColumnsBox.Name = "_DetectColumnsBox";
            this._DetectColumnsBox.UseVisualStyleBackColor = true;
            // 
            // _StretchBox
            // 
            resources.ApplyResources(this._StretchBox, "_StretchBox");
            this._StretchBox.Name = "_StretchBox";
            this._StretchBox.UseVisualStyleBackColor = true;
            // 
            // _OrientBox
            // 
            resources.ApplyResources(this._OrientBox, "_OrientBox");
            this._OrientBox.Name = "_OrientBox";
            this._OrientBox.UseVisualStyleBackColor = true;
            // 
            // _OcrLangBox
            // 
            this._OcrLangBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._OcrLangBox.FormattingEnabled = true;
            resources.ApplyResources(this._OcrLangBox, "_OcrLangBox");
            this._OcrLangBox.Name = "_OcrLangBox";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _WritingDirectionBox
            // 
            this._WritingDirectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._WritingDirectionBox.FormattingEnabled = true;
            this._WritingDirectionBox.Items.AddRange(new object[] {
            resources.GetString("_WritingDirectionBox.Items"),
            resources.GetString("_WritingDirectionBox.Items1"),
            resources.GetString("_WritingDirectionBox.Items2")});
            resources.ApplyResources(this._WritingDirectionBox, "_WritingDirectionBox");
            this._WritingDirectionBox.Name = "_WritingDirectionBox";
            this._WritingDirectionBox.SelectedIndexChanged += new System.EventHandler(this.ControlEvent);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // _QuantitiveFactorBox
            // 
            this._QuantitiveFactorBox.DecimalPlaces = 2;
            this._QuantitiveFactorBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this._QuantitiveFactorBox, "_QuantitiveFactorBox");
            this._QuantitiveFactorBox.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._QuantitiveFactorBox.Name = "_QuantitiveFactorBox";
            // 
            // _SourceFileControl
            // 
            resources.ApplyResources(this._SourceFileControl, "_SourceFileControl");
            this._SourceFileControl.Name = "_SourceFileControl";
            // 
            // _BookmarkControl
            // 
            resources.ApplyResources(this._BookmarkControl, "_BookmarkControl");
            this._BookmarkControl.LabelText = "Identification result file:";
            this._BookmarkControl.Name = "_BookmarkControl";
            this._BookmarkControl.UseForBookmarkExport = true;
            // 
            // _TargetFileControl
            // 
            resources.ApplyResources(this._TargetFileControl, "_TargetFileControl");
            this._TargetFileControl.Name = "_TargetFileControl";
            // 
            // _ExportBookmarkButton
            // 
            resources.ApplyResources(this._ExportBookmarkButton, "_ExportBookmarkButton");
            this._ExportBookmarkButton.Image = global::PDFPatcher.Properties.Resources.Ocr;
            this._ExportBookmarkButton.Name = "_ExportBookmarkButton";
            this._ExportBookmarkButton.UseVisualStyleBackColor = true;
            this._ExportBookmarkButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // _ImportOcrResultButton
            // 
            this._ImportOcrResultButton.AlternativeFocusBorderColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this._ImportOcrResultButton, "_ImportOcrResultButton");
            this._ImportOcrResultButton.AnimateGlow = true;
            this._ImportOcrResultButton.BackColor = System.Drawing.SystemColors.Highlight;
            this._ImportOcrResultButton.CornerRadius = 3;
            this._ImportOcrResultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ImportOcrResultButton.GlowColor = System.Drawing.Color.White;
            this._ImportOcrResultButton.Image = global::PDFPatcher.Properties.Resources.Save;
            this._ImportOcrResultButton.InnerBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this._ImportOcrResultButton.Name = "_ImportOcrResultButton";
            this._ImportOcrResultButton.OuterBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this._ImportOcrResultButton.ShowFocusBorder = true;
            this._ImportOcrResultButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // OcrControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._TargetFileControl);
            this.Controls.Add(this._ExportBookmarkButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this._SourceFileControl);
            this.Controls.Add(this.label14);
            this.Controls.Add(this._BookmarkControl);
            this.Controls.Add(this._QuantitiveFactorBox);
            this.Controls.Add(this._ImportOcrResultButton);
            this.Name = "OcrControl";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._QuantitiveFactorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private SourceFileControl _SourceFileControl;
		private BookmarkControl _BookmarkControl;
		private System.Windows.Forms.Button _ExportBookmarkButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _PageRangeBox;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox _WritingDirectionBox;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.NumericUpDown _QuantitiveFactorBox;
		private System.Windows.Forms.CheckBox _StretchBox;
		private System.Windows.Forms.CheckBox _OrientBox;
		private System.Windows.Forms.ComboBox _OcrLangBox;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox _DetectColumnsBox;
		private System.Windows.Forms.CheckBox _DetectContentPunctuationsBox;
		private System.Windows.Forms.CheckBox _CompressWhiteSpaceBox;
		private System.Windows.Forms.CheckBox _RemoveSpaceBetweenChineseBox;
		private System.Windows.Forms.CheckBox _SaveOcredImageBox;
		private System.Windows.Forms.CheckBox _ConvertToMonoColorBox;
		private System.Windows.Forms.CheckBox _OutputOriginalOcrResultBox;
		private TargetFileControl _TargetFileControl;
		private EnhancedGlassButton.GlassButton _ImportOcrResultButton;
		private System.Windows.Forms.CheckBox _PrintOcrResultBox;

	}
}
