using GymMe.Factories;
using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GymMe.Handlers
{
	public class UserHandler
	{
		public static Response<List<MsUser>> GetUsers()
		{
			List<MsUser> users = UserRepository.GetUsers();

			if(users.Count == 0)
			{
				return new Response<List<MsUser>>
				{
					Success = false,
					Message = "Failed get users.",
					Payload = null
				};
			}

			return new Response<List<MsUser>>
			{
				Success = true,
				Message = "Successfully get users.",
				Payload = users
			};
		}

		public static Response<MsUser> GetUserById(int id)
		{
			MsUser user = UserRepository.GetUserById(id);

			if(user == null)
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "Failed get user.",
					Payload = null
				};
			}

			return new Response<MsUser>
			{
				Success = true,
				Message = "Successfully get user.",
				Payload = user
			};
		}

		public static Response<List<MsUser>> GetUsersByRole(string role)
		{
			List<MsUser> users = UserRepository.GetUsersByRole(role);

			if (users.Count == 0)
			{
				return new Response<List<MsUser>>
				{
					Success = false,
					Message = "Failed get users.",
					Payload = null
				};
			}

			return new Response<List<MsUser>>
			{
				Success = true,
				Message = "Successfully get users.",
				Payload = users
			};
		}

		public static Response<MsUser> LoginUser(string username, string password)
		{
			MsUser user = UserRepository.GetUserByUsername(username);

			if(user == null)
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "There is no user with that username.",
					Payload = null
				};
			}

			if(user.UserPassword != password) 
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "Invalid credentials.",
					Payload = null
				};
			}

			return new Response<MsUser>
			{
				Success = true,
				Message = "Successfully login.",
				Payload = user
			};
		}

		public static Response<MsUser> RegisterUser(string username, string email, string gender, string password, DateTime dob)
		{
			MsUser searchedUser = UserRepository.GetUserByUsername(username);

			if(searchedUser != null)
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "Username already exists.",
					Payload = null
				};
			}

			MsUser user = UserFactory.Create(username, email, password, dob, gender, "Customer");

			bool isSuccess = UserRepository.CreateUser(user);

			if(!isSuccess)
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "Failed to register user.",
					Payload = null
				};
			}

			return new Response<MsUser>
			{
				Success = true,
				Message = "Successfully register user.",
				Payload = user
			};
		}

		public static Response<MsUser> LoginUserByCookie(string cookie)
		{
			int userId = Convert.ToInt32(cookie);

			MsUser user = UserRepository.GetUserById(userId);

			if(user == null)
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "User not exists.",
					Payload = null
				};
			}

			return new Response<MsUser>
			{
				Success = true,
				Message = "Successfully login by cookie.",
				Payload = user
			};
		}

		public static Response<MsUser> UpdateUserInformation(int userId, string username, string email, string gender, DateTime dob)
		{
			MsUser searchedUser = UserRepository.GetUserByUsername(username);

			if(searchedUser != null && searchedUser.UserName != username)
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "Username already exists.",
					Payload = null
				};
			}

			MsUser oldUser = UserRepository.GetUserById(userId);
			MsUser user = UserFactory.Create(username, email, oldUser.UserPassword, dob, gender, oldUser.UserRole);
			user.UserID = oldUser.UserID;

			bool isUpdated = UserRepository.UpdateUser(user);

			if(!isUpdated)
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "Failed to update user information.",
					Payload = null
				};
			}

			return new Response<MsUser>
			{
				Success = true,
				Message = "Sucessfully update user information.",
				Payload = user
			};
		}

		public static Response<MsUser> UpdateUserPassword(int userId, string oldPassword, string newPassword)
		{
			MsUser oldUser = UserRepository.GetUserById(userId);

			if(oldUser.UserPassword != oldPassword)
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "Old password is wrong.",
					Payload = null
				};
			}

			MsUser user = UserFactory.Create(oldUser.UserName, oldUser.UserEmail, newPassword, oldUser.UserDOB, oldUser.UserGender, oldUser.UserRole);
			user.UserID = oldUser.UserID;

			bool isUpdated = UserRepository.UpdateUser(user);

			if (!isUpdated)
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "Failed to update user password.",
					Payload = null
				};
			}

			return new Response<MsUser>
			{
				Success = true,
				Message = "Sucessfully update user password.",
				Payload = user
			};
		}
	}
}