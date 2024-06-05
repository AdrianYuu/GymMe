using GymMe.Controllers;
using GymMe.Models;
using GymMe.Modules;
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
		private void RefreshGridView(int userId)
        {
            Response<List<TransactionHeader>> response;
            
            if (userId != -1)
            {
                response = TransactionHeaderController.GetTransactionHeadersByUserId(userId);
            }
            else
            {
                response = TransactionHeaderController.GetTransactionHeaders();
            }


            if (response.Success)
            {
                GVHistoryData.DataSource = response.Payload;
                GVHistoryData.DataBind();
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



            MsUser user = Session["user"] as MsUser;

            if (!IsPostBack)
            {
                if (user.UserRole == "Customer")
                {
                    RefreshGridView(user.UserID);
                }
                else
                {
                    RefreshGridView(-1);
                }
            }
        }
        protected void GVHistoryData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetail")
            {
                Control sourceControl = e.CommandSource as Control;
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;
                int rowIndex = row.RowIndex;

                int transactionId = Convert.ToInt32(GVHistoryData.Rows[rowIndex].Cells[0].Text);

                string targetUrl = "~/Views/TransactionDetail.aspx";
                string redirectUrl = $"{targetUrl}?transactionid={transactionId}";

                Response.Redirect(redirectUrl);
            }
        }
    }
}