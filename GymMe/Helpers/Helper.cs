using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Constants
{
	public class Helper
	{
		public static string GetDefaultCalendarValue()
		{
			return "01/01/0001 00:00:00";
		}
		
		public static bool IsAlphaNumeric(string str)
		{
			return str.All(char.IsLetterOrDigit);
		}
	}
}