using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private void roundsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups();
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
                        selectedMatchups.Add(matchup);
                    }
                }
            }
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

        private void matchupsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchupEntry();
        }
    }
}
