﻿namespace PDFPatcher.Functions
{
	partial class UpdateForm
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

		#region Code generated by the Windows Forms designer

		/// <summary>
		/// Designer supports required methods - Don't
		/// use a code editor to modify the content of this method.
		/// </summary>
		private void InitializeComponent () {
            this._InfoBox = new System.Windows.Forms.RichTextBox();
            this._HomePageButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this._DownloadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._CheckUpdateIntervalBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _InfoBox
            // 
            this._InfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._InfoBox.Location = new System.Drawing.Point(14, 13);
            this._InfoBox.Name = "_InfoBox";
            this._InfoBox.ReadOnly = true;
            this._InfoBox.Size = new System.Drawing.Size(616, 323);
            this._InfoBox.TabIndex = 0;
            this._InfoBox.Text = "";
            // 
            // _HomePageButton
            // 
            this._HomePageButton.Image = global::PDFPatcher.Properties.Resources.HomePage;
            this._HomePageButton.Location = new System.Drawing.Point(133, 342);
            this._HomePageButton.Name = "_HomePageButton";
            this._HomePageButton.Size = new System.Drawing.Size(108, 25);
            this._HomePageButton.TabIndex = 2;
            this._HomePageButton.Text = "&Homepage";
            this._HomePageButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._HomePageButton.UseVisualStyleBackColor = true;
            // 
            // _CancelButton
            // 
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(247, 342);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 25);
            this._CancelButton.TabIndex = 3;
            this._CancelButton.Text = "&Cancel";
            this._CancelButton.UseVisualStyleBackColor = true;
            // 
            // _DownloadButton
            // 
            this._DownloadButton.Enabled = false;
            this._DownloadButton.Image = global::PDFPatcher.Properties.Resources.Save;
            this._DownloadButton.Location = new System.Drawing.Point(14, 342);
            this._DownloadButton.Name = "_DownloadButton";
            this._DownloadButton.Size = new System.Drawing.Size(113, 25);
            this._DownloadButton.TabIndex = 1;
            this._DownloadButton.Text = "Download new version";
            this._DownloadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._DownloadButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 348);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Automatically check update interval:";
            // 
            // _CheckUpdateIntervalBox
            // 
            this._CheckUpdateIntervalBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._CheckUpdateIntervalBox.FormattingEnabled = true;
            this._CheckUpdateIntervalBox.Items.AddRange(new object[] {
            "7 days",
            "14 days",
            "30 days",
            "never check"});
            this._CheckUpdateIntervalBox.Location = new System.Drawing.Point(509, 342);
            this._CheckUpdateIntervalBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._CheckUpdateIntervalBox.Name = "_CheckUpdateIntervalBox";
            this._CheckUpdateIntervalBox.Size = new System.Drawing.Size(92, 21);
            this._CheckUpdateIntervalBox.TabIndex = 5;
            // 
            // UpdateForm
            // 
            this.AcceptButton = this._HomePageButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(642, 386);
            this.Controls.Add(this._CheckUpdateIntervalBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._DownloadButton);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._HomePageButton);
            this.Controls.Add(this._InfoBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.Text = "Check for updates";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox _InfoBox;
		private System.Windows.Forms.Button _HomePageButton;
		private System.Windows.Forms.Button _CancelButton;
		private System.Windows.Forms.Button _DownloadButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _CheckUpdateIntervalBox;
	}
}
