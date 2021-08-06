using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReversiMvcApp;
using ReversiMvcApp.Models;
using ReversiMvcApp.Services;
using ReversiMvcApp.Services.Authentication;
using ReversiRestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Controllers
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

		[HttpGet("LastUpdated/{token}", Name = "LastUpdated")]
		public IActionResult LastUpdated(string token)
		{
			var spelofError = GetGameOrError(token);

			if (!(spelofError is Spel))
			{
				return (IActionResult)spelofError;
			}

			Spel spel = (Spel)spelofError;


			return Ok(spel.LastUpdated);
		}

		[HttpPost("Move/{token}", Name = "Move")]
		public IActionResult Move(string token, [FromBody] Coordinate coordinate)
		{
			var spelOrError = GetGameOrError(token);

			if (!(spelOrError is Spel))
			{
				return (IActionResult)spelOrError;
			}

			Spel spel = (Spel)spelOrError;
			string decodedToken = Base64UrlEncoder.Decode(token);
			bool isPlayer1 = spel.Speler1Token == decodedToken;
			bool isTurn = (spel.Speler1Beurt && isPlayer1) || (!spel.Speler1Beurt && !isPlayer1);

			if (!isTurn)
			{
				return StatusCode(401, "Not your turn.");
			}

			//List<Coordinate> stonesToFlip = spel.GetMove(coordinate, spel.User1Turn && isPlayer1);

			////If there were more than 1 stone flipped, it's a valid turn.
			//if (stonesToFlip.Count > 1)
			//{
			//	//Create new ones
			//	spel.ApplyMove(stonesToFlip, isPlayer1);

			//	//If opponent has no more moves possible
			//	if (!spel.HasMovesPossible(!isPlayer1))
			//	{
			//		//If player has no more moves possible - game over, else, opponent skips.
			//		if (!spel.HasMovesPossible(isPlayer1))
			//		{
			//			//If game finished with 0 score, it's a tie.
			//			spel.Finished = true;
			//		}
			//	}
			//	else
			//	{
			//		spel.User1Turn = !spel.User1Turn;
			//	}

			//	_spelService.UpdateSpel(spel);
			//}
			//else
			//{
			//	return StatusCode(409, "Incorrect move.");
			//}

			return Ok();
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
