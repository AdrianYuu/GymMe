using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factories
{
	public class CartFactory
	{
		public static MsCart Create(int userId, int supplementId, int quantity)
		{
			MsCart cart = new MsCart()
			{ 
				UserID = userId,
				SupplementID = supplementId,
				Quantity = quantity
			};

			return cart;
		}
	}
}