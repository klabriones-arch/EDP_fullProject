using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace BrionesKent2A
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        MyDatabase db = new MyDatabase();
        bool isUpdate = false;

        private void frmUsersCLosing(object sender, FormClosingEventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            isUpdate = false;
            string query = "SELECT tbluserinformation.userID, tbllogincredentials.LoginID, tbluserinformation.firstname, " +
                "tbluserinformation.middlename, tbluserinformation.lastname, tbluserinformation.emailAddress," +
                " tbluserinformation.homeAddress, tbluserinformation.birthDate, tbllogincredentials.user_username as 'Username'," +
                " tbllogincredentials.user_password as 'Password' FROM tbllogincredentials INNER JOIN tbluserinformation" +
                " ON tbllogincredentials.userID = tbluserinformation.userID;";

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsers.DataSource = db.ExecuteReturnQuery(query);
            dgvUsers.Columns[0].Visible = false;
            dgvUsers.Columns[1].Visible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isUpdate == false)
            {
                int idUserInfo = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
                int idLoginCredentials = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[1].Value);

                string query = "UPDATE tbluserinformation SET firstname=@fname, middlename=@mname, lastname=@lname, " +
                    "emailAddress=@email, homeAddress=@hadd, birthDate=@bDate WHERE userID=@uid;" +
                    "UPDATE tbllogincredentials SET user_username=@username, user_password=@password WHERE LoginID=@lid;";

                int affectedRowCount = db.ExecuteNoReturnQuery(query,
                    new MySqlParameter("@fname", tbFname.Text),
                    new MySqlParameter("@mname", tbMname.Text),
                    new MySqlParameter("@lname", tbLname.Text),
                    new MySqlParameter("@email", tbEmailAdd.Text),
                    new MySqlParameter("@hadd", tbHomeAdd.Text),
                    new MySqlParameter("@bDate", dtpBirthDate.Value),
                    new MySqlParameter("@username", tbUsername.Text),
                    new MySqlParameter("@password", tbPassword.Text),
                    new MySqlParameter("@uid", idUserInfo),
                    new MySqlParameter("@lid", idLoginCredentials));

                if (affectedRowCount > 0)
                {
                    MessageBox.Show("Data Inserted!");
                    frmUsers_Load(null, null);
                }
            }
            else if (isUpdate == true)
            {
                isUpdate = false;
            }

        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to deactivate this account?", "Account Deactivation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[1].Value);
                    string query = "UPDATE tbllogincredentials SET is_active = 0 where LoginID = @id";

                    int affectedRows = db.ExecuteNoReturnQuery(query,
                        new MySqlParameter("@id", id));
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Account is deactivated!");
                        frmUsers_Load(null, null);
                    }

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) 
                {
                    MessageBox.Show("Please select a user from the list first!", "No Selection");
                    return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to update this account?", "Update Account", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                {
                    isUpdate = true;
                    int idUserInfo = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
                    int idLoginCredentials = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[1].Value);
                    tbFname.Text = dgvUsers.SelectedRows[0].Cells[2].Value.ToString();
                    tbMname.Text = dgvUsers.SelectedRows[0].Cells[3].Value.ToString();
                    tbLname.Text = dgvUsers.SelectedRows[0].Cells[4].Value.ToString();
                    tbEmailAdd.Text = dgvUsers.SelectedRows[0].Cells[5].Value.ToString();
                    tbHomeAdd.Text = dgvUsers.SelectedRows[0].Cells[6].Value.ToString();
                    dtpBirthDate.Value = Convert.ToDateTime(dgvUsers.SelectedRows[0].Cells[7].Value);
                    tbUsername.Text = dgvUsers.SelectedRows[0].Cells[8].Value.ToString();
                    tbPassword.Text = "";
            }  
        }
    }
}
