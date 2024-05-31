using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controllers
{
	public class SupplementTypeController
	{
		public static Response<List<MsSupplementType>> GetSupplementTypes()
		{
			return SupplementTypeHandler.GetSupplementTypes();
		}
	}
}