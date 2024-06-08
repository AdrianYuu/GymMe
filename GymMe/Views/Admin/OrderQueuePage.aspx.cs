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
			var response = TransactionHeaderController.GetTransactionHeaders();

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
				MsUser user = Session["user"] as MsUser;

				if (user.UserRole != "Admin")
				{
					Response.Redirect("~/Views/HomePage.aspx");
				}
				else
				{
					RefreshGridView();
				}
			}
		}

		protected void GVOrderData_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "HandleTransaction")
			{
				Control sourceControl = e.CommandSource as Control;
				GridViewRow row = sourceControl.NamingContainer as GridViewRow;
				int rowIndex = row.RowIndex;

				int transactionId = Convert.ToInt32(GVOrderData.Rows[rowIndex].Cells[0].Text);

				var response = TransactionHeaderController.UpdateTransactionHeader(transactionId, "Handled");

				if (response.Success)
				{
					RefreshGridView();
				}
			}
		}

		protected void GVOrderData_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

				Button btnHandleTransaction = (Button)e.Row.FindControl("BtnHandleTransaction");

				if (status == "Handled")
				{
					btnHandleTransaction.Enabled = false;
				}
			}
		}
	}
}
