namespace PDFPatcher.Functions
{
	partial class DocumentInfoEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentInfoEditor));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._MetadataPanel = new System.Windows.Forms.Panel();
            this._RewriteXmpBox = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this._KeywordsBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this._SubjectBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this._AuthorBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this._TitleBox = new System.Windows.Forms.TextBox();
            this._ForceMetadataBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this._PropertyMacroMenu = new PDFPatcher.Functions.MacroMenu(this.components);
            this.groupBox4.SuspendLayout();
            this._MetadataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._MetadataPanel);
            this.groupBox4.Controls.Add(this._ForceMetadataBox);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // _MetadataPanel
            // 
            this._MetadataPanel.Controls.Add(this._RewriteXmpBox);
            this._MetadataPanel.Controls.Add(this.label16);
            this._MetadataPanel.Controls.Add(this._KeywordsBox);
            this._MetadataPanel.Controls.Add(this.label17);
            this._MetadataPanel.Controls.Add(this._SubjectBox);
            this._MetadataPanel.Controls.Add(this.label18);
            this._MetadataPanel.Controls.Add(this._AuthorBox);
            this._MetadataPanel.Controls.Add(this.label19);
            this._MetadataPanel.Controls.Add(this._TitleBox);
            resources.ApplyResources(this._MetadataPanel, "_MetadataPanel");
            this._MetadataPanel.Name = "_MetadataPanel";
            // 
            // _RewriteXmpBox
            // 
            resources.ApplyResources(this._RewriteXmpBox, "_RewriteXmpBox");
            this._RewriteXmpBox.Name = "_RewriteXmpBox";
            this._RewriteXmpBox.UseVisualStyleBackColor = true;
            this._RewriteXmpBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // _KeywordsBox
            // 
            resources.ApplyResources(this._KeywordsBox, "_KeywordsBox");
            this._KeywordsBox.Name = "_KeywordsBox";
            this._KeywordsBox.TextChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // _SubjectBox
            // 
            resources.ApplyResources(this._SubjectBox, "_SubjectBox");
            this._SubjectBox.Name = "_SubjectBox";
            this._SubjectBox.TextChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // _AuthorBox
            // 
            resources.ApplyResources(this._AuthorBox, "_AuthorBox");
            this._AuthorBox.Name = "_AuthorBox";
            this._AuthorBox.TextChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // _TitleBox
            // 
            resources.ApplyResources(this._TitleBox, "_TitleBox");
            this._TitleBox.Name = "_TitleBox";
            this._TitleBox.TextChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // _ForceMetadataBox
            // 
            resources.ApplyResources(this._ForceMetadataBox, "_ForceMetadataBox");
            this._ForceMetadataBox.Name = "_ForceMetadataBox";
            this._ForceMetadataBox.UseVisualStyleBackColor = true;
            this._ForceMetadataBox.CheckedChanged += new System.EventHandler(this.DocumentInfoChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _PropertyMacroMenu
            // 
            this._PropertyMacroMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._PropertyMacroMenu.Name = "_PropertyMacroMenu";
            resources.ApplyResources(this._PropertyMacroMenu, "_PropertyMacroMenu");
            // 
            // DocumentInfoEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label5);
            this.Name = "DocumentInfoEditor";
            this.Load += new System.EventHandler(this.DocumentInfoEditor_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this._MetadataPanel.ResumeLayout(false);
            this._MetadataPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Panel _MetadataPanel;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox _KeywordsBox;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox _SubjectBox;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox _AuthorBox;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox _TitleBox;
		private System.Windows.Forms.CheckBox _ForceMetadataBox;
		private System.Windows.Forms.Label label5;
		private Functions.MacroMenu _PropertyMacroMenu;
		private System.Windows.Forms.CheckBox _RewriteXmpBox;
	}
}
