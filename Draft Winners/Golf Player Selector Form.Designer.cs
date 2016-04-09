namespace Draft_Winners
{
    partial class GolfPlayerSelectorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GolfPlayerSelectorForm));
            this.golfer3Box = new System.Windows.Forms.ComboBox();
            this.golfer2Box = new System.Windows.Forms.ComboBox();
            this.createTeamButton = new System.Windows.Forms.Button();
            this.golfer6Box = new System.Windows.Forms.ComboBox();
            this.golfer5Box = new System.Windows.Forms.ComboBox();
            this.golfer4Box = new System.Windows.Forms.ComboBox();
            this.golfer1Box = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pgaLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pgaLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // golfer3Box
            // 
            this.golfer3Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.golfer3Box.FormattingEnabled = true;
            this.golfer3Box.Location = new System.Drawing.Point(12, 172);
            this.golfer3Box.Name = "golfer3Box";
            this.golfer3Box.Size = new System.Drawing.Size(121, 21);
            this.golfer3Box.TabIndex = 22;
            // 
            // golfer2Box
            // 
            this.golfer2Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.golfer2Box.FormattingEnabled = true;
            this.golfer2Box.Location = new System.Drawing.Point(12, 112);
            this.golfer2Box.Name = "golfer2Box";
            this.golfer2Box.Size = new System.Drawing.Size(121, 21);
            this.golfer2Box.TabIndex = 21;
            // 
            // createTeamButton
            // 
            this.createTeamButton.Location = new System.Drawing.Point(306, 172);
            this.createTeamButton.Name = "createTeamButton";
            this.createTeamButton.Size = new System.Drawing.Size(121, 21);
            this.createTeamButton.TabIndex = 20;
            this.createTeamButton.Text = "Create Team";
            this.createTeamButton.UseVisualStyleBackColor = true;
            this.createTeamButton.Click += new System.EventHandler(this.createTeamButton_Click);
            // 
            // golfer6Box
            // 
            this.golfer6Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.golfer6Box.FormattingEnabled = true;
            this.golfer6Box.Location = new System.Drawing.Point(170, 172);
            this.golfer6Box.Name = "golfer6Box";
            this.golfer6Box.Size = new System.Drawing.Size(121, 21);
            this.golfer6Box.TabIndex = 19;
            // 
            // golfer5Box
            // 
            this.golfer5Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.golfer5Box.FormattingEnabled = true;
            this.golfer5Box.Location = new System.Drawing.Point(170, 113);
            this.golfer5Box.Name = "golfer5Box";
            this.golfer5Box.Size = new System.Drawing.Size(121, 21);
            this.golfer5Box.TabIndex = 18;
            // 
            // golfer4Box
            // 
            this.golfer4Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.golfer4Box.FormattingEnabled = true;
            this.golfer4Box.Location = new System.Drawing.Point(170, 57);
            this.golfer4Box.Name = "golfer4Box";
            this.golfer4Box.Size = new System.Drawing.Size(121, 21);
            this.golfer4Box.TabIndex = 17;
            // 
            // golfer1Box
            // 
            this.golfer1Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.golfer1Box.FormattingEnabled = true;
            this.golfer1Box.Location = new System.Drawing.Point(12, 56);
            this.golfer1Box.Name = "golfer1Box";
            this.golfer1Box.Size = new System.Drawing.Size(121, 21);
            this.golfer1Box.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Golfers";
            // 
            // pgaLogo
            // 
            this.pgaLogo.Image = ((System.Drawing.Image)(resources.GetObject("pgaLogo.Image")));
            this.pgaLogo.Location = new System.Drawing.Point(306, 44);
            this.pgaLogo.Name = "pgaLogo";
            this.pgaLogo.Size = new System.Drawing.Size(116, 122);
            this.pgaLogo.TabIndex = 23;
            this.pgaLogo.TabStop = false;
            // 
            // GolfPlayerSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 206);
            this.Controls.Add(this.pgaLogo);
            this.Controls.Add(this.golfer3Box);
            this.Controls.Add(this.golfer2Box);
            this.Controls.Add(this.createTeamButton);
            this.Controls.Add(this.golfer6Box);
            this.Controls.Add(this.golfer5Box);
            this.Controls.Add(this.golfer4Box);
            this.Controls.Add(this.golfer1Box);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GolfPlayerSelectorForm";
            this.Text = "Golf Player Selector";
            ((System.ComponentModel.ISupportInitialize)(this.pgaLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox golfer3Box;
        private System.Windows.Forms.ComboBox golfer2Box;
        private System.Windows.Forms.Button createTeamButton;
        private System.Windows.Forms.ComboBox golfer6Box;
        private System.Windows.Forms.ComboBox golfer5Box;
        private System.Windows.Forms.ComboBox golfer4Box;
        private System.Windows.Forms.ComboBox golfer1Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pgaLogo;
    }
}