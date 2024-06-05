using GymMe.Controllers;
using GymMe.Models;
using GymMe.Views.Base;
using System;

namespace GymMe.Views.User
{
	public partial class CartPage : BasePage
	{
		private void RefreshGridView(int userId)
		{
			var response = CartController.GetCartsByUserId(userId);

			if (response.Success)
			{
				GVCartData.DataSource = response.Payload;
				GVCartData.DataBind();
				PanelBtn.Visible = true;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			MsUser user = Session["user"] as MsUser;

			if (user.UserRole != "Customer") Response.Redirect("~/Views/HomePage.aspx");

			RefreshGridView(user.UserID);
		}

		protected void BtnCheckout_Click(object sender, EventArgs e)
		{
			MsUser user = Session["user"] as MsUser;

			var response = CartController.CheckoutCart(user.UserID);

			if (response.Success)
			{
				Response.Redirect("~/Views/HistoryPage.aspx");
			}
		}

		protected void BtnClear_Click(object sender, EventArgs e)
		{
			MsUser user = Session["user"] as MsUser;
			var response = CartController.DeleteCart(user.UserID);

			if (response.Success)
			{
				Response.Redirect("~/Views/HomePage.aspx");
			}
		}
	}
}