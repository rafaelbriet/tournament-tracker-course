namespace TrackerUI.Forms
{
    partial class TournamentViewerForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tournamentViewerHeaderLabel = new System.Windows.Forms.Label();
            this.tournamentNameLabel = new System.Windows.Forms.Label();
            this.roundsLabel = new System.Windows.Forms.Label();
            this.roundsDropDown = new System.Windows.Forms.ComboBox();
            this.unplayedOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.matchupsListBox = new System.Windows.Forms.ListBox();
            this.teamOneNameLabel = new System.Windows.Forms.Label();
            this.teamTwoNameLabel = new System.Windows.Forms.Label();
            this.teamOneScoreTextBox = new System.Windows.Forms.TextBox();
            this.teamTwoScoreTextBox = new System.Windows.Forms.TextBox();
            this.scoreButton = new System.Windows.Forms.Button();
            this.matchupEntryPanel = new System.Windows.Forms.Panel();
            this.matchupEntryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tournamentViewerHeaderLabel
            // 
            this.tournamentViewerHeaderLabel.AutoSize = true;
            this.tournamentViewerHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentViewerHeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.tournamentViewerHeaderLabel.Name = "tournamentViewerHeaderLabel";
            this.tournamentViewerHeaderLabel.Size = new System.Drawing.Size(118, 24);
            this.tournamentViewerHeaderLabel.TabIndex = 0;
            this.tournamentViewerHeaderLabel.Text = "Tournament:";
            // 
            // tournamentNameLabel
            // 
            this.tournamentNameLabel.AutoSize = true;
            this.tournamentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentNameLabel.Location = new System.Drawing.Point(136, 12);
            this.tournamentNameLabel.Name = "tournamentNameLabel";
            this.tournamentNameLabel.Size = new System.Drawing.Size(63, 20);
            this.tournamentNameLabel.TabIndex = 1;
            this.tournamentNameLabel.Text = "<none>";
            // 
            // roundsLabel
            // 
            this.roundsLabel.AutoSize = true;
            this.roundsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundsLabel.Location = new System.Drawing.Point(12, 56);
            this.roundsLabel.Name = "roundsLabel";
            this.roundsLabel.Size = new System.Drawing.Size(76, 24);
            this.roundsLabel.TabIndex = 2;
            this.roundsLabel.Text = "Rounds";
            // 
            // roundsDropDown
            // 
            this.roundsDropDown.FormattingEnabled = true;
            this.roundsDropDown.Location = new System.Drawing.Point(94, 59);
            this.roundsDropDown.Name = "roundsDropDown";
            this.roundsDropDown.Size = new System.Drawing.Size(214, 21);
            this.roundsDropDown.TabIndex = 3;
            this.roundsDropDown.SelectedIndexChanged += new System.EventHandler(this.roundsDropDown_SelectedIndexChanged);
            // 
            // unplayedOnlyCheckBox
            // 
            this.unplayedOnlyCheckBox.AutoSize = true;
            this.unplayedOnlyCheckBox.Location = new System.Drawing.Point(94, 86);
            this.unplayedOnlyCheckBox.Name = "unplayedOnlyCheckBox";
            this.unplayedOnlyCheckBox.Size = new System.Drawing.Size(121, 17);
            this.unplayedOnlyCheckBox.TabIndex = 4;
            this.unplayedOnlyCheckBox.Text = "Show only unplayed";
            this.unplayedOnlyCheckBox.UseVisualStyleBackColor = true;
            this.unplayedOnlyCheckBox.CheckedChanged += new System.EventHandler(this.unplayedOnlyCheckBox_CheckedChanged);
            // 
            // matchupsListBox
            // 
            this.matchupsListBox.FormattingEnabled = true;
            this.matchupsListBox.Location = new System.Drawing.Point(16, 124);
            this.matchupsListBox.Name = "matchupsListBox";
            this.matchupsListBox.Size = new System.Drawing.Size(292, 303);
            this.matchupsListBox.TabIndex = 5;
            this.matchupsListBox.SelectedIndexChanged += new System.EventHandler(this.matchupsListBox_SelectedIndexChanged);
            // 
            // teamOneNameLabel
            // 
            this.teamOneNameLabel.AutoSize = true;
            this.teamOneNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamOneNameLabel.Location = new System.Drawing.Point(3, 3);
            this.teamOneNameLabel.Name = "teamOneNameLabel";
            this.teamOneNameLabel.Size = new System.Drawing.Size(164, 24);
            this.teamOneNameLabel.TabIndex = 6;
            this.teamOneNameLabel.Text = "<team one name>";
            // 
            // teamTwoNameLabel
            // 
            this.teamTwoNameLabel.AutoSize = true;
            this.teamTwoNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTwoNameLabel.Location = new System.Drawing.Point(3, 84);
            this.teamTwoNameLabel.Name = "teamTwoNameLabel";
            this.teamTwoNameLabel.Size = new System.Drawing.Size(160, 24);
            this.teamTwoNameLabel.TabIndex = 7;
            this.teamTwoNameLabel.Text = "<team two name>";
            // 
            // teamOneScoreTextBox
            // 
            this.teamOneScoreTextBox.Location = new System.Drawing.Point(6, 35);
            this.teamOneScoreTextBox.Name = "teamOneScoreTextBox";
            this.teamOneScoreTextBox.Size = new System.Drawing.Size(100, 20);
            this.teamOneScoreTextBox.TabIndex = 8;
            // 
            // teamTwoScoreTextBox
            // 
            this.teamTwoScoreTextBox.Location = new System.Drawing.Point(6, 113);
            this.teamTwoScoreTextBox.Name = "teamTwoScoreTextBox";
            this.teamTwoScoreTextBox.Size = new System.Drawing.Size(100, 20);
            this.teamTwoScoreTextBox.TabIndex = 9;
            // 
            // scoreButton
            // 
            this.scoreButton.Location = new System.Drawing.Point(5, 175);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(75, 23);
            this.scoreButton.TabIndex = 10;
            this.scoreButton.Text = "Score";
            this.scoreButton.UseVisualStyleBackColor = true;
            this.scoreButton.Click += new System.EventHandler(this.scoreButton_Click);
            // 
            // matchupEntryPanel
            // 
            this.matchupEntryPanel.Controls.Add(this.teamTwoScoreTextBox);
            this.matchupEntryPanel.Controls.Add(this.scoreButton);
            this.matchupEntryPanel.Controls.Add(this.teamOneNameLabel);
            this.matchupEntryPanel.Controls.Add(this.teamTwoNameLabel);
            this.matchupEntryPanel.Controls.Add(this.teamOneScoreTextBox);
            this.matchupEntryPanel.Location = new System.Drawing.Point(325, 118);
            this.matchupEntryPanel.Name = "matchupEntryPanel";
            this.matchupEntryPanel.Size = new System.Drawing.Size(495, 312);
            this.matchupEntryPanel.TabIndex = 11;
            // 
            // TournamentViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.matchupEntryPanel);
            this.Controls.Add(this.matchupsListBox);
            this.Controls.Add(this.unplayedOnlyCheckBox);
            this.Controls.Add(this.roundsDropDown);
            this.Controls.Add(this.roundsLabel);
            this.Controls.Add(this.tournamentNameLabel);
            this.Controls.Add(this.tournamentViewerHeaderLabel);
            this.Name = "TournamentViewerForm";
            this.Text = "Tournament Viewer";
            this.matchupEntryPanel.ResumeLayout(false);
            this.matchupEntryPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tournamentViewerHeaderLabel;
        private System.Windows.Forms.Label tournamentNameLabel;
        private System.Windows.Forms.Label roundsLabel;
        private System.Windows.Forms.ComboBox roundsDropDown;
        private System.Windows.Forms.CheckBox unplayedOnlyCheckBox;
        private System.Windows.Forms.ListBox matchupsListBox;
        private System.Windows.Forms.Label teamOneNameLabel;
        private System.Windows.Forms.Label teamTwoNameLabel;
        private System.Windows.Forms.TextBox teamOneScoreTextBox;
        private System.Windows.Forms.TextBox teamTwoScoreTextBox;
        private System.Windows.Forms.Button scoreButton;
        private System.Windows.Forms.Panel matchupEntryPanel;
    }
}

