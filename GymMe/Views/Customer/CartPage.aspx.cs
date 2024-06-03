using GymMe.Controllers;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views.User
{
	public partial class CartPage : System.Web.UI.Page
	{
		private void RefreshGridView(int userId)
		{
			var response = CartController.GetCartsByUserId(userId);

			if(response.Success)
			{
				GVCartData.DataSource = response.Payload;
				GVCartData.DataBind();
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
					Response.Redirect("~/Views/Auth/LoginPage.aspx");
					return;
				}

				Session["user"] = response.Payload;
			}

			MsUser user = Session["user"] as MsUser;

			if (user.UserRole != "Customer") Response.Redirect("~/Views/HomePage.aspx");

			RefreshGridView(user.UserID);
		}

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
			MsUser user = Session["user"] as MsUser;

			var response = CartController.CheckoutCart(user.UserID);

			if(response.Success)
			{
				Response.Redirect("~/Views/HomePage.aspx");
			}
		}

		protected void BtnClear_Click(object sender, EventArgs e)
		{
			MsUser user = Session["user"] as MsUser;
			var response = CartController.DeleteCart(user.UserID);

			if(response.Success)
			{
				Response.Redirect("~/Views/HomePage.aspx");
			}
		}
	}
}