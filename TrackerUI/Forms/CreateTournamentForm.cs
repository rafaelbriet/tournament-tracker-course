using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        private BindingList<TeamModel> avaibleTeams = new BindingList<TeamModel>(GlobalConfig.Connection.GetTeam_All());
        private BindingList<TeamModel> selectedTeams = new BindingList<TeamModel>();
        private BindingList<PrizeModel> selectedPrizes = new BindingList<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            selectTeamDropDown.DataSource = avaibleTeams;
            selectTeamDropDown.DisplayMember = nameof(TeamModel.TeamName);

            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = nameof(TeamModel.TeamName);

            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = nameof(PrizeModel.PlaceName);
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)selectTeamDropDown.SelectedItem;

            if (team == null)
            {
                return;
            }

            avaibleTeams.Remove(team);
            selectedTeams.Add(team);
        }

        private void removeSelectedTeamPlayerButton_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)tournamentTeamsListBox.SelectedItem;

            if (team == null)
            {
                return;
            }

            avaibleTeams.Add(team);
            selectedTeams.Remove(team);
        }

        private void removeSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel prize = (PrizeModel)prizesListBox.SelectedItem;

            if (prize == null)
            {
                return;
            }

            selectedPrizes.Remove(prize);
        }

        private void addPrizeButton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm prizeForm = new CreatePrizeForm(this);
            prizeForm.Show();
        }

        public void PrizeCreated(PrizeModel prize)
        {
            selectedPrizes.Add(prize);
        }

        private void createTeamLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm teamForm = new CreateTeamForm(this);
            teamForm.Show();
        }

        public void TeamCreated(TeamModel team)
        {
            selectedTeams.Add(team);
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            decimal fee = 0;
            bool isFeeValid = decimal.TryParse(entryFeeTextBox.Text, out fee);

            if (isFeeValid == false)
            {
                MessageBox.Show("Please enter a valid entry fee.", "Invalid Entry Fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TournamentModel tournament = new TournamentModel();

            tournament.TournamentName = createTournamentNameTextBox.Text;
            tournament.EntryFee = fee;
            tournament.EnteredTeams = selectedTeams.ToList();
            tournament.Prizes = selectedPrizes.ToList();

            TournamentLogic.CreateRounds(tournament);

            GlobalConfig.Connection.CreateTournament(tournament);

            TournamentLogic.UpdateTournamentResults(tournament);

            TournamentViewerForm tournamentViewerForm = new TournamentViewerForm(tournament);
            tournamentViewerForm.Show();
            Close();
        }
    }
}
