namespace Draft_Winners
{
    partial class Showdown_Player_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Showdown_Player_Form));
            this.createTeamButton = new System.Windows.Forms.Button();
            this.player6Box = new System.Windows.Forms.ComboBox();
            this.player4Box = new System.Windows.Forms.ComboBox();
            this.player3Box = new System.Windows.Forms.ComboBox();
            this.player2Box = new System.Windows.Forms.ComboBox();
            this.player1Box = new System.Windows.Forms.ComboBox();
            this.player5Box = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // createTeamButton
            // 
            this.createTeamButton.Location = new System.Drawing.Point(248, 41);
            this.createTeamButton.Name = "createTeamButton";
            this.createTeamButton.Size = new System.Drawing.Size(93, 27);
            this.createTeamButton.TabIndex = 41;
            this.createTeamButton.Text = "Create Team";
            this.createTeamButton.UseVisualStyleBackColor = true;
            this.createTeamButton.Click += new System.EventHandler(this.CreateTeamButton_Click);
            // 
            // player6Box
            // 
            this.player6Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player6Box.FormattingEnabled = true;
            this.player6Box.Location = new System.Drawing.Point(118, 81);
            this.player6Box.Name = "player6Box";
            this.player6Box.Size = new System.Drawing.Size(93, 21);
            this.player6Box.TabIndex = 40;
            // 
            // player4Box
            // 
            this.player4Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player4Box.FormattingEnabled = true;
            this.player4Box.Location = new System.Drawing.Point(118, 12);
            this.player4Box.Name = "player4Box";
            this.player4Box.Size = new System.Drawing.Size(93, 21);
            this.player4Box.TabIndex = 39;
            // 
            // player3Box
            // 
            this.player3Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player3Box.FormattingEnabled = true;
            this.player3Box.Location = new System.Drawing.Point(7, 81);
            this.player3Box.Name = "player3Box";
            this.player3Box.Size = new System.Drawing.Size(93, 21);
            this.player3Box.TabIndex = 38;
            // 
            // player2Box
            // 
            this.player2Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player2Box.FormattingEnabled = true;
            this.player2Box.Location = new System.Drawing.Point(7, 45);
            this.player2Box.Name = "player2Box";
            this.player2Box.Size = new System.Drawing.Size(93, 21);
            this.player2Box.TabIndex = 37;
            // 
            // player1Box
            // 
            this.player1Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player1Box.FormattingEnabled = true;
            this.player1Box.Location = new System.Drawing.Point(7, 12);
            this.player1Box.Name = "player1Box";
            this.player1Box.Size = new System.Drawing.Size(93, 21);
            this.player1Box.TabIndex = 36;
            // 
            // player5Box
            // 
            this.player5Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player5Box.FormattingEnabled = true;
            this.player5Box.Location = new System.Drawing.Point(118, 45);
            this.player5Box.Name = "player5Box";
            this.player5Box.Size = new System.Drawing.Size(93, 21);
            this.player5Box.TabIndex = 42;
            // 
            // Showdown_Player_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 115);
            this.Controls.Add(this.player5Box);
            this.Controls.Add(this.createTeamButton);
            this.Controls.Add(this.player6Box);
            this.Controls.Add(this.player4Box);
            this.Controls.Add(this.player3Box);
            this.Controls.Add(this.player2Box);
            this.Controls.Add(this.player1Box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Showdown_Player_Form";
            this.Text = "Showdown_Player_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createTeamButton;
        private System.Windows.Forms.ComboBox player6Box;
        private System.Windows.Forms.ComboBox player4Box;
        private System.Windows.Forms.ComboBox player3Box;
        private System.Windows.Forms.ComboBox player2Box;
        private System.Windows.Forms.ComboBox player1Box;
        private System.Windows.Forms.ComboBox player5Box;
    }
}