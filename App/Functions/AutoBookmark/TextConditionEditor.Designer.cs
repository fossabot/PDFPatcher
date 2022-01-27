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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextConditionEditor));
            this.label1 = new System.Windows.Forms.Label();
            this._PatternBox = new System.Windows.Forms.TextBox();
            this._FullMatchBox = new System.Windows.Forms.CheckBox();
            this._MatchCaseBox = new System.Windows.Forms.CheckBox();
            this._UseRegexBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _PatternBox
            // 
            resources.ApplyResources(this._PatternBox, "_PatternBox");
            this._PatternBox.Name = "_PatternBox";
            this._PatternBox.TextChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _FullMatchBox
            // 
            resources.ApplyResources(this._FullMatchBox, "_FullMatchBox");
            this._FullMatchBox.Name = "_FullMatchBox";
            this._FullMatchBox.UseVisualStyleBackColor = true;
            this._FullMatchBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _MatchCaseBox
            // 
            resources.ApplyResources(this._MatchCaseBox, "_MatchCaseBox");
            this._MatchCaseBox.Name = "_MatchCaseBox";
            this._MatchCaseBox.UseVisualStyleBackColor = true;
            this._MatchCaseBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _UseRegexBox
            // 
            resources.ApplyResources(this._UseRegexBox, "_UseRegexBox");
            this._UseRegexBox.Name = "_UseRegexBox";
            this._UseRegexBox.UseVisualStyleBackColor = true;
            this._UseRegexBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // TextConditionEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._UseRegexBox);
            this.Controls.Add(this._MatchCaseBox);
            this.Controls.Add(this._FullMatchBox);
            this.Controls.Add(this._PatternBox);
            this.Controls.Add(this.label1);
            this.Name = "TextConditionEditor";
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
