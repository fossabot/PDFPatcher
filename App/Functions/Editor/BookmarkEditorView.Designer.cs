namespace PDFPatcher.Functions
{
	partial class BookmarkEditorView
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
			this.components = new System.ComponentModel.Container ();
			this.BookmarkNameColumn = new BrightIdeasSoftware.OLVColumn ();
			this.BookmarkOpenColumn = new BrightIdeasSoftware.OLVColumn ();
			this.BookmarkPageColumn = new BrightIdeasSoftware.OLVColumn ();
			this._ActionColumn = new BrightIdeasSoftware.OLVColumn ();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit ();
			this.SuspendLayout ();
			//
			// _BookmarkBox
			//
			this.AllColumns.Add (this.BookmarkNameColumn);
			this.AllColumns.Add (this.BookmarkOpenColumn);
			this.AllColumns.Add (this.BookmarkPageColumn);
			this.AllColumns.Add (this._ActionColumn);
			this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
			this.Columns.AddRange (new System.Windows.Forms.ColumnHeader[] {
            this.BookmarkNameColumn,
            this.BookmarkOpenColumn,
            this.BookmarkPageColumn,
            this._ActionColumn});
			this.CopySelectionOnControlC = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridLines = true;
			this.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.HideSelection = false;
			this.IsSimpleDragSource = true;
			this.IsSimpleDropSink = true;
			this.LabelEdit = true;
			this.Location = new System.Drawing.Point (0, 0);
			this.Name = "_BookmarkBox";
			this.OwnerDraw = true;
			this.RevealAfterExpand = false;
			this.ShowGroups = false;
			this.Size = new System.Drawing.Size (408, 208);
			this.TabIndex = 0;
			this.UseCellFormatEvents = false;
			this.UseHotItem = false;
			this.UseCompatibleStateImageBehavior = false;
			this.UseHyperlinks = true;
			this.View = System.Windows.Forms.View.Details;
			this.VirtualMode = true;
			this.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.BookmarkEditorView_BeforeLabelEdit);
			this.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler (this._BookmarkBox_AfterLabelEdit);
			this.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs> (this._BookmarkBox_FormatRow);
			this.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(BookmarkEditor_CellClick);
			this.HotItemChanged += new System.EventHandler<BrightIdeasSoftware.HotItemChangedEventArgs> (BookmarkEditor_HotItemChanged);
			//
			// _BookmarkNameColumn
			//
			this.BookmarkNameColumn.AspectName = "";
this.BookmarkNameColumn.Text = "Bookmark Text";
this.BookmarkNameColumn.Width = 241;
//
// _BookmarkOpenColumn
//
this.BookmarkOpenColumn.AspectName = "";
this.BookmarkOpenColumn.CheckBoxes = true;
this.BookmarkOpenColumn.DisplayIndex = 2;
this.BookmarkOpenColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.BookmarkOpenColumn.Text = "Open";
this.BookmarkOpenColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.BookmarkOpenColumn.Width = 40;
//
// _BookmarkPageColumn
//
this.BookmarkPageColumn.AspectName = "";
this.BookmarkPageColumn.DisplayIndex = 1;
this.BookmarkPageColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
this.BookmarkPageColumn.Text = "Page Number";
this.BookmarkPageColumn.Width = 42;
//
// _ActionColumn
//
this._ActionColumn.AspectName = "";
this._ActionColumn.Hyperlink = true;
this._ActionColumn.IsEditable = false;
this._ActionColumn.Text = "Bookmark Action";
			this._ActionColumn.Width = 100;
			//
			// BookmarkEditor
			//
			this.Name = "BookmarkEditor";
			this.Size = new System.Drawing.Size (408, 208);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit ();
			this.ResumeLayout (false);

		}

		#endregion

		private BrightIdeasSoftware.OLVColumn _ActionColumn;
	}
}
