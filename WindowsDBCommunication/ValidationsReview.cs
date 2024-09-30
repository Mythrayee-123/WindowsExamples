using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsDBCommunication
{
    public partial class ValidationsReview : Form
    {
        public ValidationsReview()
        {
            InitializeComponent();
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            //UserName should accet min 5 chars 

            if (txtUserName.Text.Length <= 5)
            {
                MessageBox.Show("Please Enter Username with min 5 chars");
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Username should accept only alphabets

            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only alphabets");
            }
        }

        private void txtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            //UserId should accept only numbers
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits");
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = "^[a-zA-z0-9+_.-]+@[a-zA-z0-9.-]+$";  // regular expression
            if (!Regex.IsMatch(txtEmail.Text, email))
            {
                MessageBox.Show("invalid email:");
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length <= 5 && txtPassword.Text.Length > 10)
            {
                MessageBox.Show("Username should be min of 5 chars and max of 10 chars");
            }
        }

        private void txtCOnf_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtCOnf.Text)
            {
                MessageBox.Show("Password and confirm password is not matching");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string hobbies = string.Empty;

            if (checkBox1.Checked)
            {
                hobbies += checkBox1.Text + ",";
            }
            if (checkBox2.Checked)
            {
                hobbies += checkBox2.Text + ",";
            }
            if (checkBox3.Checked)
            {
                hobbies += checkBox3.Text + ",";
            }
            if (checkBox4.Checked)
            {
                hobbies += checkBox4.Text + ",";
            }

            if (string.IsNullOrEmpty(hobbies))
            {
                MessageBox.Show("Atleast one hobbies should be selected");
            }

            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtUserId.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtCOnf.Text) && !string.IsNullOrEmpty(hobbies))
            {
                //add items to listbox
                listBox1.Items.Add(txtUserName.Text);
                listBox1.Items.Add(txtUserId.Text);
                listBox1.Items.Add(txtEmail.Text);
                listBox1.Items.Add(txtPassword.Text);
                listBox1.Items.Add(txtCOnf.Text);
                listBox1.Items.Add(hobbies);

                #region DBLogic 
                //Add all fields to Database table 

                #endregion
            }
            else
            {
                MessageBox.Show("All fields are mandatory");
            }
           
        }
    }
}
