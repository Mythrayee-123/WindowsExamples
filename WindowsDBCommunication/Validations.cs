using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsDBCommunication
{
    public partial class Validations : Form
    {
        public string username;
        public int id;
        public string email = "^[a-zA-z0-9+_.-]+@[a-zA-z0-9.-]+$";
        public string password;
        public string cpassword;


        public Validations()
        {
            InitializeComponent();

        }

        private void Validations_Load(object sender, EventArgs e)
        {
            //Logic


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            listBox1.Items.Add(username);
            listBox1.Items.Add(id);
            listBox1.Items.Add(email);
            listBox1.Items.Add(password);
            listBox1.Items.Add(cpassword);

            if (checkBox1.Checked)
            {
                listBox1.Items.Add("Reading");
                listBox1.Show();
            }
            if (checkBox2.Checked)
            {
                listBox1.Items.Add("dancing");
            }
            if (checkBox3.Checked)
            {
                listBox1.Items.Add("chess");
            }
            if (checkBox4.Checked)
            {
                listBox1.Items.Add("Cricket");
            }

            else if (!checkBox1.Checked || !checkBox1.Checked ||
                !checkBox1.Checked || !checkBox1.Checked)

                MessageBox.Show("Please choose atleast one check box");

            listBox1.Show();

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtUserName.Text))

            {

                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "Please enter name:");
            }
            else if (txtUserName.Text.Length < 5)
            {

                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "Please enter Valid name:");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtUserName.Text, "^[a-zA-Z]"))
            {

                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, " invalid name:");
            }
            else
            {
                errorProvider1.Clear();
                username = txtUserName.Text;

            }

        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")

            {

                txtUserId.Focus();
                errorProvider1.SetError(txtUserId, "Please enter id:");

            }
            else if (!txtUserId.Text.All(c => Char.IsNumber(c)))
            {
                txtUserId.Focus();
                errorProvider1.SetError(txtUserId, "invalid id:");
            }
            else
            {
                errorProvider1.Clear();
                id = int.Parse(txtUserId.Text.ToString());
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")

            {

                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Please enter email:");

            }

            else if (Regex.IsMatch(txtEmail.Text, email) == false)
            {
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "invalid email:");
            }
            else
            {
                errorProvider1.Clear();
                email = txtEmail.Text;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")

            {

                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Please enter password:");

            }
            else if ((txtPassword.Text.Length < 5) || (txtPassword.Text.Length > 10))
            {
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Please enter valid password:");
            }
            else
            {
                errorProvider1.Clear();
                password = txtPassword.Text;
            }
        }

        private void txtCOnf_TextChanged(object sender, EventArgs e)
        {
            if (txtCOnf.Text == "")

            {

                txtCOnf.Focus();
                errorProvider1.SetError(txtCOnf, "Please confirm password:");

            }
            else if (txtCOnf.Text != password)
            {
                txtCOnf.Focus();
                errorProvider1.SetError(txtCOnf, "invalid,try again:");
            }
            else
            {
                errorProvider1.Clear();
                cpassword = txtCOnf.Text;
            }
        }
    }

}
