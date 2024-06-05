using GymMe.Controllers;
using System;
using System.Web;
using System.Web.UI;

namespace GymMe.Views.Base
{
    public class BasePage : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // Perform the authorization check early in the lifecycle
            PerformAuthorizationCheck();
        }

        private void PerformAuthorizationCheck()
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
        }
    }
}
