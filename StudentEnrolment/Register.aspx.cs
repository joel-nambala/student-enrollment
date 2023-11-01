using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentEnrolment
{
    public partial class Register : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCountries();
                LoadCounties();
            }
        }

        private void LoadCountries()
        {
            ddlCountry.Items.Clear();
            try
            {
                using(SqlConnection connection = new SqlConnection(str))
                {
                    string sqlStmnt = "getCountries";
                    SqlCommand command = new SqlCommand();
                    command.CommandText = sqlStmnt;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    connection.Open();

                    ListItem li = new ListItem("--Select--", "0");
                    ddlCountry.Items.Add(li);

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                li = new ListItem(reader["Name"].ToString(), reader["Name"].ToString());
                                ddlCountry.Items.Add(li);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private void LoadCounties()
        {
            ddlCounty.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    string sqlStmnt = "getCounties";
                    SqlCommand command = new SqlCommand();
                    command.CommandText = sqlStmnt;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    connection.Open();

                    ListItem li = new ListItem("--Select--", "0");
                    ddlCounty.Items.Add(li);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                li = new ListItem(reader["Name"].ToString(), reader["Name"].ToString());
                                ddlCounty.Items.Add(li);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        private void LoadCountryDetails()
        {
            try
            {
                string country = ddlCountry.SelectedValue;
                if(country == "Kenya")
                {
                    panelKenya.Visible = true;
                }
                else
                {
                    panelKenya.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(str);
            try
            {
                string query = @"INSERT INTO StudentList (Username, StudentName, StudentEmail, PhoneNumber, Address, Gender, Country,
                                                    County, PostalAddress, ProfilePicture, Password, DateOfBirth, IDNumber, PassportNumber)
                                                    VALUES(@Username, @StudentName, @StudentEmail, @PhoneNumber, @Address, @Gender, @Country,
                                                    @County, @PostalAddress, @ProfilePicture, @Password, @DateOfBirth, @IDNumber, @PassportNumber)";
                SqlCommand command = new SqlCommand(query, connection);
                string studentId = Components.GenerateRandomIds();
                command.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                command.Parameters.AddWithValue("@StudentName", txtFullName.Text.Trim());
                command.Parameters.AddWithValue("@StudentEmail", txtEmail.Text.Trim());
                command.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text.Trim());
                command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                command.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue.Trim());
                command.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue.Trim());
                command.Parameters.AddWithValue("@County", ddlCounty.SelectedValue.Trim());
                command.Parameters.AddWithValue("@PostalAddress", txtPostalAddress.Text.Trim());
                command.Parameters.AddWithValue("@ProfilePicture", studentId);
                command.Parameters.AddWithValue("@DateOfBirth", dtDateofBirth.Text.Trim());
                command.Parameters.AddWithValue("@IDNumber", txtIdNumber.Text.Trim());
                command.Parameters.AddWithValue("@PassportNumber", txtPassport.Text.Trim());
                if (!ValidatePassword(txtPassword.Text))
                {
                    Message("Password do not meet the minimum requirements");
                    return;
                }
                command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                connection.Open();
                int reader = command.ExecuteNonQuery();
                if(reader > 0)
                {
                    SuccessMessage("Account has been created successifully");
                }
                else
                {
                    Message("An error has occured while creating the account. Please try again later!");
                }
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    //Message($"Username {txtUsername.Text} already exists");
                    lblMsg.Text = $"Username <b>{txtUsername.Text.Trim()}</b> already exists. Please use another username!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch(Exception ex)
            {
                Message($"ERROR: {ex.Message.ToString()}");
                ex.Data.Clear();
            }
            finally
            {
                connection.Close();
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCountryDetails();
        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        public void Message(string message)
        {
            string strScript = "<script>alert('" + message + "')</script>";
            ClientScript.RegisterStartupScript(GetType(), "Client Script", strScript.ToString());
        }
        protected void SuccessMessage(string message)
        {
            string myPage = "Default.aspx";
            string strScript = "<script>alert('" + message + "'); window.location='" + myPage + "'</script>";
            ClientScript.RegisterStartupScript(GetType(), "Client Script", strScript.ToString());
        }
        protected bool ValidatePassword(string password)
        {
            bool isStrong = false;

            string passwordRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

            if(Regex.IsMatch(password, passwordRegex))
            {
                isStrong = true;
            }

            return isStrong;
        }
    }
}