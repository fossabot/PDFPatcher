namespace PDFPatcher.Functions
{
	partial class InsertPageLabelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertPageLabelForm));
            this.label1 = new System.Windows.Forms.Label();
            this._PrefixBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._NumericStyleBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._StartAtBox = new System.Windows.Forms.NumericUpDown();
            this._OkButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._PageNumberBox = new System.Windows.Forms.Label();
            this._RemoveLabelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._StartAtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _PrefixBox
            // 
            resources.ApplyResources(this._PrefixBox, "_PrefixBox");
            this._PrefixBox.Name = "_PrefixBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _NumericStyleBox
            // 
            this._NumericStyleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._NumericStyleBox.FormattingEnabled = true;
            resources.ApplyResources(this._NumericStyleBox, "_NumericStyleBox");
            this._NumericStyleBox.Name = "_NumericStyleBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _StartAtBox
            // 
            resources.ApplyResources(this._StartAtBox, "_StartAtBox");
            this._StartAtBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this._StartAtBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._StartAtBox.Name = "_StartAtBox";
            this._StartAtBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _OkButton
            // 
            resources.ApplyResources(this._OkButton, "_OkButton");
            this._OkButton.Name = "_OkButton";
            this._OkButton.UseVisualStyleBackColor = true;
            // 
            // _CancelButton
            // 
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._CancelButton, "_CancelButton");
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // _PageNumberBox
            // 
            resources.ApplyResources(this._PageNumberBox, "_PageNumberBox");
            this._PageNumberBox.Name = "_PageNumberBox";
            // 
            // _RemoveLabelButton
            // 
            resources.ApplyResources(this._RemoveLabelButton, "_RemoveLabelButton");
            this._RemoveLabelButton.Name = "_RemoveLabelButton";
            this._RemoveLabelButton.UseVisualStyleBackColor = true;
            // 
            // InsertPageLabelForm
            // 
            this.AcceptButton = this._OkButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._CancelButton;
            this.Controls.Add(this._RemoveLabelButton);
            this.Controls.Add(this._PageNumberBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OkButton);
            this.Controls.Add(this._StartAtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._NumericStyleBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._PrefixBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InsertPageLabelForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.InsertPageLabelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._StartAtBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _PrefixBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox _NumericStyleBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown _StartAtBox;
		private System.Windows.Forms.Button _OkButton;
		private System.Windows.Forms.Button _CancelButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label _PageNumberBox;
		private System.Windows.Forms.Button _RemoveLabelButton;
	}
}
