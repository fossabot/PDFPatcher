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
			this._PageLabelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this._PageLabelBox.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
			this._PageLabelBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._SequenceColumn,
            this._PageNumColumn,
            this._LabelStyleColumn,
            this._LabelPrefixColumn,
            this._StartNumColumn});
			this._PageLabelBox.GridLines = true;
			this._PageLabelBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this._PageLabelBox.HideSelection = false;
			this._PageLabelBox.LabelEdit = true;
			this._PageLabelBox.Location = new System.Drawing.Point(3, 32);
			this._PageLabelBox.Name = "_PageLabelBox";
			this._PageLabelBox.OwnerDraw = true;
			this._PageLabelBox.ShowGroups = false;
			this._PageLabelBox.Size = new System.Drawing.Size(432, 244);
			this._PageLabelBox.TabIndex = 0;
			this._PageLabelBox.UseCompatibleStateImageBehavior = false;
			this._PageLabelBox.View = System.Windows.Forms.View.Details;
			//
			// _SequenceColumn
			//
this._SequenceColumn.IsEditable = false;
this._SequenceColumn.Text = "Sequence Number";
this._SequenceColumn.Width = 40;
//
// _PageNumColumn
//
this._PageNumColumn.Text = "Document Page Number";
this._PageNumColumn.Width = 65;
//
// _LabelStyleColumn
//
this._LabelStyleColumn.IsEditable = false;
this._LabelStyleColumn.Text = "Page Number Style";
this._LabelStyleColumn.Width = 103;
//
// _LabelPrefixColumn
//
this._LabelPrefixColumn.Text = "Prefix Text";
this._LabelPrefixColumn.Width = 70;
//
// _StartNumColumn
//
this._StartNumColumn.Text = "Start Number";
this._StartNumColumn.Width = 70;
			//
			// _RemovePageLabelButton
			//
			this._RemovePageLabelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._RemovePageLabelButton.Image = global::PDFPatcher.Properties.Resources.Delete;
			this._RemovePageLabelButton.Location = new System.Drawing.Point(382, 3);
			this._RemovePageLabelButton.Name = "_RemovePageLabelButton";
			this._RemovePageLabelButton.Size = new System.Drawing.Size(53, 23);
			this._RemovePageLabelButton.TabIndex = 2;
			this._RemovePageLabelButton.Text = "Delete";
			this._RemovePageLabelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._RemovePageLabelButton.UseVisualStyleBackColor = true;
			this._RemovePageLabelButton.Click += new System.EventHandler(this._RemovePageLabelButton_Click);
			//
			// _AddPageLabelButton
			//
			this._AddPageLabelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._AddPageLabelButton.Image = global::PDFPatcher.Properties.Resources.Add;
			this._AddPageLabelButton.Location = new System.Drawing.Point(323, 3);
			this._AddPageLabelButton.Name = "_AddPageLabelButton";
			this._AddPageLabelButton.Size = new System.Drawing.Size(53, 23);
			this._AddPageLabelButton.TabIndex = 1;
			this._AddPageLabelButton.Text = "Add";
			this._AddPageLabelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._AddPageLabelButton.UseVisualStyleBackColor = true;
			this._AddPageLabelButton.Click += new System.EventHandler(this._AddPageLabelButton_Click);
			//
			// _LabelStyleMenu
			//
			this._LabelStyleMenu.Name = "_LabelStyleMenu";
			this._LabelStyleMenu.Size = new System.Drawing.Size(61, 4);
			//
			// panel1
			//
			this.panel1.Controls.Add(this._PageLabelBox);
			this.panel1.Controls.Add(this._RemovePageLabelButton);
			this.panel1.Controls.Add(this._AddPageLabelButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(438, 279);
			this.panel1.TabIndex = 3;
			//
			// PageLabelEditor
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "PageLabelEditor";
			this.Size = new System.Drawing.Size(438, 279);
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
