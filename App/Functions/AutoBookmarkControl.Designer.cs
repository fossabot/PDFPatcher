namespace PDFPatcher.Functions
{
	partial class AutoBookmarkControl
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
            System.Windows.Forms.ToolStripDropDownButton _AddAdjustmentButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoBookmarkControl));
            this._AddFilterMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._TitleSizeThresholdBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._PageRangeBox = new System.Windows.Forms.TextBox();
            this._MergeAdjacentTitlesBox = new System.Windows.Forms.CheckBox();
            this._MergeDifferentSizeTitlesBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._FirstLineAsTitleBox = new System.Windows.Forms.CheckBox();
            this._IgnoreOverlappedTextBox = new System.Windows.Forms.CheckBox();
            this._CreateBookmarkForFirstPageBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._WritingDirectionBox = new System.Windows.Forms.ComboBox();
            this._AutoHierarchicleArrangementBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this._MaxDistanceBetweenLinesBox = new System.Windows.Forms.NumericUpDown();
            this._GoToPageTopLevelBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._YOffsetBox = new System.Windows.Forms.NumericUpDown();
            this._MergeDifferentFontTitlesBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._IgnoreNumericTitleBox = new System.Windows.Forms.CheckBox();
            this._IgnoreSingleCharacterTitleBox = new System.Windows.Forms.CheckBox();
            this._ClearTextFiltersButton = new System.Windows.Forms.Button();
            this._IgnorePatternsBox = new System.Windows.Forms.DataGridView();
            this._PatternColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._MatchCaseColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._FullMatchColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._PatternTypeColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._RemovePatternColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this._AddFilterFromInfoFileButton = new System.Windows.Forms.ToolStripButton();
            this._DeleteAdjustmentButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._CopyFilterButton = new System.Windows.Forms.ToolStripButton();
            this._PasteButton = new System.Windows.Forms.ToolStripButton();
            this._LevelAdjustmentBox = new BrightIdeasSoftware.ObjectListView();
            this._AdvancedFilterColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._AdjustmentLevelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._RelativeAdjustmentColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._FilterBeforeMergeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this._ExportTextCoordinateBox = new System.Windows.Forms.CheckBox();
            this._ShowAllFontsBox = new System.Windows.Forms.CheckBox();
            this._DisplayFontStatisticsBox = new System.Windows.Forms.CheckBox();
            this._BookmarkControl = new PDFPatcher.BookmarkControl();
            this._SourceFileControl = new PDFPatcher.SourceFileControl();
            this._ExportBookmarkButton = new EnhancedGlassButton.GlassButton();
            _AddAdjustmentButton = new System.Windows.Forms.ToolStripDropDownButton();
            ((System.ComponentModel.ISupportInitialize)(this._TitleSizeThresholdBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._MaxDistanceBetweenLinesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GoToPageTopLevelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._YOffsetBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._IgnorePatternsBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._LevelAdjustmentBox)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // _AddAdjustmentButton
            // 
            _AddAdjustmentButton.DropDown = this._AddFilterMenu;
            _AddAdjustmentButton.Image = global::PDFPatcher.Properties.Resources.Add;
            resources.ApplyResources(_AddAdjustmentButton, "_AddAdjustmentButton");
            _AddAdjustmentButton.Name = "_AddAdjustmentButton";
            // 
            // _AddFilterMenu
            // 
            this._AddFilterMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._AddFilterMenu.Name = "_AddFilterMenu";
            this._AddFilterMenu.OwnerItem = _AddAdjustmentButton;
            resources.ApplyResources(this._AddFilterMenu, "_AddFilterMenu");
            this._AddFilterMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._AddFilterMenu_ItemClicked);
            // 
            // _TitleSizeThresholdBox
            // 
            this._TitleSizeThresholdBox.DecimalPlaces = 2;
            resources.ApplyResources(this._TitleSizeThresholdBox, "_TitleSizeThresholdBox");
            this._TitleSizeThresholdBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this._TitleSizeThresholdBox.Name = "_TitleSizeThresholdBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _PageRangeBox
            // 
            resources.ApplyResources(this._PageRangeBox, "_PageRangeBox");
            this._PageRangeBox.Name = "_PageRangeBox";
            // 
            // _MergeAdjacentTitlesBox
            // 
            resources.ApplyResources(this._MergeAdjacentTitlesBox, "_MergeAdjacentTitlesBox");
            this._MergeAdjacentTitlesBox.Name = "_MergeAdjacentTitlesBox";
            this._MergeAdjacentTitlesBox.UseVisualStyleBackColor = true;
            // 
            // _MergeDifferentSizeTitlesBox
            // 
            resources.ApplyResources(this._MergeDifferentSizeTitlesBox, "_MergeDifferentSizeTitlesBox");
            this._MergeDifferentSizeTitlesBox.Name = "_MergeDifferentSizeTitlesBox";
            this._MergeDifferentSizeTitlesBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._FirstLineAsTitleBox);
            this.tabPage1.Controls.Add(this._IgnoreOverlappedTextBox);
            this.tabPage1.Controls.Add(this._CreateBookmarkForFirstPageBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this._WritingDirectionBox);
            this.tabPage1.Controls.Add(this._AutoHierarchicleArrangementBox);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this._MaxDistanceBetweenLinesBox);
            this.tabPage1.Controls.Add(this._GoToPageTopLevelBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this._YOffsetBox);
            this.tabPage1.Controls.Add(this._MergeDifferentFontTitlesBox);
            this.tabPage1.Controls.Add(this._MergeDifferentSizeTitlesBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this._TitleSizeThresholdBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this._MergeAdjacentTitlesBox);
            this.tabPage1.Controls.Add(this._PageRangeBox);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _FirstLineAsTitleBox
            // 
            resources.ApplyResources(this._FirstLineAsTitleBox, "_FirstLineAsTitleBox");
            this._FirstLineAsTitleBox.Name = "_FirstLineAsTitleBox";
            this._FirstLineAsTitleBox.UseVisualStyleBackColor = true;
            // 
            // _IgnoreOverlappedTextBox
            // 
            resources.ApplyResources(this._IgnoreOverlappedTextBox, "_IgnoreOverlappedTextBox");
            this._IgnoreOverlappedTextBox.Name = "_IgnoreOverlappedTextBox";
            this._IgnoreOverlappedTextBox.UseVisualStyleBackColor = true;
            // 
            // _CreateBookmarkForFirstPageBox
            // 
            resources.ApplyResources(this._CreateBookmarkForFirstPageBox, "_CreateBookmarkForFirstPageBox");
            this._CreateBookmarkForFirstPageBox.Name = "_CreateBookmarkForFirstPageBox";
            this._CreateBookmarkForFirstPageBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _WritingDirectionBox
            // 
            this._WritingDirectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._WritingDirectionBox.FormattingEnabled = true;
            this._WritingDirectionBox.Items.AddRange(new object[] {
            resources.GetString("_WritingDirectionBox.Items"),
            resources.GetString("_WritingDirectionBox.Items1"),
            resources.GetString("_WritingDirectionBox.Items2")});
            resources.ApplyResources(this._WritingDirectionBox, "_WritingDirectionBox");
            this._WritingDirectionBox.Name = "_WritingDirectionBox";
            // 
            // _AutoHierarchicleArrangementBox
            // 
            resources.ApplyResources(this._AutoHierarchicleArrangementBox, "_AutoHierarchicleArrangementBox");
            this._AutoHierarchicleArrangementBox.Name = "_AutoHierarchicleArrangementBox";
            this._AutoHierarchicleArrangementBox.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // _MaxDistanceBetweenLinesBox
            // 
            this._MaxDistanceBetweenLinesBox.DecimalPlaces = 2;
            resources.ApplyResources(this._MaxDistanceBetweenLinesBox, "_MaxDistanceBetweenLinesBox");
            this._MaxDistanceBetweenLinesBox.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._MaxDistanceBetweenLinesBox.Name = "_MaxDistanceBetweenLinesBox";
            // 
            // _GoToPageTopLevelBox
            // 
            resources.ApplyResources(this._GoToPageTopLevelBox, "_GoToPageTopLevelBox");
            this._GoToPageTopLevelBox.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._GoToPageTopLevelBox.Name = "_GoToPageTopLevelBox";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // _YOffsetBox
            // 
            this._YOffsetBox.DecimalPlaces = 2;
            this._YOffsetBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this._YOffsetBox, "_YOffsetBox");
            this._YOffsetBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._YOffsetBox.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this._YOffsetBox.Name = "_YOffsetBox";
            // 
            // _MergeDifferentFontTitlesBox
            // 
            resources.ApplyResources(this._MergeDifferentFontTitlesBox, "_MergeDifferentFontTitlesBox");
            this._MergeDifferentFontTitlesBox.Name = "_MergeDifferentFontTitlesBox";
            this._MergeDifferentFontTitlesBox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._IgnoreNumericTitleBox);
            this.tabPage2.Controls.Add(this._IgnoreSingleCharacterTitleBox);
            this.tabPage2.Controls.Add(this._ClearTextFiltersButton);
            this.tabPage2.Controls.Add(this._IgnorePatternsBox);
            this.tabPage2.Controls.Add(this.label10);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _IgnoreNumericTitleBox
            // 
            resources.ApplyResources(this._IgnoreNumericTitleBox, "_IgnoreNumericTitleBox");
            this._IgnoreNumericTitleBox.Name = "_IgnoreNumericTitleBox";
            this._IgnoreNumericTitleBox.UseVisualStyleBackColor = true;
            // 
            // _IgnoreSingleCharacterTitleBox
            // 
            resources.ApplyResources(this._IgnoreSingleCharacterTitleBox, "_IgnoreSingleCharacterTitleBox");
            this._IgnoreSingleCharacterTitleBox.Name = "_IgnoreSingleCharacterTitleBox";
            this._IgnoreSingleCharacterTitleBox.UseVisualStyleBackColor = true;
            // 
            // _ClearTextFiltersButton
            // 
            resources.ApplyResources(this._ClearTextFiltersButton, "_ClearTextFiltersButton");
            this._ClearTextFiltersButton.Image = global::PDFPatcher.Properties.Resources.Delete;
            this._ClearTextFiltersButton.Name = "_ClearTextFiltersButton";
            this._ClearTextFiltersButton.UseVisualStyleBackColor = true;
            this._ClearTextFiltersButton.Click += new System.EventHandler(this.ControlEvent);
            // 
            // _IgnorePatternsBox
            // 
            this._IgnorePatternsBox.AllowUserToResizeRows = false;
            resources.ApplyResources(this._IgnorePatternsBox, "_IgnorePatternsBox");
            this._IgnorePatternsBox.BackgroundColor = System.Drawing.SystemColors.Window;
            this._IgnorePatternsBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._IgnorePatternsBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._PatternColumn,
            this._MatchCaseColumn,
            this._FullMatchColumn,
            this._PatternTypeColumn,
            this._RemovePatternColumn});
            this._IgnorePatternsBox.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this._IgnorePatternsBox.Name = "_IgnorePatternsBox";
            this._IgnorePatternsBox.RowHeadersVisible = false;
            this._IgnorePatternsBox.RowTemplate.Height = 23;
            this._IgnorePatternsBox.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._IgnorePatternsBox_CellContentClick);
            // 
            // _PatternColumn
            // 
            this._PatternColumn.Frozen = true;
            resources.ApplyResources(this._PatternColumn, "_PatternColumn");
            this._PatternColumn.Name = "_PatternColumn";
            // 
            // _MatchCaseColumn
            // 
            resources.ApplyResources(this._MatchCaseColumn, "_MatchCaseColumn");
            this._MatchCaseColumn.Name = "_MatchCaseColumn";
            // 
            // _FullMatchColumn
            // 
            resources.ApplyResources(this._FullMatchColumn, "_FullMatchColumn");
            this._FullMatchColumn.Name = "_FullMatchColumn";
            // 
            // _PatternTypeColumn
            // 
            resources.ApplyResources(this._PatternTypeColumn, "_PatternTypeColumn");
            this._PatternTypeColumn.Name = "_PatternTypeColumn";
            // 
            // _RemovePatternColumn
            // 
            resources.ApplyResources(this._RemovePatternColumn, "_RemovePatternColumn");
            this._RemovePatternColumn.Name = "_RemovePatternColumn";
            this._RemovePatternColumn.Text = "Remove";
            this._RemovePatternColumn.UseColumnTextForLinkValue = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.toolStrip1);
            this.tabPage3.Controls.Add(this._LevelAdjustmentBox);
            this.tabPage3.Controls.Add(this.label12);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            _AddAdjustmentButton,
            this._AddFilterFromInfoFileButton,
            this._DeleteAdjustmentButton,
            this.toolStripSeparator1,
            this._CopyFilterButton,
            this._PasteButton});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // _AddFilterFromInfoFileButton
            // 
            this._AddFilterFromInfoFileButton.Image = global::PDFPatcher.Properties.Resources.BookmarkFile;
            resources.ApplyResources(this._AddFilterFromInfoFileButton, "_AddFilterFromInfoFileButton");
            this._AddFilterFromInfoFileButton.Name = "_AddFilterFromInfoFileButton";
            this._AddFilterFromInfoFileButton.Click += new System.EventHandler(this.ControlEvent);
            // 
            // _DeleteAdjustmentButton
            // 
            this._DeleteAdjustmentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._DeleteAdjustmentButton.Image = global::PDFPatcher.Properties.Resources.Delete;
            resources.ApplyResources(this._DeleteAdjustmentButton, "_DeleteAdjustmentButton");
            this._DeleteAdjustmentButton.Name = "_DeleteAdjustmentButton";
            this._DeleteAdjustmentButton.Click += new System.EventHandler(this.ControlEvent);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // _CopyFilterButton
            // 
            this._CopyFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._CopyFilterButton.Image = global::PDFPatcher.Properties.Resources.Copy;
            resources.ApplyResources(this._CopyFilterButton, "_CopyFilterButton");
            this._CopyFilterButton.Name = "_CopyFilterButton";
            this._CopyFilterButton.Click += new System.EventHandler(this.ControlEvent);
            // 
            // _PasteButton
            // 
            this._PasteButton.Image = global::PDFPatcher.Properties.Resources.Paste;
            resources.ApplyResources(this._PasteButton, "_PasteButton");
            this._PasteButton.Name = "_PasteButton";
            this._PasteButton.Click += new System.EventHandler(this.ControlEvent);
            // 
            // _LevelAdjustmentBox
            // 
            this._LevelAdjustmentBox.AllColumns.Add(this._AdvancedFilterColumn);
            this._LevelAdjustmentBox.AllColumns.Add(this._AdjustmentLevelColumn);
            this._LevelAdjustmentBox.AllColumns.Add(this._RelativeAdjustmentColumn);
            this._LevelAdjustmentBox.AllColumns.Add(this._FilterBeforeMergeColumn);
            resources.ApplyResources(this._LevelAdjustmentBox, "_LevelAdjustmentBox");
            this._LevelAdjustmentBox.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this._LevelAdjustmentBox.CellEditUseWholeCell = false;
            this._LevelAdjustmentBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._AdvancedFilterColumn,
            this._AdjustmentLevelColumn,
            this._RelativeAdjustmentColumn,
            this._FilterBeforeMergeColumn});
            this._LevelAdjustmentBox.Cursor = System.Windows.Forms.Cursors.Default;
            this._LevelAdjustmentBox.GridLines = true;
            this._LevelAdjustmentBox.HideSelection = false;
            this._LevelAdjustmentBox.IsSimpleDragSource = true;
            this._LevelAdjustmentBox.IsSimpleDropSink = true;
            this._LevelAdjustmentBox.Name = "_LevelAdjustmentBox";
            this._LevelAdjustmentBox.ShowGroups = false;
            this._LevelAdjustmentBox.UseCompatibleStateImageBehavior = false;
            this._LevelAdjustmentBox.View = System.Windows.Forms.View.Details;
            this._LevelAdjustmentBox.ItemActivate += new System.EventHandler(this._LevelAdjustmentBox_ItemActivate);
            // 
            // _AdvancedFilterColumn
            // 
            this._AdvancedFilterColumn.IsEditable = false;
            resources.ApplyResources(this._AdvancedFilterColumn, "_AdvancedFilterColumn");
            // 
            // _AdjustmentLevelColumn
            // 
            this._AdjustmentLevelColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this._AdjustmentLevelColumn, "_AdjustmentLevelColumn");
            // 
            // _RelativeAdjustmentColumn
            // 
            this._RelativeAdjustmentColumn.CheckBoxes = true;
            this._RelativeAdjustmentColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this._RelativeAdjustmentColumn, "_RelativeAdjustmentColumn");
            // 
            // _FilterBeforeMergeColumn
            // 
            this._FilterBeforeMergeColumn.CheckBoxes = true;
            resources.ApplyResources(this._FilterBeforeMergeColumn, "_FilterBeforeMergeColumn");
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this._ExportTextCoordinateBox);
            this.tabPage5.Controls.Add(this._ShowAllFontsBox);
            this.tabPage5.Controls.Add(this._DisplayFontStatisticsBox);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // _ExportTextCoordinateBox
            // 
            resources.ApplyResources(this._ExportTextCoordinateBox, "_ExportTextCoordinateBox");
            this._ExportTextCoordinateBox.Name = "_ExportTextCoordinateBox";
            this._ExportTextCoordinateBox.UseVisualStyleBackColor = true;
            // 
            // _ShowAllFontsBox
            // 
            resources.ApplyResources(this._ShowAllFontsBox, "_ShowAllFontsBox");
            this._ShowAllFontsBox.Name = "_ShowAllFontsBox";
            this._ShowAllFontsBox.UseVisualStyleBackColor = true;
            // 
            // _DisplayFontStatisticsBox
            // 
            resources.ApplyResources(this._DisplayFontStatisticsBox, "_DisplayFontStatisticsBox");
            this._DisplayFontStatisticsBox.Checked = true;
            this._DisplayFontStatisticsBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._DisplayFontStatisticsBox.Name = "_DisplayFontStatisticsBox";
            this._DisplayFontStatisticsBox.UseVisualStyleBackColor = true;
            // 
            // _BookmarkControl
            // 
            resources.ApplyResources(this._BookmarkControl, "_BookmarkControl");
            this._BookmarkControl.LabelText = "P&DF info file:";
            this._BookmarkControl.Name = "_BookmarkControl";
            this._BookmarkControl.UseForBookmarkExport = true;
            // 
            // _SourceFileControl
            // 
            resources.ApplyResources(this._SourceFileControl, "_SourceFileControl");
            this._SourceFileControl.Name = "_SourceFileControl";
            // 
            // _ExportBookmarkButton
            // 
            this._ExportBookmarkButton.AlternativeFocusBorderColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this._ExportBookmarkButton, "_ExportBookmarkButton");
            this._ExportBookmarkButton.AnimateGlow = true;
            this._ExportBookmarkButton.BackColor = System.Drawing.SystemColors.Highlight;
            this._ExportBookmarkButton.CornerRadius = 3;
            this._ExportBookmarkButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ExportBookmarkButton.GlowColor = System.Drawing.Color.White;
            this._ExportBookmarkButton.Image = global::PDFPatcher.Properties.Resources.Save;
            this._ExportBookmarkButton.InnerBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this._ExportBookmarkButton.Name = "_ExportBookmarkButton";
            this._ExportBookmarkButton.OuterBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this._ExportBookmarkButton.ShowFocusBorder = true;
            this._ExportBookmarkButton.Click += new System.EventHandler(this._ExportBookmarkButton_Click);
            // 
            // AutoBookmarkControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ExportBookmarkButton);
            this.Controls.Add(this._SourceFileControl);
            this.Controls.Add(this._BookmarkControl);
            this.Controls.Add(this.tabControl1);
            this.Name = "AutoBookmarkControl";
            ((System.ComponentModel.ISupportInitialize)(this._TitleSizeThresholdBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._MaxDistanceBetweenLinesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GoToPageTopLevelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._YOffsetBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._IgnorePatternsBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._LevelAdjustmentBox)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private SourceFileControl _SourceFileControl;
		private BookmarkControl _BookmarkControl;
		private System.Windows.Forms.NumericUpDown _TitleSizeThresholdBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _PageRangeBox;
		private System.Windows.Forms.CheckBox _MergeAdjacentTitlesBox;
		private System.Windows.Forms.CheckBox _MergeDifferentSizeTitlesBox;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown _GoToPageTopLevelBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown _YOffsetBox;
		private System.Windows.Forms.DataGridView _IgnorePatternsBox;
		private System.Windows.Forms.DataGridViewTextBoxColumn _PatternColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn _MatchCaseColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn _FullMatchColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn _PatternTypeColumn;
		private System.Windows.Forms.DataGridViewLinkColumn _RemovePatternColumn;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button _ClearTextFiltersButton;
		private System.Windows.Forms.CheckBox _AutoHierarchicleArrangementBox;
		private BrightIdeasSoftware.ObjectListView _LevelAdjustmentBox;
		private BrightIdeasSoftware.OLVColumn _AdvancedFilterColumn;
		private BrightIdeasSoftware.OLVColumn _AdjustmentLevelColumn;
		private BrightIdeasSoftware.OLVColumn _RelativeAdjustmentColumn;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox _WritingDirectionBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.CheckBox _ShowAllFontsBox;
		private System.Windows.Forms.CheckBox _DisplayFontStatisticsBox;
		private System.Windows.Forms.NumericUpDown _MaxDistanceBetweenLinesBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox _ExportTextCoordinateBox;
		private System.Windows.Forms.ContextMenuStrip _AddFilterMenu;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton _DeleteAdjustmentButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton _CopyFilterButton;
		private System.Windows.Forms.ToolStripButton _PasteButton;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripButton _AddFilterFromInfoFileButton;
		private System.Windows.Forms.CheckBox _CreateBookmarkForFirstPageBox;
		private System.Windows.Forms.CheckBox _MergeDifferentFontTitlesBox;
		private System.Windows.Forms.CheckBox _IgnoreOverlappedTextBox;
		private System.Windows.Forms.CheckBox _IgnoreNumericTitleBox;
		private System.Windows.Forms.CheckBox _IgnoreSingleCharacterTitleBox;
		private BrightIdeasSoftware.OLVColumn _FilterBeforeMergeColumn;
		private EnhancedGlassButton.GlassButton _ExportBookmarkButton;
        private System.Windows.Forms.CheckBox _FirstLineAsTitleBox;

	}
}
