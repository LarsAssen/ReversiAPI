using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ReversiRestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReversiController : ControllerBase
	{
		[HttpGet]
		public ActionResult<string> GetToken()
		{
			string token = "";

			return token;
		}

		[HttpPost]
		public ActionResult<string> SetToken()
		{
			string token = "";

			return token;
		}

		[HttpGet]
		public ActionResult<string> Beurt()
		{
			return "1";
		}

		[HttpPost]
		public void Zet()
		{

		}


	}
}
