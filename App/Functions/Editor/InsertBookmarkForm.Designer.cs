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
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bookmark text:";
            // 
            // _TitleBox
            // 
            this._TitleBox.Location = new System.Drawing.Point(96, 13);
            this._TitleBox.Name = "_TitleBox";
            this._TitleBox.Size = new System.Drawing.Size(308, 20);
            this._TitleBox.TabIndex = 1;
            // 
            // _OkButton
            // 
            this._OkButton.Image = global::PDFPatcher.Properties.Resources.ImportInfoFile;
            this._OkButton.Location = new System.Drawing.Point(329, 70);
            this._OkButton.Name = "_OkButton";
            this._OkButton.Size = new System.Drawing.Size(75, 25);
            this._OkButton.TabIndex = 12;
            this._OkButton.Text = "Insert (&C)";
            this._OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._OkButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Insert to the current bookmark:";
            // 
            // _CancelButton
            // 
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(329, 101);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 25);
            this._CancelButton.TabIndex = 13;
            this._CancelButton.Text = "Cancel (&X)";
            this._CancelButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Target location:";
            // 
            // _PositionBox
            // 
            this._PositionBox.DecimalPlaces = 2;
            this._PositionBox.Location = new System.Drawing.Point(212, 150);
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
            this._PositionBox.Size = new System.Drawing.Size(68, 20);
            this._PositionBox.TabIndex = 11;
            // 
            // _PageLabel
            // 
            this._PageLabel.AutoSize = true;
            this._PageLabel.Location = new System.Drawing.Point(99, 153);
            this._PageLabel.Name = "_PageLabel";
            this._PageLabel.Size = new System.Drawing.Size(51, 13);
            this._PageLabel.TabIndex = 9;
            this._PageLabel.Text = "Nth page";
            // 
            // _DirectionBox
            // 
            this._DirectionBox.AutoSize = true;
            this._DirectionBox.Location = new System.Drawing.Point(165, 153);
            this._DirectionBox.Name = "_DirectionBox";
            this._DirectionBox.Size = new System.Drawing.Size(46, 13);
            this._DirectionBox.TabIndex = 10;
            this._DirectionBox.Text = "position:";
            // 
            // _CommentBox
            // 
            this._CommentBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this._CommentBox.Location = new System.Drawing.Point(83, 39);
            this._CommentBox.Name = "_CommentBox";
            this._CommentBox.Size = new System.Drawing.Size(275, 13);
            this._CommentBox.TabIndex = 14;
            // 
            // _AfterParentBox
            // 
            this._AfterParentBox.AutoSize = true;
            this._AfterParentBox.Location = new System.Drawing.Point(154, 98);
            this._AfterParentBox.Name = "_AfterParentBox";
            this._AfterParentBox.Size = new System.Drawing.Size(155, 17);
            this._AfterParentBox.TabIndex = 6;
            this._AfterParentBox.Text = "&After the superior bookmark";
            this._AfterParentBox.UseVisualStyleBackColor = true;
            // 
            // _BeforeCurrentBox
            // 
            this._BeforeCurrentBox.AutoSize = true;
            this._BeforeCurrentBox.Location = new System.Drawing.Point(34, 74);
            this._BeforeCurrentBox.Name = "_BeforeCurrentBox";
            this._BeforeCurrentBox.Size = new System.Drawing.Size(49, 17);
            this._BeforeCurrentBox.TabIndex = 3;
            this._BeforeCurrentBox.Text = "&Front";
            this._BeforeCurrentBox.UseVisualStyleBackColor = true;
            // 
            // _AsChildBox
            // 
            this._AsChildBox.AutoSize = true;
            this._AsChildBox.Location = new System.Drawing.Point(34, 98);
            this._AsChildBox.Name = "_AsChildBox";
            this._AsChildBox.Size = new System.Drawing.Size(98, 17);
            this._AsChildBox.TabIndex = 5;
            this._AsChildBox.Text = "&Child bookmark";
            this._AsChildBox.UseVisualStyleBackColor = true;
            // 
            // _AfterCurrentBox
            // 
            this._AfterCurrentBox.AutoSize = true;
            this._AfterCurrentBox.Checked = true;
            this._AfterCurrentBox.Location = new System.Drawing.Point(119, 74);
            this._AfterCurrentBox.Name = "_AfterCurrentBox";
            this._AfterCurrentBox.Size = new System.Drawing.Size(50, 17);
            this._AfterCurrentBox.TabIndex = 4;
            this._AfterCurrentBox.TabStop = true;
            this._AfterCurrentBox.Text = "&Back";
            this._AfterCurrentBox.UseVisualStyleBackColor = true;
            // 
            // _ReplaceBookmarkBox
            // 
            this._ReplaceBookmarkBox.AutoSize = true;
            this._ReplaceBookmarkBox.Location = new System.Drawing.Point(14, 121);
            this._ReplaceBookmarkBox.Name = "_ReplaceBookmarkBox";
            this._ReplaceBookmarkBox.Size = new System.Drawing.Size(169, 17);
            this._ReplaceBookmarkBox.TabIndex = 7;
            this._ReplaceBookmarkBox.TabStop = true;
            this._ReplaceBookmarkBox.Text = "&Replace the current bookmark";
            this._ReplaceBookmarkBox.UseVisualStyleBackColor = true;
            // 
            // InsertBookmarkForm
            // 
            this.AcceptButton = this._OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(421, 185);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Insert bookmark";
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
