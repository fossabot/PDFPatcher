namespace PDFPatcher.Functions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextPositionConditionEditor));
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
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _PositionBox
            // 
            this._PositionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._PositionBox.FormattingEnabled = true;
            this._PositionBox.Items.AddRange(new object[] {
            resources.GetString("_PositionBox.Items"),
            resources.GetString("_PositionBox.Items1"),
            resources.GetString("_PositionBox.Items2"),
            resources.GetString("_PositionBox.Items3")});
            resources.ApplyResources(this._PositionBox, "_PositionBox");
            this._PositionBox.Name = "_PositionBox";
            this._PositionBox.SelectedIndexChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _RangeBox
            // 
            resources.ApplyResources(this._RangeBox, "_RangeBox");
            this._RangeBox.Name = "_RangeBox";
            this._RangeBox.TabStop = true;
            this._RangeBox.UseVisualStyleBackColor = true;
            this._RangeBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _SpecificValueBox
            // 
            this._SpecificValueBox.DecimalPlaces = 2;
            resources.ApplyResources(this._SpecificValueBox, "_SpecificValueBox");
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
            this._SpecificValueBox.ValueChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _SpecificBox
            // 
            resources.ApplyResources(this._SpecificBox, "_SpecificBox");
            this._SpecificBox.Name = "_SpecificBox";
            this._SpecificBox.TabStop = true;
            this._SpecificBox.UseVisualStyleBackColor = true;
            this._SpecificBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _MinBox
            // 
            this._MinBox.DecimalPlaces = 2;
            resources.ApplyResources(this._MinBox, "_MinBox");
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
            this._MinBox.ValueChanged += new System.EventHandler(this.ControlChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _MaxBox
            // 
            this._MaxBox.DecimalPlaces = 2;
            resources.ApplyResources(this._MaxBox, "_MaxBox");
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
            this._MaxBox.ValueChanged += new System.EventHandler(this.ControlChanged);
            // 
            // TextPositionConditionEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "TextPositionConditionEditor";
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
