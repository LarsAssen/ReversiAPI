using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReversiMvcApp;
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
		private ISpelRepository _spelRepo;

		public SpelAPIController(ISpelRepository spelRepo)
		{
			_spelRepo = spelRepo;
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

		[HttpPost]
		public Spel GeefOp(Kleur speler, Spel spel)
		{
			spel.Afgelopen();
			return spel;
		}
	}
}
