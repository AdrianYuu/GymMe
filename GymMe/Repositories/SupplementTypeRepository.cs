using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class SupplementTypeRepository
	{
		public static List<MsSupplementType> GetSupplementTypes()
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsSupplementTypes.ToList();
		}
	}
}