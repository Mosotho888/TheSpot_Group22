﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TheSpotGroup22
{
    public partial class EmployeeLogin : System.Web.UI.Page
    {
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        SqlDataReader theReader;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie employeeCookie = Request.Cookies["EmployeeInfo"];

            Control myHome = Page.Master.FindControl("home");
            Control myAddPRoduct = Page.Master.FindControl("addProduct");
            Control myEditMenu = Page.Master.FindControl("editMenu");
            Control myViewOrders = Page.Master.FindControl("viewOrders");
            Control myViewBookings = Page.Master.FindControl("viewBookings");
            Control myCustomerInfo = Page.Master.FindControl("customerInfo");
            Control myReports = Page.Master.FindControl("reports");

            Control btnLogout = Page.Master.FindControl("logOut");

            if (myHome != null && myAddPRoduct != null && myEditMenu != null && myViewOrders != null && myViewBookings != null && myCustomerInfo != null && myReports != null && btnLogout != null)
            {
                myHome.Visible = false;
                myAddPRoduct.Visible = false;
                myEditMenu.Visible = false;
                myViewOrders.Visible = false;
                myViewBookings.Visible = false;
                myCustomerInfo.Visible = false;
                myReports.Visible = false;

                btnLogout.Visible = false;
            }

            if (!IsPostBack)
            {
                if (employeeCookie != null)
                {

                    Response.Redirect("Home.aspx");
                }

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            checkInfo();
        }

        private void checkInfo()
        {

            conn = new SqlConnection(constr);
            try
            {
                HttpCookie employeeCookie = new HttpCookie("employeeInfo");
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = $"SELECT employeeId,password FROM tblEmployeeDetails WHERE email = '{txtEmail.Text}'";

                comm = new SqlCommand(sql, conn);

                theReader = comm.ExecuteReader();

                if (theReader.Read())
                {
                    string id = theReader.GetValue(0).ToString();
                    employeeCookie["employeeId"] = id;
                    Response.Cookies.Add(employeeCookie);

                    string tempPassword = theReader.GetValue(1).ToString();

                    string enteredPassword = txtPassword.Text;

                    if (String.Compare(tempPassword, enteredPassword) == 0)
                    {
                        if (cbRememberMe.Checked)
                        {
                            employeeCookie.Expires = DateTime.Now.AddDays(2);
                        }
                        Response.Redirect("Home.aspx", false);
                    }
                    else
                    {

                        lblError.Text = "Invalid Password";

                    }
                }
                else
                {

                    lblError.Text = "Invalid Email";

                }
                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }
    }
}