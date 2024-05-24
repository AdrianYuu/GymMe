using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class NavBar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LBLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LogoutPage.aspx");
        }
    }
}