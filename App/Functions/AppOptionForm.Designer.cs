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
            this._DocInfoEncodingBox.Location = new System.Drawing.Point(125, 46);
            this._DocInfoEncodingBox.Margin = new System.Windows.Forms.Padding(4);
            this._DocInfoEncodingBox.Name = "_DocInfoEncodingBox";
            this._DocInfoEncodingBox.Size = new System.Drawing.Size(177, 21);
            this._DocInfoEncodingBox.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 50);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Document Properties:";
            // 
            // _BookmarkEncodingBox
            // 
            this._BookmarkEncodingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._BookmarkEncodingBox.FormattingEnabled = true;
            this._BookmarkEncodingBox.Location = new System.Drawing.Point(442, 46);
            this._BookmarkEncodingBox.Margin = new System.Windows.Forms.Padding(4);
            this._BookmarkEncodingBox.Name = "_BookmarkEncodingBox";
            this._BookmarkEncodingBox.Size = new System.Drawing.Size(177, 21);
            this._BookmarkEncodingBox.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 50);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Bookmark text:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._LoadPartialFileBox);
            this.groupBox1.Controls.Add(this._LoadEntireFileBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(625, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Access PDF documentation";
            // 
            // _LoadPartialFileBox
            // 
            this._LoadPartialFileBox.AutoSize = true;
            this._LoadPartialFileBox.Location = new System.Drawing.Point(282, 25);
            this._LoadPartialFileBox.Margin = new System.Windows.Forms.Padding(4);
            this._LoadPartialFileBox.Name = "_LoadPartialFileBox";
            this._LoadPartialFileBox.Size = new System.Drawing.Size(334, 17);
            this._LoadPartialFileBox.TabIndex = 1;
            this._LoadPartialFileBox.TabStop = true;
            this._LoadPartialFileBox.Text = "Reduce the occupation of memory (Only load the processing part)";
            this._LoadPartialFileBox.UseVisualStyleBackColor = true;
            // 
            // _LoadEntireFileBox
            // 
            this._LoadEntireFileBox.AutoSize = true;
            this._LoadEntireFileBox.Location = new System.Drawing.Point(11, 25);
            this._LoadEntireFileBox.Margin = new System.Windows.Forms.Padding(4);
            this._LoadEntireFileBox.Name = "_LoadEntireFileBox";
            this._LoadEntireFileBox.Size = new System.Drawing.Size(263, 17);
            this._LoadEntireFileBox.TabIndex = 0;
            this._LoadEntireFileBox.TabStop = true;
            this._LoadEntireFileBox.Text = "Optimize processing efficiency (Load the entire file)";
            this._LoadEntireFileBox.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(8, 21);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(612, 21);
            this.label12.TabIndex = 6;
            this.label12.Text = "Note: When the text of the PDF document is garbled, you can try to use this optio" +
    "n to force the setting encoding.";
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
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 108);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(628, 114);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Read the encoding used by the document";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Font Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Text text:";
            // 
            // _FontNameEncodingBox
            // 
            this._FontNameEncodingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._FontNameEncodingBox.FormattingEnabled = true;
            this._FontNameEncodingBox.Location = new System.Drawing.Point(442, 79);
            this._FontNameEncodingBox.Margin = new System.Windows.Forms.Padding(4);
            this._FontNameEncodingBox.Name = "_FontNameEncodingBox";
            this._FontNameEncodingBox.Size = new System.Drawing.Size(177, 21);
            this._FontNameEncodingBox.TabIndex = 3;
            // 
            // _TextEncodingBox
            // 
            this._TextEncodingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._TextEncodingBox.FormattingEnabled = true;
            this._TextEncodingBox.Location = new System.Drawing.Point(125, 79);
            this._TextEncodingBox.Margin = new System.Windows.Forms.Padding(4);
            this._TextEncodingBox.Name = "_TextEncodingBox";
            this._TextEncodingBox.Size = new System.Drawing.Size(177, 21);
            this._TextEncodingBox.TabIndex = 3;
            // 
            // _SaveAppSettingsBox
            // 
            this._SaveAppSettingsBox.AutoSize = true;
            this._SaveAppSettingsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._SaveAppSettingsBox.Location = new System.Drawing.Point(16, 15);
            this._SaveAppSettingsBox.Margin = new System.Windows.Forms.Padding(4);
            this._SaveAppSettingsBox.Name = "_SaveAppSettingsBox";
            this._SaveAppSettingsBox.Size = new System.Drawing.Size(207, 17);
            this._SaveAppSettingsBox.TabIndex = 11;
            this._SaveAppSettingsBox.Text = "Automatically save application settings";
            this._SaveAppSettingsBox.UseVisualStyleBackColor = true;
            // 
            // _CreateShortcutButton
            // 
            this._CreateShortcutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CreateShortcutButton.Location = new System.Drawing.Point(324, 8);
            this._CreateShortcutButton.Margin = new System.Windows.Forms.Padding(4);
            this._CreateShortcutButton.Name = "_CreateShortcutButton";
            this._CreateShortcutButton.Size = new System.Drawing.Size(278, 29);
            this._CreateShortcutButton.TabIndex = 12;
            this._CreateShortcutButton.Text = "Create a program shortcut at desktop";
            this._CreateShortcutButton.UseVisualStyleBackColor = true;
            this._CreateShortcutButton.Click += new System.EventHandler(this._CreateShortcutButton_Click);
            // 
            // AppOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 334);
            this.Controls.Add(this._CreateShortcutButton);
            this.Controls.Add(this._SaveAppSettingsBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppOptionForm";
            this.Text = "Program work option";
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
