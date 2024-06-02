using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class CartRepository
	{
		public static List<MsCart> GetCartsByUserId(int id)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsCarts.Where(x => x.UserID == id).ToList();
		}

		public static MsCart GetCartByUserIdAndSupplementId(int userId, int supplementId)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsCarts.Where(x => x.UserID == userId && x.SupplementID == supplementId).FirstOrDefault();
		}

		public static bool CreateCart(MsCart cart)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			db.MsCarts.Add(cart);
			return db.SaveChanges() > 0;
		}

		public static bool UpdateCart(MsCart cart)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			MsCart updatedCart = db.MsCarts.Find(cart.CartID);

			if (updatedCart == null)
			{
				return false;
			}

			updatedCart.Quantity = cart.Quantity;

			db.SaveChanges();
			return true;
		}

		public static bool DeleteCart(int cartId)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			MsCart deletedCart = db.MsCarts.Find(cartId);

			if (deletedCart == null)
			{
				return false;
			}

			db.MsCarts.Remove(deletedCart);
			db.SaveChanges();
			return true;
		}
	}
}