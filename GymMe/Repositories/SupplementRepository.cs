using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
    public class SupplementRepository
    {
        public static List<MsSupplement> GetSupplements()
        {
            var db = DatabaseSingleton.GetInstance();
            return db.MsSupplements.ToList();
        }
    }
}