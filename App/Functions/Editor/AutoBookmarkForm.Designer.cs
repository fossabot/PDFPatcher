namespace PDFPatcher.Functions
{
	partial class AutoBookmarkForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoBookmarkForm));
            this.label1 = new System.Windows.Forms.Label();
            this._BookmarkConditionBox = new BrightIdeasSoftware.ObjectListView();
            this._ConditionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._LevelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._BoldColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ItalicColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ColorColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._OpenColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._RemoveButton = new System.Windows.Forms.Button();
            this._AutoBookmarkButton = new System.Windows.Forms.Button();
            this._MergeAdjacentTitleBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._BookmarkConditionBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _BookmarkConditionBox
            // 
            this._BookmarkConditionBox.AllColumns.Add(this._ConditionColumn);
            this._BookmarkConditionBox.AllColumns.Add(this._LevelColumn);
            this._BookmarkConditionBox.AllColumns.Add(this._BoldColumn);
            this._BookmarkConditionBox.AllColumns.Add(this._ItalicColumn);
            this._BookmarkConditionBox.AllColumns.Add(this._ColorColumn);
            this._BookmarkConditionBox.AllColumns.Add(this._OpenColumn);
            resources.ApplyResources(this._BookmarkConditionBox, "_BookmarkConditionBox");
            this._BookmarkConditionBox.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this._BookmarkConditionBox.CellEditUseWholeCell = false;
            this._BookmarkConditionBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._ConditionColumn,
            this._LevelColumn,
            this._BoldColumn,
            this._ItalicColumn,
            this._ColorColumn,
            this._OpenColumn});
            this._BookmarkConditionBox.Cursor = System.Windows.Forms.Cursors.Default;
            this._BookmarkConditionBox.GridLines = true;
            this._BookmarkConditionBox.HideSelection = false;
            this._BookmarkConditionBox.Name = "_BookmarkConditionBox";
            this._BookmarkConditionBox.ShowGroups = false;
            this._BookmarkConditionBox.UseCompatibleStateImageBehavior = false;
            this._BookmarkConditionBox.View = System.Windows.Forms.View.Details;
            // 
            // _ConditionColumn
            // 
            this._ConditionColumn.IsEditable = false;
            resources.ApplyResources(this._ConditionColumn, "_ConditionColumn");
            // 
            // _LevelColumn
            // 
            this._LevelColumn.MinimumWidth = 80;
            resources.ApplyResources(this._LevelColumn, "_LevelColumn");
            // 
            // _BoldColumn
            // 
            this._BoldColumn.CheckBoxes = true;
            resources.ApplyResources(this._BoldColumn, "_BoldColumn");
            // 
            // _ItalicColumn
            // 
            this._ItalicColumn.CheckBoxes = true;
            resources.ApplyResources(this._ItalicColumn, "_ItalicColumn");
            // 
            // _ColorColumn
            // 
            this._ColorColumn.IsEditable = false;
            resources.ApplyResources(this._ColorColumn, "_ColorColumn");
            // 
            // _OpenColumn
            // 
            this._OpenColumn.CheckBoxes = true;
            resources.ApplyResources(this._OpenColumn, "_OpenColumn");
            // 
            // _RemoveButton
            // 
            resources.ApplyResources(this._RemoveButton, "_RemoveButton");
            this._RemoveButton.Image = global::PDFPatcher.Properties.Resources.Delete;
            this._RemoveButton.Name = "_RemoveButton";
            this._RemoveButton.UseVisualStyleBackColor = true;
            this._RemoveButton.Click += new System.EventHandler(this._RemoveButton_Click);
            // 
            // _AutoBookmarkButton
            // 
            resources.ApplyResources(this._AutoBookmarkButton, "_AutoBookmarkButton");
            this._AutoBookmarkButton.Image = global::PDFPatcher.Properties.Resources.AutoBookmark;
            this._AutoBookmarkButton.Name = "_AutoBookmarkButton";
            this._AutoBookmarkButton.UseVisualStyleBackColor = true;
            this._AutoBookmarkButton.Click += new System.EventHandler(this._AutoBookmarkButton_Click);
            // 
            // _MergeAdjacentTitleBox
            // 
            resources.ApplyResources(this._MergeAdjacentTitleBox, "_MergeAdjacentTitleBox");
            this._MergeAdjacentTitleBox.Checked = true;
            this._MergeAdjacentTitleBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._MergeAdjacentTitleBox.Name = "_MergeAdjacentTitleBox";
            this._MergeAdjacentTitleBox.UseVisualStyleBackColor = true;
            // 
            // AutoBookmarkForm
            // 
            this.AcceptButton = this._AutoBookmarkButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._MergeAdjacentTitleBox);
            this.Controls.Add(this._AutoBookmarkButton);
            this.Controls.Add(this._RemoveButton);
            this.Controls.Add(this._BookmarkConditionBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoBookmarkForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.AutoBookmarkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._BookmarkConditionBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private BrightIdeasSoftware.ObjectListView _BookmarkConditionBox;
		private BrightIdeasSoftware.OLVColumn _ConditionColumn;
		private System.Windows.Forms.Button _RemoveButton;
		private System.Windows.Forms.Button _AutoBookmarkButton;
		private BrightIdeasSoftware.OLVColumn _LevelColumn;
		private BrightIdeasSoftware.OLVColumn _BoldColumn;
		private BrightIdeasSoftware.OLVColumn _ItalicColumn;
		private BrightIdeasSoftware.OLVColumn _ColorColumn;
		private BrightIdeasSoftware.OLVColumn _OpenColumn;
		private System.Windows.Forms.CheckBox _MergeAdjacentTitleBox;
	}
}
