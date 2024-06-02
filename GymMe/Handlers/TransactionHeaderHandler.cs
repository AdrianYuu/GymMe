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
	public class TransactionHeaderHandler
	{
		public static Response<List<TransactionHeader>> GetTransactionHeaders()
		{
			List<TransactionHeader> transactionHeaders = TransactionHeaderRepository.GetTransactionHeaders();

			if (transactionHeaders.Count == 0)
			{
				return new Response<List<TransactionHeader>>()
				{
					Success = false,
					Message = "Failed to get transaction headers",
					Payload = null
				};
			}

			return new Response<List<TransactionHeader>>()
			{
				Success = true,
				Message = "Successfully get transaction headers",
				Payload = transactionHeaders
			};
		}

		public static Response<List<TransactionHeader>> GetTransactionHeadersByUserId(int userId)
		{
			List<TransactionHeader> transactionHeaders = TransactionHeaderRepository.GetTransactionHeadersByUserId(userId);

			if (transactionHeaders.Count == 0)
			{
				return new Response<List<TransactionHeader>>()
				{
					Success = false,
					Message = "Failed to get transaction headers",
					Payload = null
				};
			}

			return new Response<List<TransactionHeader>>()
			{
				Success = true,
				Message = "Successfully get transaction headers",
				Payload = transactionHeaders
			};
		}

		public static Response<TransactionHeader> CreateTransactionHeader(int userId, DateTime transactionDate, string status)
		{
			TransactionHeader transactionHeader = TransactionHeaderFactory.Create(userId, transactionDate, status);

			bool isCreated = TransactionHeaderRepository.CreateTransactionHeader(transactionHeader);

			if(!isCreated)
			{
				return new Response<TransactionHeader>()
				{
					Success = false,
					Message = "Failed to get transaction header",
					Payload = null
				};
			}

			return new Response<TransactionHeader>()
			{
				Success = true,
				Message = "Successfully get transaction header",
				Payload = transactionHeader
			};
		}

		public static Response<TransactionHeader> UpdateTransactionHeader(int transactionId, string status)
		{
			TransactionHeader oldTransactionHeader = TransactionHeaderRepository.GetTransactionHeaderById(transactionId);
			TransactionHeader transactionHeader = TransactionHeaderFactory.Create(oldTransactionHeader.UserID, oldTransactionHeader.TransactionDate, status);
			transactionHeader.TransactionID = transactionId;

			bool isUpdated = TransactionHeaderRepository.UpdateTransactionHeader(transactionHeader);

			if (!isUpdated)
			{
				return new Response<TransactionHeader>()
				{
					Success = false,
					Message = "Failed to update transaction header",
					Payload = null
				};
			}

			return new Response<TransactionHeader>()
			{
				Success = true,
				Message = "Successfully update transaction header",
				Payload = transactionHeader
			};
		}
	}
}