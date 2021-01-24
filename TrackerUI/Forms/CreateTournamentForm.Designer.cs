namespace TrackerUI.Forms
{
    partial class CreateTournamentForm
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
            this.createTournamentHeaderLabel = new System.Windows.Forms.Label();
            this.entryFeeLabel = new System.Windows.Forms.Label();
            this.createTournamentNameLabel = new System.Windows.Forms.Label();
            this.createTournamentNameTextBox = new System.Windows.Forms.TextBox();
            this.entryFeeTextBox = new System.Windows.Forms.TextBox();
            this.selectTeamLabel = new System.Windows.Forms.Label();
            this.teamPlayersLabel = new System.Windows.Forms.Label();
            this.prizesLabel = new System.Windows.Forms.Label();
            this.selectTeamDropDown = new System.Windows.Forms.ComboBox();
            this.tournamentTeamsListBox = new System.Windows.Forms.ListBox();
            this.addTeamButton = new System.Windows.Forms.Button();
            this.createTeamLinkLabel = new System.Windows.Forms.LinkLabel();
            this.removeSelectedTeamPlayerButton = new System.Windows.Forms.Button();
            this.removeSelectedPrizeButton = new System.Windows.Forms.Button();
            this.prizesListBox = new System.Windows.Forms.ListBox();
            this.addPrizeButton = new System.Windows.Forms.Button();
            this.createTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createTournamentHeaderLabel
            // 
            this.createTournamentHeaderLabel.AutoSize = true;
            this.createTournamentHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTournamentHeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.createTournamentHeaderLabel.Name = "createTournamentHeaderLabel";
            this.createTournamentHeaderLabel.Size = new System.Drawing.Size(173, 24);
            this.createTournamentHeaderLabel.TabIndex = 1;
            this.createTournamentHeaderLabel.Text = "Create Tournament";
            // 
            // entryFeeLabel
            // 
            this.entryFeeLabel.AutoSize = true;
            this.entryFeeLabel.Location = new System.Drawing.Point(362, 59);
            this.entryFeeLabel.Name = "entryFeeLabel";
            this.entryFeeLabel.Size = new System.Drawing.Size(52, 13);
            this.entryFeeLabel.TabIndex = 2;
            this.entryFeeLabel.Text = "Entry Fee";
            // 
            // createTournamentNameLabel
            // 
            this.createTournamentNameLabel.AutoSize = true;
            this.createTournamentNameLabel.Location = new System.Drawing.Point(12, 59);
            this.createTournamentNameLabel.Name = "createTournamentNameLabel";
            this.createTournamentNameLabel.Size = new System.Drawing.Size(93, 13);
            this.createTournamentNameLabel.TabIndex = 3;
            this.createTournamentNameLabel.Text = "Tournament name";
            // 
            // createTournamentNameTextBox
            // 
            this.createTournamentNameTextBox.Location = new System.Drawing.Point(112, 55);
            this.createTournamentNameTextBox.Name = "createTournamentNameTextBox";
            this.createTournamentNameTextBox.Size = new System.Drawing.Size(198, 20);
            this.createTournamentNameTextBox.TabIndex = 4;
            // 
            // entryFeeTextBox
            // 
            this.entryFeeTextBox.Location = new System.Drawing.Point(453, 59);
            this.entryFeeTextBox.Name = "entryFeeTextBox";
            this.entryFeeTextBox.Size = new System.Drawing.Size(198, 20);
            this.entryFeeTextBox.TabIndex = 5;
            // 
            // selectTeamLabel
            // 
            this.selectTeamLabel.AutoSize = true;
            this.selectTeamLabel.Location = new System.Drawing.Point(13, 122);
            this.selectTeamLabel.Name = "selectTeamLabel";
            this.selectTeamLabel.Size = new System.Drawing.Size(67, 13);
            this.selectTeamLabel.TabIndex = 6;
            this.selectTeamLabel.Text = "Select Team";
            // 
            // teamPlayersLabel
            // 
            this.teamPlayersLabel.AutoSize = true;
            this.teamPlayersLabel.Location = new System.Drawing.Point(362, 122);
            this.teamPlayersLabel.Name = "teamPlayersLabel";
            this.teamPlayersLabel.Size = new System.Drawing.Size(84, 13);
            this.teamPlayersLabel.TabIndex = 7;
            this.teamPlayersLabel.Text = "Teams / Players";
            // 
            // prizesLabel
            // 
            this.prizesLabel.AutoSize = true;
            this.prizesLabel.Location = new System.Drawing.Point(13, 222);
            this.prizesLabel.Name = "prizesLabel";
            this.prizesLabel.Size = new System.Drawing.Size(35, 13);
            this.prizesLabel.TabIndex = 8;
            this.prizesLabel.Text = "Prizes";
            // 
            // selectTeamDropDown
            // 
            this.selectTeamDropDown.FormattingEnabled = true;
            this.selectTeamDropDown.Location = new System.Drawing.Point(112, 122);
            this.selectTeamDropDown.Name = "selectTeamDropDown";
            this.selectTeamDropDown.Size = new System.Drawing.Size(198, 21);
            this.selectTeamDropDown.TabIndex = 9;
            // 
            // tournamentTeamsListBox
            // 
            this.tournamentTeamsListBox.FormattingEnabled = true;
            this.tournamentTeamsListBox.Location = new System.Drawing.Point(453, 122);
            this.tournamentTeamsListBox.Name = "tournamentTeamsListBox";
            this.tournamentTeamsListBox.Size = new System.Drawing.Size(198, 95);
            this.tournamentTeamsListBox.TabIndex = 10;
            // 
            // addTeamButton
            // 
            this.addTeamButton.Location = new System.Drawing.Point(112, 159);
            this.addTeamButton.Name = "addTeamButton";
            this.addTeamButton.Size = new System.Drawing.Size(75, 23);
            this.addTeamButton.TabIndex = 11;
            this.addTeamButton.Text = "Add team";
            this.addTeamButton.UseVisualStyleBackColor = true;
            this.addTeamButton.Click += new System.EventHandler(this.addTeamButton_Click);
            // 
            // createTeamLinkLabel
            // 
            this.createTeamLinkLabel.AutoSize = true;
            this.createTeamLinkLabel.Location = new System.Drawing.Point(201, 163);
            this.createTeamLinkLabel.Name = "createTeamLinkLabel";
            this.createTeamLinkLabel.Size = new System.Drawing.Size(68, 13);
            this.createTeamLinkLabel.TabIndex = 12;
            this.createTeamLinkLabel.TabStop = true;
            this.createTeamLinkLabel.Text = "Create Team";
            this.createTeamLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.createTeamLinkLabel_LinkClicked);
            // 
            // removeSelectedTeamPlayerButton
            // 
            this.removeSelectedTeamPlayerButton.Location = new System.Drawing.Point(657, 122);
            this.removeSelectedTeamPlayerButton.Name = "removeSelectedTeamPlayerButton";
            this.removeSelectedTeamPlayerButton.Size = new System.Drawing.Size(75, 38);
            this.removeSelectedTeamPlayerButton.TabIndex = 13;
            this.removeSelectedTeamPlayerButton.Text = "Remove Selected";
            this.removeSelectedTeamPlayerButton.UseVisualStyleBackColor = true;
            this.removeSelectedTeamPlayerButton.Click += new System.EventHandler(this.removeSelectedTeamPlayerButton_Click);
            // 
            // removeSelectedPrizeButton
            // 
            this.removeSelectedPrizeButton.Location = new System.Drawing.Point(657, 234);
            this.removeSelectedPrizeButton.Name = "removeSelectedPrizeButton";
            this.removeSelectedPrizeButton.Size = new System.Drawing.Size(75, 41);
            this.removeSelectedPrizeButton.TabIndex = 15;
            this.removeSelectedPrizeButton.Text = "Remove Select";
            this.removeSelectedPrizeButton.UseVisualStyleBackColor = true;
            this.removeSelectedPrizeButton.Click += new System.EventHandler(this.removeSelectedPrizeButton_Click);
            // 
            // prizesListBox
            // 
            this.prizesListBox.FormattingEnabled = true;
            this.prizesListBox.Location = new System.Drawing.Point(453, 234);
            this.prizesListBox.Name = "prizesListBox";
            this.prizesListBox.Size = new System.Drawing.Size(198, 95);
            this.prizesListBox.TabIndex = 14;
            // 
            // addPrizeButton
            // 
            this.addPrizeButton.Location = new System.Drawing.Point(15, 242);
            this.addPrizeButton.Name = "addPrizeButton";
            this.addPrizeButton.Size = new System.Drawing.Size(75, 23);
            this.addPrizeButton.TabIndex = 16;
            this.addPrizeButton.Text = "Add prize";
            this.addPrizeButton.UseVisualStyleBackColor = true;
            this.addPrizeButton.Click += new System.EventHandler(this.addPrizeButton_Click);
            // 
            // createTournamentButton
            // 
            this.createTournamentButton.Location = new System.Drawing.Point(315, 356);
            this.createTournamentButton.Name = "createTournamentButton";
            this.createTournamentButton.Size = new System.Drawing.Size(121, 23);
            this.createTournamentButton.TabIndex = 17;
            this.createTournamentButton.Text = "Create tournament";
            this.createTournamentButton.UseVisualStyleBackColor = true;
            this.createTournamentButton.Click += new System.EventHandler(this.createTournamentButton_Click);
            // 
            // CreateTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 450);
            this.Controls.Add(this.createTournamentButton);
            this.Controls.Add(this.addPrizeButton);
            this.Controls.Add(this.removeSelectedPrizeButton);
            this.Controls.Add(this.prizesListBox);
            this.Controls.Add(this.removeSelectedTeamPlayerButton);
            this.Controls.Add(this.createTeamLinkLabel);
            this.Controls.Add(this.addTeamButton);
            this.Controls.Add(this.tournamentTeamsListBox);
            this.Controls.Add(this.selectTeamDropDown);
            this.Controls.Add(this.prizesLabel);
            this.Controls.Add(this.teamPlayersLabel);
            this.Controls.Add(this.selectTeamLabel);
            this.Controls.Add(this.entryFeeTextBox);
            this.Controls.Add(this.createTournamentNameTextBox);
            this.Controls.Add(this.createTournamentNameLabel);
            this.Controls.Add(this.entryFeeLabel);
            this.Controls.Add(this.createTournamentHeaderLabel);
            this.Name = "CreateTournamentForm";
            this.Text = "Create tournament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createTournamentHeaderLabel;
        private System.Windows.Forms.Label entryFeeLabel;
        private System.Windows.Forms.Label createTournamentNameLabel;
        private System.Windows.Forms.TextBox createTournamentNameTextBox;
        private System.Windows.Forms.TextBox entryFeeTextBox;
        private System.Windows.Forms.Label selectTeamLabel;
        private System.Windows.Forms.Label teamPlayersLabel;
        private System.Windows.Forms.Label prizesLabel;
        private System.Windows.Forms.ComboBox selectTeamDropDown;
        private System.Windows.Forms.ListBox tournamentTeamsListBox;
        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.LinkLabel createTeamLinkLabel;
        private System.Windows.Forms.Button removeSelectedTeamPlayerButton;
        private System.Windows.Forms.Button removeSelectedPrizeButton;
        private System.Windows.Forms.ListBox prizesListBox;
        private System.Windows.Forms.Button addPrizeButton;
        private System.Windows.Forms.Button createTournamentButton;
    }
}