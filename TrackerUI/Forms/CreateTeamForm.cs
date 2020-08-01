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
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void createTournamentHeaderLabel_Click(object sender, EventArgs e)
        {

        }

        private void createNewMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel model = new PersonModel();

                model.FirstName = firstNameTextBox.Text;
                model.LastName = lastNameTextBox.Text;
                model.EmailAddress = emailTextBox.Text;
                model.CellphoneNunber = cellphoneNumberTextbox.Text;

                GlobalConfig.Connection.CreatePerson(model);

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
    }
}
