using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI.Forms
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        private BindingList<int> rounds = new BindingList<int>();
        private BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            roundsDropDown.DataSource = rounds;

            matchupsListBox.DataSource = selectedMatchups;
            matchupsListBox.DisplayMember = nameof(MatchupModel.DisplayName);

            LoadFormData();
            LoadRounds();
            LoadMatchups();
        }

        private void LoadFormData()
        {
            tournamentNameLabel.Text = tournament.TournamentName;
        }

        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1);

            int currentRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }
        }

        private void unplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups();
            LoadMatchupEntry();
        }

        private void roundsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups();
            LoadMatchupEntry();
        }

        private void LoadMatchups()
        {
            int selectedRound = (int)roundsDropDown.SelectedItem;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == selectedRound)
                {
                    selectedMatchups.Clear();

                    foreach (MatchupModel matchup in matchups)
                    {
                        if (matchup.Winner == null || unplayedOnlyCheckBox.Checked == false)
                        {
                            selectedMatchups.Add(matchup);
                        }
                    }
                }
            }

            DisplayMatchupInfo();
        }

        private void LoadMatchupEntry()
        {
            MatchupModel matchup = (MatchupModel)matchupsListBox.SelectedItem;

            if (matchup == null)
            {
                return;
            }

            for (int i = 0; i < matchup.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (matchup.Entries[i].TeamCompeting == null)
                    {
                        teamOneNameLabel.Text = "Not yet detemined";
                        teamOneScoreTextBox.Text = "";
                    }
                    else
                    {
                        teamOneNameLabel.Text = matchup.Entries[i].TeamCompeting.TeamName;
                        teamOneScoreTextBox.Text = matchup.Entries[i].Score.ToString();
                    }

                    teamTwoNameLabel.Text = "-";
                    teamTwoScoreTextBox.Text = "-";
                }
                else if (i == 1)
                {
                    if (matchup.Entries[i].TeamCompeting == null)
                    {
                        teamTwoNameLabel.Text = "Not yet detemined";
                        teamTwoScoreTextBox.Text = "";
                    }
                    else
                    {
                        teamTwoNameLabel.Text = matchup.Entries[i].TeamCompeting.TeamName;
                        teamTwoScoreTextBox.Text = matchup.Entries[i].Score.ToString();
                    }
                }
            }
        }

        private void DisplayMatchupInfo()
        {
            bool hasMatchups = selectedMatchups.Count > 0;

            matchupEntryPanel.Visible = hasMatchups;
        }

        private void matchupsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchupEntry();
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            MatchupModel selectedMatchup = (MatchupModel)matchupsListBox.SelectedItem;

            if (selectedMatchup == null)
            {
                return;
            }

            int teamOneScore = 0;
            int teamTwoScore = 0;

            for (int i = 0; i < selectedMatchup.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (selectedMatchup.Entries[i].TeamCompeting != null)
                    {
                        bool isScoreValid = int.TryParse(teamOneScoreTextBox.Text, out teamOneScore);

                        if (isScoreValid && teamOneScore >= 0)
                        {
                            selectedMatchup.Entries[i].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show($"Please enter a valid positive number for the { selectedMatchup.Entries[i].TeamCompeting.TeamName } score.");
                            return;
                        }
                    }
                }
                else if (i == 1)
                {
                    if (selectedMatchup.Entries[i].TeamCompeting != null)
                    {
                        bool isScoreValid = int.TryParse(teamTwoScoreTextBox.Text, out teamTwoScore);

                        if (isScoreValid && teamTwoScore >= 0)
                        {
                            selectedMatchup.Entries[i].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show($"Please enter a valid positive number for the { selectedMatchup.Entries[i].TeamCompeting.TeamName } score.");
                            return;
                        }
                    }
                }
            }

            if (teamOneScore > teamTwoScore)
            {
                selectedMatchup.Winner = selectedMatchup.Entries[0].TeamCompeting;
            }
            else if (teamOneScore < teamTwoScore)
            {
                selectedMatchup.Winner = selectedMatchup.Entries[1].TeamCompeting;
            }
            else
            {
                MessageBox.Show("This tournament can't have ties.");
                return;
            }

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                foreach (MatchupModel matchup in matchups)
                {
                    foreach (MatchupEntryModel entry in matchup.Entries)
                    {
                        if (entry.ParentMatchup != null && entry.ParentMatchup.Id == selectedMatchup.Id)
                        {
                            entry.TeamCompeting = selectedMatchup.Winner;
                            GlobalConfig.Connection.UpdateMatchup(matchup);
                        }
                    }
                }
            }

            GlobalConfig.Connection.UpdateMatchup(selectedMatchup);

            if (unplayedOnlyCheckBox.Checked)
            {
                LoadMatchups();
                LoadMatchupEntry();
            }
        }
    }
}
