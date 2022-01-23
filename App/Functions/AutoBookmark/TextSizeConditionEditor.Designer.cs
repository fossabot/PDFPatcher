namespace PDFPatcher.Functions
{
	partial class TextSizeConditionEditor
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
			this._MinSizeBox = new System.Windows.Forms.NumericUpDown ();
			this._MaxSizeBox = new System.Windows.Forms.NumericUpDown ();
			this.label2 = new System.Windows.Forms.Label ();
			this._SizeBox = new System.Windows.Forms.RadioButton ();
			this._SpecificSizeBox = new System.Windows.Forms.NumericUpDown ();
			this._SizeRangeBox = new System.Windows.Forms.RadioButton ();
			((System.ComponentModel.ISupportInitialize)(this._MinSizeBox)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this._MaxSizeBox)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this._SpecificSizeBox)).BeginInit ();
			this.SuspendLayout ();
			//
			// _MinSizeBox
			//
			this._MinSizeBox.DecimalPlaces = 2;
			this._MinSizeBox.Location = new System.Drawing.Point (128, 30);
			this._MinSizeBox.Maximum = new decimal (new int[] {
            9999,
            0,
            0,
            0});
			this._MinSizeBox.Name = "_MinSizeBox";
			this._MinSizeBox.Size = new System.Drawing.Size (67, 21);
			this._MinSizeBox.TabIndex = 1;
			this._MinSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._MinSizeBox.ValueChanged += new System.EventHandler (this.ControlChanged);
			//
			// _MaxSizeBox
			//
			this._MaxSizeBox.DecimalPlaces = 2;
			this._MaxSizeBox.Location = new System.Drawing.Point (224, 30);
			this._MaxSizeBox.Maximum = new decimal (new int[] {
            9999,
            0,
            0,
            0});
			this._MaxSizeBox.Name = "_MaxSizeBox";
			this._MaxSizeBox.Size = new System.Drawing.Size (67, 21);
			this._MaxSizeBox.TabIndex = 1;
			this._MaxSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._MaxSizeBox.ValueChanged += new System.EventHandler (this.ControlChanged);
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point (201, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size (17, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = " to ";
			//
			// _SizeBox
			//
			this._SizeBox.AutoSize = true;
			this._SizeBox.Location = new System.Drawing.Point (3, 3);
			this._SizeBox.Name = "_SizeBox";
			this._SizeBox.Size = new System.Drawing.Size (119, 16);
			this._SizeBox.TabIndex = 3;
			this._SizeBox.TabStop = true;
			this._SizeBox.Text = "Match a specific text size";
			this._SizeBox.UseVisualStyleBackColor = true;
			this._SizeBox.CheckedChanged += new System.EventHandler (this.ControlChanged);
			//
			// _SpecificSizeBox
			//
			this._SpecificSizeBox.DecimalPlaces = 2;
			this._SpecificSizeBox.Location = new System.Drawing.Point (128, 3);
			this._SpecificSizeBox.Maximum = new decimal (new int[] {
            9999,
            0,
            0,
            0});
			this._SpecificSizeBox.Name = "_SpecificSizeBox";
			this._SpecificSizeBox.Size = new System.Drawing.Size (67, 21);
			this._SpecificSizeBox.TabIndex = 1;
			this._SpecificSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._SpecificSizeBox.ValueChanged += new System.EventHandler (this.ControlChanged);
			//
			// _SizeRangeBox
			//
			this._SizeRangeBox.AutoSize = true;
			this._SizeRangeBox.Location = new System.Drawing.Point (3, 30);
			this._SizeRangeBox.Name = "_SizeRangeBox";
			this._SizeRangeBox.Size = new System.Drawing.Size (119, 16);
			this._SizeRangeBox.TabIndex = 3;
			this._SizeRangeBox.TabStop = true;
			this._SizeRangeBox.Text = "Match text size range";
			this._SizeRangeBox.UseVisualStyleBackColor = true;
			this._SizeRangeBox.CheckedChanged += new System.EventHandler (this.ControlChanged);
			//
			// FontSizeFilterEditor
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this._SizeRangeBox);
			this.Controls.Add (this._SizeBox);
			this.Controls.Add (this.label2);
			this.Controls.Add (this._MaxSizeBox);
			this.Controls.Add (this._SpecificSizeBox);
			this.Controls.Add (this._MinSizeBox);
			this.Name = "FontSizeFilterEditor";
			this.Size = new System.Drawing.Size (338, 71);
			((System.ComponentModel.ISupportInitialize)(this._MinSizeBox)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this._MaxSizeBox)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this._SpecificSizeBox)).EndInit ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown _MinSizeBox;
		private System.Windows.Forms.NumericUpDown _MaxSizeBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton _SizeBox;
		private System.Windows.Forms.NumericUpDown _SpecificSizeBox;
		private System.Windows.Forms.RadioButton _SizeRangeBox;

	}
}
