namespace PDFPatcher
{
	partial class BookmarkControl
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
            this.label1 = new System.Windows.Forms.Label();
            this._BrowseBookmarkButton = new System.Windows.Forms.Button();
            this._OpenBookmarkBox = new System.Windows.Forms.OpenFileDialog();
            this._SaveBookmarkBox = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FileList = new PDFPatcher.HistoryComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "P&DF information file:";
            //
            // _BrowseBookmarkButton
            //
            this._BrowseBookmarkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._BrowseBookmarkButton.Image = global::PDFPatcher.Properties.Resources.BookmarkFile;
            this._BrowseBookmarkButton.Location = new System.Drawing.Point(391, 1);
            this._BrowseBookmarkButton.Name = "_BrowseBookmarkButton";
            this._BrowseBookmarkButton.Size = new System.Drawing.Size(75, 23);
            this._BrowseBookmarkButton.TabIndex = 2;
            this._BrowseBookmarkButton.Text = "Browse...";
            this._BrowseBookmarkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._BrowseBookmarkButton.UseVisualStyleBackColor = true;
            this._BrowseBookmarkButton.Click += new System.EventHandler(this._BrowseSourcePdfButton_Click);
            //
            // _OpenBookmarkBox
            //
            this._OpenBookmarkBox.DefaultExt = "xml";
            this._OpenBookmarkBox.Filter = "Supported information file (*.xml,*.txt)|*.xml;*.txt|XML Information file (*.xml)|*.xml|Simple text bookmark file(*.txt)|*.txt";
            this._OpenBookmarkBox.Title = "Specify the path to the information that needs to be imported";
            //
            // _SaveBookmarkBox
            //
            this._SaveBookmarkBox.DefaultExt = "xml";
   this._SaveBookmarkBox.Filter = "Supported information file (*.xml,*.txt)|*.xml;*.txt|XML information file (*.xml)|*.xml|Simple text bookmark file (*.txt) |*.txt";
             this._SaveBookmarkBox.Title = "Specify the exported information file path";
            //
            // panel1
            //
            this.panel1.Controls.Add(this.FileList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._BrowseBookmarkButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 26);
            this.panel1.TabIndex = 3;
            //
            // _BookmarkBox
            //
            this.FileList.AllowDrop = true;
            this.FileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FileList.Contents = null;
            this.FileList.FormattingEnabled = true;
            this.FileList.Location = new System.Drawing.Point(104, 3);
            this.FileList.MaxItemCount = 16;
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(281, 20);
            this.FileList.TabIndex = 1;
            this.FileList.DragDrop += new System.Windows.Forms.DragEventHandler(this._BookmarkBox_DragDrop);
            this.FileList.DragEnter += new System.Windows.Forms.DragEventHandler(this._BookmarkBox_DragEnter);
            this.FileList.TextChanged += new System.EventHandler(this._BookmarkBox_TextChanged);
            //
            // BookmarkControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "BookmarkControl";
            this.Size = new System.Drawing.Size(469, 26);
            this.Load += new System.EventHandler(this.BookmarkControl_Show);
            this.VisibleChanged += new System.EventHandler(this.BookmarkControl_Show);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _BrowseBookmarkButton;
		private System.Windows.Forms.OpenFileDialog _OpenBookmarkBox;
		private System.Windows.Forms.SaveFileDialog _SaveBookmarkBox;
		private System.Windows.Forms.Panel panel1;
	}
}
