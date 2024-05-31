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
	public class SupplementHandler
	{
		public static Response<List<MsSupplement>> GetSupplements()
		{
			List<MsSupplement> supplements = SupplementRepository.GetSupplements();

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

		public static Response<MsSupplement> GetSupplementById(int id)
		{
			MsSupplement supplement = SupplementRepository.GetSupplementById(id);

			if (supplement == null)
			{
				return new Response<MsSupplement>
				{
					Success = false,
					Message = "Failed get supplement.",
					Payload = null
				};
			}

			return new Response<MsSupplement>
			{
				Success = true,
				Message = "Successfully get supplement.",
				Payload = supplement
			};
		}

		public static Response<MsSupplement> CreateSupplement(string name, DateTime expiryDate, int price, int supplementTypeId)
		{
			MsSupplement supplement = SupplementFactory.Create(name, expiryDate, price, supplementTypeId);

			bool isSuccess = SupplementRepository.CreateSupplement(supplement);

			if(!isSuccess)
			{
				return new Response<MsSupplement>
				{
					Success = false,
					Message = "Failed to create supplement.",
					Payload = null
				};
			}

			return new Response<MsSupplement>
			{
				Success = true,
				Message = "Successfully create supplement.",
				Payload = supplement
			};
		}

		public static Response<MsSupplement> DeleteSupplement(int supplementId)
		{
			bool isDeleted = SupplementRepository.DeleteSupplement(supplementId);

			if(!isDeleted)
			{
				return new Response<MsSupplement>
				{
					Success = false,
					Message = "Failed to delete supplement.",
					Payload = null
				};
			}

			return new Response<MsSupplement>
			{
				Success = true,
				Message = "Successfully delete supplement.",
				Payload = null
			};
		}
	}
}