using GymMe.Controllers;
using GymMe.Models;
using GymMe.Views.Base;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
	public partial class OrderSupplementPage : BasePage
	{
		private void RefreshGridView()
		{
			var response = SupplementController.GetSupplements();

			if (response.Success)
			{
				GVSupplementData.DataSource = response.Payload;
				GVSupplementData.DataBind();
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			MsUser user = Session["user"] as MsUser;

			if (user.UserRole != "Customer") Response.Redirect("~/Views/HomePage.aspx");

			if (!IsPostBack)
			{
				RefreshGridView();
			}
		}

		protected void GVSupplementData_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Order")
			{
				Control sourceControl = e.CommandSource as Control;
				GridViewRow row = sourceControl.NamingContainer as GridViewRow;
				int rowIndex = row.RowIndex;

				int supplementId = Convert.ToInt32(GVSupplementData.Rows[rowIndex].Cells[0].Text);

				TextBox txtQuantity = GVSupplementData.Rows[rowIndex].Cells[5].FindControl("TxtQuantity") as TextBox;
				string quantity = txtQuantity.Text;
				txtQuantity.Text = string.Empty;

				MsUser user = Session["user"] as MsUser;

				var response = CartController.CreateOrUpdateCart(user.UserID, supplementId, quantity);

				if (!response.Success)
				{
					LblStatus.ForeColor = System.Drawing.Color.Red;
					LblStatus.Text = response.Message;
					return;
				}

				Response.Redirect("~/Views/Customer/CartPage.aspx");
			}
		}
	}
}