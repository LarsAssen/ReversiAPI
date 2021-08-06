using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reversi.Services.Authentication;
using ReversiMvcApp;
using ReversiMvcApp.Models;
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
		private readonly ISpelService _spelService;
		private readonly IAuthenticationService _authService;



		public SpelAPIController(ISpelService spelService, IAuthenticationService authSevice)
		{
			_spelService = spelService;
			_authService = authSevice;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_spelService.GetSpellen());
		}


		[HttpGet("{token}", Name = "GetSpel")]
		public IActionResult GetSpel(string token)
		{
			var spel = GetGameOrError(token);

			if(!(spel is Spel))
			{
				return (IActionResult)spel;
			}

			Spel nieuwspel = (Spel)spel;
			nieuwspel.Speler1Token = nieuwspel.Speler1Token == null ? null : Base64UrlEncoder.Encode(nieuwspel.Speler1Token);
			nieuwspel.Speler2Token = nieuwspel.Speler2Token == null ? null : Base64UrlEncoder.Encode(nieuwspel.Speler2Token);

			return Ok(nieuwspel);
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

		private object GetGameOrError(string token)
		{
			string decodedToken = "";

			try
			{
				decodedToken = Base64UrlEncoder.Decode(token);
			}
			catch
			{
				return StatusCode(404, "Game not found");
			}

			Speler authenticatedUser = _authService.Get();
			Spel game = _spelService.GetSpel(decodedToken);

			if (game == null)
			{
				return StatusCode(404, "Game not found");
			}

			if (authenticatedUser == null || (game.Speler1Token == decodedToken && game.Speler1.Id != authenticatedUser.Id) || (game.Speler2Token == decodedToken && game.Speler2.Id != authenticatedUser.Id))
			{
				return StatusCode(401, "You do not have access to this game.");
			}

			return game;
		}
	}
}
