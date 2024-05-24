using GymMe.Controllers;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class OrderSupplementPage : System.Web.UI.Page
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

                var rs = UserController.LoginUserByCookie(cookie);

                if (!rs.Success)
                {
                    Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
                    Response.Redirect("~/Views/LoginPage.aspx");
                    return;
                }

                Session["user"] = rs.Payload;
            }

            var response = SupplementController.GetSupplements();

            if (response.Success)
            {
                GVSupplementData.DataSource = response.Payload;
                GVSupplementData.DataBind();
            }
        }
    }
}