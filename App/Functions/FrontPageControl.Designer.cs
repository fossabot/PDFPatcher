﻿namespace PDFPatcher
{
    partial class FrontPageControl
    {
        /// <summary>
        /// Required designer variables.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up all resources in use.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code generated by the Windows Forms designer

        /// <summary>
        /// Designer supports required methods - Don't
        /// use a code editor to modify the content of this method.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrontPageControl));
            this._FrontPageBox = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.SuspendLayout();
            // 
            // _FrontPageBox
            // 
            resources.ApplyResources(this._FrontPageBox, "_FrontPageBox");
            this._FrontPageBox.BackColor = System.Drawing.SystemColors.Window;
            this._FrontPageBox.BaseStylesheet = "";
            this._FrontPageBox.IsContextMenuEnabled = false;
            this._FrontPageBox.IsSelectionEnabled = false;
            this._FrontPageBox.Name = "_FrontPageBox";
            this._FrontPageBox.LinkClicked += new System.EventHandler<TheArtOfDev.HtmlRenderer.Core.Entities.HtmlLinkClickedEventArgs>(this._FrontPageBox_LinkClicked);
            this._FrontPageBox.ImageLoad += new System.EventHandler<TheArtOfDev.HtmlRenderer.Core.Entities.HtmlImageLoadEventArgs>(this._FrontPageBox_ImageLoad);
            // 
            // FrontPageControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._FrontPageBox);
            this.Name = "FrontPageControl";
            this.ResumeLayout(false);

        }

        #endregion

        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel _FrontPageBox;

    }
}
