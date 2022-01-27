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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageSettingsEditor));
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
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // _RotateZeroMenuItem
            // 
            this._RotateZeroMenuItem.Name = "_RotateZeroMenuItem";
            resources.ApplyResources(this._RotateZeroMenuItem, "_RotateZeroMenuItem");
            // 
            // _PageSettingsBox
            // 
            this._PageSettingsBox.AllColumns.Add(this._SequenceColumn);
            this._PageSettingsBox.AllColumns.Add(this._PageRangeColumn);
            this._PageSettingsBox.AllColumns.Add(this._PageFilterColumn);
            this._PageSettingsBox.AllColumns.Add(this._SettingsColumn);
            resources.ApplyResources(this._PageSettingsBox, "_PageSettingsBox");
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
            this._PageSettingsBox.Name = "_PageSettingsBox";
            this._PageSettingsBox.ShowGroups = false;
            this._PageSettingsBox.UseCompatibleStateImageBehavior = false;
            this._PageSettingsBox.View = System.Windows.Forms.View.Details;
            // 
            // _SequenceColumn
            // 
            this._SequenceColumn.IsEditable = false;
            resources.ApplyResources(this._SequenceColumn, "_SequenceColumn");
            // 
            // _PageRangeColumn
            // 
            this._PageRangeColumn.AspectName = "";
            resources.ApplyResources(this._PageRangeColumn, "_PageRangeColumn");
            // 
            // _PageFilterColumn
            // 
            this._PageFilterColumn.AspectName = "";
            this._PageFilterColumn.IsEditable = false;
            resources.ApplyResources(this._PageFilterColumn, "_PageFilterColumn");
            // 
            // _SettingsColumn
            // 
            this._SettingsColumn.IsEditable = false;
            resources.ApplyResources(this._SettingsColumn, "_SettingsColumn");
            // 
            // _PageRangeFilterTypeMenu
            // 
            this._PageRangeFilterTypeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._PageRangeFilterTypeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._AllPagesMenu,
            toolStripSeparator1,
            this._OddPagesMenu,
            this._EvenPagesMenu,
            toolStripSeparator2,
            this._PortraitPagesMenu,
            this._LandscapePagesMenu});
            this._PageRangeFilterTypeMenu.Name = "_PageRangeFilterTypeMenu";
            resources.ApplyResources(this._PageRangeFilterTypeMenu, "_PageRangeFilterTypeMenu");
            // 
            // _AllPagesMenu
            // 
            this._AllPagesMenu.Image = global::PDFPatcher.Properties.Resources.Copy;
            this._AllPagesMenu.Name = "_AllPagesMenu";
            resources.ApplyResources(this._AllPagesMenu, "_AllPagesMenu");
            // 
            // _OddPagesMenu
            // 
            this._OddPagesMenu.Image = global::PDFPatcher.Properties.Resources.OddPage;
            this._OddPagesMenu.Name = "_OddPagesMenu";
            resources.ApplyResources(this._OddPagesMenu, "_OddPagesMenu");
            // 
            // _EvenPagesMenu
            // 
            this._EvenPagesMenu.Image = global::PDFPatcher.Properties.Resources.EvenPage;
            this._EvenPagesMenu.Name = "_EvenPagesMenu";
            resources.ApplyResources(this._EvenPagesMenu, "_EvenPagesMenu");
            // 
            // _PortraitPagesMenu
            // 
            this._PortraitPagesMenu.Image = global::PDFPatcher.Properties.Resources.Portrait;
            this._PortraitPagesMenu.Name = "_PortraitPagesMenu";
            resources.ApplyResources(this._PortraitPagesMenu, "_PortraitPagesMenu");
            // 
            // _LandscapePagesMenu
            // 
            this._LandscapePagesMenu.Image = global::PDFPatcher.Properties.Resources.Lanscape;
            this._LandscapePagesMenu.Name = "_LandscapePagesMenu";
            resources.ApplyResources(this._LandscapePagesMenu, "_LandscapePagesMenu");
            // 
            // _PageSettingsMenu
            // 
            this._PageSettingsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._PageSettingsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._RotateMenu});
            this._PageSettingsMenu.Name = "_PageSettingsMenu";
            resources.ApplyResources(this._PageSettingsMenu, "_PageSettingsMenu");
            // 
            // _RotateMenu
            // 
            this._RotateMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._RotateZeroMenuItem,
            this._RotateLeftMenuItem,
            this._RotateRightMenuItem,
            this._Rotate180MenuItem});
            this._RotateMenu.Name = "_RotateMenu";
            resources.ApplyResources(this._RotateMenu, "_RotateMenu");
            // 
            // _RotateLeftMenuItem
            // 
            this._RotateLeftMenuItem.Image = global::PDFPatcher.Properties.Resources.RotateLeft;
            this._RotateLeftMenuItem.Name = "_RotateLeftMenuItem";
            resources.ApplyResources(this._RotateLeftMenuItem, "_RotateLeftMenuItem");
            // 
            // _RotateRightMenuItem
            // 
            this._RotateRightMenuItem.Image = global::PDFPatcher.Properties.Resources.RotateRight;
            this._RotateRightMenuItem.Name = "_RotateRightMenuItem";
            resources.ApplyResources(this._RotateRightMenuItem, "_RotateRightMenuItem");
            // 
            // _Rotate180MenuItem
            // 
            this._Rotate180MenuItem.Image = global::PDFPatcher.Properties.Resources.Refresh;
            this._Rotate180MenuItem.Name = "_Rotate180MenuItem";
            resources.ApplyResources(this._Rotate180MenuItem, "_Rotate180MenuItem");
            // 
            // _RemoveButton
            // 
            resources.ApplyResources(this._RemoveButton, "_RemoveButton");
            this._RemoveButton.Image = global::PDFPatcher.Properties.Resources.Delete;
            this._RemoveButton.Name = "_RemoveButton";
            this._RemoveButton.UseVisualStyleBackColor = true;
            this._RemoveButton.Click += new System.EventHandler(this._RemovePageSettingsButton_Click);
            // 
            // _AddButton
            // 
            resources.ApplyResources(this._AddButton, "_AddButton");
            this._AddButton.Image = global::PDFPatcher.Properties.Resources.Add;
            this._AddButton.Name = "_AddButton";
            this._AddButton.UseVisualStyleBackColor = true;
            this._AddButton.Click += new System.EventHandler(this._AddPageSettingsButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._PageSettingsBox);
            this.panel1.Controls.Add(this._AddButton);
            this.panel1.Controls.Add(this._RemoveButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // PageSettingsEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PageSettingsEditor";
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
