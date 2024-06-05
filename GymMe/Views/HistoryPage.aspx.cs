using GymMe.Controllers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymMe.Views.Base;

namespace GymMe.Views
{
    public partial class HistoryPage : BasePage
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

                string targetUrl = "~/Views/TransactionDetailPage.aspx";
                string redirectUrl = $"{targetUrl}?transactionId={transactionId}";

                Response.Redirect(redirectUrl);
            }
        }
    }
}