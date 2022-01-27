namespace PDFPatcher.Functions
{
	partial class FontNameConditionEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontNameConditionEditor));
            this.label1 = new System.Windows.Forms.Label();
            this._FontNameBox = new System.Windows.Forms.TextBox();
            this._FullMatchBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _FontNameBox
            // 
            resources.ApplyResources(this._FontNameBox, "_FontNameBox");
            this._FontNameBox.Name = "_FontNameBox";
            this._FontNameBox.TextChanged += new System.EventHandler(this.ControlChanged);
            // 
            // _FullMatchBox
            // 
            resources.ApplyResources(this._FullMatchBox, "_FullMatchBox");
            this._FullMatchBox.Name = "_FullMatchBox";
            this._FullMatchBox.UseVisualStyleBackColor = true;
            this._FullMatchBox.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // FontNameConditionEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._FullMatchBox);
            this.Controls.Add(this._FontNameBox);
            this.Controls.Add(this.label1);
            this.Name = "FontNameConditionEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _FontNameBox;
		private System.Windows.Forms.CheckBox _FullMatchBox;
	}
}
