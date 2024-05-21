using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factories
{
	public class UserFactory
	{
		public static MsUser Create(string userName, string userEmail, string userPassword, DateTime userDOB, string userGender, string userRole)
		{
			var user = new MsUser()
			{
				UserName = userName,
				UserEmail = userEmail,
				UserPassword = userPassword,
				UserDOB = userDOB,
				UserGender = userGender,
				UserRole = userRole
			};

			return user;
		}
	}
}