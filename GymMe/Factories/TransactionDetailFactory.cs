using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factories
{
	public class TransactionDetailFactory
	{
		public static TransactionDetail Create(int transactionId, int supplmentId, int quantity)
		{
			TransactionDetail transactionDetail = new TransactionDetail()
			{
				TransactionID = transactionId,
				SupplementID = supplmentId,
				Quantity = quantity
			};

			return transactionDetail;
		}
	}
}