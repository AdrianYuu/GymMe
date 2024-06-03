using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controllers
{
	public class CartController
	{
		public static Response<List<MsCart>> GetCartsByUserId(int userId)
		{
			return CartHandler.GetCartsByUserId(userId);
		}

		public static Response<MsCart> CreateOrUpdateCart(int userId, int supplementId, string quantity)
		{
			string errorMsg = string.Empty;

			if (quantity == string.Empty)
			{
				errorMsg = "Quantity is required.";
			}
			else if(Convert.ToInt32(quantity) <= 0)
			{
				errorMsg = "Quantity must be bigger than 0.";
			}

			if (!errorMsg.Equals(string.Empty))
			{
				return new Response<MsCart>()
				{
					Success = false,
					Message = errorMsg,
					Payload = null
				};
			}

			return CartHandler.CreateOrUpdateCart(userId, supplementId, Convert.ToInt32(quantity));
		}

		public static Response<List<MsCart>> DeleteCart(int userId)
		{
			return CartHandler.DeleteCart(userId);
		}

		public static Response<List<MsCart>> CheckoutCart(int userId)
		{
			return CartHandler.CheckoutCart(userId);
		}
	}
}