using GymMe.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class HistoryPage : System.Web.UI.Page
    {
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

                var response = UserController.LoginUserByCookie(cookie);

                if (!response.Success)
                {
                    Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
                    Response.Redirect("~/Views/LoginPage.aspx");
                    return;
                }

                Session["user"] = response.Payload;
            }
        }
    }
}