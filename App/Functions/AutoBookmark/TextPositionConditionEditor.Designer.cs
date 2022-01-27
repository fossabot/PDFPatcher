﻿namespace PDFPatcher.Functions
{
	partial class TextPositionConditionEditor
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this._PositionBox = new System.Windows.Forms.ComboBox();
            this._RangeBox = new System.Windows.Forms.RadioButton();
            this._SpecificValueBox = new System.Windows.Forms.NumericUpDown();
            this._SpecificBox = new System.Windows.Forms.RadioButton();
            this._MinBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this._MaxBox = new System.Windows.Forms.NumericUpDown();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SpecificValueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._MinBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._MaxBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this._PositionBox);
            this.panel2.Controls.Add(this._RangeBox);
            this.panel2.Controls.Add(this._SpecificValueBox);
            this.panel2.Controls.Add(this._SpecificBox);
            this.panel2.Controls.Add(this._MinBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this._MaxBox);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 95);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Match the coordinates of text blocks";
            // 
            // _PositionBox
            // 
            this._PositionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._PositionBox.FormattingEnabled = true;
            this._PositionBox.Items.AddRange(new object[] {
            "upper coordinates",
            "lower coordinates",
            "left coordinate",
            "Right coordinate"});
            this._PositionBox.Location = new System.Drawing.Point(206, 0);
            this._PositionBox.Name = "_PositionBox";
            this._PositionBox.Size = new System.Drawing.Size(121, 21);
            this._PositionBox.TabIndex = 4;
            this._PositionBox.SelectedIndexChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _RangeBox
            // 
            this._RangeBox.AutoSize = true;
            this._RangeBox.Location = new System.Drawing.Point(23, 61);
            this._RangeBox.Name = "_RangeBox";
            this._RangeBox.Size = new System.Drawing.Size(152, 17);
            this._RangeBox.TabIndex = 3;
            this._RangeBox.TabStop = true;
            this._RangeBox.Text = "Matching coordinate range";
            this._RangeBox.UseVisualStyleBackColor = true;
            this._RangeBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _SpecificValueBox
            // 
            this._SpecificValueBox.DecimalPlaces = 2;
            this._SpecificValueBox.Location = new System.Drawing.Point(206, 28);
            this._SpecificValueBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this._SpecificValueBox.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this._SpecificValueBox.Name = "_SpecificValueBox";
            this._SpecificValueBox.Size = new System.Drawing.Size(67, 20);
            this._SpecificValueBox.TabIndex = 1;
            this._SpecificValueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._SpecificValueBox.ValueChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _SpecificBox
            // 
            this._SpecificBox.AutoSize = true;
            this._SpecificBox.Location = new System.Drawing.Point(23, 31);
            this._SpecificBox.Name = "_SpecificBox";
            this._SpecificBox.Size = new System.Drawing.Size(185, 17);
            this._SpecificBox.TabIndex = 3;
            this._SpecificBox.TabStop = true;
            this._SpecificBox.Text = "Match a specific coordinate value";
            this._SpecificBox.UseVisualStyleBackColor = true;
            this._SpecificBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _MinBox
            // 
            this._MinBox.DecimalPlaces = 2;
            this._MinBox.Location = new System.Drawing.Point(178, 61);
            this._MinBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this._MinBox.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this._MinBox.Name = "_MinBox";
            this._MinBox.Size = new System.Drawing.Size(67, 20);
            this._MinBox.TabIndex = 1;
            this._MinBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._MinBox.ValueChanged += new System.EventHandler(this.ControlChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = " to ";
            // 
            // _MaxBox
            // 
            this._MaxBox.DecimalPlaces = 2;
            this._MaxBox.Location = new System.Drawing.Point(279, 61);
            this._MaxBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this._MaxBox.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this._MaxBox.Name = "_MaxBox";
            this._MaxBox.Size = new System.Drawing.Size(67, 20);
            this._MaxBox.TabIndex = 1;
            this._MaxBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._MaxBox.ValueChanged += new System.EventHandler(this.ControlChanged);
            // 
            // TextPositionConditionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "TextPositionConditionEditor";
            this.Size = new System.Drawing.Size(383, 95);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SpecificValueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._MinBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._MaxBox)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton _RangeBox;
		private System.Windows.Forms.NumericUpDown _SpecificValueBox;
		private System.Windows.Forms.RadioButton _SpecificBox;
		private System.Windows.Forms.NumericUpDown _MinBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown _MaxBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox _PositionBox;

	}
}
