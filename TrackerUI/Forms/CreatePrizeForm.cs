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
    public partial class CreatePrizeForm : Form
    {
        private IPrizeRequester prizeRequester;
        public CreatePrizeForm(IPrizeRequester prizeRequester)
        {
            InitializeComponent();

            this.prizeRequester = prizeRequester;
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            string errors;

            if (ValidateForm(out errors))
            {
                PrizeModel model = new PrizeModel(placeNumberTextBox.Text, placeNameTextBox.Text, prizeAmountTextBox.Text, prizePercentageTextBox.Text);

                GlobalConfig.Connection.CreatePrize(model);

                prizeRequester.PrizeCreated(model);

                this.Close();
            } 
            else
            {
                MessageBox.Show(errors);
            }
        }

        private bool ValidateForm(out string errors)
        {
            bool output = true;

            int placeNumber;
            bool isPlaceNumberValid = int.TryParse(placeNumberTextBox.Text, out placeNumber);

            decimal prizeAmount = 0;
            bool isPrizeAmountValid = decimal.TryParse(prizeAmountTextBox.Text, out prizeAmount);

            double prizePercentage = 0;
            bool isPrizePercentageValid = double.TryParse(prizePercentageTextBox.Text, out prizePercentage);

            errors = "";

            if (isPlaceNumberValid == false)
            {
                errors += "Please enter a valid number. \n";
                output = false;
            }

            if (placeNumber < 1)
            {
                errors += "Place number must be greater than 0. \n";
                output = false;
            }

            if (placeNameTextBox.Text.Length == 0)
            {
                errors += "Place name can't be empty. \n";
                output = false;
            }

            if (isPrizeAmountValid == false || isPrizePercentageValid == false)
            {
                errors += "Please enter a valid number. \n";
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                errors += "Please enter a valid amount or percentage. \n";
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                errors += "Please enter a valid percentage (0-100). \n";
                output = false;
            }

            if (prizeAmount > 0 && prizePercentage > 0)
            {
                errors += "Please choose between the prize amount or percentage. Leave one at 0. \n";
                output = false;
            }

            return output;
        }
    }
}
