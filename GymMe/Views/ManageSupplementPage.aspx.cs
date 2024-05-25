﻿using GymMe.Controllers;
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
		private void RefreshGridView()
		{
			var response = SupplementController.GetSupplements();

			if (response.Success)
			{
				GVSupplementData.DataSource = response.Payload;
				GVSupplementData.DataBind();
			}
		}

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

			MsUser user = Session["user"] as MsUser;

			if (user.UserRole != "Admin") Response.Redirect("~/Views/HomePage.aspx");

			RefreshGridView();
		}

        protected void GVSupplementData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
			GridViewRow row = GVSupplementData.Rows[e.RowIndex];
			int id = Convert.ToInt32(row.Cells[0].Text);

			var response = SupplementController.DeleteSupplement(id);

			if(response.Success)
			{
				RefreshGridView();
			}
		}

		protected void GVSupplementData_RowEditing(object sender, GridViewEditEventArgs e)
		{

		}
	}
}