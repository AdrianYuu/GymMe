using GymMe.Controllers;
using GymMe.Models;
using GymMe.Views.Base;
using System;

namespace GymMe.Views
{
	public partial class HomePage : BasePage
	{
		private void RefreshGridView()
		{
			var response = UserController.GetUsersByRole("Customer");

			if (response.Success)
			{
				GVCustomerData.DataSource = response.Payload;
				GVCustomerData.DataBind();
			}
		}

        protected void Page_Load(object sender, EventArgs e)
		{	
			MsUser user = Session["user"] as MsUser;

			LblRole.Text = "Your role is " + user.UserRole;

			if(user.UserRole == "Admin")
			{
				RefreshGridView();
				PanelAdmin.Visible = true;
			}
		}
	}
}