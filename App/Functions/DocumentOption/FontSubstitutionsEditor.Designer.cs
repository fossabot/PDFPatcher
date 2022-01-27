namespace PDFPatcher.Functions
{
	partial class FontSubstitutionsEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontSubstitutionsEditor));
            this._FontSubstitutionsBox = new BrightIdeasSoftware.ObjectListView();
            this._SequenceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._OriginalFontColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._SubstitutionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._CharSubstitutionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._FontSubstitutionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._CopySubstitutionFont = new System.Windows.Forms.ToolStripMenuItem();
            this._PasteSubstitutionFont = new System.Windows.Forms.ToolStripMenuItem();
            this._RemovePageLabelButton = new System.Windows.Forms.Button();
            this._AddPageLabelButton = new System.Windows.Forms.Button();
            this._ListDocumentFontButton = new System.Windows.Forms.Button();
            this._EmbedLegacyCjkFontsBox = new System.Windows.Forms.CheckBox();
            this._EnableFontSubstitutionsBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._TrimTrailingWhiteSpaceBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._FontSubstitutionsBox)).BeginInit();
            this._FontSubstitutionMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _FontSubstitutionsBox
            // 
            this._FontSubstitutionsBox.AllColumns.Add(this._SequenceColumn);
            this._FontSubstitutionsBox.AllColumns.Add(this._OriginalFontColumn);
            this._FontSubstitutionsBox.AllColumns.Add(this._SubstitutionColumn);
            this._FontSubstitutionsBox.AllColumns.Add(this._CharSubstitutionColumn);
            resources.ApplyResources(this._FontSubstitutionsBox, "_FontSubstitutionsBox");
            this._FontSubstitutionsBox.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this._FontSubstitutionsBox.CellEditUseWholeCell = false;
            this._FontSubstitutionsBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._SequenceColumn,
            this._OriginalFontColumn,
            this._SubstitutionColumn,
            this._CharSubstitutionColumn});
            this._FontSubstitutionsBox.ContextMenuStrip = this._FontSubstitutionMenu;
            this._FontSubstitutionsBox.Cursor = System.Windows.Forms.Cursors.Default;
            this._FontSubstitutionsBox.GridLines = true;
            this._FontSubstitutionsBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._FontSubstitutionsBox.HideSelection = false;
            this._FontSubstitutionsBox.LabelEdit = true;
            this._FontSubstitutionsBox.Name = "_FontSubstitutionsBox";
            this._FontSubstitutionsBox.SelectColumnsOnRightClick = false;
            this._FontSubstitutionsBox.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this._FontSubstitutionsBox.ShowGroups = false;
            this._FontSubstitutionsBox.UseCompatibleStateImageBehavior = false;
            this._FontSubstitutionsBox.View = System.Windows.Forms.View.Details;
            // 
            // _SequenceColumn
            // 
            resources.ApplyResources(this._SequenceColumn, "_SequenceColumn");
            // 
            // _OriginalFontColumn
            // 
            this._OriginalFontColumn.AspectName = "";
            resources.ApplyResources(this._OriginalFontColumn, "_OriginalFontColumn");
            // 
            // _SubstitutionColumn
            // 
            this._SubstitutionColumn.AspectName = "";
            resources.ApplyResources(this._SubstitutionColumn, "_SubstitutionColumn");
            // 
            // _CharSubstitutionColumn
            // 
            resources.ApplyResources(this._CharSubstitutionColumn, "_CharSubstitutionColumn");
            // 
            // _FontSubstitutionMenu
            // 
            this._FontSubstitutionMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._FontSubstitutionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._CopySubstitutionFont,
            this._PasteSubstitutionFont});
            this._FontSubstitutionMenu.Name = "_FontSubstitutionMenu";
            resources.ApplyResources(this._FontSubstitutionMenu, "_FontSubstitutionMenu");
            this._FontSubstitutionMenu.Opening += new System.ComponentModel.CancelEventHandler(this._FontSubstitutionMenu_Opening);
            this._FontSubstitutionMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._FontSubstitutionMenu_ItemClicked);
            // 
            // _CopySubstitutionFont
            // 
            this._CopySubstitutionFont.Image = global::PDFPatcher.Properties.Resources.Copy;
            this._CopySubstitutionFont.Name = "_CopySubstitutionFont";
            resources.ApplyResources(this._CopySubstitutionFont, "_CopySubstitutionFont");
            // 
            // _PasteSubstitutionFont
            // 
            this._PasteSubstitutionFont.Image = global::PDFPatcher.Properties.Resources.Paste;
            this._PasteSubstitutionFont.Name = "_PasteSubstitutionFont";
            resources.ApplyResources(this._PasteSubstitutionFont, "_PasteSubstitutionFont");
            // 
            // _RemovePageLabelButton
            // 
            resources.ApplyResources(this._RemovePageLabelButton, "_RemovePageLabelButton");
            this._RemovePageLabelButton.Image = global::PDFPatcher.Properties.Resources.Delete;
            this._RemovePageLabelButton.Name = "_RemovePageLabelButton";
            this._RemovePageLabelButton.UseVisualStyleBackColor = true;
            this._RemovePageLabelButton.Click += new System.EventHandler(this._RemovePageLabelButton_Click);
            // 
            // _AddPageLabelButton
            // 
            resources.ApplyResources(this._AddPageLabelButton, "_AddPageLabelButton");
            this._AddPageLabelButton.Image = global::PDFPatcher.Properties.Resources.Add;
            this._AddPageLabelButton.Name = "_AddPageLabelButton";
            this._AddPageLabelButton.UseVisualStyleBackColor = true;
            this._AddPageLabelButton.Click += new System.EventHandler(this._AddPageLabelButton_Click);
            // 
            // _ListDocumentFontButton
            // 
            resources.ApplyResources(this._ListDocumentFontButton, "_ListDocumentFontButton");
            this._ListDocumentFontButton.Name = "_ListDocumentFontButton";
            this._ListDocumentFontButton.UseVisualStyleBackColor = true;
            this._ListDocumentFontButton.Click += new System.EventHandler(this._ListDocumentFontButton_Click);
            // 
            // _EmbedLegacyCjkFontsBox
            // 
            resources.ApplyResources(this._EmbedLegacyCjkFontsBox, "_EmbedLegacyCjkFontsBox");
            this._EmbedLegacyCjkFontsBox.Name = "_EmbedLegacyCjkFontsBox";
            this._EmbedLegacyCjkFontsBox.UseVisualStyleBackColor = true;
            // 
            // _EnableFontSubstitutionsBox
            // 
            resources.ApplyResources(this._EnableFontSubstitutionsBox, "_EnableFontSubstitutionsBox");
            this._EnableFontSubstitutionsBox.Name = "_EnableFontSubstitutionsBox";
            this._EnableFontSubstitutionsBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._TrimTrailingWhiteSpaceBox);
            this.panel1.Controls.Add(this._FontSubstitutionsBox);
            this.panel1.Controls.Add(this._EnableFontSubstitutionsBox);
            this.panel1.Controls.Add(this._AddPageLabelButton);
            this.panel1.Controls.Add(this._EmbedLegacyCjkFontsBox);
            this.panel1.Controls.Add(this._RemovePageLabelButton);
            this.panel1.Controls.Add(this._ListDocumentFontButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // _TrimTrailingWhiteSpaceBox
            // 
            resources.ApplyResources(this._TrimTrailingWhiteSpaceBox, "_TrimTrailingWhiteSpaceBox");
            this._TrimTrailingWhiteSpaceBox.Name = "_TrimTrailingWhiteSpaceBox";
            this._TrimTrailingWhiteSpaceBox.UseVisualStyleBackColor = true;
            // 
            // FontSubstitutionsEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FontSubstitutionsEditor";
            this.Load += new System.EventHandler(this.FontSubstitutionsEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this._FontSubstitutionsBox)).EndInit();
            this._FontSubstitutionMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _RemovePageLabelButton;
		private System.Windows.Forms.Button _AddPageLabelButton;
		private BrightIdeasSoftware.ObjectListView _FontSubstitutionsBox;
		private BrightIdeasSoftware.OLVColumn _OriginalFontColumn;
		private BrightIdeasSoftware.OLVColumn _SubstitutionColumn;
		private BrightIdeasSoftware.OLVColumn _SequenceColumn;
		private System.Windows.Forms.Button _ListDocumentFontButton;
		private System.Windows.Forms.CheckBox _EmbedLegacyCjkFontsBox;
		private System.Windows.Forms.CheckBox _EnableFontSubstitutionsBox;
		private System.Windows.Forms.ContextMenuStrip _FontSubstitutionMenu;
		private System.Windows.Forms.ToolStripMenuItem _CopySubstitutionFont;
		private System.Windows.Forms.ToolStripMenuItem _PasteSubstitutionFont;
		private System.Windows.Forms.Panel panel1;
		private BrightIdeasSoftware.OLVColumn _CharSubstitutionColumn;
		private System.Windows.Forms.CheckBox _TrimTrailingWhiteSpaceBox;
	}
}
