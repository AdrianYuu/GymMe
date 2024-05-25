using GymMe.Controllers;
using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
	public partial class HomePage : System.Web.UI.Page
	{
        protected string UserRole { get; set; }
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
            UserRole = user.UserRole;

			var response = UserController.GetUsersByRole("Customer");

			if(response.Success)
			{
				GVCustomerData.DataSource = response.Payload;
				GVCustomerData.DataBind();
			}
        }
	}
}