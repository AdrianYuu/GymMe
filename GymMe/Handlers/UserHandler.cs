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

		public static Response<MsUser> GetUserByID(int id)
		{
			var user = UserRepository.GetUserByID(id);

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
	}
}