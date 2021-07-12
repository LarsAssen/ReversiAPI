
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.ClassHelpers
{
	public static class ServiceHelper
	{
		/// <summary>
		/// Gets a service of type T from the given Actioncontext
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="context"></param>
		/// <returns></returns>
		public static T Get<T>(ActionContext context)
		{
			return (T)context.HttpContext.RequestServices.GetService(typeof(T));
		}
	}
}
