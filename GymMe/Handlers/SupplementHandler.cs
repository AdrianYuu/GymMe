using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handlers
{
	public class SupplementHandler
	{
		public static Response<List<MsSupplement>> GetSupplements()
		{
			var supplements = SupplementRepository.GetSupplements();

			if (supplements.Count == 0)
			{
				return new Response<List<MsSupplement>>
				{
					Success = false,
					Message = "Failed get supplements.",
					Payload = null
				};
			}

			return new Response<List<MsSupplement>>
			{
				Success = true,
				Message = "Successfully get supplements.",
				Payload = supplements
			};
		}
	}
}