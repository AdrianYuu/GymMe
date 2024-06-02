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
	public class CartHandler
	{
		public static Response<List<MsCart>> GetCartsByUserId(int userId)
		{
			List<MsCart> carts = CartRepository.GetCartsByUserId(userId);

			if (carts.Count == 0)
			{
				return new Response<List<MsCart>>()
				{
					Success = false,
					Message = "Failed to get carts",
					Payload = null
				};
			}

			return new Response<List<MsCart>>()
			{
				Success = true,
				Message = "Successfully get carts",
				Payload = carts
			};
		}
		public static Response<MsCart> CreateOrUpdateCart(int userId, int supplementId, int quantity)
		{
			MsCart searchedCart = CartRepository.GetCartByUserIdAndSupplementId(userId, supplementId);
			MsCart cart = CartFactory.Create(userId, supplementId, quantity);

			if (searchedCart == null)
			{
				bool isCreated = CartRepository.CreateCart(cart);

				if (!isCreated)
				{
					return new Response<MsCart>()
					{
						Success = false,
						Message = "Failed to create cart",
						Payload = null
					};
				}

				return new Response<MsCart>()
				{
					Success = true,
					Message = "Successfully create cart",
					Payload = cart
				};
			}

			cart.CartID = searchedCart.CartID;
			cart.Quantity += searchedCart.Quantity;
			bool isUpdated = CartRepository.UpdateCart(cart);

			if (!isUpdated)
			{
				return new Response<MsCart>()
				{
					Success = false,
					Message = "Failed to update cart",
					Payload = null
				};
			}

			return new Response<MsCart>()
			{
				Success = true,
				Message = "Successfully update cart",
				Payload = cart
			};
		}

		public static Response<List<MsCart>> DeleteCart(int userId)
		{
			List<MsCart> carts = CartRepository.GetCartsByUserId(userId);

			foreach (MsCart cart in carts)
			{
				bool isDeleted = CartRepository.DeleteCart(cart.CartID);

				if (!isDeleted)
				{
					return new Response<List<MsCart>>()
					{
						Success = false,
						Message = "Failed to delete cart",
						Payload = null
					};
				}
			}

			return new Response<List<MsCart>>()
			{
				Success = false,
				Message = "Successfully delete cart",
				Payload = null
			};
		}
	}
}