using GymMe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class NavBar : System.Web.UI.MasterPage
    {
        protected string UserRole { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                MsUser user = Session["user"] as MsUser;

                if (user.UserRole == "Admin")
                {
                    UserRole = "Admin";
                }
                else if (user.UserRole == "Customer")
                {
                    UserRole = "Customer";
                }
            }
        }
	}
}