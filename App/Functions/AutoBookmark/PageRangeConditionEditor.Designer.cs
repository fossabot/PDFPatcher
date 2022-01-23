namespace PDFPatcher.Functions
{
	partial class PageRangeConditionEditor
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
			this.label1 = new System.Windows.Forms.Label ();
			this._PageRangeBox = new System.Windows.Forms.TextBox ();
			this.SuspendLayout ();
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point (3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (89, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Match the page size range:";
			//
			// _PageRangeBox
			//
			this._PageRangeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._PageRangeBox.Location = new System.Drawing.Point (98, 6);
			this._PageRangeBox.Name = "_PageRangeBox";
			this._PageRangeBox.Size = new System.Drawing.Size (237, 21);
			this._PageRangeBox.TabIndex = 1;
			this._PageRangeBox.TextChanged += new System.EventHandler (this.ControlChanged);
			//
			// PageNumberConditionEditor
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this._PageRangeBox);
			this.Controls.Add (this.label1);
			this.Name = "PageNumberConditionEditor";
			this.Size = new System.Drawing.Size (338, 71);
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _PageRangeBox;


	}
}
