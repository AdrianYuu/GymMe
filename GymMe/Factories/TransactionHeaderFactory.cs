using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factories
{
	public class TransactionHeaderFactory
	{
		public static TransactionHeader Create(int userId, DateTime transactionDate, string status)
		{
			TransactionHeader transactionHeader = new TransactionHeader()
			{
				UserID = userId,
				TransactionDate = transactionDate,
				Status = status
			};

			return transactionHeader;
		}
	}
}