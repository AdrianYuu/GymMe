using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
    public class SupplementRepository
    {
        public static List<MsSupplement> GetSupplements()
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
            return db.MsSupplements.ToList();
        }

		public static bool DeleteSupplement(int supplementId)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			MsSupplement deletedSupplement = db.MsSupplements.Find(supplementId);

			if (deletedSupplement == null)
			{
				return false;
			}

			db.MsSupplements.Remove(deletedSupplement);
			db.SaveChanges();
			return true;
		}
	}
}