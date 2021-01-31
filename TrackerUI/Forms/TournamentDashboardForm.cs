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
    public partial class TournamentDashboardForm : Form
    {
        private BindingList<TournamentModel> tournaments = new BindingList<TournamentModel>(GlobalConfig.Connection.GetTournament_All());

        public TournamentDashboardForm()
        {
            InitializeComponent();

            WireUpList();
        }

        private void WireUpList()
        {
            selectTournamentDropDown.DataSource = tournaments;
            selectTournamentDropDown.DisplayMember = nameof(TournamentModel.TournamentName);
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm createTournamentForm = new CreateTournamentForm();
            createTournamentForm.Show();
        }
    }
}
