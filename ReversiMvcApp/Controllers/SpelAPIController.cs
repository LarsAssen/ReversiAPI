using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReversiMvcApp;
using ReversiMvcApp.Services;
using ReversiRestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpelAPIController : ControllerBase
	{
		private ISpelService _spelService;

		public SpelAPIController(ISpelService spelService)
		{
			_spelService = spelService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_spelService.GetSpellen());
		}


		public Spel GetSpel(string token)
		{
			Spel spel = _spelService.GetSpel(token);
			return spel;
		}

		public Spel StartSpel(Spel spel)
		{
			spel.Speler1.Kleur = Kleur.Zwart;
			spel.Speler2.Kleur = Kleur.Wit;

			var bord = spel.Bord;

			spel.AandeBeurt = Kleur.Zwart;
			return spel;
		}

		[HttpPost]
		public Spel DoeZet(int x, int y, Kleur kleur, Spel spel)
		{
			spel.DoeZet(x, y);
			return spel;
		}

		[HttpPost("GeefOp/{token}", Name = "GeefOp")]
		public IActionResult GeefOp(Kleur speler, Spel spel)
		{
			if (spel.Afgelopen())
			{
				return StatusCode(409, "Spel is al afgelopen");
			}
			spel.Cancelled = true;
			return Ok();
		}
	}
}
