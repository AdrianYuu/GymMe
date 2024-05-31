using GymMe.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
	public partial class RegisterPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LblError.ForeColor = System.Drawing.Color.Red;

			if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
			{
				Response.Redirect("~/Views/HomePage.aspx");
				return;
			}
		}

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
			string username = TxtUsername.Text;
			string email = TxtEmail.Text;
			string gender = RBGender.SelectedValue;
			string password = TxtPassword.Text;
			string confirmPassword = TxtConfirmPassword.Text;
			string dob = TxtDOB.Text;

			var response = UserController.RegisterUser(username, email, gender, password, confirmPassword, dob);

			if(!response.Success)
			{
				LblError.Text = response.Message;
				return;
			}

			Response.Redirect("~/Views/Auth/LoginPage.aspx");
		}

		protected void LBLogin_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Views/Auth/LoginPage.aspx");
		}
	}
}