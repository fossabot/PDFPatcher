namespace PDFPatcher.Functions
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
			this.label1 = new System.Windows.Forms.Label ();
			this._PatternBox = new System.Windows.Forms.TextBox ();
			this._FullMatchBox = new System.Windows.Forms.CheckBox ();
			this._MatchCaseBox = new System.Windows.Forms.CheckBox ();
			this._UseRegexBox = new System.Windows.Forms.CheckBox ();
			this.SuspendLayout ();
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point (3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (89, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "匹配文本内容：";
			//
			// _PatternBox
			//
			this._PatternBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._PatternBox.Location = new System.Drawing.Point (98, 6);
			this._PatternBox.Name = "_PatternBox";
			this._PatternBox.Size = new System.Drawing.Size (238, 21);
			this._PatternBox.TabIndex = 1;
			this._PatternBox.TextChanged += new System.EventHandler (this.ControlChanged);
			//
			// _FullMatchBox
			//
			this._FullMatchBox.AutoSize = true;
			this._FullMatchBox.Location = new System.Drawing.Point (5, 33);
			this._FullMatchBox.Name = "_FullMatchBox";
			this._FullMatchBox.Size = new System.Drawing.Size (72, 16);
			this._FullMatchBox.TabIndex = 2;
			this._FullMatchBox.Text = "完全匹配";
			this._FullMatchBox.UseVisualStyleBackColor = true;
			this._FullMatchBox.CheckedChanged += new System.EventHandler (this.ControlChanged);
			//
			// _MatchCaseBox
			//
			this._MatchCaseBox.AutoSize = true;
			this._MatchCaseBox.Location = new System.Drawing.Point (98, 33);
			this._MatchCaseBox.Name = "_MatchCaseBox";
			this._MatchCaseBox.Size = new System.Drawing.Size (108, 16);
			this._MatchCaseBox.TabIndex = 3;
			this._MatchCaseBox.Text = "匹配英文大小写";
			this._MatchCaseBox.UseVisualStyleBackColor = true;
			this._MatchCaseBox.CheckedChanged += new System.EventHandler (this.ControlChanged);
			//
			// _UseRegexBox
			//
			this._UseRegexBox.AutoSize = true;
			this._UseRegexBox.Location = new System.Drawing.Point (212, 33);
			this._UseRegexBox.Name = "_UseRegexBox";
			this._UseRegexBox.Size = new System.Drawing.Size (108, 16);
			this._UseRegexBox.TabIndex = 4;
			this._UseRegexBox.Text = "使用正则表达式";
			this._UseRegexBox.UseVisualStyleBackColor = true;
			this._UseRegexBox.CheckedChanged += new System.EventHandler (this.ControlChanged);
			//
			// TextConditionEditor
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this._UseRegexBox);
			this.Controls.Add (this._MatchCaseBox);
			this.Controls.Add (this._FullMatchBox);
			this.Controls.Add (this._PatternBox);
			this.Controls.Add (this.label1);
			this.Name = "TextConditionEditor";
			this.Size = new System.Drawing.Size (339, 80);
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _PatternBox;
		private System.Windows.Forms.CheckBox _FullMatchBox;
		private System.Windows.Forms.CheckBox _MatchCaseBox;
		private System.Windows.Forms.CheckBox _UseRegexBox;
	}
}
