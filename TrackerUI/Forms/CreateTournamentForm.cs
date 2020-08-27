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
    public partial class CreateTournamentForm : Form
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

        private void deleteSelectedTeamPlayerButton_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)tournamentTeamsListBox.SelectedItem;

            if (team == null)
            {
                return;
            }

            avaibleTeams.Add(team);
            selectedTeams.Remove(team);
        }
    }
}
