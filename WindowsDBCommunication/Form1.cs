using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime; // step-1

namespace WindowsDBCommunication
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);
        int currentrow = 0;
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Logic to communicate with the DB and insert into the table

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
            try
            {

                //Delete logic 

                SqlCommand cmd = new SqlCommand("Delete Employee where EmpId=@empid", con);
                cmd.Parameters.AddWithValue("@empid", txtEmpid.Text);

                con.Open();  //step-4

                cmd.ExecuteNonQuery();  // step-5 // insert,update,delete  --action commands 
                con.Close();
                MessageBox.Show("Record deleted Sucessfully");

            }
            catch (Exception)
            {

                MessageBox.Show("Invalid EmployeeId");
            }

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from employee where empid =@empid", con);
            cmd.Parameters.AddWithValue("@empid", txtEmpid.Text);
            con.Open();  //step-4
            SqlDataReader dr = cmd.ExecuteReader();  // step-5
            if (dr.Read() == true)
            {
                //fill the data into respective textboxes 
                txtEmpid.Text = dr[0].ToString();
                txtEmpName.Text = dr[1].ToString();
                txtEmpSal.Text = dr[2].ToString();
                txtEmpAdd.Text = dr[3].ToString();
            }
            else
            {
                MessageBox.Show("Invalid EmployeeId");
            }
            con.Close();
        }

        private void Displaydata(int currentrow)
        {
            txtEmpid.Text = dt.Rows[currentrow]["Empid"].ToString();
            txtEmpName.Text = dt.Rows[currentrow]["EmpName"].ToString();
            txtEmpSal.Text = dt.Rows[currentrow]["EmpSal"].ToString();
            txtEmpAdd.Text = dt.Rows[currentrow]["EmpAdd"].ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                currentrow--;
                Displaydata(currentrow);
            }
            catch (Exception ex)
            {
                if (currentrow <= 0)
                    currentrow = 0;
                MessageBox.Show("No data available");

            }

        }
        private void btnNext_Click(object sender, EventArgs e)
        {

            try
            {
                currentrow++;
                Displaydata(currentrow);

            }
            catch (Exception ex)
            {
                if (currentrow >= dt.Rows.Count)
                    currentrow = dt.Rows.Count - 1;
                MessageBox.Show("No data available");

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from employee", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
            }
            catch
            {
                MessageBox.Show("error happened");
            }
            Displaydata(currentrow);
        }
    }
}
