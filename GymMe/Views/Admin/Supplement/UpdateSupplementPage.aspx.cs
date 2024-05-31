using GymMe.Controllers;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views.Admin.Supplement
{
	public partial class UpdateSupplementPage : System.Web.UI.Page
	{
		private void LoadSupplement(int id)
		{
			var response = SupplementController.GetSupplementById(id);

			if(response.Success)
			{
				// Add fill field logic
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
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
						Response.Redirect("~/Views/Auth/LoginPage.aspx");
						return;
					}

					Session["user"] = response.Payload;
				}

				MsUser user = Session["user"] as MsUser;

				if (user.UserRole != "Admin") Response.Redirect("~/Views/HomePage.aspx");

				string id = Request.QueryString["id"];

				LoadSupplement(Convert.ToInt32(id));
			}
		}
	}
}