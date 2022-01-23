namespace PDFPatcher.Functions
{
	partial class FontNameConditionEditor
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
			this._FontNameBox = new System.Windows.Forms.TextBox ();
			this._FullMatchBox = new System.Windows.Forms.CheckBox ();
			this.SuspendLayout ();
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point (3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (89, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Match font name:";
			//
			// _FontNameBox
			//
			this._FontNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._FontNameBox.Location = new System.Drawing.Point (98, 6);
			this._FontNameBox.Name = "_FontNameBox";
			this._FontNameBox.Size = new System.Drawing.Size (238, 21);
			this._FontNameBox.TabIndex = 1;
			this._FontNameBox.TextChanged += new System.EventHandler (this.ControlChanged);
			//
			// _FullMatchBox
			//
			this._FullMatchBox.AutoSize = true;
			this._FullMatchBox.Location = new System.Drawing.Point (5, 33);
			this._FullMatchBox.Name = "_FullMatchBox";
			this._FullMatchBox.Size = new System.Drawing.Size (120, 16);
			this._FullMatchBox.TabIndex = 2;
			this._FullMatchBox.Text = "Full match font name";
			this._FullMatchBox.UseVisualStyleBackColor = true;
			this._FullMatchBox.CheckedChanged += new System.EventHandler (this.ControlChanged);
			//
			// FontNameFilterEditor
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this._FullMatchBox);
			this.Controls.Add (this._FontNameBox);
			this.Controls.Add (this.label1);
			this.Name = "FontNameFilterEditor";
			this.Size = new System.Drawing.Size (339, 80);
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _FontNameBox;
		private System.Windows.Forms.CheckBox _FullMatchBox;
	}
}
