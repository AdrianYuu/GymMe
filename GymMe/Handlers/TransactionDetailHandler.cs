using GymMe.Factories;
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

		public static Response<TransactionDetail> CreateTransactionDetail(int transactionId, int supplementId, int quantity)
		{
			TransactionDetail transactionDetail = TransactionDetailFactory.Create(transactionId, supplementId, quantity);

			bool isCreated = TransactionDetailRepository.CreateTransactionDetail(transactionDetail);

			if (!isCreated)
			{
				return new Response<TransactionDetail>()
				{
					Success = false,
					Message = "Failed to createtransaction detail",
					Payload = null
				};
			}

			return new Response<TransactionDetail>()
			{
				Success = true,
				Message = "Successfully create transaction detail",
				Payload = transactionDetail
			};
		}
	}
}