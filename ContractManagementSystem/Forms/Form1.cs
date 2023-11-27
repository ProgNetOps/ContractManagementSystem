using ContractManagementSystem.Forms;
using SLRDbConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContractManagementSystem
{
    public partial class Form1 : Form
    {
        DbConnector db;
        public Form1()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                if (CheckLogin())
                {
                    using (Form_Dashboard fd = new Form_Dashboard())
                    {
                        fd.ShowDialog();
                    }
                }
            }
        }

        private bool CheckLogin()
        {
            string username = db.getSingleValue("SELECT UserName from tblUsers WHERE UserName='"+txtUserName.Text+"'and Password ='"+txtPassword.Text+"'",out username,0);
            if (username==null)
            {
                MessageBox.Show("Username or Password is incorrect", "Incorrect Details", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isFormValid()
        {
            if (txtUserName.Text.Trim() == string.Empty || txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Required Fields are Empty", "Please Fill All Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
