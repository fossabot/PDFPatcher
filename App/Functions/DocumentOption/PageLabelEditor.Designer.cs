namespace PDFPatcher.Functions
{
	partial class PageLabelEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageLabelEditor));
            this._PageLabelBox = new BrightIdeasSoftware.ObjectListView();
            this._SequenceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._PageNumColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._LabelStyleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._LabelPrefixColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._StartNumColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._RemovePageLabelButton = new System.Windows.Forms.Button();
            this._AddPageLabelButton = new System.Windows.Forms.Button();
            this._LabelStyleMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._PageLabelBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _PageLabelBox
            // 
            this._PageLabelBox.AllColumns.Add(this._SequenceColumn);
            this._PageLabelBox.AllColumns.Add(this._PageNumColumn);
            this._PageLabelBox.AllColumns.Add(this._LabelStyleColumn);
            this._PageLabelBox.AllColumns.Add(this._LabelPrefixColumn);
            this._PageLabelBox.AllColumns.Add(this._StartNumColumn);
            resources.ApplyResources(this._PageLabelBox, "_PageLabelBox");
            this._PageLabelBox.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this._PageLabelBox.CellEditUseWholeCell = false;
            this._PageLabelBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._SequenceColumn,
            this._PageNumColumn,
            this._LabelStyleColumn,
            this._LabelPrefixColumn,
            this._StartNumColumn});
            this._PageLabelBox.Cursor = System.Windows.Forms.Cursors.Default;
            this._PageLabelBox.GridLines = true;
            this._PageLabelBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._PageLabelBox.HideSelection = false;
            this._PageLabelBox.LabelEdit = true;
            this._PageLabelBox.Name = "_PageLabelBox";
            this._PageLabelBox.ShowGroups = false;
            this._PageLabelBox.UseCompatibleStateImageBehavior = false;
            this._PageLabelBox.View = System.Windows.Forms.View.Details;
            // 
            // _SequenceColumn
            // 
            this._SequenceColumn.IsEditable = false;
            resources.ApplyResources(this._SequenceColumn, "_SequenceColumn");
            // 
            // _PageNumColumn
            // 
            resources.ApplyResources(this._PageNumColumn, "_PageNumColumn");
            // 
            // _LabelStyleColumn
            // 
            this._LabelStyleColumn.IsEditable = false;
            resources.ApplyResources(this._LabelStyleColumn, "_LabelStyleColumn");
            // 
            // _LabelPrefixColumn
            // 
            resources.ApplyResources(this._LabelPrefixColumn, "_LabelPrefixColumn");
            // 
            // _StartNumColumn
            // 
            resources.ApplyResources(this._StartNumColumn, "_StartNumColumn");
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
            // _LabelStyleMenu
            // 
            this._LabelStyleMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._LabelStyleMenu.Name = "_LabelStyleMenu";
            resources.ApplyResources(this._LabelStyleMenu, "_LabelStyleMenu");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._PageLabelBox);
            this.panel1.Controls.Add(this._RemovePageLabelButton);
            this.panel1.Controls.Add(this._AddPageLabelButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // PageLabelEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PageLabelEditor";
            ((System.ComponentModel.ISupportInitialize)(this._PageLabelBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _RemovePageLabelButton;
		private System.Windows.Forms.Button _AddPageLabelButton;
		private BrightIdeasSoftware.ObjectListView _PageLabelBox;
		private BrightIdeasSoftware.OLVColumn _PageNumColumn;
		private BrightIdeasSoftware.OLVColumn _LabelStyleColumn;
		private BrightIdeasSoftware.OLVColumn _LabelPrefixColumn;
		private BrightIdeasSoftware.OLVColumn _StartNumColumn;
		private BrightIdeasSoftware.OLVColumn _SequenceColumn;
		private System.Windows.Forms.ContextMenuStrip _LabelStyleMenu;
		private System.Windows.Forms.Panel panel1;
	}
}
