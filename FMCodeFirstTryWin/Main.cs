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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        const string errTitleGet = "Error while retriving drivers data";
        
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            BindAllDrivers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Insert insert = new Insert();
            insert.ShowDialog();

            //refresh records
            BindAllDrivers();
        }

        private void BindAllDrivers()
        {
            //Create object of driver class and call get all records method
            Driver oDriver = new Driver();

            try
            {
                DataTable dtAllDrivers = oDriver.GetAllDrivers();
                listDrivers.DataSource = dtAllDrivers;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;

#if DEBUG
                errorMsg = errorMsg + " \n" + ex.StackTrace;
#endif

                MessageBox.Show(errorMsg, errTitleGet, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
