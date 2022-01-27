namespace PDFPatcher.Functions
{
	partial class RenderImageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenderImageControl));
            this._ExtractPageRangeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._SaveImageBox = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._FileMaskPreviewBox = new System.Windows.Forms.Label();
            this._FileNameMaskBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._InvertColorBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._RotationBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this._HorizontalFlipImageBox = new System.Windows.Forms.CheckBox();
            this._HideAnnotationsBox = new System.Windows.Forms.CheckBox();
            this._VerticalFlipImageBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._ResolutionBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._ExtractPageImageWidthBox = new System.Windows.Forms.NumericUpDown();
            this._ExtractPageRatioBox = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._SpecificRatioBox = new System.Windows.Forms.RadioButton();
            this._SpecificWidthBox = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._ColorSpaceRgbBox = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this._QuantizeBox = new System.Windows.Forms.CheckBox();
            this._ColorSpaceGrayBox = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._JpegQualityBox = new System.Windows.Forms.ComboBox();
            this._ImageFormatBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._AutoOutputDirBox = new System.Windows.Forms.CheckBox();
            this._BrowseTargetPdfButton = new System.Windows.Forms.Button();
            this._TargetBox = new PDFPatcher.HistoryComboBox();
            this._SourceFileControl = new PDFPatcher.SourceFileControl();
            this._ExtractButton = new EnhancedGlassButton.GlassButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ExtractPageImageWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ExtractPageRatioBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ExtractPageRangeBox
            // 
            resources.ApplyResources(this._ExtractPageRangeBox, "_ExtractPageRangeBox");
            this._ExtractPageRangeBox.Name = "_ExtractPageRangeBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _SaveImageBox
            // 
            resources.ApplyResources(this._SaveImageBox, "_SaveImageBox");
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _FileMaskPreviewBox
            // 
            resources.ApplyResources(this._FileMaskPreviewBox, "_FileMaskPreviewBox");
            this._FileMaskPreviewBox.Name = "_FileMaskPreviewBox";
            // 
            // _FileNameMaskBox
            // 
            resources.ApplyResources(this._FileNameMaskBox, "_FileNameMaskBox");
            this._FileNameMaskBox.FormattingEnabled = true;
            this._FileNameMaskBox.Items.AddRange(new object[] {
            resources.GetString("_FileNameMaskBox.Items"),
            resources.GetString("_FileNameMaskBox.Items1"),
            resources.GetString("_FileNameMaskBox.Items2"),
            resources.GetString("_FileNameMaskBox.Items3")});
            this._FileNameMaskBox.Name = "_FileNameMaskBox";
            this._FileNameMaskBox.TextChanged += new System.EventHandler(this._FileNameMaskBox_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // _InvertColorBox
            // 
            resources.ApplyResources(this._InvertColorBox, "_InvertColorBox");
            this._InvertColorBox.Name = "_InvertColorBox";
            this._InvertColorBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this._JpegQualityBox);
            this.tabPage1.Controls.Add(this._ImageFormatBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this._ExtractPageRangeBox);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._RotationBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this._HorizontalFlipImageBox);
            this.groupBox3.Controls.Add(this._HideAnnotationsBox);
            this.groupBox3.Controls.Add(this._VerticalFlipImageBox);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // _RotationBox
            // 
            this._RotationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._RotationBox.FormattingEnabled = true;
            this._RotationBox.Items.AddRange(new object[] {
            resources.GetString("_RotationBox.Items"),
            resources.GetString("_RotationBox.Items1"),
            resources.GetString("_RotationBox.Items2"),
            resources.GetString("_RotationBox.Items3")});
            resources.ApplyResources(this._RotationBox, "_RotationBox");
            this._RotationBox.Name = "_RotationBox";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // _HorizontalFlipImageBox
            // 
            resources.ApplyResources(this._HorizontalFlipImageBox, "_HorizontalFlipImageBox");
            this._HorizontalFlipImageBox.Name = "_HorizontalFlipImageBox";
            this._HorizontalFlipImageBox.UseVisualStyleBackColor = true;
            // 
            // _HideAnnotationsBox
            // 
            resources.ApplyResources(this._HideAnnotationsBox, "_HideAnnotationsBox");
            this._HideAnnotationsBox.Name = "_HideAnnotationsBox";
            this._HideAnnotationsBox.UseVisualStyleBackColor = true;
            // 
            // _VerticalFlipImageBox
            // 
            resources.ApplyResources(this._VerticalFlipImageBox, "_VerticalFlipImageBox");
            this._VerticalFlipImageBox.Name = "_VerticalFlipImageBox";
            this._VerticalFlipImageBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._ResolutionBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this._ExtractPageImageWidthBox);
            this.groupBox2.Controls.Add(this._ExtractPageRatioBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this._SpecificRatioBox);
            this.groupBox2.Controls.Add(this._SpecificWidthBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // _ResolutionBox
            // 
            this._ResolutionBox.FormattingEnabled = true;
            this._ResolutionBox.Items.AddRange(new object[] {
            resources.GetString("_ResolutionBox.Items"),
            resources.GetString("_ResolutionBox.Items1"),
            resources.GetString("_ResolutionBox.Items2"),
            resources.GetString("_ResolutionBox.Items3"),
            resources.GetString("_ResolutionBox.Items4"),
            resources.GetString("_ResolutionBox.Items5"),
            resources.GetString("_ResolutionBox.Items6"),
            resources.GetString("_ResolutionBox.Items7"),
            resources.GetString("_ResolutionBox.Items8"),
            resources.GetString("_ResolutionBox.Items9")});
            resources.ApplyResources(this._ResolutionBox, "_ResolutionBox");
            this._ResolutionBox.Name = "_ResolutionBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // _ExtractPageImageWidthBox
            // 
            this._ExtractPageImageWidthBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this._ExtractPageImageWidthBox, "_ExtractPageImageWidthBox");
            this._ExtractPageImageWidthBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ExtractPageImageWidthBox.Name = "_ExtractPageImageWidthBox";
            // 
            // _ExtractPageRatioBox
            // 
            this._ExtractPageRatioBox.DecimalPlaces = 1;
            this._ExtractPageRatioBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this._ExtractPageRatioBox, "_ExtractPageRatioBox");
            this._ExtractPageRatioBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this._ExtractPageRatioBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this._ExtractPageRatioBox.Name = "_ExtractPageRatioBox";
            this._ExtractPageRatioBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // _SpecificRatioBox
            // 
            resources.ApplyResources(this._SpecificRatioBox, "_SpecificRatioBox");
            this._SpecificRatioBox.Name = "_SpecificRatioBox";
            this._SpecificRatioBox.TabStop = true;
            this._SpecificRatioBox.UseVisualStyleBackColor = true;
            // 
            // _SpecificWidthBox
            // 
            resources.ApplyResources(this._SpecificWidthBox, "_SpecificWidthBox");
            this._SpecificWidthBox.Name = "_SpecificWidthBox";
            this._SpecificWidthBox.TabStop = true;
            this._SpecificWidthBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._ColorSpaceRgbBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this._QuantizeBox);
            this.groupBox1.Controls.Add(this._ColorSpaceGrayBox);
            this.groupBox1.Controls.Add(this._InvertColorBox);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _ColorSpaceRgbBox
            // 
            resources.ApplyResources(this._ColorSpaceRgbBox, "_ColorSpaceRgbBox");
            this._ColorSpaceRgbBox.Name = "_ColorSpaceRgbBox";
            this._ColorSpaceRgbBox.TabStop = true;
            this._ColorSpaceRgbBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // _QuantizeBox
            // 
            resources.ApplyResources(this._QuantizeBox, "_QuantizeBox");
            this._QuantizeBox.Name = "_QuantizeBox";
            this._QuantizeBox.UseVisualStyleBackColor = true;
            // 
            // _ColorSpaceGrayBox
            // 
            resources.ApplyResources(this._ColorSpaceGrayBox, "_ColorSpaceGrayBox");
            this._ColorSpaceGrayBox.Name = "_ColorSpaceGrayBox";
            this._ColorSpaceGrayBox.TabStop = true;
            this._ColorSpaceGrayBox.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // _JpegQualityBox
            // 
            this._JpegQualityBox.FormattingEnabled = true;
            this._JpegQualityBox.Items.AddRange(new object[] {
            resources.GetString("_JpegQualityBox.Items"),
            resources.GetString("_JpegQualityBox.Items1"),
            resources.GetString("_JpegQualityBox.Items2"),
            resources.GetString("_JpegQualityBox.Items3"),
            resources.GetString("_JpegQualityBox.Items4")});
            resources.ApplyResources(this._JpegQualityBox, "_JpegQualityBox");
            this._JpegQualityBox.Name = "_JpegQualityBox";
            // 
            // _ImageFormatBox
            // 
            this._ImageFormatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ImageFormatBox.FormattingEnabled = true;
            this._ImageFormatBox.Items.AddRange(new object[] {
            resources.GetString("_ImageFormatBox.Items"),
            resources.GetString("_ImageFormatBox.Items1"),
            resources.GetString("_ImageFormatBox.Items2")});
            resources.ApplyResources(this._ImageFormatBox, "_ImageFormatBox");
            this._ImageFormatBox.Name = "_ImageFormatBox";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._FileNameMaskBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this._FileMaskPreviewBox);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _AutoOutputDirBox
            // 
            resources.ApplyResources(this._AutoOutputDirBox, "_AutoOutputDirBox");
            this._AutoOutputDirBox.Name = "_AutoOutputDirBox";
            this._AutoOutputDirBox.UseVisualStyleBackColor = true;
            // 
            // _BrowseTargetPdfButton
            // 
            resources.ApplyResources(this._BrowseTargetPdfButton, "_BrowseTargetPdfButton");
            this._BrowseTargetPdfButton.Image = global::PDFPatcher.Properties.Resources.ImageFolder;
            this._BrowseTargetPdfButton.Name = "_BrowseTargetPdfButton";
            this._BrowseTargetPdfButton.UseVisualStyleBackColor = true;
            this._BrowseTargetPdfButton.Click += new System.EventHandler(this._BrowseTargetPdfButton_Click);
            // 
            // _TargetBox
            // 
            resources.ApplyResources(this._TargetBox, "_TargetBox");
            this._TargetBox.Contents = null;
            this._TargetBox.FormattingEnabled = true;
            this._TargetBox.MaxItemCount = 16;
            this._TargetBox.Name = "_TargetBox";
            // 
            // _SourceFileControl
            // 
            resources.ApplyResources(this._SourceFileControl, "_SourceFileControl");
            this._SourceFileControl.Name = "_SourceFileControl";
            // 
            // _ExtractButton
            // 
            this._ExtractButton.AlternativeFocusBorderColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this._ExtractButton, "_ExtractButton");
            this._ExtractButton.AnimateGlow = true;
            this._ExtractButton.BackColor = System.Drawing.SystemColors.Highlight;
            this._ExtractButton.CornerRadius = 3;
            this._ExtractButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ExtractButton.GlowColor = System.Drawing.Color.White;
            this._ExtractButton.Image = global::PDFPatcher.Properties.Resources.Save;
            this._ExtractButton.InnerBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this._ExtractButton.Name = "_ExtractButton";
            this._ExtractButton.OuterBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this._ExtractButton.ShowFocusBorder = true;
            this._ExtractButton.Click += new System.EventHandler(this._ExtractButton_Click);
            // 
            // RenderImageControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ExtractButton);
            this.Controls.Add(this._AutoOutputDirBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this._TargetBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._SourceFileControl);
            this.Controls.Add(this._BrowseTargetPdfButton);
            this.Name = "RenderImageControl";
            this.Load += new System.EventHandler(this.Control_Show);
            this.VisibleChanged += new System.EventHandler(this.Control_Show);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ExtractPageImageWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ExtractPageRatioBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _ExtractPageRangeBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button _BrowseTargetPdfButton;
		private SourceFileControl _SourceFileControl;
		private System.Windows.Forms.FolderBrowserDialog _SaveImageBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label _FileMaskPreviewBox;
		private System.Windows.Forms.ComboBox _FileNameMaskBox;
		private HistoryComboBox _TargetBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox _InvertColorBox;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.CheckBox _AutoOutputDirBox;
		private System.Windows.Forms.NumericUpDown _ExtractPageImageWidthBox;
		private System.Windows.Forms.RadioButton _ColorSpaceGrayBox;
		private System.Windows.Forms.RadioButton _ColorSpaceRgbBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox _ImageFormatBox;
		private System.Windows.Forms.CheckBox _VerticalFlipImageBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox _RotationBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox _JpegQualityBox;
		private System.Windows.Forms.CheckBox _HorizontalFlipImageBox;
		private System.Windows.Forms.CheckBox _HideAnnotationsBox;
		private System.Windows.Forms.CheckBox _QuantizeBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown _ExtractPageRatioBox;
		private System.Windows.Forms.RadioButton _SpecificRatioBox;
		private System.Windows.Forms.RadioButton _SpecificWidthBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private EnhancedGlassButton.GlassButton _ExtractButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox _ResolutionBox;
	}
}
