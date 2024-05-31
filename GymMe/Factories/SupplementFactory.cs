using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factories
{
	public class SupplementFactory
	{
		public static MsSupplement Create(string supplementName, DateTime supplementExpiryDate, int supplementPrice, int supplementTypeId)
		{
			MsSupplement supplement = new MsSupplement()
			{
				SupplementName = supplementName,
				SupplementExpiryDate = supplementExpiryDate,
				SupplementPrice = supplementPrice,
				SupplementTypeID = supplementTypeId
			};

			return supplement;
		}
	}
}