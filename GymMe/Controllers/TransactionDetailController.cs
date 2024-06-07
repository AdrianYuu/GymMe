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
			if (transacitonId <= 0)
			{
				return new Response<List<TransactionDetail>>()
				{
					Success = false,
					Message = "Transaction ID is not valid.",
					Payload = null
				};
			}

			return TransactionDetailHandler.GetTransactionDetailsByTransactionId(transacitonId);
		}
	}
}