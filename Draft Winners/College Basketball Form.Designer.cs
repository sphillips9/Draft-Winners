namespace Draft_Winners
{
    partial class BasketballChooserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasketballChooserForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.forward1Box = new System.Windows.Forms.ComboBox();
            this.guard1Box = new System.Windows.Forms.ComboBox();
            this.guard2Box = new System.Windows.Forms.ComboBox();
            this.guard3Box = new System.Windows.Forms.ComboBox();
            this.createTeamButton = new System.Windows.Forms.Button();
            this.forward2Box = new System.Windows.Forms.ComboBox();
            this.forward3Box = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forwards";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Guards";
            // 
            // forward1Box
            // 
            this.forward1Box.FormattingEnabled = true;
            this.forward1Box.Location = new System.Drawing.Point(16, 58);
            this.forward1Box.Name = "forward1Box";
            this.forward1Box.Size = new System.Drawing.Size(121, 21);
            this.forward1Box.TabIndex = 3;
            // 
            // guard1Box
            // 
            this.guard1Box.FormattingEnabled = true;
            this.guard1Box.Location = new System.Drawing.Point(264, 58);
            this.guard1Box.Name = "guard1Box";
            this.guard1Box.Size = new System.Drawing.Size(121, 21);
            this.guard1Box.TabIndex = 6;
            // 
            // guard2Box
            // 
            this.guard2Box.FormattingEnabled = true;
            this.guard2Box.Location = new System.Drawing.Point(264, 114);
            this.guard2Box.Name = "guard2Box";
            this.guard2Box.Size = new System.Drawing.Size(121, 21);
            this.guard2Box.TabIndex = 7;
            // 
            // guard3Box
            // 
            this.guard3Box.FormattingEnabled = true;
            this.guard3Box.Location = new System.Drawing.Point(264, 173);
            this.guard3Box.Name = "guard3Box";
            this.guard3Box.Size = new System.Drawing.Size(121, 21);
            this.guard3Box.TabIndex = 8;
            // 
            // createTeamButton
            // 
            this.createTeamButton.Location = new System.Drawing.Point(400, 173);
            this.createTeamButton.Name = "createTeamButton";
            this.createTeamButton.Size = new System.Drawing.Size(121, 21);
            this.createTeamButton.TabIndex = 11;
            this.createTeamButton.Text = "Create Team";
            this.createTeamButton.UseVisualStyleBackColor = true;
            this.createTeamButton.Click += new System.EventHandler(this.createTeamButton_Click);
            // 
            // forward2Box
            // 
            this.forward2Box.FormattingEnabled = true;
            this.forward2Box.Location = new System.Drawing.Point(16, 114);
            this.forward2Box.Name = "forward2Box";
            this.forward2Box.Size = new System.Drawing.Size(121, 21);
            this.forward2Box.TabIndex = 12;
            // 
            // forward3Box
            // 
            this.forward3Box.FormattingEnabled = true;
            this.forward3Box.Location = new System.Drawing.Point(16, 174);
            this.forward3Box.Name = "forward3Box";
            this.forward3Box.Size = new System.Drawing.Size(121, 21);
            this.forward3Box.TabIndex = 13;
            // 
            // BasketballChooserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 205);
            this.Controls.Add(this.forward3Box);
            this.Controls.Add(this.forward2Box);
            this.Controls.Add(this.createTeamButton);
            this.Controls.Add(this.guard3Box);
            this.Controls.Add(this.guard2Box);
            this.Controls.Add(this.guard1Box);
            this.Controls.Add(this.forward1Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BasketballChooserForm";
            this.Text = "Selection Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox forward1Box;
        private System.Windows.Forms.ComboBox guard1Box;
        private System.Windows.Forms.ComboBox guard2Box;
        private System.Windows.Forms.ComboBox guard3Box;
        private System.Windows.Forms.Button createTeamButton;
        private System.Windows.Forms.ComboBox forward2Box;
        private System.Windows.Forms.ComboBox forward3Box;
    }
}