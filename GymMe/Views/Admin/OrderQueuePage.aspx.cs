using GymMe.Controllers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views.Admin
{
    public partial class OrderQueuePage : System.Web.UI.Page
    {
        private void RefreshGridView()
        {
            Response<List<TransactionHeader>> response = TransactionHeaderController.GetTransactionHeaders();

            if (response.Success)
            {
                GVOrderData.DataSource = response.Payload;
                GVOrderData.DataBind();
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
                RefreshGridView();
            }
        }
        protected void GVOrderData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChangeStatus")
            {
                Control sourceControl = e.CommandSource as Control;
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;
                int rowIndex = row.RowIndex;

                int transactionId = Convert.ToInt32(GVOrderData.Rows[rowIndex].Cells[0].Text);

                TransactionHeaderController.UpdateTransactionHeader(transactionId, "Handled");
                RefreshGridView();
            }
        }
    }
}