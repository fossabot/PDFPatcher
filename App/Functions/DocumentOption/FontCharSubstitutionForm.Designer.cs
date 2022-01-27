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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontCharSubstitutionForm));
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
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _OriginalCharactersBox
            // 
            resources.ApplyResources(this._OriginalCharactersBox, "_OriginalCharactersBox");
            this._OriginalCharactersBox.HideSelection = false;
            this._OriginalCharactersBox.Name = "_OriginalCharactersBox";
            this._OriginalCharactersBox.SelectionChanged += new System.EventHandler(this._OriginalCharactersBox_SelectionChanged);
            this._OriginalCharactersBox.TextChanged += new System.EventHandler(this._OriginalCharactersBox_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _SubstituteCharactersBox
            // 
            resources.ApplyResources(this._SubstituteCharactersBox, "_SubstituteCharactersBox");
            this._SubstituteCharactersBox.HideSelection = false;
            this._SubstituteCharactersBox.Name = "_SubstituteCharactersBox";
            this._SubstituteCharactersBox.TextChanged += new System.EventHandler(this._SubstituteCharactersBox_TextChanged);
            this._SubstituteCharactersBox.Enter += new System.EventHandler(this._SubstituteCharactersBox_Enter);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _ChineseCaseBox
            // 
            this._ChineseCaseBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ChineseCaseBox.FormattingEnabled = true;
            this._ChineseCaseBox.Items.AddRange(new object[] {
            resources.GetString("_ChineseCaseBox.Items"),
            resources.GetString("_ChineseCaseBox.Items1"),
            resources.GetString("_ChineseCaseBox.Items2")});
            resources.ApplyResources(this._ChineseCaseBox, "_ChineseCaseBox");
            this._ChineseCaseBox.Name = "_ChineseCaseBox";
            this._ChineseCaseBox.SelectedIndexChanged += new System.EventHandler(this._ChineseCaseBox_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // _NumericWidthBox
            // 
            this._NumericWidthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._NumericWidthBox.FormattingEnabled = true;
            this._NumericWidthBox.Items.AddRange(new object[] {
            resources.GetString("_NumericWidthBox.Items"),
            resources.GetString("_NumericWidthBox.Items1"),
            resources.GetString("_NumericWidthBox.Items2")});
            resources.ApplyResources(this._NumericWidthBox, "_NumericWidthBox");
            this._NumericWidthBox.Name = "_NumericWidthBox";
            this._NumericWidthBox.SelectedIndexChanged += new System.EventHandler(this._NumericWidthBox_SelectedIndexChanged);
            // 
            // _LetterWidthBox
            // 
            this._LetterWidthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._LetterWidthBox.FormattingEnabled = true;
            this._LetterWidthBox.Items.AddRange(new object[] {
            resources.GetString("_LetterWidthBox.Items"),
            resources.GetString("_LetterWidthBox.Items1"),
            resources.GetString("_LetterWidthBox.Items2")});
            resources.ApplyResources(this._LetterWidthBox, "_LetterWidthBox");
            this._LetterWidthBox.Name = "_LetterWidthBox";
            this._LetterWidthBox.SelectedIndexChanged += new System.EventHandler(this._LetterWidthBox_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _PunctuationWidthBox
            // 
            this._PunctuationWidthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._PunctuationWidthBox.FormattingEnabled = true;
            this._PunctuationWidthBox.Items.AddRange(new object[] {
            resources.GetString("_PunctuationWidthBox.Items"),
            resources.GetString("_PunctuationWidthBox.Items1"),
            resources.GetString("_PunctuationWidthBox.Items2")});
            resources.ApplyResources(this._PunctuationWidthBox, "_PunctuationWidthBox");
            this._PunctuationWidthBox.Name = "_PunctuationWidthBox";
            this._PunctuationWidthBox.SelectedIndexChanged += new System.EventHandler(this._PunctuationWidthBox_SelectedIndexChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // FontCharSubstitutionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontCharSubstitutionForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
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
