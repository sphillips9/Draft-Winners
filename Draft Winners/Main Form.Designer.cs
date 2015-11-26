﻿namespace Draft_Winners
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCollegeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlayerValueSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryCapTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.salaryThresholdTextBox = new System.Windows.Forms.TextBox();
            this.workingProgressLabel = new System.Windows.Forms.Label();
            this.openNHLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.footballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hockeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCSVFileToolStripMenuItem,
            this.openCollegeFileToolStripMenuItem,
            this.openNHLFileToolStripMenuItem,
            this.openPlayerValueSheetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(547, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openCSVFileToolStripMenuItem
            // 
            this.openCSVFileToolStripMenuItem.Name = "openCSVFileToolStripMenuItem";
            this.openCSVFileToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.openCSVFileToolStripMenuItem.Text = "Open NFL File";
            this.openCSVFileToolStripMenuItem.Click += new System.EventHandler(this.openCSVFileToolStripMenuItem_Click);
            // 
            // openCollegeFileToolStripMenuItem
            // 
            this.openCollegeFileToolStripMenuItem.Name = "openCollegeFileToolStripMenuItem";
            this.openCollegeFileToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.openCollegeFileToolStripMenuItem.Text = "Open College File";
            this.openCollegeFileToolStripMenuItem.Click += new System.EventHandler(this.openCollegeFileToolStripMenuItem_Click);
            // 
            // openPlayerValueSheetToolStripMenuItem
            // 
            this.openPlayerValueSheetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.footballToolStripMenuItem,
            this.hockeyToolStripMenuItem});
            this.openPlayerValueSheetToolStripMenuItem.Name = "openPlayerValueSheetToolStripMenuItem";
            this.openPlayerValueSheetToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.openPlayerValueSheetToolStripMenuItem.Text = "Open Player Value Sheet";
            // 
            // salaryCapTextBox
            // 
            this.salaryCapTextBox.Location = new System.Drawing.Point(103, 21);
            this.salaryCapTextBox.Name = "salaryCapTextBox";
            this.salaryCapTextBox.Size = new System.Drawing.Size(100, 20);
            this.salaryCapTextBox.TabIndex = 1;
            this.salaryCapTextBox.Text = "50000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Salary Cap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Salary Threshold";
            // 
            // salaryThresholdTextBox
            // 
            this.salaryThresholdTextBox.Location = new System.Drawing.Point(103, 47);
            this.salaryThresholdTextBox.Name = "salaryThresholdTextBox";
            this.salaryThresholdTextBox.Size = new System.Drawing.Size(100, 20);
            this.salaryThresholdTextBox.TabIndex = 3;
            this.salaryThresholdTextBox.Text = "100";
            // 
            // workingProgressLabel
            // 
            this.workingProgressLabel.AutoSize = true;
            this.workingProgressLabel.Location = new System.Drawing.Point(12, 80);
            this.workingProgressLabel.Name = "workingProgressLabel";
            this.workingProgressLabel.Size = new System.Drawing.Size(74, 13);
            this.workingProgressLabel.TabIndex = 5;
            this.workingProgressLabel.Text = "Awaiting Input";
            // 
            // openNHLFileToolStripMenuItem
            // 
            this.openNHLFileToolStripMenuItem.Name = "openNHLFileToolStripMenuItem";
            this.openNHLFileToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.openNHLFileToolStripMenuItem.Text = "Open NHL File";
            this.openNHLFileToolStripMenuItem.Click += new System.EventHandler(this.openNHLFileToolStripMenuItem_Click);
            // 
            // footballToolStripMenuItem
            // 
            this.footballToolStripMenuItem.Name = "footballToolStripMenuItem";
            this.footballToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.footballToolStripMenuItem.Text = "Football";
            this.footballToolStripMenuItem.Click += new System.EventHandler(this.footballToolStripMenuItem_Click);
            // 
            // hockeyToolStripMenuItem
            // 
            this.hockeyToolStripMenuItem.Name = "hockeyToolStripMenuItem";
            this.hockeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hockeyToolStripMenuItem.Text = "Hockey";
            this.hockeyToolStripMenuItem.Click += new System.EventHandler(this.hockeyToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 345);
            this.Controls.Add(this.workingProgressLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.salaryThresholdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.salaryCapTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Draft Winners";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openCSVFileToolStripMenuItem;
        private System.Windows.Forms.TextBox salaryCapTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox salaryThresholdTextBox;
        private System.Windows.Forms.ToolStripMenuItem openCollegeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlayerValueSheetToolStripMenuItem;
        private System.Windows.Forms.Label workingProgressLabel;
        private System.Windows.Forms.ToolStripMenuItem openNHLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem footballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hockeyToolStripMenuItem;
    }
}

