using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // step-1

namespace WindowsDBCommunication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Logic to communicate with the DB and insert into the table
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-78LDJ37C\\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True;TrustServerCertificate=True");  //step-2

            SqlCommand cmd = new SqlCommand("Insert into Employee (EmpId,EmpName,EmpSal,EmpAdd)Values(@empid,@empname,@empsal,@empadd)", con);// step-3

            cmd.Parameters.AddWithValue("@empid", txtEmpid.Text);
            cmd.Parameters.AddWithValue("@empname", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@empsal", txtEmpSal.Text);
            cmd.Parameters.AddWithValue("@empadd", txtEmpAdd.Text);

            con.Open();  //step-4

            cmd.ExecuteNonQuery();  // step-5 // insert,update,delete  --action commands 
            con.Close();
            MessageBox.Show("Record Inserted Sucessfully");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //UpdateLogics
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-78LDJ37C\\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True;TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand("Update Employee set EmpName=@empname,EmpSal=@empsal,EmpAdd=@empadd where EmpId=@empid", con);
            cmd.Parameters.AddWithValue("@empid", txtEmpid.Text);
            cmd.Parameters.AddWithValue("@empname", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@empsal", txtEmpSal.Text);
            cmd.Parameters.AddWithValue("@empadd", txtEmpAdd.Text);
            con.Open();  //step-4

            cmd.ExecuteNonQuery();  // step-5 // insert,update,delete  --action commands 
            con.Close();
            MessageBox.Show("Record UPDATED Sucessfully");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete logic 
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-78LDJ37C\\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True;TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand("Delete Employee where EmpId=@empid", con);
            cmd.Parameters.AddWithValue("@empid", txtEmpid.Text);
            
            con.Open();  //step-4

            cmd.ExecuteNonQuery();  // step-5 // insert,update,delete  --action commands 
            con.Close();
            MessageBox.Show("Record deleted Sucessfully");

        }
    }
}
