using GymMe.Controllers;
using GymMe.Models;
using GymMe.Modules;
using GymMe.Views.Base;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views.Admin
{
    public partial class OrderQueuePage : BasePage
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