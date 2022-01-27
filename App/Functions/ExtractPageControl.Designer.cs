namespace PDFPatcher.Functions
{
	partial class ExtractPageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractPageControl));
            this._ExtractPageRangeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._KeepBookmarkBox = new System.Windows.Forms.CheckBox();
            this._RemoveOrphanBoomarksBox = new System.Windows.Forms.CheckBox();
            this._KeepDocInfoPropertyBox = new System.Windows.Forms.CheckBox();
            this._SourceFileControl = new PDFPatcher.SourceFileControl();
            this._TargetFileControl = new PDFPatcher.TargetFileControl();
            this._RemoveRestrictionBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this._ExcludePageRangeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._SeparatingModeBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._NumberFileNamesBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this._SeperateByPageNumberBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._ExtractButton = new EnhancedGlassButton.GlassButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SeperateByPageNumberBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ExtractPageRangeBox
            // 
            resources.ApplyResources(this._ExtractPageRangeBox, "_ExtractPageRangeBox");
            this._ExtractPageRangeBox.Name = "_ExtractPageRangeBox";
            this._ExtractPageRangeBox.TextChanged += new System.EventHandler(this._ExtractPageRangeBox_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _KeepBookmarkBox
            // 
            resources.ApplyResources(this._KeepBookmarkBox, "_KeepBookmarkBox");
            this._KeepBookmarkBox.Name = "_KeepBookmarkBox";
            this._KeepBookmarkBox.UseVisualStyleBackColor = true;
            // 
            // _RemoveOrphanBoomarksBox
            // 
            resources.ApplyResources(this._RemoveOrphanBoomarksBox, "_RemoveOrphanBoomarksBox");
            this._RemoveOrphanBoomarksBox.Name = "_RemoveOrphanBoomarksBox";
            this._RemoveOrphanBoomarksBox.UseVisualStyleBackColor = true;
            // 
            // _KeepDocInfoPropertyBox
            // 
            resources.ApplyResources(this._KeepDocInfoPropertyBox, "_KeepDocInfoPropertyBox");
            this._KeepDocInfoPropertyBox.Name = "_KeepDocInfoPropertyBox";
            this._KeepDocInfoPropertyBox.UseVisualStyleBackColor = true;
            // 
            // _SourceFileControl
            // 
            resources.ApplyResources(this._SourceFileControl, "_SourceFileControl");
            this._SourceFileControl.Name = "_SourceFileControl";
            // 
            // _TargetFileControl
            // 
            resources.ApplyResources(this._TargetFileControl, "_TargetFileControl");
            this._TargetFileControl.Name = "_TargetFileControl";
            // 
            // _RemoveRestrictionBox
            // 
            resources.ApplyResources(this._RemoveRestrictionBox, "_RemoveRestrictionBox");
            this._RemoveRestrictionBox.Name = "_RemoveRestrictionBox";
            this._RemoveRestrictionBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _ExcludePageRangeBox
            // 
            resources.ApplyResources(this._ExcludePageRangeBox, "_ExcludePageRangeBox");
            this._ExcludePageRangeBox.Name = "_ExcludePageRangeBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _SeparatingModeBox
            // 
            this._SeparatingModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._SeparatingModeBox.FormattingEnabled = true;
            this._SeparatingModeBox.Items.AddRange(new object[] {
            resources.GetString("_SeparatingModeBox.Items"),
            resources.GetString("_SeparatingModeBox.Items1"),
            resources.GetString("_SeparatingModeBox.Items2")});
            resources.ApplyResources(this._SeparatingModeBox, "_SeparatingModeBox");
            this._SeparatingModeBox.Name = "_SeparatingModeBox";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._KeepDocInfoPropertyBox);
            this.groupBox2.Controls.Add(this._RemoveOrphanBoomarksBox);
            this.groupBox2.Controls.Add(this._RemoveRestrictionBox);
            this.groupBox2.Controls.Add(this._KeepBookmarkBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._NumberFileNamesBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._SeperateByPageNumberBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._SeparatingModeBox);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _NumberFileNamesBox
            // 
            resources.ApplyResources(this._NumberFileNamesBox, "_NumberFileNamesBox");
            this._NumberFileNamesBox.Name = "_NumberFileNamesBox";
            this._NumberFileNamesBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _SeperateByPageNumberBox
            // 
            resources.ApplyResources(this._SeperateByPageNumberBox, "_SeperateByPageNumberBox");
            this._SeperateByPageNumberBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._SeperateByPageNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._SeperateByPageNumberBox.Name = "_SeperateByPageNumberBox";
            this._SeperateByPageNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // _ExtractButton
            // 
            this._ExtractButton.AlternativeFocusBorderColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this._ExtractButton, "_ExtractButton");
            this._ExtractButton.AnimateGlow = true;
            this._ExtractButton.BackColor = System.Drawing.SystemColors.Highlight;
            this._ExtractButton.CornerRadius = 3;
            this._ExtractButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ExtractButton.GlowColor = System.Drawing.Color.White;
            this._ExtractButton.Image = global::PDFPatcher.Properties.Resources.Save;
            this._ExtractButton.InnerBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this._ExtractButton.Name = "_ExtractButton";
            this._ExtractButton.OuterBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this._ExtractButton.ShowFocusBorder = true;
            this._ExtractButton.Click += new System.EventHandler(this._ExtractButton_Click);
            // 
            // ExtractPageControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ExtractButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this._ExcludePageRangeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._SourceFileControl);
            this.Controls.Add(this._ExtractPageRangeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._TargetFileControl);
            this.Name = "ExtractPageControl";
            this.Load += new System.EventHandler(this.ExtractPageControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SeperateByPageNumberBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _ExtractPageRangeBox;
		private System.Windows.Forms.Label label3;
		private SourceFileControl _SourceFileControl;
		private TargetFileControl _TargetFileControl;
		private System.Windows.Forms.CheckBox _KeepBookmarkBox;
		private System.Windows.Forms.CheckBox _RemoveOrphanBoomarksBox;
		private System.Windows.Forms.CheckBox _KeepDocInfoPropertyBox;
		private System.Windows.Forms.CheckBox _RemoveRestrictionBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox _ExcludePageRangeBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _SeparatingModeBox;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown _SeperateByPageNumberBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox _NumberFileNamesBox;
		private EnhancedGlassButton.GlassButton _ExtractButton;
	}
}
