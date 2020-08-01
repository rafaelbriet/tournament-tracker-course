namespace TrackerUI.Forms
{
    partial class CreateTeamForm
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
            this.addMemberButton = new System.Windows.Forms.Button();
            this.teamMembersListBox = new System.Windows.Forms.ListBox();
            this.selectTeamMemberDropDown = new System.Windows.Forms.ComboBox();
            this.selectTeamMemberLabel = new System.Windows.Forms.Label();
            this.teamNameTextBox = new System.Windows.Forms.TextBox();
            this.createTeamNameLabel = new System.Windows.Forms.Label();
            this.createTeamHeaderLabel = new System.Windows.Forms.Label();
            this.addNewMemberGroupBox = new System.Windows.Forms.GroupBox();
            this.createNewMemberButton = new System.Windows.Forms.Button();
            this.cellphoneNumberTextbox = new System.Windows.Forms.TextBox();
            this.cellphoneNumberLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.createNewTeamButton = new System.Windows.Forms.Button();
            this.removeSelectedMemberButton = new System.Windows.Forms.Button();
            this.addNewMemberGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // addMemberButton
            // 
            this.addMemberButton.Location = new System.Drawing.Point(131, 159);
            this.addMemberButton.Name = "addMemberButton";
            this.addMemberButton.Size = new System.Drawing.Size(75, 23);
            this.addMemberButton.TabIndex = 19;
            this.addMemberButton.Text = "Add member";
            this.addMemberButton.UseVisualStyleBackColor = true;
            this.addMemberButton.Click += new System.EventHandler(this.addMemberButton_Click);
            // 
            // teamMembersListBox
            // 
            this.teamMembersListBox.FormattingEnabled = true;
            this.teamMembersListBox.Location = new System.Drawing.Point(356, 122);
            this.teamMembersListBox.Name = "teamMembersListBox";
            this.teamMembersListBox.Size = new System.Drawing.Size(238, 225);
            this.teamMembersListBox.TabIndex = 18;
            // 
            // selectTeamMemberDropDown
            // 
            this.selectTeamMemberDropDown.FormattingEnabled = true;
            this.selectTeamMemberDropDown.Location = new System.Drawing.Point(131, 123);
            this.selectTeamMemberDropDown.Name = "selectTeamMemberDropDown";
            this.selectTeamMemberDropDown.Size = new System.Drawing.Size(198, 21);
            this.selectTeamMemberDropDown.TabIndex = 17;
            // 
            // selectTeamMemberLabel
            // 
            this.selectTeamMemberLabel.AutoSize = true;
            this.selectTeamMemberLabel.Location = new System.Drawing.Point(13, 122);
            this.selectTeamMemberLabel.Name = "selectTeamMemberLabel";
            this.selectTeamMemberLabel.Size = new System.Drawing.Size(108, 13);
            this.selectTeamMemberLabel.TabIndex = 15;
            this.selectTeamMemberLabel.Text = "Select Team Member";
            // 
            // teamNameTextBox
            // 
            this.teamNameTextBox.Location = new System.Drawing.Point(131, 56);
            this.teamNameTextBox.Name = "teamNameTextBox";
            this.teamNameTextBox.Size = new System.Drawing.Size(198, 20);
            this.teamNameTextBox.TabIndex = 14;
            // 
            // createTeamNameLabel
            // 
            this.createTeamNameLabel.AutoSize = true;
            this.createTeamNameLabel.Location = new System.Drawing.Point(12, 59);
            this.createTeamNameLabel.Name = "createTeamNameLabel";
            this.createTeamNameLabel.Size = new System.Drawing.Size(63, 13);
            this.createTeamNameLabel.TabIndex = 13;
            this.createTeamNameLabel.Text = "Team name";
            // 
            // createTeamHeaderLabel
            // 
            this.createTeamHeaderLabel.AutoSize = true;
            this.createTeamHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTeamHeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.createTeamHeaderLabel.Name = "createTeamHeaderLabel";
            this.createTeamHeaderLabel.Size = new System.Drawing.Size(119, 24);
            this.createTeamHeaderLabel.TabIndex = 12;
            this.createTeamHeaderLabel.Text = "Create Team";
            // 
            // addNewMemberGroupBox
            // 
            this.addNewMemberGroupBox.Controls.Add(this.createNewMemberButton);
            this.addNewMemberGroupBox.Controls.Add(this.cellphoneNumberTextbox);
            this.addNewMemberGroupBox.Controls.Add(this.cellphoneNumberLabel);
            this.addNewMemberGroupBox.Controls.Add(this.emailTextBox);
            this.addNewMemberGroupBox.Controls.Add(this.emailLabel);
            this.addNewMemberGroupBox.Controls.Add(this.lastNameTextBox);
            this.addNewMemberGroupBox.Controls.Add(this.lastNameLabel);
            this.addNewMemberGroupBox.Controls.Add(this.firstNameTextBox);
            this.addNewMemberGroupBox.Controls.Add(this.firstNameLabel);
            this.addNewMemberGroupBox.Location = new System.Drawing.Point(15, 199);
            this.addNewMemberGroupBox.Name = "addNewMemberGroupBox";
            this.addNewMemberGroupBox.Size = new System.Drawing.Size(314, 178);
            this.addNewMemberGroupBox.TabIndex = 20;
            this.addNewMemberGroupBox.TabStop = false;
            this.addNewMemberGroupBox.Text = "Add new member";
            // 
            // createNewMemberButton
            // 
            this.createNewMemberButton.Location = new System.Drawing.Point(101, 138);
            this.createNewMemberButton.Name = "createNewMemberButton";
            this.createNewMemberButton.Size = new System.Drawing.Size(116, 23);
            this.createNewMemberButton.TabIndex = 8;
            this.createNewMemberButton.Text = "Create Member";
            this.createNewMemberButton.UseVisualStyleBackColor = true;
            this.createNewMemberButton.Click += new System.EventHandler(this.createNewMemberButton_Click);
            // 
            // cellphoneNumberTextbox
            // 
            this.cellphoneNumberTextbox.Location = new System.Drawing.Point(67, 103);
            this.cellphoneNumberTextbox.Name = "cellphoneNumberTextbox";
            this.cellphoneNumberTextbox.Size = new System.Drawing.Size(241, 20);
            this.cellphoneNumberTextbox.TabIndex = 7;
            // 
            // cellphoneNumberLabel
            // 
            this.cellphoneNumberLabel.AutoSize = true;
            this.cellphoneNumberLabel.Location = new System.Drawing.Point(6, 107);
            this.cellphoneNumberLabel.Name = "cellphoneNumberLabel";
            this.cellphoneNumberLabel.Size = new System.Drawing.Size(54, 13);
            this.cellphoneNumberLabel.TabIndex = 6;
            this.cellphoneNumberLabel.Text = "Cellphone";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(67, 77);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(241, 20);
            this.emailTextBox.TabIndex = 5;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(6, 81);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "Email";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(67, 51);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(241, 20);
            this.lastNameTextBox.TabIndex = 3;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(6, 55);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(58, 13);
            this.lastNameLabel.TabIndex = 2;
            this.lastNameLabel.Text = "Last Name";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(67, 25);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(241, 20);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(6, 29);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(54, 13);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "Firs Name";
            // 
            // createNewTeamButton
            // 
            this.createNewTeamButton.Location = new System.Drawing.Point(265, 404);
            this.createNewTeamButton.Name = "createNewTeamButton";
            this.createNewTeamButton.Size = new System.Drawing.Size(75, 23);
            this.createNewTeamButton.TabIndex = 21;
            this.createNewTeamButton.Text = "Create team";
            this.createNewTeamButton.UseVisualStyleBackColor = true;
            // 
            // removeSelectedMemberButton
            // 
            this.removeSelectedMemberButton.Location = new System.Drawing.Point(419, 354);
            this.removeSelectedMemberButton.Name = "removeSelectedMemberButton";
            this.removeSelectedMemberButton.Size = new System.Drawing.Size(116, 23);
            this.removeSelectedMemberButton.TabIndex = 9;
            this.removeSelectedMemberButton.Text = "Remove Selected";
            this.removeSelectedMemberButton.UseVisualStyleBackColor = true;
            this.removeSelectedMemberButton.Click += new System.EventHandler(this.removeSelectedMemberButton_Click);
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 450);
            this.Controls.Add(this.removeSelectedMemberButton);
            this.Controls.Add(this.createNewTeamButton);
            this.Controls.Add(this.addNewMemberGroupBox);
            this.Controls.Add(this.addMemberButton);
            this.Controls.Add(this.teamMembersListBox);
            this.Controls.Add(this.selectTeamMemberDropDown);
            this.Controls.Add(this.selectTeamMemberLabel);
            this.Controls.Add(this.teamNameTextBox);
            this.Controls.Add(this.createTeamNameLabel);
            this.Controls.Add(this.createTeamHeaderLabel);
            this.Name = "CreateTeamForm";
            this.Text = "Create Team";
            this.addNewMemberGroupBox.ResumeLayout(false);
            this.addNewMemberGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addMemberButton;
        private System.Windows.Forms.ListBox teamMembersListBox;
        private System.Windows.Forms.ComboBox selectTeamMemberDropDown;
        private System.Windows.Forms.Label selectTeamMemberLabel;
        private System.Windows.Forms.TextBox teamNameTextBox;
        private System.Windows.Forms.Label createTeamNameLabel;
        private System.Windows.Forms.Label createTeamHeaderLabel;
        private System.Windows.Forms.GroupBox addNewMemberGroupBox;
        private System.Windows.Forms.Button createNewMemberButton;
        private System.Windows.Forms.TextBox cellphoneNumberTextbox;
        private System.Windows.Forms.Label cellphoneNumberLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Button createNewTeamButton;
        private System.Windows.Forms.Button removeSelectedMemberButton;
    }
}