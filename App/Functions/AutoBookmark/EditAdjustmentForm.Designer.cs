namespace PDFPatcher.Functions
{
	partial class EditAdjustmentForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean all the resources being used.
		/// </summary>
		/// <param name="disposing">If you should release the managed resource, for true; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region WINDOWS Form Designer Generated Code

		/// <summary>
		/// Designer supports the required method - do not
		/// Use the code editor to modify the contents of this method.
		/// </summary>
		private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAdjustmentForm));
            this._AddFilterMenuItem = new System.Windows.Forms.ToolStripDropDownButton();
            this._OkButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this._FilterBox = new BrightIdeasSoftware.ObjectListView();
            this._TypeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ConditionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._IsInclusiveColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._RemoveButton = new System.Windows.Forms.ToolStripButton();
            this._EditFilterBox = new System.Windows.Forms.GroupBox();
            this._EditFilterPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._FilterBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this._EditFilterBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _AddFilterMenuItem
            // 
            this._AddFilterMenuItem.Image = global::PDFPatcher.Properties.Resources.Add;
            resources.ApplyResources(this._AddFilterMenuItem, "_AddFilterMenuItem");
            this._AddFilterMenuItem.Name = "_AddFilterMenuItem";
            this._AddFilterMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._AddFilterMenuItem_DropDownItemClicked);
            // 
            // _OkButton
            // 
            resources.ApplyResources(this._OkButton, "_OkButton");
            this._OkButton.Name = "_OkButton";
            this._OkButton.UseVisualStyleBackColor = true;
            this._OkButton.Click += new System.EventHandler(this._OkButton_Click);
            // 
            // _CancelButton
            // 
            resources.ApplyResources(this._CancelButton, "_CancelButton");
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // _FilterBox
            // 
            this._FilterBox.AllColumns.Add(this._TypeColumn);
            this._FilterBox.AllColumns.Add(this._ConditionColumn);
            this._FilterBox.AllColumns.Add(this._IsInclusiveColumn);
            resources.ApplyResources(this._FilterBox, "_FilterBox");
            this._FilterBox.CellEditUseWholeCell = false;
            this._FilterBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._TypeColumn,
            this._ConditionColumn,
            this._IsInclusiveColumn});
            this._FilterBox.Cursor = System.Windows.Forms.Cursors.Default;
            this._FilterBox.FullRowSelect = true;
            this._FilterBox.GridLines = true;
            this._FilterBox.HideSelection = false;
            this._FilterBox.IsSimpleDragSource = true;
            this._FilterBox.IsSimpleDropSink = true;
            this._FilterBox.MultiSelect = false;
            this._FilterBox.Name = "_FilterBox";
            this._FilterBox.ShowGroups = false;
            this._FilterBox.UseCompatibleStateImageBehavior = false;
            this._FilterBox.View = System.Windows.Forms.View.Details;
            this._FilterBox.SelectedIndexChanged += new System.EventHandler(this._FilterBox_SelectedIndexChanged);
            // 
            // _TypeColumn
            // 
            this._TypeColumn.IsEditable = false;
            resources.ApplyResources(this._TypeColumn, "_TypeColumn");
            // 
            // _ConditionColumn
            // 
            this._ConditionColumn.FillsFreeSpace = true;
            resources.ApplyResources(this._ConditionColumn, "_ConditionColumn");
            // 
            // _IsInclusiveColumn
            // 
            this._IsInclusiveColumn.IsEditable = false;
            resources.ApplyResources(this._IsInclusiveColumn, "_IsInclusiveColumn");
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._AddFilterMenuItem,
            this._RemoveButton});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // _RemoveButton
            // 
            this._RemoveButton.Image = global::PDFPatcher.Properties.Resources.Delete;
            resources.ApplyResources(this._RemoveButton, "_RemoveButton");
            this._RemoveButton.Name = "_RemoveButton";
            this._RemoveButton.Click += new System.EventHandler(this._RemoveButton_Click);
            // 
            // _EditFilterBox
            // 
            resources.ApplyResources(this._EditFilterBox, "_EditFilterBox");
            this._EditFilterBox.Controls.Add(this._EditFilterPanel);
            this._EditFilterBox.Name = "_EditFilterBox";
            this._EditFilterBox.TabStop = false;
            // 
            // _EditFilterPanel
            // 
            resources.ApplyResources(this._EditFilterPanel, "_EditFilterPanel");
            this._EditFilterPanel.Name = "_EditFilterPanel";
            // 
            // EditAdjustmentForm
            // 
            this.AcceptButton = this._OkButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._CancelButton;
            this.ControlBox = false;
            this.Controls.Add(this._EditFilterBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this._FilterBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OkButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditAdjustmentForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.EditAdjustmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._FilterBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this._EditFilterBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _OkButton;
		private System.Windows.Forms.Button _CancelButton;
		private BrightIdeasSoftware.ObjectListView _FilterBox;
		private BrightIdeasSoftware.OLVColumn _ConditionColumn;
		private BrightIdeasSoftware.OLVColumn _TypeColumn;
		private BrightIdeasSoftware.OLVColumn _IsInclusiveColumn;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton _RemoveButton;
		private System.Windows.Forms.GroupBox _EditFilterBox;
		private System.Windows.Forms.Panel _EditFilterPanel;
		private System.Windows.Forms.ToolStripDropDownButton _AddFilterMenuItem;
	}
}

