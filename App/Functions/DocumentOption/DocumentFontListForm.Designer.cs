﻿namespace PDFPatcher.Functions
{
	partial class DocumentFontListForm
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

		#region Code generated by the Windows Forms designer

		/// <summary>
		/// Designer supports required methods - Don't
		/// use a code editor to modify the content of this method.
		/// </summary>
		private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentFontListForm));
            this.label1 = new System.Windows.Forms.Label();
            this._PageRangeBox = new System.Windows.Forms.TextBox();
            this._FontListBox = new BrightIdeasSoftware.FastObjectListView();
            this._NameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._EmbeddedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._FirstPageColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ReferenceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._Worker = new System.ComponentModel.BackgroundWorker();
            this._ProgressBar = new System.Windows.Forms.ProgressBar();
            this._AddSelectedFontsButton = new System.Windows.Forms.Button();
            this._SelectAllButton = new System.Windows.Forms.Button();
            this._ListFontsButton = new System.Windows.Forms.Button();
            this._SourceFileBox = new PDFPatcher.SourceFileControl();
            this._AppConfigButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._FontListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _PageRangeBox
            // 
            resources.ApplyResources(this._PageRangeBox, "_PageRangeBox");
            this._PageRangeBox.Name = "_PageRangeBox";
            // 
            // _FontListBox
            // 
            this._FontListBox.AllColumns.Add(this._NameColumn);
            this._FontListBox.AllColumns.Add(this._EmbeddedColumn);
            this._FontListBox.AllColumns.Add(this._FirstPageColumn);
            this._FontListBox.AllColumns.Add(this._ReferenceColumn);
            resources.ApplyResources(this._FontListBox, "_FontListBox");
            this._FontListBox.CellEditUseWholeCell = false;
            this._FontListBox.CheckBoxes = true;
            this._FontListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._NameColumn,
            this._EmbeddedColumn,
            this._FirstPageColumn,
            this._ReferenceColumn});
            this._FontListBox.GridLines = true;
            this._FontListBox.HideSelection = false;
            this._FontListBox.MultiSelect = false;
            this._FontListBox.Name = "_FontListBox";
            this._FontListBox.ShowGroups = false;
            this._FontListBox.ShowImagesOnSubItems = true;
            this._FontListBox.UseCompatibleStateImageBehavior = false;
            this._FontListBox.View = System.Windows.Forms.View.Details;
            this._FontListBox.VirtualMode = true;
            // 
            // _NameColumn
            // 
            this._NameColumn.AspectName = "";
            resources.ApplyResources(this._NameColumn, "_NameColumn");
            // 
            // _EmbeddedColumn
            // 
            this._EmbeddedColumn.AspectName = "";
            this._EmbeddedColumn.CheckBoxes = true;
            this._EmbeddedColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._EmbeddedColumn.IsEditable = false;
            resources.ApplyResources(this._EmbeddedColumn, "_EmbeddedColumn");
            // 
            // _FirstPageColumn
            // 
            this._FirstPageColumn.AspectName = "";
            this._FirstPageColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this._FirstPageColumn, "_FirstPageColumn");
            // 
            // _ReferenceColumn
            // 
            this._ReferenceColumn.AspectName = "";
            this._ReferenceColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this._ReferenceColumn, "_ReferenceColumn");
            // 
            // _Worker
            // 
            this._Worker.WorkerReportsProgress = true;
            this._Worker.WorkerSupportsCancellation = true;
            // 
            // _ProgressBar
            // 
            resources.ApplyResources(this._ProgressBar, "_ProgressBar");
            this._ProgressBar.Name = "_ProgressBar";
            // 
            // _AddSelectedFontsButton
            // 
            resources.ApplyResources(this._AddSelectedFontsButton, "_AddSelectedFontsButton");
            this._AddSelectedFontsButton.Name = "_AddSelectedFontsButton";
            this._AddSelectedFontsButton.UseVisualStyleBackColor = true;
            this._AddSelectedFontsButton.Click += new System.EventHandler(this._AddSelectedFontsButton_Click);
            // 
            // _SelectAllButton
            // 
            resources.ApplyResources(this._SelectAllButton, "_SelectAllButton");
            this._SelectAllButton.Name = "_SelectAllButton";
            this._SelectAllButton.UseVisualStyleBackColor = true;
            this._SelectAllButton.Click += new System.EventHandler(this._SelectAllButton_Click);
            // 
            // _ListFontsButton
            // 
            resources.ApplyResources(this._ListFontsButton, "_ListFontsButton");
            this._ListFontsButton.Name = "_ListFontsButton";
            this._ListFontsButton.UseVisualStyleBackColor = true;
            this._ListFontsButton.Click += new System.EventHandler(this._ListFontsButton_Click);
            // 
            // _SourceFileBox
            // 
            resources.ApplyResources(this._SourceFileBox, "_SourceFileBox");
            this._SourceFileBox.Name = "_SourceFileBox";
            // 
            // _AppConfigButton
            // 
            resources.ApplyResources(this._AppConfigButton, "_AppConfigButton");
            this._AppConfigButton.Name = "_AppConfigButton";
            this._AppConfigButton.UseVisualStyleBackColor = true;
            this._AppConfigButton.Click += new System.EventHandler(this._AppConfigButton_Click);
            // 
            // DocumentFontListForm
            // 
            this.AcceptButton = this._ListFontsButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._AppConfigButton);
            this.Controls.Add(this._SelectAllButton);
            this.Controls.Add(this._AddSelectedFontsButton);
            this.Controls.Add(this._ProgressBar);
            this.Controls.Add(this._FontListBox);
            this.Controls.Add(this._ListFontsButton);
            this.Controls.Add(this._PageRangeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._SourceFileBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentFontListForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            ((System.ComponentModel.ISupportInitialize)(this._FontListBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private SourceFileControl _SourceFileBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _PageRangeBox;
		private System.Windows.Forms.Button _ListFontsButton;
		private BrightIdeasSoftware.FastObjectListView _FontListBox;
		private BrightIdeasSoftware.OLVColumn _NameColumn;
		private BrightIdeasSoftware.OLVColumn _FirstPageColumn;
		private BrightIdeasSoftware.OLVColumn _EmbeddedColumn;
		private System.ComponentModel.BackgroundWorker _Worker;
		private System.Windows.Forms.ProgressBar _ProgressBar;
		private BrightIdeasSoftware.OLVColumn _ReferenceColumn;
		private System.Windows.Forms.Button _AddSelectedFontsButton;
		private System.Windows.Forms.Button _SelectAllButton;
        private System.Windows.Forms.Button _AppConfigButton;
    }
}
