namespace PDFPatcher.Functions
{
    partial class ExtractImageControl
    {
        /// <summary>
        /// Required designer variables.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up all resources in use.
        /// </summary>
        /// <param name="disposing">true if the managed resource should be released; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer Generated Code

        /// <summary>
        /// Designer supports required methods - Don't
        /// use a code editor to modify the content of this method.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractImageControl));
            this._ExtractPageRangeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._BrowseTargetPdfButton = new System.Windows.Forms.Button();
            this._SaveImageBox = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._FileMaskPreviewBox = new System.Windows.Forms.Label();
            this._FileNameMaskBox = new System.Windows.Forms.ComboBox();
            this._MergeImageBox = new System.Windows.Forms.CheckBox();
            this._VerticalFlipImageBox = new System.Windows.Forms.CheckBox();
            this._InvertBlackAndWhiteBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this._MinWidthBox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this._MinHeightBox = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._SkipRedundantImagesBox = new System.Windows.Forms.CheckBox();
            this._MonoPngBox = new System.Windows.Forms.RadioButton();
            this._MonoTiffBox = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this._InvertSoftMaskBox = new System.Windows.Forms.CheckBox();
            this._ExportSoftMaskBox = new System.Windows.Forms.CheckBox();
            this._ExportAnnotImagesBox = new System.Windows.Forms.CheckBox();
            this._MergeJpgToPngBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._AutoOutputDirBox = new System.Windows.Forms.CheckBox();
            this._TargetBox = new PDFPatcher.HistoryComboBox();
            this._SourceFileControl = new PDFPatcher.SourceFileControl();
            this._ExtractButton = new EnhancedGlassButton.GlassButton();
            ((System.ComponentModel.ISupportInitialize)(this._MinWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._MinHeightBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            // _BrowseTargetPdfButton
            // 
            resources.ApplyResources(this._BrowseTargetPdfButton, "_BrowseTargetPdfButton");
            this._BrowseTargetPdfButton.Image = global::PDFPatcher.Properties.Resources.ImageFolder;
            this._BrowseTargetPdfButton.Name = "_BrowseTargetPdfButton";
            this._BrowseTargetPdfButton.UseVisualStyleBackColor = true;
            this._BrowseTargetPdfButton.Click += new System.EventHandler(this._BrowseTargetPdfButton_Click);
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
            this._FileNameMaskBox.FormattingEnabled = true;
            this._FileNameMaskBox.Items.AddRange(new object[] {
            resources.GetString("_FileNameMaskBox.Items"),
            resources.GetString("_FileNameMaskBox.Items1"),
            resources.GetString("_FileNameMaskBox.Items2"),
            resources.GetString("_FileNameMaskBox.Items3")});
            resources.ApplyResources(this._FileNameMaskBox, "_FileNameMaskBox");
            this._FileNameMaskBox.Name = "_FileNameMaskBox";
            this._FileNameMaskBox.TextChanged += new System.EventHandler(this._FileNameMaskBox_TextChanged);
            // 
            // _MergeImageBox
            // 
            resources.ApplyResources(this._MergeImageBox, "_MergeImageBox");
            this._MergeImageBox.Name = "_MergeImageBox";
            this._MergeImageBox.UseVisualStyleBackColor = true;
            // 
            // _VerticalFlipImageBox
            // 
            resources.ApplyResources(this._VerticalFlipImageBox, "_VerticalFlipImageBox");
            this._VerticalFlipImageBox.Name = "_VerticalFlipImageBox";
            this._VerticalFlipImageBox.UseVisualStyleBackColor = true;
            // 
            // _InvertBlackAndWhiteBox
            // 
            resources.ApplyResources(this._InvertBlackAndWhiteBox, "_InvertBlackAndWhiteBox");
            this._InvertBlackAndWhiteBox.Name = "_InvertBlackAndWhiteBox";
            this._InvertBlackAndWhiteBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // _MinWidthBox
            // 
            this._MinWidthBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            resources.ApplyResources(this._MinWidthBox, "_MinWidthBox");
            this._MinWidthBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._MinWidthBox.Name = "_MinWidthBox";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // _MinHeightBox
            // 
            this._MinHeightBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            resources.ApplyResources(this._MinHeightBox, "_MinHeightBox");
            this._MinHeightBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._MinHeightBox.Name = "_MinHeightBox";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._SkipRedundantImagesBox);
            this.tabPage1.Controls.Add(this._MonoPngBox);
            this.tabPage1.Controls.Add(this._MonoTiffBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this._InvertSoftMaskBox);
            this.tabPage1.Controls.Add(this._ExportSoftMaskBox);
            this.tabPage1.Controls.Add(this._ExportAnnotImagesBox);
            this.tabPage1.Controls.Add(this._MergeJpgToPngBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this._InvertBlackAndWhiteBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this._VerticalFlipImageBox);
            this.tabPage1.Controls.Add(this._ExtractPageRangeBox);
            this.tabPage1.Controls.Add(this._MinWidthBox);
            this.tabPage1.Controls.Add(this._MergeImageBox);
            this.tabPage1.Controls.Add(this._MinHeightBox);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _SkipRedundantImagesBox
            // 
            resources.ApplyResources(this._SkipRedundantImagesBox, "_SkipRedundantImagesBox");
            this._SkipRedundantImagesBox.Name = "_SkipRedundantImagesBox";
            this._SkipRedundantImagesBox.UseVisualStyleBackColor = true;
            // 
            // _MonoPngBox
            // 
            resources.ApplyResources(this._MonoPngBox, "_MonoPngBox");
            this._MonoPngBox.Name = "_MonoPngBox";
            this._MonoPngBox.TabStop = true;
            this._MonoPngBox.UseVisualStyleBackColor = true;
            // 
            // _MonoTiffBox
            // 
            resources.ApplyResources(this._MonoTiffBox, "_MonoTiffBox");
            this._MonoTiffBox.Name = "_MonoTiffBox";
            this._MonoTiffBox.TabStop = true;
            this._MonoTiffBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _InvertSoftMaskBox
            // 
            resources.ApplyResources(this._InvertSoftMaskBox, "_InvertSoftMaskBox");
            this._InvertSoftMaskBox.Name = "_InvertSoftMaskBox";
            this._InvertSoftMaskBox.UseVisualStyleBackColor = true;
            // 
            // _ExportSoftMaskBox
            // 
            resources.ApplyResources(this._ExportSoftMaskBox, "_ExportSoftMaskBox");
            this._ExportSoftMaskBox.Name = "_ExportSoftMaskBox";
            this._ExportSoftMaskBox.UseVisualStyleBackColor = true;
            // 
            // _ExportAnnotImagesBox
            // 
            resources.ApplyResources(this._ExportAnnotImagesBox, "_ExportAnnotImagesBox");
            this._ExportAnnotImagesBox.Name = "_ExportAnnotImagesBox";
            this._ExportAnnotImagesBox.UseVisualStyleBackColor = true;
            // 
            // _MergeJpgToPngBox
            // 
            resources.ApplyResources(this._MergeJpgToPngBox, "_MergeJpgToPngBox");
            this._MergeJpgToPngBox.Name = "_MergeJpgToPngBox";
            this._MergeJpgToPngBox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this._FileNameMaskBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this._FileMaskPreviewBox);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox1);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // _AutoOutputDirBox
            // 
            resources.ApplyResources(this._AutoOutputDirBox, "_AutoOutputDirBox");
            this._AutoOutputDirBox.Name = "_AutoOutputDirBox";
            this._AutoOutputDirBox.UseVisualStyleBackColor = true;
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
            // ExtractImageControl
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
            this.Name = "ExtractImageControl";
            this.Load += new System.EventHandler(this.Control_Show);
            this.VisibleChanged += new System.EventHandler(this.Control_Show);
            this.Click += new System.EventHandler(this._ExtractButton_Click);
            ((System.ComponentModel.ISupportInitialize)(this._MinWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._MinHeightBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.CheckBox _MergeImageBox;
        private System.Windows.Forms.CheckBox _VerticalFlipImageBox;
        private System.Windows.Forms.CheckBox _InvertBlackAndWhiteBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown _MinHeightBox;
        private System.Windows.Forms.NumericUpDown _MinWidthBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox _AutoOutputDirBox;
        private System.Windows.Forms.CheckBox _MergeJpgToPngBox;
        private System.Windows.Forms.CheckBox _ExportAnnotImagesBox;
        private System.Windows.Forms.CheckBox _ExportSoftMaskBox;
        private System.Windows.Forms.CheckBox _InvertSoftMaskBox;
        private System.Windows.Forms.RadioButton _MonoTiffBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton _MonoPngBox;
        private EnhancedGlassButton.GlassButton _ExtractButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox _SkipRedundantImagesBox;
    }
}
