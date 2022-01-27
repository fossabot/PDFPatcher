namespace PDFPatcher.Functions.Editor
{
	partial class InsertBookmarkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertBookmarkForm));
            this.label1 = new System.Windows.Forms.Label();
            this._TitleBox = new System.Windows.Forms.TextBox();
            this._OkButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._CancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._PositionBox = new System.Windows.Forms.NumericUpDown();
            this._PageLabel = new System.Windows.Forms.Label();
            this._DirectionBox = new System.Windows.Forms.Label();
            this._CommentBox = new System.Windows.Forms.Label();
            this._AfterParentBox = new PDFPatcher.Functions.DoubleClickableRadioButton();
            this._BeforeCurrentBox = new PDFPatcher.Functions.DoubleClickableRadioButton();
            this._AsChildBox = new PDFPatcher.Functions.DoubleClickableRadioButton();
            this._AfterCurrentBox = new PDFPatcher.Functions.DoubleClickableRadioButton();
            this._ReplaceBookmarkBox = new PDFPatcher.Functions.DoubleClickableRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this._PositionBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _TitleBox
            // 
            resources.ApplyResources(this._TitleBox, "_TitleBox");
            this._TitleBox.Name = "_TitleBox";
            // 
            // _OkButton
            // 
            this._OkButton.Image = global::PDFPatcher.Properties.Resources.ImportInfoFile;
            resources.ApplyResources(this._OkButton, "_OkButton");
            this._OkButton.Name = "_OkButton";
            this._OkButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _CancelButton
            // 
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._CancelButton, "_CancelButton");
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _PositionBox
            // 
            this._PositionBox.DecimalPlaces = 2;
            resources.ApplyResources(this._PositionBox, "_PositionBox");
            this._PositionBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this._PositionBox.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this._PositionBox.Name = "_PositionBox";
            // 
            // _PageLabel
            // 
            resources.ApplyResources(this._PageLabel, "_PageLabel");
            this._PageLabel.Name = "_PageLabel";
            // 
            // _DirectionBox
            // 
            resources.ApplyResources(this._DirectionBox, "_DirectionBox");
            this._DirectionBox.Name = "_DirectionBox";
            // 
            // _CommentBox
            // 
            this._CommentBox.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(this._CommentBox, "_CommentBox");
            this._CommentBox.Name = "_CommentBox";
            // 
            // _AfterParentBox
            // 
            resources.ApplyResources(this._AfterParentBox, "_AfterParentBox");
            this._AfterParentBox.Name = "_AfterParentBox";
            this._AfterParentBox.UseVisualStyleBackColor = true;
            // 
            // _BeforeCurrentBox
            // 
            resources.ApplyResources(this._BeforeCurrentBox, "_BeforeCurrentBox");
            this._BeforeCurrentBox.Name = "_BeforeCurrentBox";
            this._BeforeCurrentBox.UseVisualStyleBackColor = true;
            // 
            // _AsChildBox
            // 
            resources.ApplyResources(this._AsChildBox, "_AsChildBox");
            this._AsChildBox.Name = "_AsChildBox";
            this._AsChildBox.UseVisualStyleBackColor = true;
            // 
            // _AfterCurrentBox
            // 
            resources.ApplyResources(this._AfterCurrentBox, "_AfterCurrentBox");
            this._AfterCurrentBox.Checked = true;
            this._AfterCurrentBox.Name = "_AfterCurrentBox";
            this._AfterCurrentBox.TabStop = true;
            this._AfterCurrentBox.UseVisualStyleBackColor = true;
            // 
            // _ReplaceBookmarkBox
            // 
            resources.ApplyResources(this._ReplaceBookmarkBox, "_ReplaceBookmarkBox");
            this._ReplaceBookmarkBox.Name = "_ReplaceBookmarkBox";
            this._ReplaceBookmarkBox.TabStop = true;
            this._ReplaceBookmarkBox.UseVisualStyleBackColor = true;
            // 
            // InsertBookmarkForm
            // 
            this.AcceptButton = this._OkButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._CancelButton;
            this.Controls.Add(this._ReplaceBookmarkBox);
            this.Controls.Add(this._CommentBox);
            this.Controls.Add(this._DirectionBox);
            this.Controls.Add(this._PageLabel);
            this.Controls.Add(this._PositionBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._AfterParentBox);
            this.Controls.Add(this._BeforeCurrentBox);
            this.Controls.Add(this._AsChildBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._AfterCurrentBox);
            this.Controls.Add(this._OkButton);
            this.Controls.Add(this._TitleBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InsertBookmarkForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this._PositionBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _TitleBox;
		private System.Windows.Forms.Button _OkButton;
		private DoubleClickableRadioButton _AfterCurrentBox;
		private System.Windows.Forms.Label label2;
		private DoubleClickableRadioButton _AsChildBox;
		private DoubleClickableRadioButton _BeforeCurrentBox;
		private DoubleClickableRadioButton _AfterParentBox;
		private System.Windows.Forms.Button _CancelButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown _PositionBox;
		private System.Windows.Forms.Label _PageLabel;
		private System.Windows.Forms.Label _DirectionBox;
		private System.Windows.Forms.Label _CommentBox;
		private DoubleClickableRadioButton _ReplaceBookmarkBox;
	}
}
