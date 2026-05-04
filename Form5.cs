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
    public partial class frmVendors : Form
    {
        public frmVendors()
        {
            InitializeComponent();
        }

        private void frmVendorsClosing(object sender, FormClosingEventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
        }
    }
}
