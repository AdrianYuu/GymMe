using GymMe.Controllers;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class TransasctionDetail : System.Web.UI.Page
    {
        private void RefreshGridView(int transactionId)
        {
            var response = TransactionDetailController.GetTransactionDetailsByTransactionId(transactionId);

            if (response.Success)
            {
                GVTransactionDetailData.DataSource = response.Payload;
                GVTransactionDetailData.DataBind();
            }
        }
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
                    Response.Redirect("~/Views/Auth/LoginPage.aspx");
                    return;
                }

                Session["user"] = response.Payload;
            }

            if (!IsPostBack)
            {
                int transactionId = Convert.ToInt32(Request.QueryString["transactionid"]);
                RefreshGridView(transactionId);
            }
        }
    }
}