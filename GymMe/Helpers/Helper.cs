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
			bool hasLetter = false;
			bool hasDigit = false;

			foreach (char c in str)
			{
				if (char.IsLetter(c))
				{
					hasLetter = true;
				}
				else if (char.IsDigit(c))
				{
					hasDigit = true;
				}
				else
				{
					return false;
				}
			}

			return hasLetter && hasDigit;
		}
	}
}