using GymMe.Controllers;
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

			if (user.UserRole == "Customer")
			{
				PanelCustomer.Visible = true;
			}
			else if (user.UserRole == "Admin")
			{
				PanelAdmin.Visible = true;
			}
		}

		protected void LBHome_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Views/HomePage.aspx");
		}

		protected void LBOrderSupplement_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Views/Customer/OrderSupplementPage.aspx");
		}

		protected void LBHistory_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Views/HistoryPage.aspx");
		}

		protected void LBManageSupplement_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Views/Admin/ManageSupplementPage.aspx");
		}

		protected void LBOrderQueue_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Views/Admin/OrderQueuePage.aspx");
		}

		protected void LBTransactionReport_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Views/Admin/TransactionReportPage.aspx");
		}

		protected void LBProfile_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Views/ProfilePage.aspx");
		}

		protected void BtnLogout_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
			Response.Redirect("~/Views/Auth/LoginPage.aspx");
		}

        protected void LBCart_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/Views/Customer/CartPage.aspx");
		}
    }
}