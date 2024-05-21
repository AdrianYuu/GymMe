﻿using GymMe.Constants;
using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controllers
{
	public class UserController
	{
		public static Response<List<MsUser>> GetUsers()
		{
			return UserHandler.GetUsers();
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
			else if((username.Length < 5 || username.Length > 15) || !username.Contains(" "))
			{
				errorMsg = "Username length must be between 5 and 15 also with space.";
			}
			else if(!email.EndsWith(".com"))
			{
				errorMsg = "Email must ends with '.com'";
			}
			else if(!Helper.IsAlphaNumeric(password))
			{
				errorMsg = "Password must be alphanumeric.";
			}
			else if(password != confirmPassword)
			{
				errorMsg = "Password must be the same with confirm password";
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

			return UserHandler.RegisterUser(username, email, gender, password, confirmPassword, DateTime.Parse(dob));
		}

		public static Response<MsUser> LoginUserByCookie(string cookie)
		{
			return UserHandler.LoginUserByCookie(cookie);
		}
	}
}