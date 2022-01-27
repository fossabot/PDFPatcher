namespace PDFPatcher.Functions
{
    partial class MergerControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripDropDownButton _File;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergerControl));
            System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
            System.Windows.Forms.ToolStripMenuItem _LoadList;
            System.Windows.Forms.ToolStripMenuItem _SaveList;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripButton _EditItemProperty;
            System.Windows.Forms.ToolStripButton _Refresh;
            System.Windows.Forms.ToolStripMenuItem _SetPdfOptions;
            System.Windows.Forms.ToolStripMenuItem _SetCroppingOptions;
            System.Windows.Forms.ToolStripMenuItem _Copy;
            System.Windows.Forms.ToolStripMenuItem _RefreshFolder;
            System.Windows.Forms.ToolStripMenuItem _ClearBookmarkTitle;
            System.Windows.Forms.ToolStripMenuItem _SetBookmarkTitle;
            System.Windows.Forms.ToolStripMenuItem _PasteBookmarkText;
            System.Windows.Forms.ToolStripMenuItem _CopyBookmarkText;
            System.Windows.Forms.ToolStripMenuItem _CopyFileName;
            System.Windows.Forms.ToolStripButton _Delete;
            this._FileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._SortByNaturalNumberItem = new System.Windows.Forms.ToolStripMenuItem();
            this._SortByAlphaItem = new System.Windows.Forms.ToolStripMenuItem();
            this._MainToolbar = new System.Windows.Forms.ToolStrip();
            this._AddFilesButton = new System.Windows.Forms.ToolStripSplitButton();
            this._RecentFileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._AddFolderButton = new System.Windows.Forms.ToolStripSplitButton();
            this._RecentFolderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._InsertEmptyPage = new System.Windows.Forms.ToolStripButton();
            this._BoldStyleButton = new System.Windows.Forms.ToolStripButton();
            this._ItalicStyleButton = new System.Windows.Forms.ToolStripButton();
            this._BookmarkColorButton = new ColorPicker.ToolStripColorPicker();
            this._BookmarkTextMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this._ItemList = new BrightIdeasSoftware.TreeListView();
            this._NameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._BookmarkColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._PageRangeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._FolderColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ItemListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._FileTypeList = new System.Windows.Forms.ImageList(this.components);
            this._OpenImageBox = new System.Windows.Forms.OpenFileDialog();
            this._OpenPdfBox = new System.Windows.Forms.OpenFileDialog();
            this._AddDocumentWorker = new System.ComponentModel.BackgroundWorker();
            this._BookmarkControl = new PDFPatcher.BookmarkControl();
            this._TargetPdfFile = new PDFPatcher.TargetFileControl();
            this._ImportButton = new EnhancedGlassButton.GlassButton();
            this._IndividualMergerModeBox = new System.Windows.Forms.CheckBox();
            this._ConfigButton = new System.Windows.Forms.Button();
            _File = new System.Windows.Forms.ToolStripDropDownButton();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            _LoadList = new System.Windows.Forms.ToolStripMenuItem();
            _SaveList = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            _EditItemProperty = new System.Windows.Forms.ToolStripButton();
            _Refresh = new System.Windows.Forms.ToolStripButton();
            _SetPdfOptions = new System.Windows.Forms.ToolStripMenuItem();
            _SetCroppingOptions = new System.Windows.Forms.ToolStripMenuItem();
            _Copy = new System.Windows.Forms.ToolStripMenuItem();
            _RefreshFolder = new System.Windows.Forms.ToolStripMenuItem();
            _ClearBookmarkTitle = new System.Windows.Forms.ToolStripMenuItem();
            _SetBookmarkTitle = new System.Windows.Forms.ToolStripMenuItem();
            _PasteBookmarkText = new System.Windows.Forms.ToolStripMenuItem();
            _CopyBookmarkText = new System.Windows.Forms.ToolStripMenuItem();
            _CopyFileName = new System.Windows.Forms.ToolStripMenuItem();
            _Delete = new System.Windows.Forms.ToolStripButton();
            this._FileMenu.SuspendLayout();
            this._MainToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ItemList)).BeginInit();
            this._ItemListMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _File
            // 
            _File.AutoToolTip = false;
            _File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            _File.DropDown = this._FileMenu;
            _File.Image = global::PDFPatcher.Properties.Resources.Sort;
            resources.ApplyResources(_File, "_File");
            _File.Name = "_File";
            _File.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._MainToolbar_ItemClicked);
            // 
            // _FileMenu
            // 
            this._FileMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._FileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._SortByNaturalNumberItem,
            this._SortByAlphaItem,
            toolStripSeparator4,
            _LoadList,
            _SaveList});
            this._FileMenu.Name = "_SortMenu";
            this._FileMenu.OwnerItem = _File;
            resources.ApplyResources(this._FileMenu, "_FileMenu");
            this._FileMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._SortMenu_ItemClicked);
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
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
            // 
            // _LoadList
            // 
            _LoadList.Image = global::PDFPatcher.Properties.Resources.Open;
            _LoadList.Name = "_LoadList";
            resources.ApplyResources(_LoadList, "_LoadList");
            // 
            // _SaveList
            // 
            _SaveList.Image = global::PDFPatcher.Properties.Resources.Save;
            _SaveList.Name = "_SaveList";
            resources.ApplyResources(_SaveList, "_SaveList");
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
            // _EditItemProperty
            // 
            _EditItemProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            _EditItemProperty.Image = global::PDFPatcher.Properties.Resources.PdfPageRange;
            resources.ApplyResources(_EditItemProperty, "_EditItemProperty");
            _EditItemProperty.Name = "_EditItemProperty";
            // 
            // _Refresh
            // 
            _Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            _Refresh.Image = global::PDFPatcher.Properties.Resources.Refresh;
            resources.ApplyResources(_Refresh, "_Refresh");
            _Refresh.Name = "_Refresh";
            // 
            // _SetPdfOptions
            // 
            _SetPdfOptions.Name = "_SetPdfOptions";
            resources.ApplyResources(_SetPdfOptions, "_SetPdfOptions");
            // 
            // _SetCroppingOptions
            // 
            _SetCroppingOptions.Name = "_SetCroppingOptions";
            resources.ApplyResources(_SetCroppingOptions, "_SetCroppingOptions");
            // 
            // _Copy
            // 
            _Copy.Name = "_Copy";
            resources.ApplyResources(_Copy, "_Copy");
            // 
            // _RefreshFolder
            // 
            _RefreshFolder.Image = global::PDFPatcher.Properties.Resources.Refresh;
            _RefreshFolder.Name = "_RefreshFolder";
            resources.ApplyResources(_RefreshFolder, "_RefreshFolder");
            // 
            // _ClearBookmarkTitle
            // 
            _ClearBookmarkTitle.Name = "_ClearBookmarkTitle";
            resources.ApplyResources(_ClearBookmarkTitle, "_ClearBookmarkTitle");
            // 
            // _SetBookmarkTitle
            // 
            _SetBookmarkTitle.Name = "_SetBookmarkTitle";
            resources.ApplyResources(_SetBookmarkTitle, "_SetBookmarkTitle");
            // 
            // _PasteBookmarkText
            // 
            _PasteBookmarkText.Image = global::PDFPatcher.Properties.Resources.Paste;
            _PasteBookmarkText.Name = "_PasteBookmarkText";
            resources.ApplyResources(_PasteBookmarkText, "_PasteBookmarkText");
            // 
            // _CopyBookmarkText
            // 
            _CopyBookmarkText.Image = global::PDFPatcher.Properties.Resources.Copy;
            _CopyBookmarkText.Name = "_CopyBookmarkText";
            resources.ApplyResources(_CopyBookmarkText, "_CopyBookmarkText");
            // 
            // _CopyFileName
            // 
            _CopyFileName.Name = "_CopyFileName";
            resources.ApplyResources(_CopyFileName, "_CopyFileName");
            // 
            // _Delete
            // 
            _Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            _Delete.Image = global::PDFPatcher.Properties.Resources.Delete;
            resources.ApplyResources(_Delete, "_Delete");
            _Delete.Name = "_Delete";
            // 
            // _MainToolbar
            // 
            resources.ApplyResources(this._MainToolbar, "_MainToolbar");
            this._MainToolbar.GripMargin = new System.Windows.Forms.Padding(0);
            this._MainToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _File,
            this._AddFilesButton,
            this._AddFolderButton,
            this._InsertEmptyPage,
            _Delete,
            toolStripSeparator1,
            this._BoldStyleButton,
            this._ItalicStyleButton,
            this._BookmarkColorButton,
            this._BookmarkTextMenu,
            toolStripSeparator2,
            _EditItemProperty,
            _Refresh});
            this._MainToolbar.Name = "_MainToolbar";
            this._MainToolbar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._MainToolbar_ItemClicked);
            // 
            // _AddFilesButton
            // 
            this._AddFilesButton.DropDown = this._RecentFileMenu;
            this._AddFilesButton.Image = global::PDFPatcher.Properties.Resources.Add;
            resources.ApplyResources(this._AddFilesButton, "_AddFilesButton");
            this._AddFilesButton.Name = "_AddFilesButton";
            this._AddFilesButton.ButtonClick += new System.EventHandler(this._MainToolbar_ButtonClick);
            // 
            // _RecentFileMenu
            // 
            this._RecentFileMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._RecentFileMenu.Name = "_RecentFileMenu";
            this._RecentFileMenu.OwnerItem = this._AddFilesButton;
            this._RecentFileMenu.ShowImageMargin = false;
            resources.ApplyResources(this._RecentFileMenu, "_RecentFileMenu");
            // 
            // _AddFolderButton
            // 
            this._AddFolderButton.DropDown = this._RecentFolderMenu;
            this._AddFolderButton.Image = global::PDFPatcher.Properties.Resources.ImageFolder;
            resources.ApplyResources(this._AddFolderButton, "_AddFolderButton");
            this._AddFolderButton.Name = "_AddFolderButton";
            this._AddFolderButton.ButtonClick += new System.EventHandler(this._MainToolbar_ButtonClick);
            this._AddFolderButton.DropDownOpening += new System.EventHandler(this._AddFolder_DropDownOpening);
            this._AddFolderButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._AddFolderButton_DropDownItemClicked);
            // 
            // _RecentFolderMenu
            // 
            this._RecentFolderMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._RecentFolderMenu.Name = "_RecentFolderMenu";
            this._RecentFolderMenu.OwnerItem = this._AddFolderButton;
            this._RecentFolderMenu.ShowImageMargin = false;
            resources.ApplyResources(this._RecentFolderMenu, "_RecentFolderMenu");
            // 
            // _InsertEmptyPage
            // 
            this._InsertEmptyPage.Image = global::PDFPatcher.Properties.Resources.EmptyPage;
            resources.ApplyResources(this._InsertEmptyPage, "_InsertEmptyPage");
            this._InsertEmptyPage.Name = "_InsertEmptyPage";
            // 
            // _BoldStyleButton
            // 
            this._BoldStyleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._BoldStyleButton.Image = global::PDFPatcher.Properties.Resources.Bold;
            resources.ApplyResources(this._BoldStyleButton, "_BoldStyleButton");
            this._BoldStyleButton.Name = "_BoldStyleButton";
            // 
            // _ItalicStyleButton
            // 
            this._ItalicStyleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ItalicStyleButton.Image = global::PDFPatcher.Properties.Resources.Italic;
            resources.ApplyResources(this._ItalicStyleButton, "_ItalicStyleButton");
            this._ItalicStyleButton.Name = "_ItalicStyleButton";
            // 
            // _BookmarkColorButton
            // 
            resources.ApplyResources(this._BookmarkColorButton, "_BookmarkColorButton");
            this._BookmarkColorButton.ButtonDisplayStyle = ColorPicker.ToolStripColorPickerDisplayType.UnderLineAndImage;
            this._BookmarkColorButton.Color = System.Drawing.Color.Black;
            this._BookmarkColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._BookmarkColorButton.Name = "_BookmarkColorButton";
            // 
            // _BookmarkTextMenu
            // 
            this._BookmarkTextMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._BookmarkTextMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _ClearBookmarkTitle,
            _SetBookmarkTitle});
            this._BookmarkTextMenu.Image = global::PDFPatcher.Properties.Resources.Mark;
            resources.ApplyResources(this._BookmarkTextMenu, "_BookmarkTextMenu");
            this._BookmarkTextMenu.Name = "_BookmarkTextMenu";
            this._BookmarkTextMenu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._MainToolbar_ItemClicked);
            // 
            // _ItemList
            // 
            this._ItemList.AllColumns.Add(this._NameColumn);
            this._ItemList.AllColumns.Add(this._BookmarkColumn);
            this._ItemList.AllColumns.Add(this._PageRangeColumn);
            this._ItemList.AllColumns.Add(this._FolderColumn);
            this._ItemList.AllowDrop = true;
            resources.ApplyResources(this._ItemList, "_ItemList");
            this._ItemList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this._ItemList.CellEditUseWholeCell = false;
            this._ItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._NameColumn,
            this._BookmarkColumn,
            this._PageRangeColumn,
            this._FolderColumn});
            this._ItemList.ContextMenuStrip = this._ItemListMenu;
            this._ItemList.Cursor = System.Windows.Forms.Cursors.Default;
            this._ItemList.GridLines = true;
            this._ItemList.HideSelection = false;
            this._ItemList.IsSimpleDragSource = true;
            this._ItemList.IsSimpleDropSink = true;
            this._ItemList.Name = "_ItemList";
            this._ItemList.ShowGroups = false;
            this._ItemList.SmallImageList = this._FileTypeList;
            this._ItemList.UseCellFormatEvents = true;
            this._ItemList.UseCompatibleStateImageBehavior = false;
            this._ItemList.View = System.Windows.Forms.View.Details;
            this._ItemList.VirtualMode = true;
            this._ItemList.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this._ItemList_FormatRow);
            this._ItemList.ItemActivate += new System.EventHandler(this._ItemList_ItemActivate);
            // 
            // _NameColumn
            // 
            this._NameColumn.IsEditable = false;
            resources.ApplyResources(this._NameColumn, "_NameColumn");
            // 
            // _BookmarkColumn
            // 
            resources.ApplyResources(this._BookmarkColumn, "_BookmarkColumn");
            // 
            // _PageRangeColumn
            // 
            this._PageRangeColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            resources.ApplyResources(this._PageRangeColumn, "_PageRangeColumn");
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
            _CopyBookmarkText,
            _PasteBookmarkText,
            _CopyFileName,
            _Copy,
            this.toolStripSeparator3,
            _SetCroppingOptions,
            _SetPdfOptions,
            _RefreshFolder});
            this._ItemListMenu.Name = "_ItemListMenu";
            resources.ApplyResources(this._ItemListMenu, "_ItemListMenu");
            this._ItemListMenu.Opening += new System.ComponentModel.CancelEventHandler(this._ItemListMenu_Opening);
            this._ItemListMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._MainToolbar_ItemClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // _FileTypeList
            // 
            this._FileTypeList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this._FileTypeList, "_FileTypeList");
            this._FileTypeList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _OpenImageBox
            // 
            resources.ApplyResources(this._OpenImageBox, "_OpenImageBox");
            this._OpenImageBox.Multiselect = true;
            // 
            // _OpenPdfBox
            // 
            this._OpenPdfBox.DefaultExt = "pdf";
            resources.ApplyResources(this._OpenPdfBox, "_OpenPdfBox");
            this._OpenPdfBox.Multiselect = true;
            // 
            // _AddDocumentWorker
            // 
            this._AddDocumentWorker.WorkerReportsProgress = true;
            this._AddDocumentWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._AddDocumentWorker_DoWork);
            this._AddDocumentWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._AddDocumentWorker_ProgressChanged);
            this._AddDocumentWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._AddDocumentWorker_RunWorkerCompleted);
            // 
            // _BookmarkControl
            // 
            resources.ApplyResources(this._BookmarkControl, "_BookmarkControl");
            this._BookmarkControl.LabelText = "P&DF information file:";
            this._BookmarkControl.Name = "_BookmarkControl";
            // 
            // _TargetPdfFile
            // 
            resources.ApplyResources(this._TargetPdfFile, "_TargetPdfFile");
            this._TargetPdfFile.Name = "_TargetPdfFile";
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
            // _IndividualMergerModeBox
            // 
            resources.ApplyResources(this._IndividualMergerModeBox, "_IndividualMergerModeBox");
            this._IndividualMergerModeBox.Name = "_IndividualMergerModeBox";
            this._IndividualMergerModeBox.UseVisualStyleBackColor = true;
            // 
            // _ConfigButton
            // 
            resources.ApplyResources(this._ConfigButton, "_ConfigButton");
            this._ConfigButton.Image = global::PDFPatcher.Properties.Resources.PdfOptions;
            this._ConfigButton.Name = "_ConfigButton";
            this._ConfigButton.UseVisualStyleBackColor = true;
            this._ConfigButton.Click += new System.EventHandler(this._MainToolbar_ButtonClick);
            // 
            // MergerControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ConfigButton);
            this.Controls.Add(this._IndividualMergerModeBox);
            this.Controls.Add(this._MainToolbar);
            this.Controls.Add(this._TargetPdfFile);
            this.Controls.Add(this._ImportButton);
            this.Controls.Add(this._BookmarkControl);
            this.Controls.Add(this._ItemList);
            this.Name = "MergerControl";
            this.Load += new System.EventHandler(this.MergerControl_Load);
            this._FileMenu.ResumeLayout(false);
            this._MainToolbar.ResumeLayout(false);
            this._MainToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ItemList)).EndInit();
            this._ItemListMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.TreeListView _ItemList;
        private BrightIdeasSoftware.OLVColumn _NameColumn;
        private EnhancedGlassButton.GlassButton _ImportButton;
        private System.Windows.Forms.OpenFileDialog _OpenImageBox;
        private BrightIdeasSoftware.OLVColumn _FolderColumn;
        private TargetFileControl _TargetPdfFile;
        private System.Windows.Forms.ContextMenuStrip _FileMenu;
        private System.Windows.Forms.ToolStripMenuItem _SortByAlphaItem;
        private BookmarkControl _BookmarkControl;
        private System.Windows.Forms.ContextMenuStrip _ItemListMenu;
        private System.Windows.Forms.ToolStripSplitButton _AddFilesButton;
        private System.Windows.Forms.ContextMenuStrip _RecentFileMenu;
        private System.Windows.Forms.OpenFileDialog _OpenPdfBox;
        private System.Windows.Forms.ToolStripButton _InsertEmptyPage;
        private System.ComponentModel.BackgroundWorker _AddDocumentWorker;
        private System.Windows.Forms.ImageList _FileTypeList;
        private BrightIdeasSoftware.OLVColumn _BookmarkColumn;
        private System.Windows.Forms.ToolStripButton _BoldStyleButton;
        private System.Windows.Forms.ToolStripButton _ItalicStyleButton;
        private ColorPicker.ToolStripColorPicker _BookmarkColorButton;
        private System.Windows.Forms.ToolStrip _MainToolbar;
        private System.Windows.Forms.ToolStripSplitButton _AddFolderButton;
        private System.Windows.Forms.ContextMenuStrip _RecentFolderMenu;
        private System.Windows.Forms.ToolStripDropDownButton _BookmarkTextMenu;
        private System.Windows.Forms.CheckBox _IndividualMergerModeBox;
        private BrightIdeasSoftware.OLVColumn _PageRangeColumn;
        private System.Windows.Forms.Button _ConfigButton;
        private System.Windows.Forms.ToolStripMenuItem _SortByNaturalNumberItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
