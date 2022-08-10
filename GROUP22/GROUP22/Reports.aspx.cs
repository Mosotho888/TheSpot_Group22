using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace GROUP22
{
    public partial class Reports : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            //master page control
            LinkButton linkHome = (LinkButton)Page.Master.FindControl("home");
            linkHome.Visible = true;
            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("menu");
            linkMenu.Visible = false;
            LinkButton linkProduct = (LinkButton)Page.Master.FindControl("product");
            linkProduct.Visible = false;
            LinkButton linkOrder = (LinkButton)Page.Master.FindControl("order");
            linkOrder.Visible = false;
            LinkButton linkBook = (LinkButton)Page.Master.FindControl("booking");
            linkBook.Visible = false;
            LinkButton linkAccount = (LinkButton)Page.Master.FindControl("account");
            linkAccount.Visible = true;
            LinkButton linkReport = (LinkButton)Page.Master.FindControl("report");
            linkReport.Visible = false;

            LinkButton linkIn = (LinkButton)Page.Master.FindControl("login");
            linkIn.Visible = false;
            LinkButton linkUp = (LinkButton)Page.Master.FindControl("signup");
            linkUp.Visible = false;

            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = true;
            //

            HttpCookie employeeCookie = Request.Cookies["EmployeeInfo"];
            if (!IsPostBack)
            {
                if (employeeCookie != null)
                {
                    lblEmployeeEmail.Text = employeeCookie["employeeEmail"];
                    lblGrand.Visible = false;

                }
                else
                {
                    Response.Redirect("EmployeeLogin.aspx");
                }

            }
        }

        protected void gdRowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        public void ascendingOrder()
        {
            string sql = "SELECT orderId, productId, customerId, productName, productPrice, productQuantity, totalPrice, dateOfOrder FROM TableReports ORDER BY totalPrice ASC";

            comm = new SqlCommand(sql, conn);
            adapt.SelectCommand = comm;
            adapt.Fill(ds);

            gvReport.DataSource = ds;
            gvReport.DataBind();

            grandtot();
        }

        public void descendingOrder()
        {
            string sql = "SELECT orderId, productId, customerId, productName, productPrice, productQuantity, totalPrice, dateOfOrder FROM TableReports ORDER BY totalPrice DESC";

            comm = new SqlCommand(sql, conn);
            adapt.SelectCommand = comm;
            adapt.Fill(ds);

            gvReport.DataSource = ds;
            gvReport.DataBind();

            grandtot();

        }

        public void defaultOrder()
        {
            string sql = "SELECT orderId, productId, customerId, productName, productPrice, productQuantity, totalPrice, dateOfOrder FROM TableReports";

            comm = new SqlCommand(sql, conn);
            adapt.SelectCommand = comm;
            adapt.Fill(ds);

            gvReport.DataSource = ds;
            gvReport.DataBind();

            grandtot();
        }

        public void grandtot()
        {

            string sql = "SELECT SUM(totalPrice) FROM TableReports";
            comm = new SqlCommand(sql, conn);
            string amount = comm.ExecuteScalar().ToString();

            lblTotalAmount.Text = amount;

        }

        public void search()
        {
            lblInfo.Text = "All the infomation of orders received for a particular customer";
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT * FROM TableReports WHERE customerId LIKE '%" + txtSearch.Text + "%'";
                comm = new SqlCommand(sql, conn);
                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                gvReport.DataSource = ds;
                gvReport.DataBind();

                sumSearch();

            }
            catch (Exception error)
            {
                lblError.Text = error.Message;

            }
        }

        public void sumSearch()
        {
            string sq2 = "SELECT SUM(totalPrice) FROM TableReports WHERE customerId = '" + txtSearch.Text + "'";
            comm = new SqlCommand(sq2, conn);
            string amount = comm.ExecuteScalar().ToString();

            lblTotalAmount.Text = amount;
        }
    }
}