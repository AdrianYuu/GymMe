using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class UserRepository
	{
		public static List<MsUser> GetUsers()
		{
			var db = DatabaseSingleton.GetInstance();
			return db.MsUsers.ToList();
		}

		public static MsUser GetUserById(int id)
		{
			var db = DatabaseSingleton.GetInstance();
			return db.MsUsers.Find(id);
		}

		public static MsUser GetUserByUsername(string username)
		{
			var db = DatabaseSingleton.GetInstance();
			return db.MsUsers.Where(x => x.UserName == username).FirstOrDefault();
		}

		public static bool CreateUser(MsUser user)
		{
			var db = DatabaseSingleton.GetInstance();
			db.MsUsers.Add(user);
			return db.SaveChanges() > 0;
		}

		public static bool UpdateUser(MsUser user)
		{
			var db = DatabaseSingleton.GetInstance();
			var updatedUser = db.MsUsers.Find(user.UserID);

			if (updatedUser == null)
			{
				return false;
			}

			updatedUser.UserName = user.UserName;
			updatedUser.UserEmail = user.UserEmail;
			updatedUser.UserPassword = user.UserPassword;
			updatedUser.UserDOB = user.UserDOB;
			updatedUser.UserGender = user.UserGender;
			updatedUser.UserRole = user.UserRole;

			return db.SaveChanges() > 0;
		}
	}
}