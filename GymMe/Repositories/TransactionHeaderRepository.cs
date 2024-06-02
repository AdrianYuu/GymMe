using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class TransactionHeaderRepository
	{
		public static List<TransactionHeader> GetTransactionHeaders()
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.TransactionHeaders.ToList();
		}

		public static List<TransactionHeader> GetTransactionHeadersByUserId(int userId)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.TransactionHeaders.Where(x => x.UserID == userId).ToList();
		}

		public static TransactionHeader GetTransactionHeaderById(int id)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.TransactionHeaders.Find(id);
		}

		public static bool CreateTransactionHeader(TransactionHeader transactionHeader)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			db.TransactionHeaders.Add(transactionHeader);
			return db.SaveChanges() > 0;
		}

		public static bool UpdateTransactionHeader(TransactionHeader transactionHeader)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			TransactionHeader updatedTransactionHeader = db.TransactionHeaders.Find(transactionHeader.TransactionID);

			if(updatedTransactionHeader == null)
			{
				return false;
			}

			updatedTransactionHeader.Status = transactionHeader.Status;

			db.SaveChanges();
			return true;
		}
	}
}