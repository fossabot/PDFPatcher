namespace PDFPatcher.Functions
{
	partial class FontCharSubstitutionForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
            this.label1 = new System.Windows.Forms.Label();
            this._OriginalCharactersBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._SubstituteCharactersBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._ChineseCaseBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._NumericWidthBox = new System.Windows.Forms.ComboBox();
            this._LetterWidthBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._PunctuationWidthBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what:";
            // 
            // _OriginalCharactersBox
            // 
            this._OriginalCharactersBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._OriginalCharactersBox.HideSelection = false;
            this._OriginalCharactersBox.Location = new System.Drawing.Point(85, 21);
            this._OriginalCharactersBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._OriginalCharactersBox.Multiline = false;
            this._OriginalCharactersBox.Name = "_OriginalCharactersBox";
            this._OriginalCharactersBox.Size = new System.Drawing.Size(373, 22);
            this._OriginalCharactersBox.TabIndex = 1;
            this._OriginalCharactersBox.Text = "";
            this._OriginalCharactersBox.SelectionChanged += new System.EventHandler(this._OriginalCharactersBox_SelectionChanged);
            this._OriginalCharactersBox.TextChanged += new System.EventHandler(this._OriginalCharactersBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Replace with:";
            // 
            // _SubstituteCharactersBox
            // 
            this._SubstituteCharactersBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._SubstituteCharactersBox.HideSelection = false;
            this._SubstituteCharactersBox.Location = new System.Drawing.Point(85, 63);
            this._SubstituteCharactersBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._SubstituteCharactersBox.Multiline = false;
            this._SubstituteCharactersBox.Name = "_SubstituteCharactersBox";
            this._SubstituteCharactersBox.Size = new System.Drawing.Size(373, 22);
            this._SubstituteCharactersBox.TabIndex = 1;
            this._SubstituteCharactersBox.Text = "";
            this._SubstituteCharactersBox.TextChanged += new System.EventHandler(this._SubstituteCharactersBox_TextChanged);
            this._SubstituteCharactersBox.Enter += new System.EventHandler(this._SubstituteCharactersBox_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Simplified and Traditional Chinese Characters Replacement: ";
            // 
            // _ChineseCaseBox
            // 
            this._ChineseCaseBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ChineseCaseBox.FormattingEnabled = true;
            this._ChineseCaseBox.Items.AddRange(new object[] {
            "not changing",
            "Simplified to Traditional",
            "Traditional to simplified"});
            this._ChineseCaseBox.Location = new System.Drawing.Point(304, 107);
            this._ChineseCaseBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._ChineseCaseBox.Name = "_ChineseCaseBox";
            this._ChineseCaseBox.Size = new System.Drawing.Size(109, 21);
            this._ChineseCaseBox.TabIndex = 4;
            this._ChineseCaseBox.SelectedIndexChanged += new System.EventHandler(this._ChineseCaseBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Digital replacement:";
            // 
            // _NumericWidthBox
            // 
            this._NumericWidthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._NumericWidthBox.FormattingEnabled = true;
            this._NumericWidthBox.Items.AddRange(new object[] {
            "not changing",
            "Half-width to full-width",
            "Full-width to half-width"});
            this._NumericWidthBox.Location = new System.Drawing.Point(151, 126);
            this._NumericWidthBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._NumericWidthBox.Name = "_NumericWidthBox";
            this._NumericWidthBox.Size = new System.Drawing.Size(109, 21);
            this._NumericWidthBox.TabIndex = 4;
            this._NumericWidthBox.SelectedIndexChanged += new System.EventHandler(this._NumericWidthBox_SelectedIndexChanged);
            // 
            // _LetterWidthBox
            // 
            this._LetterWidthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._LetterWidthBox.FormattingEnabled = true;
            this._LetterWidthBox.Items.AddRange(new object[] {
            "not changing",
            "Half-width to full-width",
            "Full-width to half-width"});
            this._LetterWidthBox.Location = new System.Drawing.Point(151, 151);
            this._LetterWidthBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._LetterWidthBox.Name = "_LetterWidthBox";
            this._LetterWidthBox.Size = new System.Drawing.Size(109, 21);
            this._LetterWidthBox.TabIndex = 4;
            this._LetterWidthBox.SelectedIndexChanged += new System.EventHandler(this._LetterWidthBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Alphase replacement:";
            // 
            // _PunctuationWidthBox
            // 
            this._PunctuationWidthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._PunctuationWidthBox.FormattingEnabled = true;
            this._PunctuationWidthBox.Items.AddRange(new object[] {
            "not changing",
            "Half-width to full-width",
            "Full-width to half-width"});
            this._PunctuationWidthBox.Location = new System.Drawing.Point(151, 176);
            this._PunctuationWidthBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._PunctuationWidthBox.Name = "_PunctuationWidthBox";
            this._PunctuationWidthBox.Size = new System.Drawing.Size(109, 21);
            this._PunctuationWidthBox.TabIndex = 4;
            this._PunctuationWidthBox.SelectedIndexChanged += new System.EventHandler(this._PunctuationWidthBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 180);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Punctuation Replacement: ";
            // 
            // FontCharSubstitutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 208);
            this.Controls.Add(this._PunctuationWidthBox);
            this.Controls.Add(this._LetterWidthBox);
            this.Controls.Add(this._NumericWidthBox);
            this.Controls.Add(this._ChineseCaseBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._SubstituteCharactersBox);
            this.Controls.Add(this._OriginalCharactersBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontCharSubstitutionForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace character";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox _OriginalCharactersBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox _SubstituteCharactersBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox _ChineseCaseBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox _NumericWidthBox;
		private System.Windows.Forms.ComboBox _LetterWidthBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox _PunctuationWidthBox;
		private System.Windows.Forms.Label label6;
	}
}
