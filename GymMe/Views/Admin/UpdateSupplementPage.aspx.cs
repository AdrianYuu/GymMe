using GymMe.Controllers;
using GymMe.Models;
using GymMe.Views.Base;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace GymMe.Views.Admin.Supplement
{
	public partial class UpdateSupplementPage : BasePage
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

		private void LoadSupplement(int supplementId)
		{
			var response = SupplementController.GetSupplementById(supplementId);

			if(response.Success)
			{
				MsSupplement supplement = response.Payload;
				TxtName.Text = supplement.SupplementName;
				TxtPrice.Text = supplement.SupplementPrice.ToString();
				TxtExpiryDate.Text = supplement.SupplementExpiryDate.ToString("yyyy-MM-dd");
				DDLSupplementType.SelectedValue = supplement.SupplementTypeID.ToString();
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LblError.ForeColor = System.Drawing.Color.Red;

				MsUser user = Session["user"] as MsUser;

				if (user.UserRole != "Admin") Response.Redirect("~/Views/HomePage.aspx");

				int supplementId = Convert.ToInt32(Request.QueryString["id"]);

				LoadSupplementType();
				LoadSupplement(supplementId);
			}
		}

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
			string name = TxtName.Text;
			string expiryDate = TxtExpiryDate.Text;
			string price = TxtPrice.Text;
			string supplementTypeId = DDLSupplementType.SelectedValue;
			int supplementId = Convert.ToInt32(Request.QueryString["id"]);

			var response = SupplementController.UpdateSupplement(supplementId, name, expiryDate, price, supplementTypeId);

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