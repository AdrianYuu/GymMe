using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Constants
{
	public class Helper
	{
		public static bool IsAlphaNumeric(string str)
		{
			return str.All(char.IsLetterOrDigit);
		}
	}
}