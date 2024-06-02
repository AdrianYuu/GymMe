using GymMe.Controllers;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if(!IsPostBack)
			{
				LblErrorProfile.ForeColor = System.Drawing.Color.Red;
				LblErrorPassword.ForeColor = System.Drawing.Color.Red;

				if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
				{
					Response.Redirect("~/Views/LoginPage.aspx");
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
				TxtUsername.Text = user.UserName;
				TxtEmail.Text = user.UserEmail;
				RBGender.SelectedValue = user.UserGender;
				TxtDOB.Text = user.UserDOB.ToString("yyyy-MM-dd");
			}
		}

		protected void BtnUpdateUserInformation_Click(object sender, EventArgs e)
        {
			string username = TxtUsername.Text;
			string email = TxtEmail.Text;
			string gender = RBGender.SelectedValue;
			string dob = TxtDOB.Text;

			MsUser user = Session["user"] as MsUser;

			var response = UserController.UpdateUserInformation(user.UserID, username, email, gender, dob);

			if (!response.Success)
			{
				LblErrorProfile.Text = response.Message;
				return;
			}

			Session["user"] = response.Payload;
			Response.Redirect("~/Views/ProfilePage.aspx");
		}

		protected void BtnUpdatePassword_Click(object sender, EventArgs e)
		{
			string oldPassword = TxtOldPassword.Text;
			string newPassword = TxtNewPassword.Text;

			MsUser user = Session["user"] as MsUser;

			var response = UserController.UpdateUserPassword(user.UserID, oldPassword, newPassword);

			if (!response.Success)
			{
				LblErrorPassword.Text = response.Message;
				return;
			}

			Session["user"] = response.Payload;
			Response.Redirect("~/Views/ProfilePage.aspx");
		}
	}
}