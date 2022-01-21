using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FMCodeFirstTryWin
{
    public partial class Insert : Form
    {
        string errMsg = "";

        const int MinAge = -14;
        const string errTitleInsert = "Error while inserting drivers data:";

        public Insert()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                try
                {
                    //Save Records
                    Driver oDriver = new Driver();
                    bool isSaved = oDriver.CreateNewDriver(txtFirstName.Text, txtLastName.Text, dtDOB.Value, cmbCountry.SelectedText, txtLicNo.Text, dtLicExpiry.Value, txtLicFile.Text);
                    if (isSaved)
                        lblError.Text = "Record saved successfully.";
                }
                catch (Exception ex)
                {
                    string errorMsg = errTitleInsert + " \n" + ex.Message;

#if DEBUG
                    errorMsg = errorMsg + " \n" + ex.StackTrace;
#endif

                    lblError.Text = errorMsg;
                }
            }
            else
            {

            }
            
        }

        private void PopulateCombo()
        {
            //Connect to database and get the values
            List<string> countries = new List<string>();
            countries.Add("New Zealand");
            countries.Add("India");
            countries.Add("Australia");
            countries.Add("UK");
            countries.Add("More...");

            cmbCountry.DataSource = countries;

        }

        private void ClearForm(bool pIsClearError = true)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtLicFile.Text = "";
            txtLicNo.Text = "";
            cmbCountry.SelectedIndex = -1;
            dtDOB.Value = DateTime.Today;
            dtLicExpiry.Value = DateTime.Today;

            if (pIsClearError)
                lblError.Text = "";
        }
        
        private bool IsValid()
        {
            errMsg = "";

            if (txtFirstName.Text == "")
                errMsg = errMsg + "\n" + "First Name Required.";

            if (txtLastName.Text == "")
                errMsg = errMsg + "\n" + "Last Name Required.";

            if (dtDOB.Value > DateTime.Today.AddYears(MinAge))
                errMsg = errMsg + "\n" + $"Age must >= { -1*MinAge} Years.";

            if (txtLicNo.Text == "")
                errMsg = errMsg + "\n" + "License Number Required.";

            if (dtLicExpiry.Value < DateTime.Today)
                errMsg = errMsg + "\n" + "License must be Valid.";

            lblError.Text = errMsg;

            return errMsg.Length>0?false:true;
        }

        private void Insert_Load(object sender, EventArgs e)
        {
            PopulateCombo();
            ClearForm();
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            txtLicFile.Text = openFileDialog1.FileName;
        }
    }
}
