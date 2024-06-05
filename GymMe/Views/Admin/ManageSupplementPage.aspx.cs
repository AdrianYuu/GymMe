using GymMe.Controllers;
using GymMe.Models;
using GymMe.Views.Base;
using System;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
	public partial class ManageSupplementPage : BasePage
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

			if (user.UserRole != "Admin") Response.Redirect("~/Views/HomePage.aspx");

			RefreshGridView();
		}

        protected void GVSupplementData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
			GridViewRow row = GVSupplementData.Rows[e.RowIndex];
			int id = Convert.ToInt32(row.Cells[0].Text);

			var response = SupplementController.DeleteSupplement(id);

			if(response.Success)
			{
				RefreshGridView();
			}
		}

		protected void GVSupplementData_RowEditing(object sender, GridViewEditEventArgs e)
		{
			GridViewRow row = GVSupplementData.Rows[e.NewEditIndex];
			int id = Convert.ToInt32(row.Cells[0].Text);
			Response.Redirect("~/Views/Admin/UpdateSupplementPage.aspx?Id=" + id);
		}

		protected void LBCreateSupplement_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/Views/Admin/CreateSupplementPage.aspx");
        }
    }
}