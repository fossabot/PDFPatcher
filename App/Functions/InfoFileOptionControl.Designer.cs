namespace PDFPatcher.Functions
{
	partial class InfoFileOptionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoFileOptionControl));
            this._EncodingBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._ExtractPageLinksBox = new System.Windows.Forms.CheckBox();
            this._ExportViewerPreferencesBox = new System.Windows.Forms.CheckBox();
            this._ExportBookmarksBox = new System.Windows.Forms.CheckBox();
            this._ExportOptionsTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._UnitBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._ExportDocPropertiesBox = new System.Windows.Forms.CheckBox();
            this._ExtractPageSettingsBox = new System.Windows.Forms.CheckBox();
            this._ConsolidateNamedDestBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._ExportCatalogBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._ExtractPageContentBox = new System.Windows.Forms.CheckBox();
            this._PageContentBox = new System.Windows.Forms.Panel();
            this._ExportContentOperatorsBox = new System.Windows.Forms.CheckBox();
            this._ExtractPageDictionaryBox = new System.Windows.Forms.CheckBox();
            this._ExtractPageRangeBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._ExportBinaryStreamBox = new System.Windows.Forms.NumericUpDown();
            this._ExtractImagesBox = new System.Windows.Forms.CheckBox();
            this._ExtractPageTextContentBox = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._ImportPageSettingsBox = new System.Windows.Forms.CheckBox();
            this._ImportDocumentInfoBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this._RemoveOriginalPageLinksBox = new System.Windows.Forms.RadioButton();
            this._KeepOriginalPageLinksBox = new System.Windows.Forms.RadioButton();
            this._ImportBookmarksBox = new System.Windows.Forms.CheckBox();
            this._ImportPageLinksBox = new System.Windows.Forms.CheckBox();
            this._ImportViewerPreferencesBox = new System.Windows.Forms.CheckBox();
            this._ExportOptionsTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this._PageContentBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ExportBinaryStreamBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _EncodingBox
            // 
            this._EncodingBox.FormattingEnabled = true;
            this._EncodingBox.Items.AddRange(new object[] {
            resources.GetString("_EncodingBox.Items"),
            resources.GetString("_EncodingBox.Items1"),
            resources.GetString("_EncodingBox.Items2"),
            resources.GetString("_EncodingBox.Items3"),
            resources.GetString("_EncodingBox.Items4")});
            resources.ApplyResources(this._EncodingBox, "_EncodingBox");
            this._EncodingBox.Name = "_EncodingBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _ExtractPageLinksBox
            // 
            resources.ApplyResources(this._ExtractPageLinksBox, "_ExtractPageLinksBox");
            this._ExtractPageLinksBox.Name = "_ExtractPageLinksBox";
            this._ExtractPageLinksBox.UseVisualStyleBackColor = true;
            // 
            // _ExportViewerPreferencesBox
            // 
            resources.ApplyResources(this._ExportViewerPreferencesBox, "_ExportViewerPreferencesBox");
            this._ExportViewerPreferencesBox.Name = "_ExportViewerPreferencesBox";
            this._ExportViewerPreferencesBox.UseVisualStyleBackColor = true;
            // 
            // _ExportBookmarksBox
            // 
            resources.ApplyResources(this._ExportBookmarksBox, "_ExportBookmarksBox");
            this._ExportBookmarksBox.Name = "_ExportBookmarksBox";
            this._ExportBookmarksBox.UseVisualStyleBackColor = true;
            // 
            // _ExportOptionsTab
            // 
            resources.ApplyResources(this._ExportOptionsTab, "_ExportOptionsTab");
            this._ExportOptionsTab.Controls.Add(this.tabPage1);
            this._ExportOptionsTab.Controls.Add(this.tabPage2);
            this._ExportOptionsTab.Controls.Add(this.tabPage3);
            this._ExportOptionsTab.Name = "_ExportOptionsTab";
            this._ExportOptionsTab.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._UnitBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this._EncodingBox);
            this.tabPage1.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _UnitBox
            // 
            this._UnitBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._UnitBox.FormattingEnabled = true;
            resources.ApplyResources(this._UnitBox, "_UnitBox");
            this._UnitBox.Name = "_UnitBox";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this._ExportDocPropertiesBox);
            this.groupBox1.Controls.Add(this._ExportBookmarksBox);
            this.groupBox1.Controls.Add(this._ExtractPageSettingsBox);
            this.groupBox1.Controls.Add(this._ConsolidateNamedDestBox);
            this.groupBox1.Controls.Add(this._ExtractPageLinksBox);
            this.groupBox1.Controls.Add(this._ExportViewerPreferencesBox);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _ExportDocPropertiesBox
            // 
            resources.ApplyResources(this._ExportDocPropertiesBox, "_ExportDocPropertiesBox");
            this._ExportDocPropertiesBox.Name = "_ExportDocPropertiesBox";
            this._ExportDocPropertiesBox.UseVisualStyleBackColor = true;
            // 
            // _ExtractPageSettingsBox
            // 
            resources.ApplyResources(this._ExtractPageSettingsBox, "_ExtractPageSettingsBox");
            this._ExtractPageSettingsBox.Name = "_ExtractPageSettingsBox";
            this._ExtractPageSettingsBox.UseVisualStyleBackColor = true;
            // 
            // _ConsolidateNamedDestBox
            // 
            resources.ApplyResources(this._ConsolidateNamedDestBox, "_ConsolidateNamedDestBox");
            this._ConsolidateNamedDestBox.Name = "_ConsolidateNamedDestBox";
            this._ConsolidateNamedDestBox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._ExportCatalogBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this._ExtractPageContentBox);
            this.tabPage2.Controls.Add(this._PageContentBox);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _ExportCatalogBox
            // 
            resources.ApplyResources(this._ExportCatalogBox, "_ExportCatalogBox");
            this._ExportCatalogBox.Name = "_ExportCatalogBox";
            this._ExportCatalogBox.UseVisualStyleBackColor = true;
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
            // _ExtractPageContentBox
            // 
            resources.ApplyResources(this._ExtractPageContentBox, "_ExtractPageContentBox");
            this._ExtractPageContentBox.Name = "_ExtractPageContentBox";
            this._ExtractPageContentBox.UseVisualStyleBackColor = true;
            // 
            // _PageContentBox
            // 
            this._PageContentBox.Controls.Add(this._ExportContentOperatorsBox);
            this._PageContentBox.Controls.Add(this._ExtractPageDictionaryBox);
            this._PageContentBox.Controls.Add(this._ExtractPageRangeBox);
            this._PageContentBox.Controls.Add(this.label9);
            this._PageContentBox.Controls.Add(this.label3);
            this._PageContentBox.Controls.Add(this.label8);
            this._PageContentBox.Controls.Add(this._ExportBinaryStreamBox);
            this._PageContentBox.Controls.Add(this._ExtractImagesBox);
            this._PageContentBox.Controls.Add(this._ExtractPageTextContentBox);
            resources.ApplyResources(this._PageContentBox, "_PageContentBox");
            this._PageContentBox.Name = "_PageContentBox";
            // 
            // _ExportContentOperatorsBox
            // 
            resources.ApplyResources(this._ExportContentOperatorsBox, "_ExportContentOperatorsBox");
            this._ExportContentOperatorsBox.Name = "_ExportContentOperatorsBox";
            this._ExportContentOperatorsBox.UseVisualStyleBackColor = true;
            // 
            // _ExtractPageDictionaryBox
            // 
            resources.ApplyResources(this._ExtractPageDictionaryBox, "_ExtractPageDictionaryBox");
            this._ExtractPageDictionaryBox.Name = "_ExtractPageDictionaryBox";
            this._ExtractPageDictionaryBox.UseVisualStyleBackColor = true;
            // 
            // _ExtractPageRangeBox
            // 
            resources.ApplyResources(this._ExtractPageRangeBox, "_ExtractPageRangeBox");
            this._ExtractPageRangeBox.Name = "_ExtractPageRangeBox";
            this._ExtractPageRangeBox.Leave += new System.EventHandler(this._ExtractPageRangeBox_Leave);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // _ExportBinaryStreamBox
            // 
            this._ExportBinaryStreamBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this._ExportBinaryStreamBox, "_ExportBinaryStreamBox");
            this._ExportBinaryStreamBox.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this._ExportBinaryStreamBox.Name = "_ExportBinaryStreamBox";
            // 
            // _ExtractImagesBox
            // 
            resources.ApplyResources(this._ExtractImagesBox, "_ExtractImagesBox");
            this._ExtractImagesBox.Name = "_ExtractImagesBox";
            this._ExtractImagesBox.UseVisualStyleBackColor = true;
            // 
            // _ExtractPageTextContentBox
            // 
            resources.ApplyResources(this._ExtractPageTextContentBox, "_ExtractPageTextContentBox");
            this._ExtractPageTextContentBox.Name = "_ExtractPageTextContentBox";
            this._ExtractPageTextContentBox.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this._ImportPageSettingsBox);
            this.groupBox2.Controls.Add(this._ImportDocumentInfoBox);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this._ImportBookmarksBox);
            this.groupBox2.Controls.Add(this._ImportPageLinksBox);
            this.groupBox2.Controls.Add(this._ImportViewerPreferencesBox);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // _ImportPageSettingsBox
            // 
            resources.ApplyResources(this._ImportPageSettingsBox, "_ImportPageSettingsBox");
            this._ImportPageSettingsBox.Name = "_ImportPageSettingsBox";
            this._ImportPageSettingsBox.UseVisualStyleBackColor = true;
            // 
            // _ImportDocumentInfoBox
            // 
            resources.ApplyResources(this._ImportDocumentInfoBox, "_ImportDocumentInfoBox");
            this._ImportDocumentInfoBox.Checked = true;
            this._ImportDocumentInfoBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ImportDocumentInfoBox.Name = "_ImportDocumentInfoBox";
            this._ImportDocumentInfoBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this._RemoveOriginalPageLinksBox);
            this.panel1.Controls.Add(this._KeepOriginalPageLinksBox);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // _RemoveOriginalPageLinksBox
            // 
            resources.ApplyResources(this._RemoveOriginalPageLinksBox, "_RemoveOriginalPageLinksBox");
            this._RemoveOriginalPageLinksBox.Checked = true;
            this._RemoveOriginalPageLinksBox.Name = "_RemoveOriginalPageLinksBox";
            this._RemoveOriginalPageLinksBox.TabStop = true;
            this._RemoveOriginalPageLinksBox.UseVisualStyleBackColor = true;
            // 
            // _KeepOriginalPageLinksBox
            // 
            resources.ApplyResources(this._KeepOriginalPageLinksBox, "_KeepOriginalPageLinksBox");
            this._KeepOriginalPageLinksBox.Name = "_KeepOriginalPageLinksBox";
            this._KeepOriginalPageLinksBox.UseVisualStyleBackColor = true;
            // 
            // _ImportBookmarksBox
            // 
            resources.ApplyResources(this._ImportBookmarksBox, "_ImportBookmarksBox");
            this._ImportBookmarksBox.Checked = true;
            this._ImportBookmarksBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ImportBookmarksBox.Name = "_ImportBookmarksBox";
            this._ImportBookmarksBox.UseVisualStyleBackColor = true;
            // 
            // _ImportPageLinksBox
            // 
            resources.ApplyResources(this._ImportPageLinksBox, "_ImportPageLinksBox");
            this._ImportPageLinksBox.Checked = true;
            this._ImportPageLinksBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ImportPageLinksBox.Name = "_ImportPageLinksBox";
            this._ImportPageLinksBox.UseVisualStyleBackColor = true;
            // 
            // _ImportViewerPreferencesBox
            // 
            resources.ApplyResources(this._ImportViewerPreferencesBox, "_ImportViewerPreferencesBox");
            this._ImportViewerPreferencesBox.Checked = true;
            this._ImportViewerPreferencesBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ImportViewerPreferencesBox.Name = "_ImportViewerPreferencesBox";
            this._ImportViewerPreferencesBox.UseVisualStyleBackColor = true;
            // 
            // InfoFileOptionControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ExportOptionsTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoFileOptionControl";
            this.VisibleChanged += new System.EventHandler(this.ExportOptionControl_VisibleChanged);
            this._ExportOptionsTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this._PageContentBox.ResumeLayout(false);
            this._PageContentBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ExportBinaryStreamBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox _ExtractPageLinksBox;
		private System.Windows.Forms.CheckBox _ExportViewerPreferencesBox;
		private System.Windows.Forms.CheckBox _ExportBookmarksBox;
		private System.Windows.Forms.ComboBox _EncodingBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl _ExportOptionsTab;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox _ExtractPageRangeBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox _ExtractPageContentBox;
		private System.Windows.Forms.CheckBox _ExtractPageSettingsBox;
		private System.Windows.Forms.CheckBox _ExtractImagesBox;
		private System.Windows.Forms.CheckBox _ConsolidateNamedDestBox;
		private System.Windows.Forms.CheckBox _ExportDocPropertiesBox;
		private System.Windows.Forms.ComboBox _UnitBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown _ExportBinaryStreamBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox _ExportCatalogBox;
		private System.Windows.Forms.CheckBox _ExtractPageTextContentBox;
		private System.Windows.Forms.Panel _PageContentBox;
		private System.Windows.Forms.CheckBox _ExtractPageDictionaryBox;
		private System.Windows.Forms.CheckBox _ExportContentOperatorsBox;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox _ImportDocumentInfoBox;
		private System.Windows.Forms.CheckBox _ImportPageLinksBox;
		private System.Windows.Forms.CheckBox _ImportViewerPreferencesBox;
		private System.Windows.Forms.CheckBox _ImportBookmarksBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.RadioButton _RemoveOriginalPageLinksBox;
		private System.Windows.Forms.RadioButton _KeepOriginalPageLinksBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox _ImportPageSettingsBox;
	}
}
