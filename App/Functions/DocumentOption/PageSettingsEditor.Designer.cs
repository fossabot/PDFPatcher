namespace PDFPatcher.Functions
{
	partial class PageSettingsEditor
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
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            this._RotateZeroMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._PageSettingsBox = new BrightIdeasSoftware.ObjectListView();
            this._SequenceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._PageRangeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._PageFilterColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._SettingsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._PageRangeFilterTypeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._AllPagesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._OddPagesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._EvenPagesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._PortraitPagesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._LandscapePagesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._PageSettingsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._RotateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._RotateLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._RotateRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Rotate180MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._RemoveButton = new System.Windows.Forms.Button();
            this._AddButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this._PageSettingsBox)).BeginInit();
            this._PageRangeFilterTypeMenu.SuspendLayout();
            this._PageSettingsMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // _RotateZeroMenuItem
            // 
            this._RotateZeroMenuItem.Name = "_RotateZeroMenuItem";
            this._RotateZeroMenuItem.Size = new System.Drawing.Size(195, 22);
            this._RotateZeroMenuItem.Text = "constant(&B)";
            // 
            // _PageSettingsBox
            // 
            this._PageSettingsBox.AllColumns.Add(this._SequenceColumn);
            this._PageSettingsBox.AllColumns.Add(this._PageRangeColumn);
            this._PageSettingsBox.AllColumns.Add(this._PageFilterColumn);
            this._PageSettingsBox.AllColumns.Add(this._SettingsColumn);
            this._PageSettingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._PageSettingsBox.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this._PageSettingsBox.CellEditUseWholeCell = false;
            this._PageSettingsBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._SequenceColumn,
            this._PageRangeColumn,
            this._PageFilterColumn,
            this._SettingsColumn});
            this._PageSettingsBox.Cursor = System.Windows.Forms.Cursors.Default;
            this._PageSettingsBox.GridLines = true;
            this._PageSettingsBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._PageSettingsBox.HideSelection = false;
            this._PageSettingsBox.IsSimpleDragSource = true;
            this._PageSettingsBox.IsSimpleDropSink = true;
            this._PageSettingsBox.LabelEdit = true;
            this._PageSettingsBox.Location = new System.Drawing.Point(3, 35);
            this._PageSettingsBox.Name = "_PageSettingsBox";
            this._PageSettingsBox.ShowGroups = false;
            this._PageSettingsBox.Size = new System.Drawing.Size(432, 264);
            this._PageSettingsBox.TabIndex = 3;
            this._PageSettingsBox.UseCompatibleStateImageBehavior = false;
            this._PageSettingsBox.View = System.Windows.Forms.View.Details;
            // 
            // _SequenceColumn
            // 
            this._SequenceColumn.IsEditable = false;
            this._SequenceColumn.Text = "Sequence Number";
            this._SequenceColumn.Width = 40;
            // 
            // _PageRangeColumn
            // 
            this._PageRangeColumn.AspectName = "";
            this._PageRangeColumn.Text = "Page Range";
            this._PageRangeColumn.Width = 82;
            // 
            // _PageFilterColumn
            // 
            this._PageFilterColumn.AspectName = "";
            this._PageFilterColumn.IsEditable = false;
            this._PageFilterColumn.Text = "Filter page";
            this._PageFilterColumn.Width = 61;
            // 
            // _SettingsColumn
            // 
            this._SettingsColumn.IsEditable = false;
            this._SettingsColumn.Text = "Processing";
            this._SettingsColumn.Width = 214;
            // 
            // _PageRangeFilterTypeMenu
            // 
            this._PageRangeFilterTypeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._AllPagesMenu,
            toolStripSeparator1,
            this._OddPagesMenu,
            this._EvenPagesMenu,
            toolStripSeparator2,
            this._PortraitPagesMenu,
            this._LandscapePagesMenu});
            this._PageRangeFilterTypeMenu.Name = "_PageRangeFilterTypeMenu";
            this._PageRangeFilterTypeMenu.Size = new System.Drawing.Size(165, 126);
            // 
            // _AllPagesMenu
            // 
            this._AllPagesMenu.Image = global::PDFPatcher.Properties.Resources.Copy;
            this._AllPagesMenu.Name = "_AllPagesMenu";
            this._AllPagesMenu.Size = new System.Drawing.Size(164, 22);
            this._AllPagesMenu.Text = "&All Pages";
            // 
            // _OddPagesMenu
            // 
            this._OddPagesMenu.Image = global::PDFPatcher.Properties.Resources.OddPage;
            this._OddPagesMenu.Name = "_OddPagesMenu";
            this._OddPagesMenu.Size = new System.Drawing.Size(164, 22);
            this._OddPagesMenu.Text = "&Oddpages";
            // 
            // _EvenPagesMenu
            // 
            this._EvenPagesMenu.Image = global::PDFPatcher.Properties.Resources.EvenPage;
            this._EvenPagesMenu.Name = "_EvenPagesMenu";
            this._EvenPagesMenu.Size = new System.Drawing.Size(164, 22);
            this._EvenPagesMenu.Text = "&EvenPages";
            // 
            // _PortraitPagesMenu
            // 
            this._PortraitPagesMenu.Image = global::PDFPatcher.Properties.Resources.Portrait;
            this._PortraitPagesMenu.Name = "_PortraitPagesMenu";
            this._PortraitPagesMenu.Size = new System.Drawing.Size(164, 22);
            this._PortraitPagesMenu.Text = "&Portrait page";
            // 
            // _LandscapePagesMenu
            // 
            this._LandscapePagesMenu.Image = global::PDFPatcher.Properties.Resources.Lanscape;
            this._LandscapePagesMenu.Name = "_LandscapePagesMenu";
            this._LandscapePagesMenu.Size = new System.Drawing.Size(164, 22);
            this._LandscapePagesMenu.Text = "&Landscape Pages";
            // 
            // _PageSettingsMenu
            // 
            this._PageSettingsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._RotateMenu});
            this._PageSettingsMenu.Name = "_PageSettingsMenu";
            this._PageSettingsMenu.Size = new System.Drawing.Size(158, 26);
            // 
            // _RotateMenu
            // 
            this._RotateMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._RotateZeroMenuItem,
            this._RotateLeftMenuItem,
            this._RotateRightMenuItem,
            this._Rotate180MenuItem});
            this._RotateMenu.Name = "_RotateMenu";
            this._RotateMenu.Size = new System.Drawing.Size(157, 22);
            this._RotateMenu.Text = "&Rotate the page";
            // 
            // _RotateLeftMenuItem
            // 
            this._RotateLeftMenuItem.Image = global::PDFPatcher.Properties.Resources.RotateLeft;
            this._RotateLeftMenuItem.Name = "_RotateLeftMenuItem";
            this._RotateLeftMenuItem.Size = new System.Drawing.Size(195, 22);
            this._RotateLeftMenuItem.Text = "Rotate &left 90 degrees";
            // 
            // _RotateRightMenuItem
            // 
            this._RotateRightMenuItem.Image = global::PDFPatcher.Properties.Resources.RotateRight;
            this._RotateRightMenuItem.Name = "_RotateRightMenuItem";
            this._RotateRightMenuItem.Size = new System.Drawing.Size(195, 22);
            this._RotateRightMenuItem.Text = "Rotate &right 90 degrees";
            // 
            // _Rotate180MenuItem
            // 
            this._Rotate180MenuItem.Image = global::PDFPatcher.Properties.Resources.Refresh;
            this._Rotate180MenuItem.Name = "_Rotate180MenuItem";
            this._Rotate180MenuItem.Size = new System.Drawing.Size(195, 22);
            this._Rotate180MenuItem.Text = "Rotate 180 degrees";
            // 
            // _RemoveButton
            // 
            this._RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._RemoveButton.Image = global::PDFPatcher.Properties.Resources.Delete;
            this._RemoveButton.Location = new System.Drawing.Point(364, 3);
            this._RemoveButton.Name = "_RemoveButton";
            this._RemoveButton.Size = new System.Drawing.Size(71, 25);
            this._RemoveButton.TabIndex = 5;
            this._RemoveButton.Text = "Remove";
            this._RemoveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._RemoveButton.UseVisualStyleBackColor = true;
            this._RemoveButton.Click += new System.EventHandler(this._RemovePageSettingsButton_Click);
            // 
            // _AddButton
            // 
            this._AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._AddButton.Image = global::PDFPatcher.Properties.Resources.Add;
            this._AddButton.Location = new System.Drawing.Point(305, 3);
            this._AddButton.Name = "_AddButton";
            this._AddButton.Size = new System.Drawing.Size(53, 25);
            this._AddButton.TabIndex = 4;
            this._AddButton.Text = "Add";
            this._AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._AddButton.UseVisualStyleBackColor = true;
            this._AddButton.Click += new System.EventHandler(this._AddPageSettingsButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._PageSettingsBox);
            this.panel1.Controls.Add(this._AddButton);
            this.panel1.Controls.Add(this._RemoveButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 302);
            this.panel1.TabIndex = 6;
            // 
            // PageSettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PageSettingsEditor";
            this.Size = new System.Drawing.Size(438, 302);
            ((System.ComponentModel.ISupportInitialize)(this._PageSettingsBox)).EndInit();
            this._PageRangeFilterTypeMenu.ResumeLayout(false);
            this._PageSettingsMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _RemoveButton;
		private System.Windows.Forms.Button _AddButton;
		private BrightIdeasSoftware.ObjectListView _PageSettingsBox;
		private BrightIdeasSoftware.OLVColumn _SequenceColumn;
		private BrightIdeasSoftware.OLVColumn _PageRangeColumn;
		private BrightIdeasSoftware.OLVColumn _PageFilterColumn;
		private BrightIdeasSoftware.OLVColumn _SettingsColumn;
		private System.Windows.Forms.ContextMenuStrip _PageRangeFilterTypeMenu;
		private System.Windows.Forms.ContextMenuStrip _PageSettingsMenu;
		private System.Windows.Forms.ToolStripMenuItem _RotateMenu;
		private System.Windows.Forms.ToolStripMenuItem _AllPagesMenu;
		private System.Windows.Forms.ToolStripMenuItem _OddPagesMenu;
		private System.Windows.Forms.ToolStripMenuItem _EvenPagesMenu;
		private System.Windows.Forms.ToolStripMenuItem _LandscapePagesMenu;
		private System.Windows.Forms.ToolStripMenuItem _PortraitPagesMenu;
		private System.Windows.Forms.ToolStripMenuItem _RotateZeroMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _RotateLeftMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _RotateRightMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _Rotate180MenuItem;
		private System.Windows.Forms.Panel panel1;
	}
}
