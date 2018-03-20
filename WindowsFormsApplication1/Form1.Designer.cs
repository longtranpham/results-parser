using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.processButton = new System.Windows.Forms.Button();
            this.dragFolderLabel = new System.Windows.Forms.Label();
            this.numberFiles = new System.Windows.Forms.Label();
            this.fileCountLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.fileList = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.version = new System.Windows.Forms.Label();
            this.compareButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Location = new System.Drawing.Point(42, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 1;
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(82, 362);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(110, 39);
            this.processButton.TabIndex = 0;
            this.processButton.Text = "Process results";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // dragFolderLabel
            // 
            this.dragFolderLabel.AutoSize = true;
            this.dragFolderLabel.Location = new System.Drawing.Point(89, 64);
            this.dragFolderLabel.Name = "dragFolderLabel";
            this.dragFolderLabel.Size = new System.Drawing.Size(88, 13);
            this.dragFolderLabel.TabIndex = 1;
            this.dragFolderLabel.Text = "Drag folders here";
            // 
            // numberFiles
            // 
            this.numberFiles.AutoSize = true;
            this.numberFiles.Location = new System.Drawing.Point(89, 88);
            this.numberFiles.Name = "numberFiles";
            this.numberFiles.Size = new System.Drawing.Size(83, 13);
            this.numberFiles.TabIndex = 2;
            this.numberFiles.Text = "Number of files: ";
            // 
            // fileCountLabel
            // 
            this.fileCountLabel.AutoSize = true;
            this.fileCountLabel.Location = new System.Drawing.Point(169, 88);
            this.fileCountLabel.Name = "fileCountLabel";
            this.fileCountLabel.Size = new System.Drawing.Size(13, 13);
            this.fileCountLabel.TabIndex = 3;
            this.fileCountLabel.Text = "0";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(82, 407);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(110, 37);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // fileList
            // 
            this.fileList.AutoSize = true;
            this.fileList.Location = new System.Drawing.Point(89, 101);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(0, 13);
            this.fileList.TabIndex = 5;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(166, 470);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(0, 13);
            this.version.TabIndex = 6;
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(82, 450);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(110, 37);
            this.compareButton.TabIndex = 7;
            this.compareButton.Text = "Compare";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(286, 510);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.version);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.fileCountLabel);
            this.Controls.Add(this.numberFiles);
            this.Controls.Add(this.dragFolderLabel);
            this.Controls.Add(this.processButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

     
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Label dragFolderLabel;
        private System.Windows.Forms.Label numberFiles;
        private System.Windows.Forms.Label fileCountLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label fileList;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label version;
        private Button compareButton;
    }
}

