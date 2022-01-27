﻿namespace PDFPatcher.Functions
{
	partial class ZoomRateEntryForm
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
            this._OkButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this._MessageLabel = new System.Windows.Forms.Label();
            this._ZoomRateBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _OkButton
            // 
            this._OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OkButton.Location = new System.Drawing.Point(129, 99);
            this._OkButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._OkButton.Name = "_OkButton";
            this._OkButton.Size = new System.Drawing.Size(100, 31);
            this._OkButton.TabIndex = 0;
            this._OkButton.Text = "&OK";
            this._OkButton.UseVisualStyleBackColor = true;
            this._OkButton.Click += new System.EventHandler(this._OkButton_Click);
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(237, 99);
            this._CancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(100, 31);
            this._CancelButton.TabIndex = 1;
            this._CancelButton.Text = "&Cancel";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // _MessageLabel
            // 
            this._MessageLabel.AutoSize = true;
            this._MessageLabel.Location = new System.Drawing.Point(16, 44);
            this._MessageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._MessageLabel.Name = "_MessageLabel";
            this._MessageLabel.Size = new System.Drawing.Size(93, 20);
            this._MessageLabel.TabIndex = 2;
            this._MessageLabel.Text = "Zoom ratio:";
            // 
            // _ZoomRateBox
            // 
            this._ZoomRateBox.FormattingEnabled = true;
            this._ZoomRateBox.Items.AddRange(new object[] {
            "1",
            "constant",
            "——————",
            "4",
            "3",
            "2",
            "1.5",
            "1.3",
            "1.2",
            "1",
            "0.9",
            "0.8",
            "0.5",
            "0.3",
            "0.2"});
            this._ZoomRateBox.Location = new System.Drawing.Point(175, 40);
            this._ZoomRateBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._ZoomRateBox.Name = "_ZoomRateBox";
            this._ZoomRateBox.Size = new System.Drawing.Size(160, 24);
            this._ZoomRateBox.TabIndex = 3;
            // 
            // ZoomRateEntryForm
            // 
            this.AcceptButton = this._OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(353, 145);
            this.Controls.Add(this._ZoomRateBox);
            this.Controls.Add(this._MessageLabel);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZoomRateEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter zoom ratio";
            this.Load += new System.EventHandler(this.ZoomRateEntryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _OkButton;
		private System.Windows.Forms.Button _CancelButton;
		private System.Windows.Forms.Label _MessageLabel;
		private System.Windows.Forms.ComboBox _ZoomRateBox;
	}
}

