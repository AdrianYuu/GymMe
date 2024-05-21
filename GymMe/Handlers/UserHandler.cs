using GymMe.Factories;
using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handlers
{
	public class UserHandler
	{
		public static Response<List<MsUser>> GetUsers()
		{
			var users = UserRepository.GetUsers();

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
			var user = UserRepository.GetUserById(id);

			if(user is null)
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

		public static Response<MsUser> LoginUser(string username, string password)
		{
			var user = UserRepository.GetUserByUsername(username);

			if(user is null)
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

		public static Response<MsUser> RegisterUser(string username, string email, string gender, string password, string confirmPassword, DateTime dob)
		{
			var searchedUser = UserRepository.GetUserByUsername(username);

			if(searchedUser != null)
			{
				return new Response<MsUser>
				{
					Success = false,
					Message = "Username already exists.",
					Payload = null
				};
			}

			var user = UserFactory.Create(username, email, password, dob, gender, "Customer");
			
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

			var user = UserRepository.GetUserById(userId);

			if(user is null)
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
	}
}