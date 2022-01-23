using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using PDFPatcher.Common;
using PDFPatcher.Processor;
using PowerJson;

namespace PDFPatcher.Model;

public abstract class AutoBookmarkCondition : ICloneable
{
    [XmlAttribute(Constants.AutoBookmark.IsInclusive)]
    public bool IsInclusive { get; set; }

    public abstract string Description { get; }
    public abstract string Name { get; }
    internal abstract bool IsTextLineFilter { get; }

    public abstract object Clone();
    internal abstract AutoBookmarkFilter CreateFilter();

    [JsonTypeAlias(ThisName)]
    public class MultiCondition : AutoBookmarkCondition
    {
        internal const string ThisName = "Condition group";

        public MultiCondition()
        {
        }

        public MultiCondition(AutoBookmarkCondition condition)
        {
            if (condition is MultiCondition m)
            {
                foreach (AutoBookmarkCondition item in m.Conditions)
                {
                    Conditions.Add(item.Clone() as AutoBookmarkCondition);
                }
            }
            else
            {
                Conditions.Add(condition);
            }
        }

        [XmlElement(FontNameCondition.ThisName, typeof(FontNameCondition))]
        [XmlElement(TextSizeCondition.ThisName, typeof(TextSizeCondition))]
        [XmlElement(PageRangeCondition.ThisName, typeof(PageRangeCondition))]
        [XmlElement(TextCondition.ThisName, typeof(TextCondition))]
        [JsonField("condition")]
        public Collection<AutoBookmarkCondition> Conditions { get; } = new();

        public override string Description
        {
            get
            {
                string[] s = new string[Conditions.Count];
                for (int i = 0; i < s.Length; i++)
                {
                    s[i] = Conditions[i].Description;
                }

                return string.Join(";", s);
            }
        }

        public override string Name => "Multi-conditional combination";

        internal override bool IsTextLineFilter => Conditions.Any(item => item.IsTextLineFilter);

        public override object Clone()
        {
            MultiCondition m = new();
            foreach (AutoBookmarkCondition item in Conditions)
            {
                m.Conditions.Add(item.Clone() as AutoBookmarkCondition);
            }

            return m;
        }

        internal override AutoBookmarkFilter CreateFilter() => new MultiConditionFilter(this);
    }

    [JsonTypeAlias(ThisName)]
    public class FontNameCondition : AutoBookmarkCondition
    {
        internal const string ThisName = "Font name";

        public FontNameCondition()
        {
        }

        internal FontNameCondition(string fontName, bool matchFullName)
        {
            FontName = fontName;
            MatchFullName = matchFullName;
        }

        /// <summary>
        ///     Need to adjust the font name of the level.
        /// </summary>
        [XmlAttribute(ThisName)]
        public string FontName { get; set; }

        /// <summary>
        ///     Do you match the full name of the font.
        /// </summary>
        [XmlAttribute("Match font full name")]
        public bool MatchFullName { get; set; }

        public override string Description =>
            string.Concat(ThisName, MatchFullName ? "is" : "includes", "\"", FontName, "\"");

        public override string Name => ThisName;

        internal override bool IsTextLineFilter => false;

        internal override AutoBookmarkFilter CreateFilter() => new FontNameFilter(FontName, MatchFullName);

        public override object Clone() => new FontNameCondition(FontName, MatchFullName);
    }

    [JsonTypeAlias(ThisName)]
    public class TextSizeCondition : AutoBookmarkCondition
    {
        internal const string ThisName = "Font size";
        private string _description;
        private float _minSize, _maxSize;

        public TextSizeCondition()
        {
        }

        internal TextSizeCondition(float size) => SetRange(size, size);

        internal TextSizeCondition(float minSize, float maxSize) => SetRange(minSize, maxSize);

        [XmlAttribute("smallest size")]
        [DefaultValue(0)]
        public float MinSize
        {
            get => _minSize;
            set
            {
                _minSize = value;
                _description = null;
            }
        }

        [XmlAttribute("biggest size")]
        [DefaultValue(0)]
        public float MaxSize
        {
            get => _maxSize;
            set
            {
                _maxSize = value;
                _description = null;
            }
        }

        public override string Description
        {
            get
            {
                if (_description == null)
                {
                    UpdateRangeDescription();
                }

                return _description;
            }
        }

        public override string Name => ThisName;

        internal override bool IsTextLineFilter => false;

