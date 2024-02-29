using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Saint_Gobain_Project
{
    public partial class Student_Register : System.Web.UI.Page
    {
        string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConString"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindToGrid();
            
        }
        private void BindToGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConStr);
            SqlDataAdapter sda = new SqlDataAdapter("select * from Student order by StudentName", con);
            con.Open();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConStr);
            SqlCommand cmd = new SqlCommand("insert into Student values('"+ Stname.Text +"','"+ dob.Text +"','"+ age.Text +"','"+ faname.Text +"','"+ add.Text +"','"+ course.SelectedItem +"','"+ semfee.Text +"','"+ hosfee.Text +"','"+ totfee.Text +"')", con);
            con.Open();
            cmd.Parameters.AddWithValue("StudentName", Stname.Text);
            cmd.Parameters.AddWithValue("DOB",dob.Text);
            cmd.Parameters.AddWithValue("Age", age.Text);
            cmd.Parameters.AddWithValue("FatherName", faname.Text);
            cmd.Parameters.AddWithValue("Address", add.Text);
            cmd.Parameters.AddWithValue("Course", course.Text);
            cmd.Parameters.AddWithValue("SemesterFees",semfee.Text);
            cmd.Parameters.AddWithValue("HostelFees", hosfee.Text);
            cmd.Parameters.AddWithValue("TotalFees",totfee.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Student Register.aspx");
           
        }
        protected void hosfee_CheckedChanged(object sender, EventArgs e)
        {
            totfee.Text = (int.Parse(hosfee.Text) + int.Parse(semfee.Text)).ToString();
        }

    }
    
}