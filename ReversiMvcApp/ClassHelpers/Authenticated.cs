using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ReversiMvcApp.Enumerations;
using ReversiMvcApp.Models;
using ReversiMvcApp.Services.Spelers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.ClassHelpers
{
	public class Authenticated : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			ITempDataDictionaryFactory factory = ServiceHelper.Get<ITempDataDictionaryFactory>(context);
			ITempDataDictionary tempData = factory.GetTempData(context.HttpContext);
			Role role = GetRole(context);

			if (role == Role.Visitor)
			{
				context.Result = new RedirectResult("/home");
				tempData["ErrorMessage"] = "You do not have the role required to see this page!";
			}
		}

		private Role GetRole(ActionExecutingContext context)
		{
			Role role = Role.Visitor;

			if (((Session)context.HttpContext.Items["session"]).TryGetValue("user", out int id))
			{
				Speler user = ServiceHelper.Get<ISpelerService>(context).GetUser(id);

				if (user != null)
				{
					role = user.Role;
				}
			}

			return role;
		}
	}
}
