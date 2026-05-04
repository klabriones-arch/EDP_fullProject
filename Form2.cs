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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegisterClosing(object sender, FormClosingEventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
        }
    }
}
