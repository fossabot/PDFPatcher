namespace PDFPatcher.Functions
{
	partial class ViewerPreferenceEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerPreferenceEditor));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._ForceInternalLinkBox = new System.Windows.Forms.CheckBox();
            this._ForceRemoveZoomRateBox = new System.Windows.Forms.CheckBox();
            this._ForceBookmarkOpenBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this._ForceInitialModeBox = new System.Windows.Forms.ComboBox();
            this._ForceDirectionBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this._ForceInitialViewBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._HideMenuBox = new System.Windows.Forms.CheckBox();
            this._HideToolbarBox = new System.Windows.Forms.CheckBox();
            this._HideUIBox = new System.Windows.Forms.CheckBox();
            this._FitWindowBox = new System.Windows.Forms.CheckBox();
            this._CenterWindowBox = new System.Windows.Forms.CheckBox();
            this._DisplayDocTitleBox = new System.Windows.Forms.CheckBox();
            this._UISettingsPanel = new System.Windows.Forms.Panel();
            this._OverrideUISettingsBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._UISettingsPanel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._ForceInternalLinkBox);
            this.groupBox2.Controls.Add(this._ForceRemoveZoomRateBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // _ForceInternalLinkBox
            // 
            resources.ApplyResources(this._ForceInternalLinkBox, "_ForceInternalLinkBox");
            this._ForceInternalLinkBox.Name = "_ForceInternalLinkBox";
            this._ForceInternalLinkBox.UseVisualStyleBackColor = true;
            this._ForceInternalLinkBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // _ForceRemoveZoomRateBox
            // 
            resources.ApplyResources(this._ForceRemoveZoomRateBox, "_ForceRemoveZoomRateBox");
            this._ForceRemoveZoomRateBox.Name = "_ForceRemoveZoomRateBox";
            this._ForceRemoveZoomRateBox.UseVisualStyleBackColor = true;
            this._ForceRemoveZoomRateBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // _ForceBookmarkOpenBox
            // 
            this._ForceBookmarkOpenBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ForceBookmarkOpenBox.FormattingEnabled = true;
            resources.ApplyResources(this._ForceBookmarkOpenBox, "_ForceBookmarkOpenBox");
            this._ForceBookmarkOpenBox.Name = "_ForceBookmarkOpenBox";
            this._ForceBookmarkOpenBox.SelectedIndexChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this._ForceBookmarkOpenBox);
            this.groupBox1.Controls.Add(this._ForceInitialModeBox);
            this.groupBox1.Controls.Add(this._ForceDirectionBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._ForceInitialViewBox);
            this.groupBox1.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // _ForceInitialModeBox
            // 
            this._ForceInitialModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ForceInitialModeBox.FormattingEnabled = true;
            resources.ApplyResources(this._ForceInitialModeBox, "_ForceInitialModeBox");
            this._ForceInitialModeBox.Name = "_ForceInitialModeBox";
            this._ForceInitialModeBox.SelectedIndexChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // _ForceDirectionBox
            // 
            this._ForceDirectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ForceDirectionBox.FormattingEnabled = true;
            resources.ApplyResources(this._ForceDirectionBox, "_ForceDirectionBox");
            this._ForceDirectionBox.Name = "_ForceDirectionBox";
            this._ForceDirectionBox.SelectedIndexChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // _ForceInitialViewBox
            // 
            this._ForceInitialViewBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this._ForceInitialViewBox, "_ForceInitialViewBox");
            this._ForceInitialViewBox.Name = "_ForceInitialViewBox";
            this._ForceInitialViewBox.SelectedIndexChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _HideMenuBox
            // 
            resources.ApplyResources(this._HideMenuBox, "_HideMenuBox");
            this._HideMenuBox.Name = "_HideMenuBox";
            this._HideMenuBox.UseVisualStyleBackColor = true;
            this._HideMenuBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // _HideToolbarBox
            // 
            resources.ApplyResources(this._HideToolbarBox, "_HideToolbarBox");
            this._HideToolbarBox.Name = "_HideToolbarBox";
            this._HideToolbarBox.UseVisualStyleBackColor = true;
            this._HideToolbarBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // _HideUIBox
            // 
            resources.ApplyResources(this._HideUIBox, "_HideUIBox");
            this._HideUIBox.Name = "_HideUIBox";
            this._HideUIBox.UseVisualStyleBackColor = true;
            this._HideUIBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // _FitWindowBox
            // 
            resources.ApplyResources(this._FitWindowBox, "_FitWindowBox");
            this._FitWindowBox.Name = "_FitWindowBox";
            this._FitWindowBox.UseVisualStyleBackColor = true;
            this._FitWindowBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // _CenterWindowBox
            // 
            resources.ApplyResources(this._CenterWindowBox, "_CenterWindowBox");
            this._CenterWindowBox.Name = "_CenterWindowBox";
            this._CenterWindowBox.UseVisualStyleBackColor = true;
            this._CenterWindowBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // _DisplayDocTitleBox
            // 
            resources.ApplyResources(this._DisplayDocTitleBox, "_DisplayDocTitleBox");
            this._DisplayDocTitleBox.Name = "_DisplayDocTitleBox";
            this._DisplayDocTitleBox.UseVisualStyleBackColor = true;
            this._DisplayDocTitleBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // _UISettingsPanel
            // 
            this._UISettingsPanel.Controls.Add(this._DisplayDocTitleBox);
            this._UISettingsPanel.Controls.Add(this._HideMenuBox);
            this._UISettingsPanel.Controls.Add(this._CenterWindowBox);
            this._UISettingsPanel.Controls.Add(this._HideToolbarBox);
            this._UISettingsPanel.Controls.Add(this._FitWindowBox);
            this._UISettingsPanel.Controls.Add(this._HideUIBox);
            resources.ApplyResources(this._UISettingsPanel, "_UISettingsPanel");
            this._UISettingsPanel.Name = "_UISettingsPanel";
            // 
            // _OverrideUISettingsBox
            // 
            resources.ApplyResources(this._OverrideUISettingsBox, "_OverrideUISettingsBox");
            this._OverrideUISettingsBox.Name = "_OverrideUISettingsBox";
            this._OverrideUISettingsBox.UseVisualStyleBackColor = true;
            this._OverrideUISettingsBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._OverrideUISettingsBox);
            this.groupBox4.Controls.Add(this._UISettingsPanel);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // ViewerPreferenceEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Name = "ViewerPreferenceEditor";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._UISettingsPanel.ResumeLayout(false);
            this._UISettingsPanel.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox _ForceBookmarkOpenBox;
		private System.Windows.Forms.CheckBox _ForceRemoveZoomRateBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox _ForceInitialModeBox;
		private System.Windows.Forms.ComboBox _ForceDirectionBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox _ForceInitialViewBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox _HideUIBox;
		private System.Windows.Forms.CheckBox _HideToolbarBox;
		private System.Windows.Forms.CheckBox _HideMenuBox;
		private System.Windows.Forms.CheckBox _FitWindowBox;
		private System.Windows.Forms.CheckBox _DisplayDocTitleBox;
		private System.Windows.Forms.CheckBox _CenterWindowBox;
		private System.Windows.Forms.Panel _UISettingsPanel;
		private System.Windows.Forms.CheckBox _OverrideUISettingsBox;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox _ForceInternalLinkBox;
	}
}
