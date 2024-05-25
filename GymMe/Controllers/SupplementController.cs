using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controllers
{
	public class SupplementController
	{
		public static Response<List<MsSupplement>> GetSupplements()
		{
			return SupplementHandler.GetSupplements();
		}

		public static Response<MsSupplement> DeleteSupplement(int supplementId)
		{
			return SupplementHandler.DeleteSupplement(supplementId);
		}
	}
}