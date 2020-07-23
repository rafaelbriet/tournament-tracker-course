﻿namespace TrackerUI.Forms
{
    partial class TournamentDashboardForm
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
            this.loadTournamentButton = new System.Windows.Forms.Button();
            this.selectTeamMemberDropDown = new System.Windows.Forms.ComboBox();
            this.tournamentDashboardHeaderLabel = new System.Windows.Forms.Label();
            this.createTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadTournamentButton
            // 
            this.loadTournamentButton.Location = new System.Drawing.Point(94, 76);
            this.loadTournamentButton.Name = "loadTournamentButton";
            this.loadTournamentButton.Size = new System.Drawing.Size(119, 23);
            this.loadTournamentButton.TabIndex = 23;
            this.loadTournamentButton.Text = "Load toutnament";
            this.loadTournamentButton.UseVisualStyleBackColor = true;
            // 
            // selectTeamMemberDropDown
            // 
            this.selectTeamMemberDropDown.FormattingEnabled = true;
            this.selectTeamMemberDropDown.Location = new System.Drawing.Point(16, 49);
            this.selectTeamMemberDropDown.Name = "selectTeamMemberDropDown";
            this.selectTeamMemberDropDown.Size = new System.Drawing.Size(275, 21);
            this.selectTeamMemberDropDown.TabIndex = 22;
            // 
            // tournamentDashboardHeaderLabel
            // 
            this.tournamentDashboardHeaderLabel.AutoSize = true;
            this.tournamentDashboardHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentDashboardHeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.tournamentDashboardHeaderLabel.Name = "tournamentDashboardHeaderLabel";
            this.tournamentDashboardHeaderLabel.Size = new System.Drawing.Size(279, 24);
            this.tournamentDashboardHeaderLabel.TabIndex = 20;
            this.tournamentDashboardHeaderLabel.Text = "Tournament Tracker Dashboard";
            // 
            // createTournamentButton
            // 
            this.createTournamentButton.Location = new System.Drawing.Point(94, 129);
            this.createTournamentButton.Name = "createTournamentButton";
            this.createTournamentButton.Size = new System.Drawing.Size(120, 23);
            this.createTournamentButton.TabIndex = 24;
            this.createTournamentButton.Text = "Create tournament";
            this.createTournamentButton.UseVisualStyleBackColor = true;
            // 
            // TournamentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 184);
            this.Controls.Add(this.createTournamentButton);
            this.Controls.Add(this.loadTournamentButton);
            this.Controls.Add(this.selectTeamMemberDropDown);
            this.Controls.Add(this.tournamentDashboardHeaderLabel);
            this.Name = "TournamentDashboardForm";
            this.Text = "Tournament Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadTournamentButton;
        private System.Windows.Forms.ComboBox selectTeamMemberDropDown;
        private System.Windows.Forms.Label tournamentDashboardHeaderLabel;
        private System.Windows.Forms.Button createTournamentButton;
    }
}