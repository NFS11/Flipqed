namespace Flipqed
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button foundButton;
        private System.Windows.Forms.Button giveUpButton;
        private System.Windows.Forms.Label gamesStatsLabel;
        private System.Windows.Forms.ListBox fastestTimesListBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.foundButton = new System.Windows.Forms.Button();
            this.giveUpButton = new System.Windows.Forms.Button();
            this.gamesStatsLabel = new System.Windows.Forms.Label();
            this.fastestTimesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 24);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 37);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // foundButton
            // 
            this.foundButton.Location = new System.Drawing.Point(12, 67);
            this.foundButton.Name = "foundButton";
            this.foundButton.Size = new System.Drawing.Size(100, 35);
            this.foundButton.TabIndex = 1;
            this.foundButton.Text = "Found it?";
            this.foundButton.UseVisualStyleBackColor = true;
            this.foundButton.Click += new System.EventHandler(this.foundButton_Click);
            // 
            // giveUpButton
            // 
            this.giveUpButton.Location = new System.Drawing.Point(12, 108);
            this.giveUpButton.Name = "giveUpButton";
            this.giveUpButton.Size = new System.Drawing.Size(100, 35);
            this.giveUpButton.TabIndex = 2;
            this.giveUpButton.Text = "I give up.";
            this.giveUpButton.UseVisualStyleBackColor = true;
            this.giveUpButton.Click += new System.EventHandler(this.giveUpButton_Click);
            // 
            // gamesStatsLabel
            // 
            this.gamesStatsLabel.Location = new System.Drawing.Point(156, 133);
            this.gamesStatsLabel.Name = "gamesStatsLabel";
            this.gamesStatsLabel.Size = new System.Drawing.Size(162, 43);
            this.gamesStatsLabel.TabIndex = 3;
            this.gamesStatsLabel.Text = "Games Won: 0 | Games Lost: 0";
            // 
            // fastestTimesListBox
            // 
            this.fastestTimesListBox.Location = new System.Drawing.Point(159, 24);
            this.fastestTimesListBox.Name = "fastestTimesListBox";
            this.fastestTimesListBox.Size = new System.Drawing.Size(159, 95);
            this.fastestTimesListBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(352, 289);
            this.Controls.Add(this.fastestTimesListBox);
            this.Controls.Add(this.gamesStatsLabel);
            this.Controls.Add(this.giveUpButton);
            this.Controls.Add(this.foundButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Flipqed!";
            this.ResumeLayout(false);

        }
    }
}

