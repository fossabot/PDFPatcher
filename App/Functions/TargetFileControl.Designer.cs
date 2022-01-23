namespace PDFPatcher
{
	partial class TargetFileControl
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
            this.label1 = new System.Windows.Forms.Label();
            this._SavePdfBox = new System.Windows.Forms.SaveFileDialog();
            this._BrowseTargetPdfButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FileList = new PDFPatcher.HistoryComboBox();
            this._FileMacroMenu = new PDFPatcher.Functions.MacroMenu(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
this.label1.TabIndex = 0;
            this.label1.Text = "Output PD&F file:";
            //
            // _SavePdfBox
            //
            this._SavePdfBox.DefaultExt = "pdf";
            this._SavePdfBox.Filter = "PDF file (*.pdf)|*.pdf";
            this._SavePdfBox.OverwritePrompt = false;
            this._SavePdfBox.Title = "Specify the output PDF file path";
            //
            // _BrowseTargetPdfButton
            //
            this._BrowseTargetPdfButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._BrowseTargetPdfButton.Image = global::PDFPatcher.Properties.Resources.NewPdfFile;
            this._BrowseTargetPdfButton.Location = new System.Drawing.Point(391, 1);
            this._BrowseTargetPdfButton.Name = "_BrowseTargetPdfButton";
            this._BrowseTargetPdfButton.Size = new System.Drawing.Size(75, 23);
            this._BrowseTargetPdfButton.TabIndex = 2;
            this._BrowseTargetPdfButton.Text = "Browse...";
            this._BrowseTargetPdfButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._BrowseTargetPdfButton.UseVisualStyleBackColor = true;
            this._BrowseTargetPdfButton.Click += new System.EventHandler(this._BrowseTargetPdfButton_Click);
            //
            // panel1
            //
            this.panel1.Controls.Add(this._BrowseTargetPdfButton);
            this.panel1.Controls.Add(this.FileList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 25);
            this.panel1.TabIndex = 3;
            //
            // _TargetPdfBox
            //
            this.FileList.AllowDrop = true;
            this.FileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FileList.Contents = null;
            this.FileList.ContextMenuStrip = this._FileMacroMenu;
            this.FileList.FormattingEnabled = true;
            this.FileList.Location = new System.Drawing.Point(104, 3);
            this.FileList.MaxItemCount = 16;
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(281, 20);
            this.FileList.TabIndex = 1;
            this.FileList.DragDrop += new System.Windows.Forms.DragEventHandler(this._TargetPdfBox_DragDrop);
            this.FileList.DragEnter += new System.Windows.Forms.DragEventHandler(this._TargetPdfBox_DragEnter);
            this.FileList.TextChanged += new System.EventHandler(this._TargetPdfBox_TextChanged);
            //
            // _FileMacroMenu
            //
            this._FileMacroMenu.Name = "_FileMacroMenu";
            this._FileMacroMenu.Size = new System.Drawing.Size(61, 4);
            //
            // TargetFileControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "TargetFileControl";
            this.Size = new System.Drawing.Size(469, 25);
            this.Load += new System.EventHandler(this.TargetFileControl_Show);
            this.VisibleChanged += new System.EventHandler(this.TargetFileControl_Show);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _BrowseTargetPdfButton;
		private System.Windows.Forms.SaveFileDialog _SavePdfBox;
		private Functions.MacroMenu _FileMacroMenu;
        private System.Windows.Forms.Panel panel1;
	}
}
