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

		public static MsSupplement GetSupplementById(int id)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsSupplements.Find(id);
		}

		public static bool CreateSupplement(MsSupplement supplement)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			db.MsSupplements.Add(supplement);
			return db.SaveChanges() > 0;
		}

		public static bool UpdateSupplement(MsSupplement supplement)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			MsSupplement updatedSupplement = db.MsSupplements.Find(supplement.SupplementID);

			if (updatedSupplement == null)
			{
				return false;
			}

			updatedSupplement.SupplementName = supplement.SupplementName;
			updatedSupplement.SupplementPrice = supplement.SupplementPrice;
			updatedSupplement.SupplementTypeID = supplement.SupplementTypeID;

			db.SaveChanges();
			return true;
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