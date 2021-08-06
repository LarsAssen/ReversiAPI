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

			if (!spel.Afgelopen())
			{
				spel.DoeZet(coordinate.X, coordinate.Y);
			}
			_spelService.UpdateSpel(spel);

			return Ok();
		}

		[HttpPost("Cancel/{token}", Name = "Cancel")]
		public IActionResult Cancel(string token)
		{
			var spelOrError = GetGameOrError(token);

			if (!(spelOrError is Spel))
			{
				return (IActionResult)spelOrError;
			}

			Spel spel = (Spel)spelOrError;

			if (spel.Afgelopen())
			{
				return StatusCode(409, "Game is already finished");
			}
			else if (spel.Cancelled)
			{
				return StatusCode(409, "Game is already cancelled");
			}

			spel.Cancelled = true;
			_spelService.UpdateSpel(spel);


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
