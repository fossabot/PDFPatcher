namespace PDFPatcher.Functions
{
	partial class PageRangeConditionEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageRangeConditionEditor));
            this.label1 = new System.Windows.Forms.Label();
            this._PageRangeBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _PageRangeBox
            // 
            resources.ApplyResources(this._PageRangeBox, "_PageRangeBox");
            this._PageRangeBox.Name = "_PageRangeBox";
            this._PageRangeBox.TextChanged += new System.EventHandler(this.ControlChanged);
            // 
            // PageRangeConditionEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._PageRangeBox);
            this.Controls.Add(this.label1);
            this.Name = "PageRangeConditionEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _PageRangeBox;


	}
}
