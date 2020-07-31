namespace TrackerUI.Forms
{
    partial class CreatePrizeForm
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
            this.placeNumberTextBox = new System.Windows.Forms.TextBox();
            this.placeNumberLabel = new System.Windows.Forms.Label();
            this.createPrizeHeaderLabel = new System.Windows.Forms.Label();
            this.placeNameTextBox = new System.Windows.Forms.TextBox();
            this.PlaceNameLabel = new System.Windows.Forms.Label();
            this.prizeAmountTextBox = new System.Windows.Forms.TextBox();
            this.prizeAmountLabel = new System.Windows.Forms.Label();
            this.prizePercentageTextBox = new System.Windows.Forms.TextBox();
            this.prizePercentageLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // placeNumberTextBox
            // 
            this.placeNumberTextBox.Location = new System.Drawing.Point(103, 56);
            this.placeNumberTextBox.Name = "placeNumberTextBox";
            this.placeNumberTextBox.Size = new System.Drawing.Size(198, 20);
            this.placeNumberTextBox.TabIndex = 17;
            // 
            // placeNumberLabel
            // 
            this.placeNumberLabel.AutoSize = true;
            this.placeNumberLabel.Location = new System.Drawing.Point(12, 59);
            this.placeNumberLabel.Name = "placeNumberLabel";
            this.placeNumberLabel.Size = new System.Drawing.Size(72, 13);
            this.placeNumberLabel.TabIndex = 16;
            this.placeNumberLabel.Text = "Place number";
            // 
            // createPrizeHeaderLabel
            // 
            this.createPrizeHeaderLabel.AutoSize = true;
            this.createPrizeHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPrizeHeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.createPrizeHeaderLabel.Name = "createPrizeHeaderLabel";
            this.createPrizeHeaderLabel.Size = new System.Drawing.Size(112, 24);
            this.createPrizeHeaderLabel.TabIndex = 15;
            this.createPrizeHeaderLabel.Text = "Create Prize";
            // 
            // placeNameTextBox
            // 
            this.placeNameTextBox.Location = new System.Drawing.Point(104, 83);
            this.placeNameTextBox.Name = "placeNameTextBox";
            this.placeNameTextBox.Size = new System.Drawing.Size(198, 20);
            this.placeNameTextBox.TabIndex = 19;
            // 
            // PlaceNameLabel
            // 
            this.PlaceNameLabel.AutoSize = true;
            this.PlaceNameLabel.Location = new System.Drawing.Point(13, 86);
            this.PlaceNameLabel.Name = "PlaceNameLabel";
            this.PlaceNameLabel.Size = new System.Drawing.Size(63, 13);
            this.PlaceNameLabel.TabIndex = 18;
            this.PlaceNameLabel.Text = "Place name";
            // 
            // prizeAmountTextBox
            // 
            this.prizeAmountTextBox.Location = new System.Drawing.Point(104, 114);
            this.prizeAmountTextBox.Name = "prizeAmountTextBox";
            this.prizeAmountTextBox.Size = new System.Drawing.Size(198, 20);
            this.prizeAmountTextBox.TabIndex = 21;
            this.prizeAmountTextBox.Text = "0";
            // 
            // prizeAmountLabel
            // 
            this.prizeAmountLabel.AutoSize = true;
            this.prizeAmountLabel.Location = new System.Drawing.Point(13, 118);
            this.prizeAmountLabel.Name = "prizeAmountLabel";
            this.prizeAmountLabel.Size = new System.Drawing.Size(69, 13);
            this.prizeAmountLabel.TabIndex = 20;
            this.prizeAmountLabel.Text = "Prize Amount";
            // 
            // prizePercentageTextBox
            // 
            this.prizePercentageTextBox.Location = new System.Drawing.Point(470, 114);
            this.prizePercentageTextBox.Name = "prizePercentageTextBox";
            this.prizePercentageTextBox.Size = new System.Drawing.Size(198, 20);
            this.prizePercentageTextBox.TabIndex = 23;
            this.prizePercentageTextBox.Text = "0";
            // 
            // prizePercentageLabel
            // 
            this.prizePercentageLabel.AutoSize = true;
            this.prizePercentageLabel.Location = new System.Drawing.Point(376, 118);
            this.prizePercentageLabel.Name = "prizePercentageLabel";
            this.prizePercentageLabel.Size = new System.Drawing.Size(88, 13);
            this.prizePercentageLabel.TabIndex = 22;
            this.prizePercentageLabel.Text = "Prize Percentage";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "-or-";
            // 
            // createPrizeButton
            // 
            this.createPrizeButton.Location = new System.Drawing.Point(304, 164);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(75, 23);
            this.createPrizeButton.TabIndex = 25;
            this.createPrizeButton.Text = "CreatePrize";
            this.createPrizeButton.UseVisualStyleBackColor = true;
            this.createPrizeButton.Click += new System.EventHandler(this.createPrizeButton_Click);
            // 
            // CreatePrizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 210);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prizePercentageTextBox);
            this.Controls.Add(this.prizePercentageLabel);
            this.Controls.Add(this.prizeAmountTextBox);
            this.Controls.Add(this.prizeAmountLabel);
            this.Controls.Add(this.placeNameTextBox);
            this.Controls.Add(this.PlaceNameLabel);
            this.Controls.Add(this.placeNumberTextBox);
            this.Controls.Add(this.placeNumberLabel);
            this.Controls.Add(this.createPrizeHeaderLabel);
            this.Name = "CreatePrizeForm";
            this.Text = "Create Prize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox placeNumberTextBox;
        private System.Windows.Forms.Label placeNumberLabel;
        private System.Windows.Forms.Label createPrizeHeaderLabel;
        private System.Windows.Forms.TextBox placeNameTextBox;
        private System.Windows.Forms.Label PlaceNameLabel;
        private System.Windows.Forms.TextBox prizeAmountTextBox;
        private System.Windows.Forms.Label prizeAmountLabel;
        private System.Windows.Forms.TextBox prizePercentageTextBox;
        private System.Windows.Forms.Label prizePercentageLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createPrizeButton;
    }
}