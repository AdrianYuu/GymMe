using GymMe.Factories;
using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controllers
{
	public class TransactionDetailController
	{
		public static Response<List<TransactionDetail>> GetTransactionDetailsByTransactionId(int transacitonId)
		{
			return TransactionDetailHandler.GetTransactionDetailsByTransactionId(transacitonId);
		}

		public static Response<TransactionDetail> CreateTransactionDetail(int transactionId, int supplementId, int quantity)
		{
			return TransactionDetailHandler.CreateTransactionDetail(transactionId, supplementId, quantity);
		}
	}
}