using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentEnrolment
{
    public partial class Default : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        SqlCommand command;
        SqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if(username == "" ||  password == "")
            {
                lblError.Text = "Username and password cannot be empty";
                txtUsername.Focus();
                return;
            }

            try
            {
                connection = new SqlConnection(str);
                string query = @"SELECT * FROM StudentList WHERE Username = @Username and Password = @Password";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Session["username"] = reader["Username"];
                    Response.Redirect("Student/Dashboard.aspx");
                    return;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                connection.Close();
            }
        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "")
            {
                lblError.Text = "Username cannot be empty";
                txtUsername.Focus();
                return;
            }

            try
            {
                Response.Redirect("~/ResetPassword.aspx");
            }
            catch(Exception ex)
            {
                ex.Data.Clear();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }
    }
}