﻿namespace PDFPatcher.Functions
{
	partial class SearchBookmarkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBookmarkForm));
            this._SearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._MatchCaseBox = new System.Windows.Forms.CheckBox();
            this._FullMatchBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this._ReplaceButton = new System.Windows.Forms.Button();
            this._ResultLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._NormalSearchBox = new System.Windows.Forms.RadioButton();
            this._RegexSearchBox = new System.Windows.Forms.RadioButton();
            this._XPathSearchBox = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this._ReplaceInSelectionBox = new System.Windows.Forms.RadioButton();
            this._ReplaceInAllBox = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._SearchNextButton = new System.Windows.Forms.Button();
            this._ReplaceTextBox = new PDFPatcher.HistoryComboBox();
            this._SearchTextBox = new PDFPatcher.HistoryComboBox();
            this._CloseButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _SearchButton
            // 
            resources.ApplyResources(this._SearchButton, "_SearchButton");
            this._SearchButton.Name = "_SearchButton";
            this._SearchButton.UseVisualStyleBackColor = true;
            this._SearchButton.Click += new System.EventHandler(this._SearchButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _MatchCaseBox
            // 
            resources.ApplyResources(this._MatchCaseBox, "_MatchCaseBox");
            this._MatchCaseBox.Name = "_MatchCaseBox";
            this._MatchCaseBox.UseVisualStyleBackColor = true;
            // 
            // _FullMatchBox
            // 
            resources.ApplyResources(this._FullMatchBox, "_FullMatchBox");
            this._FullMatchBox.Name = "_FullMatchBox";
            this._FullMatchBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _ReplaceButton
            // 
            resources.ApplyResources(this._ReplaceButton, "_ReplaceButton");
            this._ReplaceButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._ReplaceButton.Name = "_ReplaceButton";
            this._ReplaceButton.UseVisualStyleBackColor = true;
            this._ReplaceButton.Click += new System.EventHandler(this._ReplaceButton_Click);
            // 
            // _ResultLabel
            // 
            resources.ApplyResources(this._ResultLabel, "_ResultLabel");
            this._ResultLabel.Name = "_ResultLabel";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _NormalSearchBox
            // 
            resources.ApplyResources(this._NormalSearchBox, "_NormalSearchBox");
            this._NormalSearchBox.Name = "_NormalSearchBox";
            this._NormalSearchBox.TabStop = true;
            this._NormalSearchBox.UseVisualStyleBackColor = true;
            this._NormalSearchBox.CheckedChanged += new System.EventHandler(this.MatchModeChanged);
            // 
            // _RegexSearchBox
            // 
            resources.ApplyResources(this._RegexSearchBox, "_RegexSearchBox");
            this._RegexSearchBox.Name = "_RegexSearchBox";
            this._RegexSearchBox.TabStop = true;
            this._RegexSearchBox.UseVisualStyleBackColor = true;
            this._RegexSearchBox.CheckedChanged += new System.EventHandler(this.MatchModeChanged);
            // 
            // _XPathSearchBox
            // 
            resources.ApplyResources(this._XPathSearchBox, "_XPathSearchBox");
            this._XPathSearchBox.Name = "_XPathSearchBox";
            this._XPathSearchBox.TabStop = true;
            this._XPathSearchBox.UseVisualStyleBackColor = true;
            this._XPathSearchBox.CheckedChanged += new System.EventHandler(this.MatchModeChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // _ReplaceInSelectionBox
            // 
            resources.ApplyResources(this._ReplaceInSelectionBox, "_ReplaceInSelectionBox");
            this._ReplaceInSelectionBox.Name = "_ReplaceInSelectionBox";
            this._ReplaceInSelectionBox.TabStop = true;
            this._ReplaceInSelectionBox.UseVisualStyleBackColor = true;
            this._ReplaceInSelectionBox.CheckedChanged += new System.EventHandler(this.ReplaceModeChanged);
            // 
            // _ReplaceInAllBox
            // 
            resources.ApplyResources(this._ReplaceInAllBox, "_ReplaceInAllBox");
            this._ReplaceInAllBox.Name = "_ReplaceInAllBox";
            this._ReplaceInAllBox.TabStop = true;
            this._ReplaceInAllBox.UseVisualStyleBackColor = true;
            this._ReplaceInAllBox.CheckedChanged += new System.EventHandler(this.ReplaceModeChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._ReplaceInAllBox);
            this.panel1.Controls.Add(this._ReplaceInSelectionBox);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._NormalSearchBox);
            this.panel2.Controls.Add(this._XPathSearchBox);
            this.panel2.Controls.Add(this._RegexSearchBox);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // _SearchNextButton
            // 
            resources.ApplyResources(this._SearchNextButton, "_SearchNextButton");
            this._SearchNextButton.Name = "_SearchNextButton";
            this._SearchNextButton.UseVisualStyleBackColor = true;
            this._SearchNextButton.Click += new System.EventHandler(this._SearchButton_Click);
            // 
            // _ReplaceTextBox
            // 
            resources.ApplyResources(this._ReplaceTextBox, "_ReplaceTextBox");
            this._ReplaceTextBox.Contents = null;
            this._ReplaceTextBox.FormattingEnabled = true;
            this._ReplaceTextBox.MaxItemCount = 16;
            this._ReplaceTextBox.Name = "_ReplaceTextBox";
            // 
            // _SearchTextBox
            // 
            resources.ApplyResources(this._SearchTextBox, "_SearchTextBox");
            this._SearchTextBox.Contents = null;
            this._SearchTextBox.FormattingEnabled = true;
            this._SearchTextBox.MaxItemCount = 16;
            this._SearchTextBox.Name = "_SearchTextBox";
            // 
            // _CloseButton
            // 
            resources.ApplyResources(this._CloseButton, "_CloseButton");
            this._CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CloseButton.Name = "_CloseButton";
            this._CloseButton.UseVisualStyleBackColor = true;
            this._CloseButton.Click += new System.EventHandler(this._CloseButton_Click);
            // 
            // SearchBookmarkForm
            // 
            this.AcceptButton = this._SearchButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._CloseButton;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._ReplaceTextBox);
            this.Controls.Add(this._SearchTextBox);
            this.Controls.Add(this._ResultLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._FullMatchBox);
            this.Controls.Add(this._MatchCaseBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._CloseButton);
            this.Controls.Add(this._ReplaceButton);
            this.Controls.Add(this._SearchNextButton);
            this.Controls.Add(this._SearchButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchBookmarkForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.SearchBookmarkForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _SearchButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox _MatchCaseBox;
		private System.Windows.Forms.CheckBox _FullMatchBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button _ReplaceButton;
		private System.Windows.Forms.Label _ResultLabel;
		private HistoryComboBox _SearchTextBox;
		private HistoryComboBox _ReplaceTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton _NormalSearchBox;
		private System.Windows.Forms.RadioButton _RegexSearchBox;
		private System.Windows.Forms.RadioButton _XPathSearchBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton _ReplaceInSelectionBox;
		private System.Windows.Forms.RadioButton _ReplaceInAllBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button _SearchNextButton;
		private System.Windows.Forms.Button _CloseButton;
	}
}