        private void UpdateRangeDescription() =>
            _description = ThisName + (_minSize == _maxSize
                ? "equal to" + _minSize.ToText()
                : "Between" + _minSize.ToText() + " and " + _maxSize.ToText());

        public override object Clone()
        {
            TextSizeCondition f = new() { _minSize = _minSize, _maxSize = _maxSize };
            f.UpdateRangeDescription();
            return f;
        }

        internal void SetRange(float a, float b)
        {
            if (a > b)
            {
                _minSize = b;
                _maxSize = a;
            }
            else
            {
                _minSize = a;
                _maxSize = b;
            }

            _description = null;
        }


        internal override AutoBookmarkFilter CreateFilter() => new TextSizeFilter(_minSize, _maxSize);
    }

    [JsonTypeAlias(ThisName)]
    public class TextPositionCondition : AutoBookmarkCondition
    {
        internal const string ThisName = "Text coordinates";
        private string _description;
        private float _minValue, _maxValue;
        private byte _position;

        public TextPositionCondition()
        {
        }

        internal TextPositionCondition(byte position, float value) => SetRange(position, value, value);

        internal TextPositionCondition(byte position, float value1, float value2) => SetRange(position, value1, value2);

        [XmlAttribute("coordinate value")]
        [DefaultValue(0)]
        public byte Position
        {
            get => _position;
            set
            {
                _position = value;
                _description = null;
            }
        }

        [XmlAttribute("Coordinate minimum value")]
        [DefaultValue(0)]
        public float MinValue
        {
            get => _minValue;
            set
            {
                _minValue = value;
                _description = null;
            }
        }

        [XmlAttribute("coordinate maximum value")]
        [DefaultValue(0)]
        public float MaxValue
        {
            get => _maxValue;
            set
            {
                _maxValue = value;
                _description = null;
            }
        }

        public override string Description
        {
            get
            {
                if (_description == null)
                {
                    UpdateRangeDescription();
                }

                return _description;
            }
        }

        public override string Name => ThisName;

        internal override bool IsTextLineFilter => false;

        private void UpdateRangeDescription() =>
            _description = string.Concat(ThisName,
                _position switch
                {
                    1 => "up",
                    2 => "down",
                    3 => "left",
                    4 => "right",
                    _ => string.Empty
                },
                "coordinate",
                _minValue == _maxValue
                    ? "equal to" + _minValue.ToText()
                    : "between" + _minValue.ToText() + " and " + _maxValue
            );

        public override object Clone()
        {
            TextPositionCondition f = new() { _position = _position, _minValue = _minValue, _maxValue = _maxValue };
            f.UpdateRangeDescription();
            return f;
        }

        internal void SetRange(byte position, float value1, float value2)
        {
            _position = position;
            if (value1 > value2)
            {
                _minValue = value2;
                _maxValue = value1;
            }
            else
            {
                _minValue = value1;
                _maxValue = value2;
            }

            _description = null;
        }


        internal override AutoBookmarkFilter CreateFilter() => new TextPositionFilter(_position, _minValue, _maxValue);
    }

    [JsonTypeAlias(ThisName)]
    public class PageRangeCondition : AutoBookmarkCondition
    {
        internal const string ThisName = "Page size range";

        [XmlAttribute(ThisName)] public string PageRange { get; set; }

        public override string Description => "The page size range is \"" + PageRange + "\"";

        public override string Name => ThisName;

        internal override bool IsTextLineFilter => false;

        public override object Clone() => new PageRangeCondition { PageRange = PageRange };

        internal override AutoBookmarkFilter CreateFilter() => new PageRangeFilter(PageRange);
    }

    [JsonTypeAlias(ThisName)]
    public class TextCondition : AutoBookmarkCondition
    {
        internal const string ThisName = "Text content";

        public TextCondition() => Pattern = new MatchPattern();

        private TextCondition(MatchPattern pattern) => Pattern = pattern.Clone() as MatchPattern;

        [XmlElement("Text Pattern")] public MatchPattern Pattern { get; set; }

        public override string Description => string.Concat(ThisName,
            Pattern.MatchCase ? "case sensitive" : string.Empty,
            Pattern.FullMatch ? "exact match" : "match",
            Pattern.UseRegularExpression ? "regular expression" : string.Empty,
            Pattern.Text);

        public override string Name => ThisName;

        internal override bool IsTextLineFilter => true;

        public override object Clone() => new TextCondition(Pattern);

        internal override AutoBookmarkFilter CreateFilter() => new TextFilter(Pattern);
    }
}
