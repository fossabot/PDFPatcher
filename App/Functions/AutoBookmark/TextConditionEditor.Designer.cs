﻿namespace PDFPatcher.Functions
{
	partial class TextConditionEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this._PatternBox = new System.Windows.Forms.TextBox();
            this._FullMatchBox = new System.Windows.Forms.CheckBox();
            this._MatchCaseBox = new System.Windows.Forms.CheckBox();
            this._UseRegexBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Match the text content:";
            // 
            // _PatternBox
            // 
            this._PatternBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._PatternBox.Location = new System.Drawing.Point(126, 7);
            this._PatternBox.Name = "_PatternBox";
            this._PatternBox.Size = new System.Drawing.Size(321, 20);
            this._PatternBox.TabIndex = 1;
            this._PatternBox.TextChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _FullMatchBox
            // 
            this._FullMatchBox.AutoSize = true;
            this._FullMatchBox.Location = new System.Drawing.Point(5, 36);
            this._FullMatchBox.Name = "_FullMatchBox";
            this._FullMatchBox.Size = new System.Drawing.Size(79, 17);
            this._FullMatchBox.TabIndex = 2;
            this._FullMatchBox.Text = "Fully match";
            this._FullMatchBox.UseVisualStyleBackColor = true;
            this._FullMatchBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _MatchCaseBox
            // 
            this._MatchCaseBox.AutoSize = true;
            this._MatchCaseBox.Location = new System.Drawing.Point(98, 36);
            this._MatchCaseBox.Name = "_MatchCaseBox";
            this._MatchCaseBox.Size = new System.Drawing.Size(119, 17);
            this._MatchCaseBox.TabIndex = 3;
            this._MatchCaseBox.Text = "Match English case";
            this._MatchCaseBox.UseVisualStyleBackColor = true;
            this._MatchCaseBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _UseRegexBox
            // 
            this._UseRegexBox.AutoSize = true;
            this._UseRegexBox.Location = new System.Drawing.Point(223, 36);
            this._UseRegexBox.Name = "_UseRegexBox";
            this._UseRegexBox.Size = new System.Drawing.Size(138, 17);
            this._UseRegexBox.TabIndex = 4;
            this._UseRegexBox.Text = "Use regular expressions";
            this._UseRegexBox.UseVisualStyleBackColor = true;
            this._UseRegexBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // TextConditionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._UseRegexBox);
            this.Controls.Add(this._MatchCaseBox);
            this.Controls.Add(this._FullMatchBox);
            this.Controls.Add(this._PatternBox);
            this.Controls.Add(this.label1);
            this.Name = "TextConditionEditor";
            this.Size = new System.Drawing.Size(380, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _PatternBox;
		private System.Windows.Forms.CheckBox _FullMatchBox;
		private System.Windows.Forms.CheckBox _MatchCaseBox;
		private System.Windows.Forms.CheckBox _UseRegexBox;
	}
}
