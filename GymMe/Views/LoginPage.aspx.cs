using GymMe.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
	public partial class LoginPage : System.Web.UI.Page
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

		protected void BtnLogin_Click(object sender, EventArgs e)
		{
			string username = TxtUsername.Text;
			string password = TxtPassword.Text;
			bool rememberMe = CBRememberMe.Checked;

			var rs = UserController.LoginUser(username, password);

			if(!rs.Success)
			{
				LblError.Text = rs.Message;
				return;
			}

            if (rememberMe)
            {
				HttpCookie cookie = new HttpCookie("user_cookie");
				cookie.Value = rs.Payload.UserID.ToString();
				cookie.Expires = DateTime.Now.AddMinutes(15);
				Response.Cookies.Add(cookie);
            }

			Session["user"] = rs.Payload;
			Response.Redirect("~/Views/HomePage.aspx");
        }

		protected void LBRegister_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Views/RegisterPage.aspx");
		}
	}
}