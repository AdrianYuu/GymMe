using GymMe.Controllers;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
	public partial class ManageSupplementPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
			{
				Response.Redirect("~/Views/LoginPage.aspx");
				return;
			}

			if (Session["user"] == null)
			{
				string cookie = Request.Cookies["user_cookie"].Value;

				var rs = UserController.LoginUserByCookie(cookie);

				if (!rs.Success)
				{
					Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
					Response.Redirect("~/Views/LoginPage.aspx");
					return;
				}

				Session["user"] = rs.Payload;
			}

			var user = Session["user"] as MsUser;

			if (user.UserRole != "Admin") Response.Redirect("~/Views/HomePage.aspx");
		}

        protected void GVSupplementData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

		protected void GVSupplementData_RowEditing(object sender, GridViewEditEventArgs e)
		{

		}
	}
}