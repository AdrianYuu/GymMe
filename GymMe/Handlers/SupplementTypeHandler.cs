using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handlers
{
	public class SupplementTypeHandler
	{
		public static Response<List<MsSupplementType>> GetSupplementTypes()
		{
			List<MsSupplementType> supplementTypes = SupplementTypeRepository.GetSupplementTypes();

			if(supplementTypes.Count == 0)
			{
				return new Response<List<MsSupplementType>>
				{
					Success = false,
					Message = "Failed get supplement types.",
					Payload = null
				};
			}

			return new Response<List<MsSupplementType>>
			{
				Success = true,
				Message = "Successfully get supplement types.",
				Payload = supplementTypes
			};
		}
	}
}