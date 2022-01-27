﻿namespace PDFPatcher.Functions
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
            this._FontSubstitutionsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._FontSubstitutionsBox.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this._FontSubstitutionsBox.CellEditUseWholeCell = false;
            this._FontSubstitutionsBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._SequenceColumn,
            this._OriginalFontColumn,
            this._SubstitutionColumn,
            this._CharSubstitutionColumn});
            this._FontSubstitutionsBox.ContextMenuStrip = this._FontSubstitutionMenu;
            this._FontSubstitutionsBox.Cursor = System.Windows.Forms.Cursors.Default;
            this._FontSubstitutionsBox.Enabled = false;
            this._FontSubstitutionsBox.GridLines = true;
            this._FontSubstitutionsBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._FontSubstitutionsBox.HideSelection = false;
            this._FontSubstitutionsBox.LabelEdit = true;
            this._FontSubstitutionsBox.Location = new System.Drawing.Point(3, 60);
            this._FontSubstitutionsBox.Name = "_FontSubstitutionsBox";
            this._FontSubstitutionsBox.SelectColumnsOnRightClick = false;
            this._FontSubstitutionsBox.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this._FontSubstitutionsBox.ShowGroups = false;
            this._FontSubstitutionsBox.Size = new System.Drawing.Size(549, 239);
            this._FontSubstitutionsBox.TabIndex = 5;
            this._FontSubstitutionsBox.UseCompatibleStateImageBehavior = false;
            this._FontSubstitutionsBox.View = System.Windows.Forms.View.Details;
            // 
            // _SequenceColumn
            // 
            this._SequenceColumn.Text = "Sequence Number";
            this._SequenceColumn.Width = 40;
            // 
            // _OriginalFontColumn
            // 
            this._OriginalFontColumn.AspectName = "";
            this._OriginalFontColumn.Text = "Original Font";
            this._OriginalFontColumn.Width = 160;
            // 
            // _SubstitutionColumn
            // 
            this._SubstitutionColumn.AspectName = "";
            this._SubstitutionColumn.Text = "Substitution Font";
            this._SubstitutionColumn.Width = 200;
            // 
            // _CharSubstitutionColumn
            // 
            this._CharSubstitutionColumn.Text = "Substitution Character";
            this._CharSubstitutionColumn.Width = 71;
            // 
            // _FontSubstitutionMenu
            // 
            this._FontSubstitutionMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._FontSubstitutionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._CopySubstitutionFont,
            this._PasteSubstitutionFont});
            this._FontSubstitutionMenu.Name = "_FontSubstitutionMenu";
            this._FontSubstitutionMenu.Size = new System.Drawing.Size(201, 56);
            this._FontSubstitutionMenu.Opening += new System.ComponentModel.CancelEventHandler(this._FontSubstitutionMenu_Opening);
            this._FontSubstitutionMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._FontSubstitutionMenu_ItemClicked);
            // 
            // _CopySubstitutionFont
            // 
            this._CopySubstitutionFont.Image = global::PDFPatcher.Properties.Resources.Copy;
            this._CopySubstitutionFont.Name = "_CopySubstitutionFont";
            this._CopySubstitutionFont.Size = new System.Drawing.Size(200, 26);
            this._CopySubstitutionFont.Text = "&Copy SubstitutionFont";
            // 
            // _PasteSubstitutionFont
            // 
            this._PasteSubstitutionFont.Image = global::PDFPatcher.Properties.Resources.Paste;
            this._PasteSubstitutionFont.Name = "_PasteSubstitutionFont";
            this._PasteSubstitutionFont.Size = new System.Drawing.Size(200, 26);
            this._PasteSubstitutionFont.Text = "&Paste Substitution Font";
            // 
            // _RemovePageLabelButton
            // 
            this._RemovePageLabelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._RemovePageLabelButton.Enabled = false;
            this._RemovePageLabelButton.Image = global::PDFPatcher.Properties.Resources.Delete;
            this._RemovePageLabelButton.Location = new System.Drawing.Point(499, 3);
            this._RemovePageLabelButton.Name = "_RemovePageLabelButton";
            this._RemovePageLabelButton.Size = new System.Drawing.Size(53, 25);
            this._RemovePageLabelButton.TabIndex = 4;
            this._RemovePageLabelButton.Text = "Remove";
            this._RemovePageLabelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._RemovePageLabelButton.UseVisualStyleBackColor = true;
            this._RemovePageLabelButton.Click += new System.EventHandler(this._RemovePageLabelButton_Click);
            // 
            // _AddPageLabelButton
            // 
            this._AddPageLabelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._AddPageLabelButton.Enabled = false;
            this._AddPageLabelButton.Image = global::PDFPatcher.Properties.Resources.Add;
            this._AddPageLabelButton.Location = new System.Drawing.Point(440, 3);
            this._AddPageLabelButton.Name = "_AddPageLabelButton";
            this._AddPageLabelButton.Size = new System.Drawing.Size(53, 25);
            this._AddPageLabelButton.TabIndex = 3;
            this._AddPageLabelButton.Text = "Add";
            this._AddPageLabelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._AddPageLabelButton.UseVisualStyleBackColor = true;
            this._AddPageLabelButton.Click += new System.EventHandler(this._AddPageLabelButton_Click);
            // 
            // _ListDocumentFontButton
            // 
            this._ListDocumentFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._ListDocumentFontButton.Enabled = false;
            this._ListDocumentFontButton.Location = new System.Drawing.Point(308, 3);
            this._ListDocumentFontButton.Name = "_ListDocumentFontButton";
            this._ListDocumentFontButton.Size = new System.Drawing.Size(126, 25);
            this._ListDocumentFontButton.TabIndex = 2;
            this._ListDocumentFontButton.Text = "List document font";
            this._ListDocumentFontButton.UseVisualStyleBackColor = true;
            this._ListDocumentFontButton.Click += new System.EventHandler(this._ListDocumentFontButton_Click);
            // 
            // _EmbedLegacyCjkFontsBox
            // 
            this._EmbedLegacyCjkFontsBox.AutoSize = true;
            this._EmbedLegacyCjkFontsBox.Location = new System.Drawing.Point(3, 8);
            this._EmbedLegacyCjkFontsBox.Name = "_EmbedLegacyCjkFontsBox";
            this._EmbedLegacyCjkFontsBox.Size = new System.Drawing.Size(174, 17);
            this._EmbedLegacyCjkFontsBox.TabIndex = 0;
            this._EmbedLegacyCjkFontsBox.Text = "Embedded Chinese word library";
            this._EmbedLegacyCjkFontsBox.UseVisualStyleBackColor = true;
            // 
            // _EnableFontSubstitutionsBox
            // 
            this._EnableFontSubstitutionsBox.AutoSize = true;
            this._EnableFontSubstitutionsBox.Location = new System.Drawing.Point(174, 8);
            this._EnableFontSubstitutionsBox.Name = "_EnableFontSubstitutionsBox";
            this._EnableFontSubstitutionsBox.Size = new System.Drawing.Size(138, 17);
            this._EnableFontSubstitutionsBox.TabIndex = 1;
            this._EnableFontSubstitutionsBox.Text = "Allow replacement fonts";
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 302);
            this.panel1.TabIndex = 6;
            // 
            // _TrimTrailingWhiteSpaceBox
            // 
            this._TrimTrailingWhiteSpaceBox.AutoSize = true;
            this._TrimTrailingWhiteSpaceBox.Location = new System.Drawing.Point(3, 30);
            this._TrimTrailingWhiteSpaceBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._TrimTrailingWhiteSpaceBox.Name = "_TrimTrailingWhiteSpaceBox";
            this._TrimTrailingWhiteSpaceBox.Size = new System.Drawing.Size(174, 17);
            this._TrimTrailingWhiteSpaceBox.TabIndex = 6;
            this._TrimTrailingWhiteSpaceBox.Text = "Also remove text trailing spaces";
            this._TrimTrailingWhiteSpaceBox.UseVisualStyleBackColor = true;
            // 
            // FontSubstitutionsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FontSubstitutionsEditor";
            this.Size = new System.Drawing.Size(555, 302);
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
