using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsDBCommunication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lnk_NewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f = new ValidationsReview();
            f.Show();
        }

        private void lnk_forgotpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f = new ForogotPassword();
            f.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //if login sucess we need to redirect to change password
        }
    }
}
