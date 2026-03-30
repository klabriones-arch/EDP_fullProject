using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrionesKent2A
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister nextForm = new frmRegister();
            nextForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLogin nextForm = new frmLogin();
            nextForm.Show();
            this.Hide();
        }

        private void btnStoreStatus_Click(object sender, EventArgs e)
        {
            frmStoreStatus nextForm = new frmStoreStatus();
            nextForm.Show();
        }

        private void btnPricebook_Click(object sender, EventArgs e)
        {
            frmPricebook nextForm = new frmPricebook();
            nextForm.Show();
        }

        private void btnVendors_Click(object sender, EventArgs e)
        {
            frmVendors nextForm = new frmVendors();
            nextForm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUsers nextForm = new frmUsers();
            nextForm.Show();
        }

        private void btnTimeClock_Click(object sender, EventArgs e)
        {
            frmTimeClock nextForm = new frmTimeClock();
            nextForm.Show();
        }
    }
}
