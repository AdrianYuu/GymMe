using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handlers
{
	public class TransactionDetailHandler
	{
		public static Response<List<TransactionDetail>> GetTransactionDetailsByTransactionId(int transacitonId)
		{
			List<TransactionDetail> transactionDetails = TransactionDetailRepository.GetTransactionDetailsByTransactionId(transacitonId);

			if(transactionDetails.Count == 0)
			{
				return new Response<List<TransactionDetail>>()
				{
					Success = false,
					Message = "Failed to get transaction details",
					Payload = null
				};
			}

			return new Response<List<TransactionDetail>>()
			{
				Success = true,
				Message = "Successfully get transaction details",
				Payload = transactionDetails
			};
		}
	}
}