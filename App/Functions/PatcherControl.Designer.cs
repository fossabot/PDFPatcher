namespace PDFPatcher.Functions
{
	partial class PatcherControl
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
            System.Windows.Forms.ToolStrip _MainToolbar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatcherControl));
            System.Windows.Forms.ToolStripDropDownButton _Sort;
            System.Windows.Forms.ToolStripButton _Delete;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripMenuItem _SelectAll;
            System.Windows.Forms.ToolStripMenuItem _InvertSelect;
            System.Windows.Forms.ToolStripMenuItem _SelectNone;
            System.Windows.Forms.ToolStripMenuItem _Copy;
            System.Windows.Forms.ToolStripMenuItem _RefreshInfo;
            this._AddFilesButton = new System.Windows.Forms.ToolStripSplitButton();
            this._RecentFileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._SortMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._SortByNaturalNumberItem = new System.Windows.Forms.ToolStripMenuItem();
            this._SortByAlphaItem = new System.Windows.Forms.ToolStripMenuItem();
            this._RefreshInfoButton = new System.Windows.Forms.ToolStripSplitButton();
            this._RefreshInfoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._SelectionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._SelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ItemList = new BrightIdeasSoftware.ObjectListView();
            this._NameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._PageCountColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._TitleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._AuthorColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._SubjectColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._KeywordsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._FolderColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ItemListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._FileTypeList = new System.Windows.Forms.ImageList(this.components);
            this._OpenPdfBox = new System.Windows.Forms.OpenFileDialog();
            this._AutoClearListBox = new System.Windows.Forms.CheckBox();
            this._AddDocumentWorker = new System.ComponentModel.BackgroundWorker();
            this._TargetPdfFile = new PDFPatcher.TargetFileControl();
            this._ActionsBox = new BrightIdeasSoftware.ObjectListView();
            this._ActionNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ItemActionsContainerBox = new System.Windows.Forms.SplitContainer();
            this._ConfigButton = new System.Windows.Forms.Button();
            this._ImportButton = new EnhancedGlassButton.GlassButton();
            _MainToolbar = new System.Windows.Forms.ToolStrip();
            _Sort = new System.Windows.Forms.ToolStripDropDownButton();
            _Delete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            _SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            _InvertSelect = new System.Windows.Forms.ToolStripMenuItem();
            _SelectNone = new System.Windows.Forms.ToolStripMenuItem();
            _Copy = new System.Windows.Forms.ToolStripMenuItem();
            _RefreshInfo = new System.Windows.Forms.ToolStripMenuItem();
            _MainToolbar.SuspendLayout();
            this._SortMenu.SuspendLayout();
            this._SelectionMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ItemList)).BeginInit();
            this._ItemListMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ActionsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ItemActionsContainerBox)).BeginInit();
            this._ItemActionsContainerBox.Panel1.SuspendLayout();
            this._ItemActionsContainerBox.Panel2.SuspendLayout();
            this._ItemActionsContainerBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _MainToolbar
            // 
            resources.ApplyResources(_MainToolbar, "_MainToolbar");
            _MainToolbar.GripMargin = new System.Windows.Forms.Padding(0);
            _MainToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            _MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._AddFilesButton,
            _Sort,
            _Delete,
            toolStripSeparator2,
            this._RefreshInfoButton});
            _MainToolbar.Name = "_MainToolbar";
            _MainToolbar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._MainToolbar_ItemClicked);
            // 
            // _AddFilesButton
            // 
            this._AddFilesButton.DropDown = this._RecentFileMenu;
            this._AddFilesButton.Image = global::PDFPatcher.Properties.Resources.Add;
            resources.ApplyResources(this._AddFilesButton, "_AddFilesButton");
            this._AddFilesButton.Name = "_AddFilesButton";
            // 
            // _RecentFileMenu
            // 
            this._RecentFileMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._RecentFileMenu.Name = "_RecentFileMenu";
            this._RecentFileMenu.OwnerItem = this._AddFilesButton;
            this._RecentFileMenu.ShowImageMargin = false;
            resources.ApplyResources(this._RecentFileMenu, "_RecentFileMenu");
            // 
            // _Sort
            // 
            _Sort.DropDown = this._SortMenu;
            _Sort.Image = global::PDFPatcher.Properties.Resources.Sort;
            resources.ApplyResources(_Sort, "_Sort");
            _Sort.Name = "_Sort";
            _Sort.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._SortMenu_ItemClicked);
            // 
            // _SortMenu
            // 
            this._SortMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._SortMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._SortByNaturalNumberItem,
            this._SortByAlphaItem});
            this._SortMenu.Name = "_SortMenu";
            this._SortMenu.OwnerItem = _Sort;
            resources.ApplyResources(this._SortMenu, "_SortMenu");
            this._SortMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._SortMenu_ItemClicked);
            // 
            // _SortByNaturalNumberItem
            // 
            this._SortByNaturalNumberItem.Image = global::PDFPatcher.Properties.Resources.NaturalSort;
            this._SortByNaturalNumberItem.Name = "_SortByNaturalNumberItem";
            resources.ApplyResources(this._SortByNaturalNumberItem, "_SortByNaturalNumberItem");
            // 
            // _SortByAlphaItem
            // 
            this._SortByAlphaItem.Image = global::PDFPatcher.Properties.Resources.AlphabeticSort;
            this._SortByAlphaItem.Name = "_SortByAlphaItem";
            resources.ApplyResources(this._SortByAlphaItem, "_SortByAlphaItem");
            // 
            // _Delete
            // 
            _Delete.Image = global::PDFPatcher.Properties.Resources.Delete;
            resources.ApplyResources(_Delete, "_Delete");
            _Delete.Name = "_Delete";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // _RefreshInfoButton
            // 
            this._RefreshInfoButton.Image = global::PDFPatcher.Properties.Resources.Refresh;
            resources.ApplyResources(this._RefreshInfoButton, "_RefreshInfoButton");
            this._RefreshInfoButton.Name = "_RefreshInfoButton";
            // 
            // _SelectAll
            // 
            _SelectAll.Image = global::PDFPatcher.Properties.Resources.SelectAll;
            _SelectAll.Name = "_SelectAll";
            resources.ApplyResources(_SelectAll, "_SelectAll");
            // 
            // _InvertSelect
            // 
            _InvertSelect.Name = "_InvertSelect";
            resources.ApplyResources(_InvertSelect, "_InvertSelect");
            // 
            // _SelectNone
            // 
            _SelectNone.Name = "_SelectNone";
            resources.ApplyResources(_SelectNone, "_SelectNone");
            // 
            // _Copy
            // 
            _Copy.Image = global::PDFPatcher.Properties.Resources.Copy;
            _Copy.Name = "_Copy";
            resources.ApplyResources(_Copy, "_Copy");
            // 
            // _RefreshInfo
            // 
            _RefreshInfo.DropDown = this._RefreshInfoMenu;
            _RefreshInfo.Image = global::PDFPatcher.Properties.Resources.Refresh;
            _RefreshInfo.Name = "_RefreshInfo";
            resources.ApplyResources(_RefreshInfo, "_RefreshInfo");
            // 
            // _RefreshInfoMenu
            // 
            this._RefreshInfoMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._RefreshInfoMenu.Name = "_RefreshInfoMenu";
            this._RefreshInfoMenu.OwnerItem = _RefreshInfo;
            resources.ApplyResources(this._RefreshInfoMenu, "_RefreshInfoMenu");
            // 
            // _SelectionMenu
            // 
            this._SelectionMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._SelectionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _SelectAll,
            _InvertSelect,
            _SelectNone});
            this._SelectionMenu.Name = "_SelectionMenu";
            this._SelectionMenu.OwnerItem = this._SelectionMenuItem;
            resources.ApplyResources(this._SelectionMenu, "_SelectionMenu");
            this._SelectionMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._MainToolbar_ItemClicked);
            // 
            // _SelectionMenuItem
            // 
            this._SelectionMenuItem.DropDown = this._SelectionMenu;
            this._SelectionMenuItem.Image = global::PDFPatcher.Properties.Resources.SelectItem;
            this._SelectionMenuItem.Name = "_SelectionMenuItem";
            resources.ApplyResources(this._SelectionMenuItem, "_SelectionMenuItem");
            // 
            // _ItemList
            // 
            this._ItemList.AllColumns.Add(this._NameColumn);
            this._ItemList.AllColumns.Add(this._PageCountColumn);
            this._ItemList.AllColumns.Add(this._TitleColumn);
            this._ItemList.AllColumns.Add(this._AuthorColumn);
            this._ItemList.AllColumns.Add(this._SubjectColumn);
            this._ItemList.AllColumns.Add(this._KeywordsColumn);
            this._ItemList.AllColumns.Add(this._FolderColumn);
            this._ItemList.AllowDrop = true;
            resources.ApplyResources(this._ItemList, "_ItemList");
            this._ItemList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this._ItemList.CellEditUseWholeCell = false;
            this._ItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._NameColumn,
            this._PageCountColumn,
            this._TitleColumn,
            this._AuthorColumn,
            this._SubjectColumn,
            this._KeywordsColumn,
            this._FolderColumn});
            this._ItemList.ContextMenuStrip = this._ItemListMenu;
            this._ItemList.Cursor = System.Windows.Forms.Cursors.Default;
            this._ItemList.GridLines = true;
            this._ItemList.HideSelection = false;
            this._ItemList.Name = "_ItemList";
            this._ItemList.ShowGroups = false;
            this._ItemList.SmallImageList = this._FileTypeList;
            this._ItemList.UseCompatibleStateImageBehavior = false;
            this._ItemList.View = System.Windows.Forms.View.Details;
            this._ItemList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this._ImageList_ColumnClick);
            // 
            // _NameColumn
            // 
            resources.ApplyResources(this._NameColumn, "_NameColumn");
            // 
            // _PageCountColumn
            // 
            this._PageCountColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._PageCountColumn.IsEditable = false;
            resources.ApplyResources(this._PageCountColumn, "_PageCountColumn");
            // 
            // _TitleColumn
            // 
            resources.ApplyResources(this._TitleColumn, "_TitleColumn");
            // 
            // _AuthorColumn
            // 
            resources.ApplyResources(this._AuthorColumn, "_AuthorColumn");
            // 
            // _SubjectColumn
            // 
            resources.ApplyResources(this._SubjectColumn, "_SubjectColumn");
            // 
            // _KeywordsColumn
            // 
            resources.ApplyResources(this._KeywordsColumn, "_KeywordsColumn");
            // 
            // _FolderColumn
            // 
            this._FolderColumn.IsEditable = false;
            resources.ApplyResources(this._FolderColumn, "_FolderColumn");
            // 
            // _ItemListMenu
            // 
            this._ItemListMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._ItemListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _Copy,
            _RefreshInfo,
            this._SelectionMenuItem});
            this._ItemListMenu.Name = "_ItemListMenu";
            resources.ApplyResources(this._ItemListMenu, "_ItemListMenu");
            this._ItemListMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._MainToolbar_ItemClicked);
            // 
            // _FileTypeList
            // 
            this._FileTypeList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this._FileTypeList, "_FileTypeList");
            this._FileTypeList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _OpenPdfBox
            // 
            this._OpenPdfBox.DefaultExt = "pdf";
            resources.ApplyResources(this._OpenPdfBox, "_OpenPdfBox");
            this._OpenPdfBox.Multiselect = true;
            // 
            // _AutoClearListBox
            // 
            resources.ApplyResources(this._AutoClearListBox, "_AutoClearListBox");
            this._AutoClearListBox.Checked = true;
            this._AutoClearListBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._AutoClearListBox.Name = "_AutoClearListBox";
            this._AutoClearListBox.UseVisualStyleBackColor = true;
            // 
            // _AddDocumentWorker
            // 
            this._AddDocumentWorker.WorkerReportsProgress = true;
            this._AddDocumentWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._AddDocumentWorker_DoWork);
            this._AddDocumentWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._AddDocumentWorker_ProgressChanged);
            this._AddDocumentWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._AddDocumentWorker_RunWorkerCompleted);
            // 
            // _TargetPdfFile
            // 
            resources.ApplyResources(this._TargetPdfFile, "_TargetPdfFile");
            this._TargetPdfFile.Name = "_TargetPdfFile";
            // 
            // _ActionsBox
            // 
            this._ActionsBox.AllColumns.Add(this._ActionNameColumn);
            resources.ApplyResources(this._ActionsBox, "_ActionsBox");
            this._ActionsBox.CellEditUseWholeCell = false;
            this._ActionsBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._ActionNameColumn});
            this._ActionsBox.Cursor = System.Windows.Forms.Cursors.Default;
            this._ActionsBox.FullRowSelect = true;
            this._ActionsBox.GridLines = true;
            this._ActionsBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._ActionsBox.HideSelection = false;
            this._ActionsBox.Name = "_ActionsBox";
            this._ActionsBox.RowHeight = 18;
            this._ActionsBox.ShowGroups = false;
            this._ActionsBox.UseCompatibleStateImageBehavior = false;
            this._ActionsBox.View = System.Windows.Forms.View.Details;
            // 
            // _ActionNameColumn
            // 
            resources.ApplyResources(this._ActionNameColumn, "_ActionNameColumn");
            // 
            // _ItemActionsContainerBox
            // 
            resources.ApplyResources(this._ItemActionsContainerBox, "_ItemActionsContainerBox");
            this._ItemActionsContainerBox.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._ItemActionsContainerBox.Name = "_ItemActionsContainerBox";
            // 
            // _ItemActionsContainerBox.Panel1
            // 
            this._ItemActionsContainerBox.Panel1.Controls.Add(this._ItemList);
            // 
            // _ItemActionsContainerBox.Panel2
            // 
            this._ItemActionsContainerBox.Panel2.Controls.Add(this._ActionsBox);
            this._ItemActionsContainerBox.Panel2Collapsed = true;
            // 
            // _ConfigButton
            // 
            resources.ApplyResources(this._ConfigButton, "_ConfigButton");
            this._ConfigButton.Image = global::PDFPatcher.Properties.Resources.PdfOptions;
            this._ConfigButton.Name = "_ConfigButton";
            this._ConfigButton.UseVisualStyleBackColor = true;
            // 
            // _ImportButton
            // 
            this._ImportButton.AlternativeFocusBorderColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this._ImportButton, "_ImportButton");
            this._ImportButton.AnimateGlow = true;
            this._ImportButton.BackColor = System.Drawing.SystemColors.Highlight;
            this._ImportButton.CornerRadius = 3;
            this._ImportButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ImportButton.GlowColor = System.Drawing.Color.White;
            this._ImportButton.Image = global::PDFPatcher.Properties.Resources.Save;
            this._ImportButton.InnerBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this._ImportButton.Name = "_ImportButton";
            this._ImportButton.OuterBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this._ImportButton.ShowFocusBorder = true;
            this._ImportButton.Click += new System.EventHandler(this._ImportButton_Click);
            // 
            // PatcherControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ImportButton);
            this.Controls.Add(this._ConfigButton);
            this.Controls.Add(_MainToolbar);
            this.Controls.Add(this._TargetPdfFile);
            this.Controls.Add(this._ItemActionsContainerBox);
            this.Controls.Add(this._AutoClearListBox);
            this.Name = "PatcherControl";
            this.Load += new System.EventHandler(this.PatcherControl_OnLoad);
            _MainToolbar.ResumeLayout(false);
            _MainToolbar.PerformLayout();
            this._SortMenu.ResumeLayout(false);
            this._SelectionMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ItemList)).EndInit();
            this._ItemListMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ActionsBox)).EndInit();
            this._ItemActionsContainerBox.Panel1.ResumeLayout(false);
            this._ItemActionsContainerBox.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ItemActionsContainerBox)).EndInit();
            this._ItemActionsContainerBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private BrightIdeasSoftware.ObjectListView _ItemList;
		private BrightIdeasSoftware.OLVColumn _NameColumn;
		private BrightIdeasSoftware.OLVColumn _FolderColumn;
		private TargetFileControl _TargetPdfFile;
		private System.Windows.Forms.ContextMenuStrip _SortMenu;
		private System.Windows.Forms.ToolStripMenuItem _SortByNaturalNumberItem;
		private System.Windows.Forms.ToolStripMenuItem _SortByAlphaItem;
		private System.Windows.Forms.ContextMenuStrip _SelectionMenu;
		private BrightIdeasSoftware.OLVColumn _PageCountColumn;
		private System.Windows.Forms.ToolStripMenuItem _SelectionMenuItem;
		private System.Windows.Forms.ContextMenuStrip _ItemListMenu;
		private System.Windows.Forms.ContextMenuStrip _RecentFileMenu;
		private System.Windows.Forms.OpenFileDialog _OpenPdfBox;
		private System.Windows.Forms.CheckBox _AutoClearListBox;
		private System.ComponentModel.BackgroundWorker _AddDocumentWorker;
		private BrightIdeasSoftware.OLVColumn _TitleColumn;
		private BrightIdeasSoftware.OLVColumn _AuthorColumn;
		private BrightIdeasSoftware.OLVColumn _SubjectColumn;
		private BrightIdeasSoftware.OLVColumn _KeywordsColumn;
		private BrightIdeasSoftware.ObjectListView _ActionsBox;
		private System.Windows.Forms.SplitContainer _ItemActionsContainerBox;
		private BrightIdeasSoftware.OLVColumn _ActionNameColumn;
		private System.Windows.Forms.ImageList _FileTypeList;
		private System.Windows.Forms.ToolStripSplitButton _RefreshInfoButton;
		private System.Windows.Forms.ContextMenuStrip _RefreshInfoMenu;
		private System.Windows.Forms.Button _ConfigButton;
		private EnhancedGlassButton.GlassButton _ImportButton;
		private System.Windows.Forms.ToolStripSplitButton _AddFilesButton;
	}
}
