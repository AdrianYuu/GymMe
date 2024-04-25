using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Modules
{
	public class Response<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public T Payload { get; set; }
	}
}