namespace Draft_Winners
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
            this.openCSVFileForTeams = new System.Windows.Forms.ToolStripMenuItem();
            this.openNFLFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openCollegeFootballFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openNHLFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openCollegeBasketballFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlayerValueSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateFootballPlayerStats = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateHockeyPlayerStats = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateBasketballPlayerStats = new System.Windows.Forms.ToolStripMenuItem();
            this.golfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseYourPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collegeBasketballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nationalHockeyLeagueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.golfToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nHLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryCapTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.salaryThresholdTextBox = new System.Windows.Forms.TextBox();
            this.workingProgressLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCSVFileForTeams,
            this.openPlayerValueSheetToolStripMenuItem,
            this.chooseYourPlayersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(547, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openCSVFileForTeams
            // 
            this.openCSVFileForTeams.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNFLFile,
            this.openCollegeFootballFile,
            this.openNHLFile,
            this.openCollegeBasketballFile});
            this.openCSVFileForTeams.Name = "openCSVFileForTeams";
            this.openCSVFileForTeams.Size = new System.Drawing.Size(93, 20);
            this.openCSVFileForTeams.Text = "Open CSV File";
            // 
            // openNFLFile
            // 
            this.openNFLFile.Name = "openNFLFile";
            this.openNFLFile.Size = new System.Drawing.Size(170, 22);
            this.openNFLFile.Text = "NFL";
            this.openNFLFile.Click += new System.EventHandler(this.openNFLTeamCalculator);
            // 
            // openCollegeFootballFile
            // 
            this.openCollegeFootballFile.Name = "openCollegeFootballFile";
            this.openCollegeFootballFile.Size = new System.Drawing.Size(170, 22);
            this.openCollegeFootballFile.Text = "College Football";
            this.openCollegeFootballFile.Click += new System.EventHandler(this.openCollegeFootballTeamCalculator);
            // 
            // openNHLFile
            // 
            this.openNHLFile.Name = "openNHLFile";
            this.openNHLFile.Size = new System.Drawing.Size(170, 22);
            this.openNHLFile.Text = "NHL";
            this.openNHLFile.Click += new System.EventHandler(this.openNHLTeamCalculator);
            // 
            // openCollegeBasketballFile
            // 
            this.openCollegeBasketballFile.Name = "openCollegeBasketballFile";
            this.openCollegeBasketballFile.Size = new System.Drawing.Size(170, 22);
            this.openCollegeBasketballFile.Text = "College Basketball";
            this.openCollegeBasketballFile.Click += new System.EventHandler(this.openCollegeBasketballTeamCalculator);
            // 
            // openPlayerValueSheetToolStripMenuItem
            // 
            this.openPlayerValueSheetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateFootballPlayerStats,
            this.calculateHockeyPlayerStats,
            this.calculateBasketballPlayerStats,
            this.golfToolStripMenuItem});
            this.openPlayerValueSheetToolStripMenuItem.Name = "openPlayerValueSheetToolStripMenuItem";
            this.openPlayerValueSheetToolStripMenuItem.Size = new System.Drawing.Size(146, 20);
            this.openPlayerValueSheetToolStripMenuItem.Text = "Open Player Value Sheet";
            // 
            // calculateFootballPlayerStats
            // 
            this.calculateFootballPlayerStats.Name = "calculateFootballPlayerStats";
            this.calculateFootballPlayerStats.Size = new System.Drawing.Size(152, 22);
            this.calculateFootballPlayerStats.Text = "Football";
            this.calculateFootballPlayerStats.Click += new System.EventHandler(this.footballPlayerStatsCalculator);
            // 
            // calculateHockeyPlayerStats
            // 
            this.calculateHockeyPlayerStats.Name = "calculateHockeyPlayerStats";
            this.calculateHockeyPlayerStats.Size = new System.Drawing.Size(152, 22);
            this.calculateHockeyPlayerStats.Text = "Hockey";
            this.calculateHockeyPlayerStats.Click += new System.EventHandler(this.hockeyPlayerStatsCalculator);
            // 
            // calculateBasketballPlayerStats
            // 
            this.calculateBasketballPlayerStats.Name = "calculateBasketballPlayerStats";
            this.calculateBasketballPlayerStats.Size = new System.Drawing.Size(152, 22);
            this.calculateBasketballPlayerStats.Text = "Basketball";
            this.calculateBasketballPlayerStats.Click += new System.EventHandler(this.basketballPlayerStatsCalculator);
            // 
            // golfToolStripMenuItem
            // 
            this.golfToolStripMenuItem.Name = "golfToolStripMenuItem";
            this.golfToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.golfToolStripMenuItem.Text = "Golf";
            this.golfToolStripMenuItem.Click += new System.EventHandler(this.golfToolStripMenuItem_Click);
            // 
            // chooseYourPlayersToolStripMenuItem
            // 
            this.chooseYourPlayersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collegeBasketballToolStripMenuItem,
            this.nationalHockeyLeagueToolStripMenuItem,
            this.golfToolStripMenuItem1,
            this.nHLToolStripMenuItem});
            this.chooseYourPlayersToolStripMenuItem.Name = "chooseYourPlayersToolStripMenuItem";
            this.chooseYourPlayersToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.chooseYourPlayersToolStripMenuItem.Text = "Choose Your Players";
            // 
            // collegeBasketballToolStripMenuItem
            // 
            this.collegeBasketballToolStripMenuItem.Name = "collegeBasketballToolStripMenuItem";
            this.collegeBasketballToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.collegeBasketballToolStripMenuItem.Text = "College Basketball";
            this.collegeBasketballToolStripMenuItem.Click += new System.EventHandler(this.pickPlayersCollegeBasketball);
            // 
            // nationalHockeyLeagueToolStripMenuItem
            // 
            this.nationalHockeyLeagueToolStripMenuItem.Name = "nationalHockeyLeagueToolStripMenuItem";
            this.nationalHockeyLeagueToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.nationalHockeyLeagueToolStripMenuItem.Text = "National Hockey League";
            this.nationalHockeyLeagueToolStripMenuItem.Click += new System.EventHandler(this.nationalHockeyLeagueToolStripMenuItem_Click);
            // 
            // golfToolStripMenuItem1
            // 
            this.golfToolStripMenuItem1.Name = "golfToolStripMenuItem1";
            this.golfToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.golfToolStripMenuItem1.Text = "Golf";
            this.golfToolStripMenuItem1.Click += new System.EventHandler(this.golfToolStripMenuItem1_Click);
            // 
            // nHLToolStripMenuItem
            // 
            this.nHLToolStripMenuItem.Name = "nHLToolStripMenuItem";
            this.nHLToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.nHLToolStripMenuItem.Text = "NFL";
            this.nHLToolStripMenuItem.Click += new System.EventHandler(this.nFLToolStripMenuItem_Click);
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
        private System.Windows.Forms.TextBox salaryCapTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox salaryThresholdTextBox;
        private System.Windows.Forms.ToolStripMenuItem openPlayerValueSheetToolStripMenuItem;
        private System.Windows.Forms.Label workingProgressLabel;
        private System.Windows.Forms.ToolStripMenuItem calculateFootballPlayerStats;
        private System.Windows.Forms.ToolStripMenuItem calculateHockeyPlayerStats;
        private System.Windows.Forms.ToolStripMenuItem openCSVFileForTeams;
        private System.Windows.Forms.ToolStripMenuItem openNFLFile;
        private System.Windows.Forms.ToolStripMenuItem openCollegeFootballFile;
        private System.Windows.Forms.ToolStripMenuItem openNHLFile;
        private System.Windows.Forms.ToolStripMenuItem openCollegeBasketballFile;
        private System.Windows.Forms.ToolStripMenuItem calculateBasketballPlayerStats;
        private System.Windows.Forms.ToolStripMenuItem chooseYourPlayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collegeBasketballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nationalHockeyLeagueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem golfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem golfToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nHLToolStripMenuItem;
    }
}

