using GymMe.Constants;
using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Util;

namespace GymMe.Controllers
{
	public class UserController
	{
		public static Response<List<MsUser>> GetUsers()
		{
			return UserHandler.GetUsers();
		}

		public static Response<List<MsUser>> GetUsersByRole(string role)
		{
			string errorMsg = string.Empty;

			if (role == string.Empty)
			{
				errorMsg = "Role is required.";
			}
			else if(role != "Admin" && role != "Customer")
			{
				errorMsg = "Role must be 'Admin' or 'Customer'.";
			}

			if (!errorMsg.Equals(string.Empty))
			{
				return new Response<List<MsUser>>()
				{
					Success = false,
					Message = errorMsg,
					Payload = null
				};
			}

			return UserHandler.GetUsersByRole(role);
		}

		public static Response<MsUser> LoginUser(string username, string password)
		{
			string errorMsg = string.Empty;

			if(username == string.Empty || password == string.Empty)
			{
				errorMsg = "All fields is required to be filled.";
			}

			if(!errorMsg.Equals(string.Empty))
			{
				return new Response<MsUser>()
				{
					Success = false,
					Message = errorMsg,
					Payload = null
				};
			}

			return UserHandler.LoginUser(username, password);
		}

		public static Response<MsUser> RegisterUser(string username, string email, string gender, string password, string confirmPassword, string dob)
		{
			string errorMsg = string.Empty;

			if(username == string.Empty || email == string.Empty || gender == string.Empty || password == string.Empty || confirmPassword == string.Empty || dob == string.Empty)
			{
				errorMsg = "All fields is required to be filled.";
			}
			else if(username.Length < 5 || username.Length > 15 || !username.Contains(" "))
			{
				errorMsg = "Username length must be between 5 and 15 also with space.";
			}
			else if(!email.EndsWith(".com"))
			{
				errorMsg = "Email must ends with '.com'.";
			}
			else if(gender != "Male" && gender != "Female")
			{
				errorMsg = "Gender must be 'Male' or 'Female'";
			}
			else if(!Helper.IsAlphaNumeric(password))
			{
				errorMsg = "Password must be alphanumeric.";
			}
			else if(password != confirmPassword)
			{
				errorMsg = "Password must be the same with confirm password.";
			}

			if (!errorMsg.Equals(string.Empty))
			{
				return new Response<MsUser>()
				{
					Success = false,
					Message = errorMsg,
					Payload = null
				};
			}

			return UserHandler.RegisterUser(username, email, gender, password, DateTime.Parse(dob));
		}

		public static Response<MsUser> LoginUserByCookie(string cookie)
		{
			if(cookie == string.Empty)
			{
				return new Response<MsUser>()
				{
					Success = false,
					Message = "Cookie is not valid.",
					Payload = null
				};
			}

			return UserHandler.LoginUserByCookie(cookie);
		}

		public static Response<MsUser> UpdateUserInformation(int userId, string username, string email, string gender, string dob)
		{
			string errorMsg = string.Empty;

			if(userId <= 0)
			{
				errorMsg = "User ID is not valid.";
			}
			else if (username == string.Empty || email == string.Empty || gender == string.Empty || dob == string.Empty)
			{
				errorMsg = "All fields is required to be filled.";
			}
			else if ((username.Length < 5 || username.Length > 15) || !username.Contains(" "))
			{
				errorMsg = "Username length must be between 5 and 15 also with space.";
			}
			else if (!email.EndsWith(".com"))
			{
				errorMsg = "Email must ends with '.com'";
			}

			if (!errorMsg.Equals(string.Empty))
			{
				return new Response<MsUser>()
				{
					Success = false,
					Message = errorMsg,
					Payload = null
				};
			}

			return UserHandler.UpdateUserInformation(userId, username, email, gender, DateTime.Parse(dob));
		}

		public static Response<MsUser> UpdateUserPassword(int userId, string oldPassword, string newPassword)
		{
			string errorMsg = string.Empty;

			if (userId <= 0)
			{
				errorMsg = "User ID is not valid.";
			}
			else if (oldPassword == string.Empty || newPassword == string.Empty)
			{
				errorMsg = "All fields is required to be filled.";
			}
			else if(!Helper.IsAlphaNumeric(newPassword))
			{
				errorMsg = "New password must be alphanumeric.";
			}

			if (!errorMsg.Equals(string.Empty))
			{
				return new Response<MsUser>()
				{
					Success = false,
					Message = errorMsg,
					Payload = null
				};
			}

			return UserHandler.UpdateUserPassword(userId, oldPassword, newPassword);
		}
	}
}