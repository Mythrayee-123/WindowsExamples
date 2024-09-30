using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsDBCommunication
{
    public partial class DBCommunicationWIthSP : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);
        public DBCommunicationWIthSP()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Logic to communicate with the DB and insert into the table

            SqlCommand cmd = new SqlCommand("usp_InsertEmployee", con);// step-3
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@empid", txtEmpid.Text);
            cmd.Parameters.AddWithValue("@empname", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@empsal", txtEmpSal.Text);
            cmd.Parameters.AddWithValue("@empadd", txtEmpAdd.Text);

            con.Open();  //step-4

            cmd.ExecuteNonQuery();  // step-5 // insert,update,delete  --action commands 
            con.Close();
            MessageBox.Show("Record Inserted Sucessfully");

        }
    }
}
