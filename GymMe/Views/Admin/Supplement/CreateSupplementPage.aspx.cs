using GymMe.Controllers;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views.Admin.Supplement
{
	public partial class CreateSupplementPage : System.Web.UI.Page
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

			if (user.UserRole != "Admin") Response.Redirect("~/Views/HomePage.aspx");
		}

		protected void BtnCreate_Click(object sender, EventArgs e)
		{
			string name = TxtName.Text;
			string expiryDate = TxtExpiryDate.Text;
			string price = TxtPrice.Text;
			string supplementTypeId = DDLSupplementType.SelectedValue;

			Debug.Print(name);
			Debug.Print(expiryDate);
			Debug.Print(price);
			Debug.Print(supplementTypeId);

			var response = SupplementController.CreateSupplement(name, expiryDate, price, supplementTypeId);

			if (!response.Success)
			{
				LblError.Text = response.Message;
				return;
			}

			Response.Redirect("~/Views/Admin/Supplement/ManageSupplementPage.aspx");
		}

        protected void BtnBack_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/Views/Admin/Supplement/ManageSupplementPage.aspx");
		}
	}
}