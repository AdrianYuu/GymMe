using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class TransactionDetailRepository
	{
		public static List<TransactionDetail> GetTransactionDetailsByTransactionId(int transacitonId)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.TransactionDetails.Where(x => x.TransactionID == transacitonId).ToList();
		}
	}
}