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

		public static Response<MsSupplement> GetSupplementById(int id)
		{
			if (id <= 0)
			{
				return new Response<MsSupplement>()
				{
					Success = false,
					Message = "Supplement ID is not valid.",
					Payload = null
				};
			}

			return SupplementHandler.GetSupplementById(id);
		}

		public static Response<MsSupplement> CreateSupplement(string name, string expiryDate, string price, string supplementTypeId)
		{
			string errorMsg = string.Empty;
			
			if (name == string.Empty || expiryDate == string.Empty || price == string.Empty || supplementTypeId == "0")
			{
				errorMsg = "All fields is required to be filled.";
			}
			else if(!name.Contains("Supplement"))
			{
				errorMsg = "Name must contains 'Supplement'.";
			}
			else if(DateTime.Parse(expiryDate) <= DateTime.Now)
			{
				errorMsg = "Expiry date must be greater than today's date.";
			}
			else if(Convert.ToInt32(price) < 3000)
			{
				errorMsg = "Price must be at least 3000.";
			}
			else if(Convert.ToInt32(supplementTypeId) <= 0)
			{
				errorMsg = "Supplement Type ID is not valid.";
			}

			if (!errorMsg.Equals(string.Empty))
			{
				return new Response<MsSupplement>()
				{
					Success = false,
					Message = errorMsg,
					Payload = null
				};
			}

			return SupplementHandler.CreateSupplement(name, DateTime.Parse(expiryDate), Convert.ToInt32(price), Convert.ToInt32(supplementTypeId));
		}

		public static Response<MsSupplement> UpdateSupplement(int supplementId, string name, string expiryDate, string price, string supplementTypeId)
		{
			string errorMsg = string.Empty;

			if(supplementId <= 0)
			{
				errorMsg = "Supplement ID is not valid.";
			}
			else if (name == string.Empty || expiryDate == string.Empty || price == string.Empty || supplementTypeId == "0")
			{
				errorMsg = "All fields is required to be filled.";
			}
			else if (!name.Contains("Supplement"))
			{
				errorMsg = "Name must contains 'Supplement'.";
			}
			else if (DateTime.Parse(expiryDate) <= DateTime.Now)
			{
				errorMsg = "Expiry date must be greater than today's date.";
			}
			else if (Convert.ToInt32(price) < 3000)
			{
				errorMsg = "Price must be at least 3000.";
			}
			else if (Convert.ToInt32(supplementTypeId) <= 0)
			{
				errorMsg = "Supplement Type ID is not valid.";
			}

			if (!errorMsg.Equals(string.Empty))
			{
				return new Response<MsSupplement>()
				{
					Success = false,
					Message = errorMsg,
					Payload = null
				};
			}

			return SupplementHandler.UpdateSupplement(supplementId, name, DateTime.Parse(expiryDate), Convert.ToInt32(price), Convert.ToInt32(supplementTypeId));
		}

		public static Response<MsSupplement> DeleteSupplement(int supplementId)
		{
			if (supplementId <= 0)
			{
				return new Response<MsSupplement>()
				{
					Success = false,
					Message = "Supplement ID is not valid.",
					Payload = null
				};
			}

			return SupplementHandler.DeleteSupplement(supplementId);
		}
	}
}