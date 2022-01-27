namespace PDFPatcher.Functions
{
	partial class ReportControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportControl));
            this._ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this._CancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._InputFileBox = new System.Windows.Forms.TextBox();
            this._OutputFileBox = new System.Windows.Forms.TextBox();
            this._TotalProgressBar = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this._LogBox = new RichTextBoxLinks.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // _ProgressBar
            // 
            resources.ApplyResources(this._ProgressBar, "_ProgressBar");
            this._ProgressBar.Name = "_ProgressBar";
            this._ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _CancelButton
            // 
            resources.ApplyResources(this._CancelButton, "_CancelButton");
            this._CancelButton.Image = global::PDFPatcher.Properties.Resources.Return;
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _InputFileBox
            // 
            resources.ApplyResources(this._InputFileBox, "_InputFileBox");
            this._InputFileBox.BackColor = System.Drawing.SystemColors.Control;
            this._InputFileBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._InputFileBox.Name = "_InputFileBox";
            this._InputFileBox.ReadOnly = true;
            // 
            // _OutputFileBox
            // 
            resources.ApplyResources(this._OutputFileBox, "_OutputFileBox");
            this._OutputFileBox.BackColor = System.Drawing.SystemColors.Control;
            this._OutputFileBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._OutputFileBox.Name = "_OutputFileBox";
            this._OutputFileBox.ReadOnly = true;
            // 
            // _TotalProgressBar
            // 
            resources.ApplyResources(this._TotalProgressBar, "_TotalProgressBar");
            this._TotalProgressBar.Name = "_TotalProgressBar";
            this._TotalProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // _LogBox
            // 
            resources.ApplyResources(this._LogBox, "_LogBox");
            this._LogBox.BackColor = System.Drawing.SystemColors.Window;
            this._LogBox.Name = "_LogBox";
            this._LogBox.ReadOnly = true;
            this._LogBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this._LogBox_LinkClicked);
            // 
            // ReportControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._OutputFileBox);
            this.Controls.Add(this._InputFileBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._TotalProgressBar);
            this.Controls.Add(this._ProgressBar);
            this.Controls.Add(this._LogBox);
            this.Name = "ReportControl";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ProgressBar _ProgressBar;
		private System.Windows.Forms.Label label2;
		internal RichTextBoxLinks.RichTextBoxEx _LogBox;
		private System.Windows.Forms.Button _CancelButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.TextBox _InputFileBox;
		internal System.Windows.Forms.TextBox _OutputFileBox;
		internal System.Windows.Forms.ProgressBar _TotalProgressBar;
		private System.Windows.Forms.Label label6;

	}
}
