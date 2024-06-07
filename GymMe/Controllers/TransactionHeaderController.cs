using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			if (userId <= 0)
			{
				return new Response<List<TransactionHeader>>()
				{
					Success = false,
					Message = "User ID is not valid.",
					Payload = null
				};
			}

			return TransactionHeaderHandler.GetTransactionHeadersByUserId(userId);
		}

		public static Response<TransactionHeader> UpdateTransactionHeader(int transactionId, string status)
		{
			string errorMsg = string.Empty;

			if (transactionId <= 0)
			{
				errorMsg = "Transaction ID is not valid.";
			}
			else if(status == string.Empty)
			{
				errorMsg = "Status is required.";
			}
			else if(status != "Handled" && status != "Unhandled")
			{
				errorMsg = "Status must be handled or unhandled.";
			}

			if (!errorMsg.Equals(string.Empty))
			{
				return new Response<TransactionHeader>()
				{
					Success = false,
					Message = errorMsg,
					Payload = null
				};
			}

			return TransactionHeaderHandler.UpdateTransactionHeader(transactionId, status);
		}
	}
}