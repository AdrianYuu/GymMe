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
		private void RefreshGridView()
		{
			var response = UserController.GetUsersByRole("Customer");

			if (response.Success)
			{
				GVCustomerData.DataSource = response.Payload;
				GVCustomerData.DataBind();
			}
		}

        protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
			{
				Response.Redirect("~/Views/Auth/LoginPage.aspx");
				return;
			}

			if (Session["user"] == null)
			{
				string cookie = Request.Cookies["user_cookie"].Value;

				var response = UserController.LoginUserByCookie(cookie);

				if (!response.Success)
				{
					Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
					Response.Redirect("~/Views/LoginPage.aspx");
					return;
				}

				Session["user"] = response.Payload;
			}
			
			MsUser user = Session["user"] as MsUser;

			LblRole.Text = "Your role is " + user.UserRole;

			if(user.UserRole == "Admin")
			{
				RefreshGridView();
				PanelAdmin.Visible = true;
			}
		}
	}
}