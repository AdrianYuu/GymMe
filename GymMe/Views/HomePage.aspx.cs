using GymMe.Controllers;
using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
	public partial class HomePage : System.Web.UI.Page
	{
        protected string UserRole { get; set; }
        protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
			{
				Response.Redirect("~/Views/LoginPage.aspx");
				return;
			}

			if (Session["user"] == null)
			{
				string cookie = Request.Cookies["user_cookie"].Value;

				var response = UserController.LoginUserByCookie(cookie);

				if (!response.Success)
				{
					Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
					Response.Redirect("~/Views/LoginPage.aspx");
					return;
				}

				Session["user"] = response.Payload;
			}
			
			MsUser user = (MsUser)Session["user"];

			// Set UserRole variable to view customer data if admin
            if (user.UserRole == "Admin")
            {
                UserRole = "Admin";
            }

			// Fetch Customer Data
			List<MsUser> UsersList = UserRepository.GetUsers();
            List<MsUser> CustomerUsers = UsersList.Where(usr => usr.UserRole == "Customer").ToList();
			
			GVCustomerData.DataSource = CustomerUsers;
			GVCustomerData.DataBind();
        }
    }
}