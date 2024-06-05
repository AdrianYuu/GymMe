using GymMe.Controllers;
using GymMe.Models;
using GymMe.Views.Base;
using System;

namespace GymMe.Views
{
    public partial class ProfilePage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if(!IsPostBack)
			{
				LblErrorProfile.ForeColor = System.Drawing.Color.Red;
				LblErrorPassword.ForeColor = System.Drawing.Color.Red;

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