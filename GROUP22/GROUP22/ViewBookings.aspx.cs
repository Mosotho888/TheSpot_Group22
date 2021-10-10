﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSpotGroup22
{
    public partial class ViewBookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control myCustomerLogin = Page.Master.FindControl("customerLogin");
            Control myCustomerSignUp = Page.Master.FindControl("customerRegistraction");


            if (myCustomerLogin != null && myCustomerSignUp != null)
            {

                myCustomerLogin.Visible = false;
                myCustomerSignUp.Visible = false;

            }
        }
    }
}