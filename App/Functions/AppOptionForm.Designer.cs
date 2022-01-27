namespace PDFPatcher.Functions
{
    partial class AppOptionForm
    {
        /// <summary>
        /// Required designer variables.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean all the resources being used.
        /// </summary>
        /// <param name="disposing">If the hosted resource should be released, true; otherwise false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component designer generated code

        /// <summary>
        /// Designer supports the required method - do not
        /// Use the code editor to modify the contents of this method.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppOptionForm));
            this._DocInfoEncodingBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this._BookmarkEncodingBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._LoadPartialFileBox = new System.Windows.Forms.RadioButton();
            this._LoadEntireFileBox = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._FontNameEncodingBox = new System.Windows.Forms.ComboBox();
            this._TextEncodingBox = new System.Windows.Forms.ComboBox();
            this._SaveAppSettingsBox = new System.Windows.Forms.CheckBox();
            this._CreateShortcutButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _DocInfoEncodingBox
            // 
            this._DocInfoEncodingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._DocInfoEncodingBox.FormattingEnabled = true;
            resources.ApplyResources(this._DocInfoEncodingBox, "_DocInfoEncodingBox");
            this._DocInfoEncodingBox.Name = "_DocInfoEncodingBox";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // _BookmarkEncodingBox
            // 
            this._BookmarkEncodingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._BookmarkEncodingBox.FormattingEnabled = true;
            resources.ApplyResources(this._BookmarkEncodingBox, "_BookmarkEncodingBox");
            this._BookmarkEncodingBox.Name = "_BookmarkEncodingBox";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._LoadPartialFileBox);
            this.groupBox1.Controls.Add(this._LoadEntireFileBox);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _LoadPartialFileBox
            // 
            resources.ApplyResources(this._LoadPartialFileBox, "_LoadPartialFileBox");
            this._LoadPartialFileBox.Name = "_LoadPartialFileBox";
            this._LoadPartialFileBox.TabStop = true;
            this._LoadPartialFileBox.UseVisualStyleBackColor = true;
            // 
            // _LoadEntireFileBox
            // 
            resources.ApplyResources(this._LoadEntireFileBox, "_LoadEntireFileBox");
            this._LoadEntireFileBox.Name = "_LoadEntireFileBox";
            this._LoadEntireFileBox.TabStop = true;
            this._LoadEntireFileBox.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this._FontNameEncodingBox);
            this.groupBox2.Controls.Add(this._TextEncodingBox);
            this.groupBox2.Controls.Add(this._DocInfoEncodingBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this._BookmarkEncodingBox);
            this.groupBox2.Controls.Add(this.label11);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _FontNameEncodingBox
            // 
            this._FontNameEncodingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._FontNameEncodingBox.FormattingEnabled = true;
            resources.ApplyResources(this._FontNameEncodingBox, "_FontNameEncodingBox");
            this._FontNameEncodingBox.Name = "_FontNameEncodingBox";
            // 
            // _TextEncodingBox
            // 
            this._TextEncodingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._TextEncodingBox.FormattingEnabled = true;
            resources.ApplyResources(this._TextEncodingBox, "_TextEncodingBox");
            this._TextEncodingBox.Name = "_TextEncodingBox";
            // 
            // _SaveAppSettingsBox
            // 
            resources.ApplyResources(this._SaveAppSettingsBox, "_SaveAppSettingsBox");
            this._SaveAppSettingsBox.Name = "_SaveAppSettingsBox";
            this._SaveAppSettingsBox.UseVisualStyleBackColor = true;
            // 
            // _CreateShortcutButton
            // 
            resources.ApplyResources(this._CreateShortcutButton, "_CreateShortcutButton");
            this._CreateShortcutButton.Name = "_CreateShortcutButton";
            this._CreateShortcutButton.UseVisualStyleBackColor = true;
            this._CreateShortcutButton.Click += new System.EventHandler(this._CreateShortcutButton_Click);
            // 
            // AppOptionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._CreateShortcutButton);
            this.Controls.Add(this._SaveAppSettingsBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppOptionForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _DocInfoEncodingBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox _BookmarkEncodingBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton _LoadEntireFileBox;
        private System.Windows.Forms.RadioButton _LoadPartialFileBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _TextEncodingBox;
        private System.Windows.Forms.CheckBox _SaveAppSettingsBox;
        private System.Windows.Forms.Button _CreateShortcutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _FontNameEncodingBox;
    }
}
