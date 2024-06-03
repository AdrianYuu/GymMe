using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controllers
{
	public class TransactionHeaderController
	{
		public static Response<List<TransactionHeader>> GetTransactionHeaders()
		{
			return TransactionHeaderHandler.GetTransactionHeaders();
		}

		public static Response<List<TransactionHeader>> GetTransactionHeadersByUserId(int userId)
		{
			return TransactionHeaderHandler.GetTransactionHeadersByUserId(userId);
		}

		public static Response<TransactionHeader> UpdateTransactionHeader(int transactionId, string status)
		{
			return TransactionHeaderHandler.UpdateTransactionHeader(transactionId, status);
		}
	}
}