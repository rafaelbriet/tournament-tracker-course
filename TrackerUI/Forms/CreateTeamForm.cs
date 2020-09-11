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
    public partial class CreateTeamForm : Form
    {
        private BindingList<PersonModel> availableTeamMembers = new BindingList<PersonModel>(GlobalConfig.Connection.GetPerson_All());
        private BindingList<PersonModel> selectedTeamMembers = new BindingList<PersonModel>();
        private ITeamRequester teamRequester;

        public CreateTeamForm(ITeamRequester teamRequester)
        {
            InitializeComponent();

            //CreateSampleData();

            WireUpLists();
            this.teamRequester = teamRequester;
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Peter", LastName = "Park"});
            availableTeamMembers.Add(new PersonModel { FirstName = "Stephen", LastName = "Stranger"});
            availableTeamMembers.Add(new PersonModel { FirstName = "Carol", LastName = "Danvers"});

            selectedTeamMembers.Add(new PersonModel { FirstName = "Natasha", LastName = "Romanova" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Tony", LastName = "Stark" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Steve", LastName = "Rogers" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Bruce", LastName = "Banner" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Thor", LastName = "Odinson" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Clint", LastName = "Barton" });
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        private void createNewMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel model = new PersonModel();

                model.FirstName = firstNameTextBox.Text;
                model.LastName = lastNameTextBox.Text;
                model.EmailAddress = emailTextBox.Text;
                model.CellphoneNumber = cellphoneNumberTextbox.Text;

                model = GlobalConfig.Connection.CreatePerson(model);

                selectedTeamMembers.Add(model);

                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                emailTextBox.Text = "";
                cellphoneNumberTextbox.Text = "";
            }
            else
            {
                MessageBox.Show("All fields are require to add a new member.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;

            if (firstNameTextBox.Text.Length == 0)
            {
                output = false;
            }

            if (lastNameTextBox.Text.Length == 0)
            {
                output = false;
            }

            if (emailTextBox.Text.Length == 0)
            {
                output = false;
            }

            if (cellphoneNumberTextbox.Text.Length == 0)
            {
                output = false;
            }

            return output;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel person = (PersonModel) selectTeamMemberDropDown.SelectedItem;

            if (person == null)
            {
                return;
            }

            availableTeamMembers.Remove(person);
            selectedTeamMembers.Add(person);
        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel person = (PersonModel) teamMembersListBox.SelectedItem;

            if (person == null)
            {
                return;
            }

            availableTeamMembers.Add(person);
            selectedTeamMembers.Remove(person);
        }

        private void createNewTeamButton_Click(object sender, EventArgs e)
        {
            string errors;

            if (ValidateCreateTeamForm(out errors))
            {
                TeamModel team = new TeamModel();

                team.TeamName = teamNameTextBox.Text;
                team.TeamMembers = selectedTeamMembers.ToList();

                GlobalConfig.Connection.CreateTeam(team);

                teamRequester.TeamCreated(team);

                this.Close();
            }
            else
            {
                MessageBox.Show(errors);
            }
        }

        private bool ValidateCreateTeamForm(out string errors)
        {
            bool output = true;

            errors = "";

            if (teamNameTextBox.Text.Length == 0)
            {
                errors += "A team needs a name to be created.\n";
                output = false;
            }

            if (selectedTeamMembers.Count == 0)
            {
                errors += "A team needs at least one member to be created.\n";
                output = false;
            }

            return output;
        }
    }
}
