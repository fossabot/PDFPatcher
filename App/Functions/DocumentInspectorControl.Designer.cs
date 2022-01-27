namespace PDFPatcher.Functions
{
	partial class DocumentInspectorControl
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
            System.Windows.Forms.ToolStripMenuItem _ExportBinary;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentInspectorControl));
            System.Windows.Forms.ToolStripMenuItem _ExportHexText;
            System.Windows.Forms.ToolStripMenuItem _ExportXml;
            System.Windows.Forms.ToolStripMenuItem _ExportUncompressedBinary;
            System.Windows.Forms.ToolStripMenuItem _ExportUncompressedHexText;
            System.Windows.Forms.ToolStripMenuItem _ExportToUnicode;
            this._Container = new System.Windows.Forms.SplitContainer();
            this._ObjectDetailBox = new BrightIdeasSoftware.TreeListView();
            this._NameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ValueColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._DescriptionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ObjectTypeIcons = new System.Windows.Forms.ImageList(this.components);
            this._DescriptionBox = new RichTextBoxLinks.RichTextBoxEx();
            this._RecentFileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._OpenButton = new System.Windows.Forms.ToolStripSplitButton();
            this._LoadDocumentWorker = new System.ComponentModel.BackgroundWorker();
            this._MainMenu = new System.Windows.Forms.ToolStrip();
            this._SaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._ExportButton = new System.Windows.Forms.ToolStripDropDownButton();
            this._ViewButton = new System.Windows.Forms.ToolStripButton();
            this._AddObjectMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this._AddArrayNode = new System.Windows.Forms.ToolStripMenuItem();
            this._AddDictNode = new System.Windows.Forms.ToolStripMenuItem();
            this._AddBooleanNode = new System.Windows.Forms.ToolStripMenuItem();
            this._AddStringNode = new System.Windows.Forms.ToolStripMenuItem();
            this._AddNumberNode = new System.Windows.Forms.ToolStripMenuItem();
            this._AddNameNode = new System.Windows.Forms.ToolStripMenuItem();
            this._DeleteButton = new System.Windows.Forms.ToolStripButton();
            this._ExpandButton = new System.Windows.Forms.ToolStripButton();
            this._CollapseButton = new System.Windows.Forms.ToolStripButton();
            _ExportBinary = new System.Windows.Forms.ToolStripMenuItem();
            _ExportHexText = new System.Windows.Forms.ToolStripMenuItem();
            _ExportXml = new System.Windows.Forms.ToolStripMenuItem();
            _ExportUncompressedBinary = new System.Windows.Forms.ToolStripMenuItem();
            _ExportUncompressedHexText = new System.Windows.Forms.ToolStripMenuItem();
            _ExportToUnicode = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._Container)).BeginInit();
            this._Container.Panel1.SuspendLayout();
            this._Container.Panel2.SuspendLayout();
            this._Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectDetailBox)).BeginInit();
            this._MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ExportBinary
            // 
            _ExportBinary.Name = "_ExportBinary";
            resources.ApplyResources(_ExportBinary, "_ExportBinary");
            // 
            // _ExportHexText
            // 
            _ExportHexText.Name = "_ExportHexText";
            resources.ApplyResources(_ExportHexText, "_ExportHexText");
            // 
            // _ExportXml
            // 
            _ExportXml.Name = "_ExportXml";
            resources.ApplyResources(_ExportXml, "_ExportXml");
            // 
            // _ExportUncompressedBinary
            // 
            _ExportUncompressedBinary.Name = "_ExportUncompressedBinary";
            resources.ApplyResources(_ExportUncompressedBinary, "_ExportUncompressedBinary");
            // 
            // _ExportUncompressedHexText
            // 
            _ExportUncompressedHexText.Name = "_ExportUncompressedHexText";
            resources.ApplyResources(_ExportUncompressedHexText, "_ExportUncompressedHexText");
            // 
            // _ExportToUnicode
            // 
            _ExportToUnicode.Name = "_ExportToUnicode";
            resources.ApplyResources(_ExportToUnicode, "_ExportToUnicode");
            // 
            // _Container
            // 
            resources.ApplyResources(this._Container, "_Container");
            this._Container.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._Container.Name = "_Container";
            // 
            // _Container.Panel1
            // 
            this._Container.Panel1.Controls.Add(this._ObjectDetailBox);
            // 
            // _Container.Panel2
            // 
            this._Container.Panel2.Controls.Add(this._DescriptionBox);
            // 
            // _ObjectDetailBox
            // 
            this._ObjectDetailBox.AllColumns.Add(this._NameColumn);
            this._ObjectDetailBox.AllColumns.Add(this._ValueColumn);
            this._ObjectDetailBox.AllColumns.Add(this._DescriptionColumn);
            resources.ApplyResources(this._ObjectDetailBox, "_ObjectDetailBox");
            this._ObjectDetailBox.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this._ObjectDetailBox.CellEditUseWholeCell = false;
            this._ObjectDetailBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._NameColumn,
            this._ValueColumn,
            this._DescriptionColumn});
            this._ObjectDetailBox.GridLines = true;
            this._ObjectDetailBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._ObjectDetailBox.HideSelection = false;
            this._ObjectDetailBox.Name = "_ObjectDetailBox";
            this._ObjectDetailBox.RevealAfterExpand = false;
            this._ObjectDetailBox.ShowGroups = false;
            this._ObjectDetailBox.SmallImageList = this._ObjectTypeIcons;
            this._ObjectDetailBox.UseCompatibleStateImageBehavior = false;
            this._ObjectDetailBox.View = System.Windows.Forms.View.Details;
            this._ObjectDetailBox.VirtualMode = true;
            this._ObjectDetailBox.ItemActivate += new System.EventHandler(this.ControlEvent);
            // 
            // _NameColumn
            // 
            this._NameColumn.IsEditable = false;
            resources.ApplyResources(this._NameColumn, "_NameColumn");
            // 
            // _ValueColumn
            // 
            resources.ApplyResources(this._ValueColumn, "_ValueColumn");
            // 
            // _DescriptionColumn
            // 
            this._DescriptionColumn.IsEditable = false;
            resources.ApplyResources(this._DescriptionColumn, "_DescriptionColumn");
            // 
            // _ObjectTypeIcons
            // 
            this._ObjectTypeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_ObjectTypeIcons.ImageStream")));
            this._ObjectTypeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this._ObjectTypeIcons.Images.SetKeyName(0, "Current");
            this._ObjectTypeIcons.Images.SetKeyName(1, "Page");
            this._ObjectTypeIcons.Images.SetKeyName(2, "Dictionary");
            this._ObjectTypeIcons.Images.SetKeyName(3, "Array");
            this._ObjectTypeIcons.Images.SetKeyName(4, "Name");
            this._ObjectTypeIcons.Images.SetKeyName(5, "String");
            this._ObjectTypeIcons.Images.SetKeyName(6, "Number");
            this._ObjectTypeIcons.Images.SetKeyName(7, "Stream");
            this._ObjectTypeIcons.Images.SetKeyName(8, "Bool");
            this._ObjectTypeIcons.Images.SetKeyName(9, "Reference");
            this._ObjectTypeIcons.Images.SetKeyName(10, "Document");
            this._ObjectTypeIcons.Images.SetKeyName(11, "Pages");
            this._ObjectTypeIcons.Images.SetKeyName(12, "PageCommands");
            this._ObjectTypeIcons.Images.SetKeyName(13, "Outlines");
            this._ObjectTypeIcons.Images.SetKeyName(14, "Outline");
            this._ObjectTypeIcons.Images.SetKeyName(15, "Trailer");
            this._ObjectTypeIcons.Images.SetKeyName(16, "GoToPage");
            this._ObjectTypeIcons.Images.SetKeyName(17, "Image");
            this._ObjectTypeIcons.Images.SetKeyName(18, "Info");
            this._ObjectTypeIcons.Images.SetKeyName(19, "Font");
            this._ObjectTypeIcons.Images.SetKeyName(20, "Resources");
            this._ObjectTypeIcons.Images.SetKeyName(21, "Null");
            this._ObjectTypeIcons.Images.SetKeyName(22, "Hidden");
            this._ObjectTypeIcons.Images.SetKeyName(23, "op_q");
            this._ObjectTypeIcons.Images.SetKeyName(24, "op_cm");
            this._ObjectTypeIcons.Images.SetKeyName(25, "op_tm");
            this._ObjectTypeIcons.Images.SetKeyName(26, "op_cs");
            this._ObjectTypeIcons.Images.SetKeyName(27, "op_sc");
            this._ObjectTypeIcons.Images.SetKeyName(28, "op_g");
            this._ObjectTypeIcons.Images.SetKeyName(29, "op_s");
            this._ObjectTypeIcons.Images.SetKeyName(30, "op_TJ");
            this._ObjectTypeIcons.Images.SetKeyName(31, "op_tj_");
            this._ObjectTypeIcons.Images.SetKeyName(32, "op_f");
            this._ObjectTypeIcons.Images.SetKeyName(33, "op_Ts");
            this._ObjectTypeIcons.Images.SetKeyName(34, "op_BT");
            this._ObjectTypeIcons.Images.SetKeyName(35, "op_Td");
            this._ObjectTypeIcons.Images.SetKeyName(36, "op_Tr");
            this._ObjectTypeIcons.Images.SetKeyName(37, "op_BDC");
            this._ObjectTypeIcons.Images.SetKeyName(38, "op_re");
            this._ObjectTypeIcons.Images.SetKeyName(39, "op_W*");
            this._ObjectTypeIcons.Images.SetKeyName(40, "op_c");
            this._ObjectTypeIcons.Images.SetKeyName(41, "op_l");
            this._ObjectTypeIcons.Images.SetKeyName(42, "op_tc");
            this._ObjectTypeIcons.Images.SetKeyName(43, "op_Tz");
            this._ObjectTypeIcons.Images.SetKeyName(44, "op_Tl");
            this._ObjectTypeIcons.Images.SetKeyName(45, "op_gs");
            this._ObjectTypeIcons.Images.SetKeyName(46, "op_w");
            this._ObjectTypeIcons.Images.SetKeyName(47, "op_M_");
            this._ObjectTypeIcons.Images.SetKeyName(48, "op_d");
            this._ObjectTypeIcons.Images.SetKeyName(49, "op_b");
            this._ObjectTypeIcons.Images.SetKeyName(50, "op_m");
            this._ObjectTypeIcons.Images.SetKeyName(51, "op_h");
            // 
            // _DescriptionBox
            // 
            resources.ApplyResources(this._DescriptionBox, "_DescriptionBox");
            this._DescriptionBox.Name = "_DescriptionBox";
            this._DescriptionBox.ReadOnly = true;
            // 
            // _RecentFileMenu
            // 
            this._RecentFileMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._RecentFileMenu.Name = "_RecentFileMenu";
            this._RecentFileMenu.OwnerItem = this._OpenButton;
            resources.ApplyResources(this._RecentFileMenu, "_RecentFileMenu");
            // 
            // _OpenButton
            // 
            this._OpenButton.DropDown = this._RecentFileMenu;
            this._OpenButton.Image = global::PDFPatcher.Properties.Resources.OpenFile;
            resources.ApplyResources(this._OpenButton, "_OpenButton");
            this._OpenButton.Name = "_OpenButton";
            this._OpenButton.ButtonClick += new System.EventHandler(this.ControlEvent);
            // 
            // _LoadDocumentWorker
            // 
            this._LoadDocumentWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._LoadDocumentWorker_DoWork);
            this._LoadDocumentWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._LoadDocumentWorker_RunWorkerCompleted);
            // 
            // _MainMenu
            // 
            this._MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._OpenButton,
            this._SaveButton,
            this.toolStripSeparator1,
            this._ExportButton,
            this._ViewButton,
            this._AddObjectMenu,
            this._DeleteButton,
            this._ExpandButton,
            this._CollapseButton});
            resources.ApplyResources(this._MainMenu, "_MainMenu");
            this._MainMenu.Name = "_MainMenu";
            this._MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolbarItemClicked);
            // 
            // _SaveButton
            // 
            resources.ApplyResources(this._SaveButton, "_SaveButton");
            this._SaveButton.Image = global::PDFPatcher.Properties.Resources.Save;
            this._SaveButton.Name = "_SaveButton";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // _ExportButton
            // 
            this._ExportButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _ExportBinary,
            _ExportHexText,
            _ExportXml,
            _ExportUncompressedBinary,
            _ExportUncompressedHexText,
            _ExportToUnicode});
            resources.ApplyResources(this._ExportButton, "_ExportButton");
            this._ExportButton.Image = global::PDFPatcher.Properties.Resources.ExportFile;
            this._ExportButton.Name = "_ExportButton";
            this._ExportButton.DropDownOpening += new System.EventHandler(this._ExportButton_DropDownOpening);
            this._ExportButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolbarItemClicked);
            // 
            // _ViewButton
            // 
            resources.ApplyResources(this._ViewButton, "_ViewButton");
            this._ViewButton.Image = global::PDFPatcher.Properties.Resources.ViewContent;
            this._ViewButton.Name = "_ViewButton";
            // 
            // _AddObjectMenu
            // 
            this._AddObjectMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._AddArrayNode,
            this._AddDictNode,
            this._AddBooleanNode,
            this._AddStringNode,
            this._AddNumberNode,
            this._AddNameNode});
            resources.ApplyResources(this._AddObjectMenu, "_AddObjectMenu");
            this._AddObjectMenu.Image = global::PDFPatcher.Properties.Resources.AddChildNode;
            this._AddObjectMenu.Name = "_AddObjectMenu";
            this._AddObjectMenu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._AddObjectMenu_DropDownItemClicked);
            // 
            // _AddArrayNode
            // 
            this._AddArrayNode.Name = "_AddArrayNode";
            resources.ApplyResources(this._AddArrayNode, "_AddArrayNode");
            // 
            // _AddDictNode
            // 
            this._AddDictNode.Name = "_AddDictNode";
            resources.ApplyResources(this._AddDictNode, "_AddDictNode");
            // 
            // _AddBooleanNode
            // 
            this._AddBooleanNode.Name = "_AddBooleanNode";
            resources.ApplyResources(this._AddBooleanNode, "_AddBooleanNode");
            // 
            // _AddStringNode
            // 
            this._AddStringNode.Name = "_AddStringNode";
            resources.ApplyResources(this._AddStringNode, "_AddStringNode");
            // 
            // _AddNumberNode
            // 
            this._AddNumberNode.Name = "_AddNumberNode";
            resources.ApplyResources(this._AddNumberNode, "_AddNumberNode");
            // 
            // _AddNameNode
            // 
            this._AddNameNode.Name = "_AddNameNode";
            resources.ApplyResources(this._AddNameNode, "_AddNameNode");
            // 
            // _DeleteButton
            // 
            this._DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._DeleteButton, "_DeleteButton");
            this._DeleteButton.Image = global::PDFPatcher.Properties.Resources.Delete;
            this._DeleteButton.Name = "_DeleteButton";
            // 
            // _ExpandButton
            // 
            this._ExpandButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._ExpandButton, "_ExpandButton");
            this._ExpandButton.Image = global::PDFPatcher.Properties.Resources.Expand;
            this._ExpandButton.Name = "_ExpandButton";
            // 
            // _CollapseButton
            // 
            this._CollapseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._CollapseButton, "_CollapseButton");
            this._CollapseButton.Image = global::PDFPatcher.Properties.Resources.Collapse;
            this._CollapseButton.Name = "_CollapseButton";
            // 
            // DocumentInspectorControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._MainMenu);
            this.Controls.Add(this._Container);
            this.Name = "DocumentInspectorControl";
            this.Load += new System.EventHandler(this.DocumentInspectorControl_OnLoad);
            this._Container.Panel1.ResumeLayout(false);
            this._Container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Container)).EndInit();
            this._Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ObjectDetailBox)).EndInit();
            this._MainMenu.ResumeLayout(false);
            this._MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer _Container;
		private BrightIdeasSoftware.TreeListView _ObjectDetailBox;
		private BrightIdeasSoftware.OLVColumn _NameColumn;
		private BrightIdeasSoftware.OLVColumn _ValueColumn;
		private RichTextBoxLinks.RichTextBoxEx _DescriptionBox;
		private System.Windows.Forms.ContextMenuStrip _RecentFileMenu;
		private System.Windows.Forms.ImageList _ObjectTypeIcons;
		private BrightIdeasSoftware.OLVColumn _DescriptionColumn;
		private System.ComponentModel.BackgroundWorker _LoadDocumentWorker;
		private System.Windows.Forms.ToolStripSplitButton _OpenButton;
		private System.Windows.Forms.ToolStrip _MainMenu;
		private System.Windows.Forms.ToolStripButton _SaveButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripDropDownButton _ExportButton;
		private System.Windows.Forms.ToolStripButton _ViewButton;
		private System.Windows.Forms.ToolStripButton _DeleteButton;
		private System.Windows.Forms.ToolStripButton _ExpandButton;
		private System.Windows.Forms.ToolStripButton _CollapseButton;
		private System.Windows.Forms.ToolStripDropDownButton _AddObjectMenu;
		private System.Windows.Forms.ToolStripMenuItem _AddNameNode;
		private System.Windows.Forms.ToolStripMenuItem _AddNumberNode;
		private System.Windows.Forms.ToolStripMenuItem _AddStringNode;
		private System.Windows.Forms.ToolStripMenuItem _AddBooleanNode;
		private System.Windows.Forms.ToolStripMenuItem _AddDictNode;
		private System.Windows.Forms.ToolStripMenuItem _AddArrayNode;
	}
}
