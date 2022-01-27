namespace PDFPatcher.Functions
{
	partial class CustomizeToolbarForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeToolbarForm));
            this._ItemListBox = new BrightIdeasSoftware.ObjectListView();
            this._NameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._VisibleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ShowTextColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._DisplayTextColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ButtonImageList = new System.Windows.Forms.ImageList(this.components);
            this._OkButton = new System.Windows.Forms.Button();
            this._ResetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._ItemListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _ItemListBox
            // 
            this._ItemListBox.AllColumns.Add(this._NameColumn);
            this._ItemListBox.AllColumns.Add(this._VisibleColumn);
            this._ItemListBox.AllColumns.Add(this._ShowTextColumn);
            this._ItemListBox.AllColumns.Add(this._DisplayTextColumn);
            this._ItemListBox.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways;
            this._ItemListBox.CellEditUseWholeCell = false;
            this._ItemListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._NameColumn,
            this._VisibleColumn,
            this._ShowTextColumn,
            this._DisplayTextColumn});
            this._ItemListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this._ItemListBox.HideSelection = false;
            resources.ApplyResources(this._ItemListBox, "_ItemListBox");
            this._ItemListBox.Name = "_ItemListBox";
            this._ItemListBox.ShowGroups = false;
            this._ItemListBox.SmallImageList = this._ButtonImageList;
            this._ItemListBox.UseCompatibleStateImageBehavior = false;
            this._ItemListBox.View = System.Windows.Forms.View.Details;
            // 
            // _NameColumn
            // 
            this._NameColumn.IsEditable = false;
            resources.ApplyResources(this._NameColumn, "_NameColumn");
            // 
            // _VisibleColumn
            // 
            this._VisibleColumn.CheckBoxes = true;
            this._VisibleColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this._VisibleColumn, "_VisibleColumn");
            // 
            // _ShowTextColumn
            // 
            this._ShowTextColumn.CheckBoxes = true;
            this._ShowTextColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this._ShowTextColumn, "_ShowTextColumn");
            // 
            // _DisplayTextColumn
            // 
            this._DisplayTextColumn.AutoCompleteEditor = false;
            this._DisplayTextColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            resources.ApplyResources(this._DisplayTextColumn, "_DisplayTextColumn");
            // 
            // _ButtonImageList
            // 
            this._ButtonImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this._ButtonImageList, "_ButtonImageList");
            this._ButtonImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _OkButton
            // 
            resources.ApplyResources(this._OkButton, "_OkButton");
            this._OkButton.Name = "_OkButton";
            this._OkButton.UseVisualStyleBackColor = true;
            this._OkButton.Click += new System.EventHandler(this._OkButton_Click);
            // 
            // _ResetButton
            // 
            resources.ApplyResources(this._ResetButton, "_ResetButton");
            this._ResetButton.Name = "_ResetButton";
            this._ResetButton.UseVisualStyleBackColor = true;
            this._ResetButton.Click += new System.EventHandler(this._ResetButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CustomizeToolbarForm
            // 
            this.AcceptButton = this._OkButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this._ResetButton);
            this.Controls.Add(this._OkButton);
            this.Controls.Add(this._ItemListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomizeToolbarForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.CustomizeToolbarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._ItemListBox)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private BrightIdeasSoftware.ObjectListView _ItemListBox;
		private System.Windows.Forms.Button _OkButton;
		private BrightIdeasSoftware.OLVColumn _NameColumn;
		private BrightIdeasSoftware.OLVColumn _VisibleColumn;
		private BrightIdeasSoftware.OLVColumn _ShowTextColumn;
		private System.Windows.Forms.Button _ResetButton;
		private System.Windows.Forms.ImageList _ButtonImageList;
		private System.Windows.Forms.Label label1;
		private BrightIdeasSoftware.OLVColumn _DisplayTextColumn;
	}
}
