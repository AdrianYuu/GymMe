using GymMe.Controllers;
using GymMe.Models;
using GymMe.Views.Base;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace GymMe.Views.Admin.Supplement
{
	public partial class CreateSupplementPage : BasePage
	{
		private void LoadSupplementType()
		{
			var response = SupplementTypeController.GetSupplementTypes();

			if (response.Success)
			{
				List<MsSupplementType> supplementTypes = response.Payload;
				DDLSupplementType.DataSource = supplementTypes;
				DDLSupplementType.DataTextField = "SupplementTypeName";
				DDLSupplementType.DataValueField = "SupplementTypeId";
				DDLSupplementType.DataBind();
			}

			DDLSupplementType.Items.Insert(0, new ListItem("Select supplement type...", "0"));
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LoadSupplementType();
			}

			LblError.ForeColor = System.Drawing.Color.Red;

			MsUser user = Session["user"] as MsUser;

			if (user.UserRole != "Admin") Response.Redirect("~/Views/HomePage.aspx");
		}

		protected void BtnCreate_Click(object sender, EventArgs e)
		{
			string name = TxtName.Text;
			string expiryDate = TxtExpiryDate.Text;
			string price = TxtPrice.Text;
			string supplementTypeId = DDLSupplementType.SelectedValue;

			var response = SupplementController.CreateSupplement(name, expiryDate, price, supplementTypeId);

			if (!response.Success)
			{
				LblError.Text = response.Message;
				return;
			}

			Response.Redirect("~/Views/Admin/ManageSupplementPage.aspx");
		}

        protected void BtnBack_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/Views/Admin/ManageSupplementPage.aspx");
		}
	}
}