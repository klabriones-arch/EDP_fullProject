using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BrionesKent2A
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        MyDatabase db = new MyDatabase();
        string[,] userCredentials =
        {
            { "Admin", "Cashier" },
            { "admin", "password" },
            { "Kent Briones", "Romelis Pineda" },
            { "Admin Department", "Staff Department" }
        };

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                MessageBox.Show("Please enter username.", "Username Required.");
                tbUsername.Focus();
            }
            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Please enter password.", "Password Required.");
                tbPassword.Focus();
            }
            else
            {
                string query = "SELECT * FROM tbllogincredentials WHERE user_username = @username and user_password = @password AND is_active = 1;";
                DataTable dt = db.ExecuteReturnQuery(query,
                    new MySqlParameter("@username", tbUsername.Text),
                    new MySqlParameter("@password", tbPassword.Text));

                if (dt.Rows.Count > 0)
                {
                    frmHome frm = new frmHome();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid credentials or account is deactivated.", "Login Failed");
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (db.TestConnection())
            {
                MessageBox.Show("Connected to Database");
            }
            else
            {
                MessageBox.Show("Cannot Connected to Database");
            }
        }

    }
}

