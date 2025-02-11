﻿namespace PDFPatcher.Functions
{
	partial class ImageViewerForm
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

		#region Code generated by the Windows Forms designer

		/// <summary>
		/// Designer supports required methods - Don't
		/// use a code editor to modify the content of this method.
		/// </summary>
		private void InitializeComponent () {
            System.Windows.Forms.ToolStripButton _Save;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewerForm));
            System.Windows.Forms.ToolStripButton _ZoomReset;
            this._MainToolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._FitWindow = new System.Windows.Forms.ToolStripButton();
            this._ImageBox = new Cyotek.Windows.Forms.ImageBox();
            _Save = new System.Windows.Forms.ToolStripButton();
            _ZoomReset = new System.Windows.Forms.ToolStripButton();
            this._MainToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Save
            // 
            _Save.Image = global::PDFPatcher.Properties.Resources.Save;
            resources.ApplyResources(_Save, "_Save");
            _Save.Name = "_Save";
            // 
            // _ZoomReset
            // 
            _ZoomReset.Image = global::PDFPatcher.Properties.Resources.Zoom;
            resources.ApplyResources(_ZoomReset, "_ZoomReset");
            _ZoomReset.Name = "_ZoomReset";
            // 
            // _MainToolbar
            // 
            this._MainToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _Save,
            this.toolStripSeparator1,
            _ZoomReset,
            this._FitWindow});
            resources.ApplyResources(this._MainToolbar, "_MainToolbar");
            this._MainToolbar.Name = "_MainToolbar";
            this._MainToolbar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._MainToolbar_ItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // _FitWindow
            // 
            this._FitWindow.Image = global::PDFPatcher.Properties.Resources.Image;
            resources.ApplyResources(this._FitWindow, "_FitWindow");
            this._FitWindow.Name = "_FitWindow";
            // 
            // _ImageBox
            // 
            resources.ApplyResources(this._ImageBox, "_ImageBox");
            this._ImageBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ImageBox.Name = "_ImageBox";
            this._ImageBox.TabStop = false;
            // 
            // ImageViewerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._MainToolbar);
            this.Controls.Add(this._ImageBox);
            this.Name = "ImageViewerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this._MainToolbar.ResumeLayout(false);
            this._MainToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Cyotek.Windows.Forms.ImageBox _ImageBox;
		private System.Windows.Forms.ToolStrip _MainToolbar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton _FitWindow;
	}
}
