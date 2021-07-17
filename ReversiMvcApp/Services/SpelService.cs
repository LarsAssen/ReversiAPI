using Microsoft.EntityFrameworkCore;
using Reversi.Services.Authentication;
using ReversiMvcApp.ClassHelpers;
using ReversiMvcApp.Data;
using ReversiMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Services
{
	public class SpelService : ISpelService
	{
		private readonly ReversiDbContext _context;
		private readonly IAuthenticationService _authService;

		public SpelService(ReversiDbContext context, IAuthenticationService service)
		{
			_context = context;
			_authService = service;
		}

		public Spel CreateSpel(Spel spel)
		{
			spel.Speler1 = _context.Speler.FirstOrDefault(x => x.Id == _authService.Get().Id);
			spel.Speler1Token = GetNextAvailableToken();

			spel.Stones = new List<Stone>();
			spel.Stones.Add(new Stone(3, 3, Kleur.Wit));
			spel.Stones.Add(new Stone(4, 3, Kleur.Zwart));
			spel.Stones.Add(new Stone(3, 4, Kleur.Zwart));
			spel.Stones.Add(new Stone(4, 4, Kleur.Wit));

			_context.Spel.Add(spel);
			_context.SaveChanges();

			return spel;
		}

		public Spel GetSpel(string token)
		{
			throw new NotImplementedException();
		}

		public Spel GetSpel(int id)
		{
			throw new NotImplementedException();
		}

		public List<Spel> GetSpellen()
		{
			throw new NotImplementedException();
		}

		public List<Spel> GetSpellen(Speler speler)
		{
			throw new NotImplementedException();
		}

		public Spel JoinSpel(Spel spel)
		{
			throw new NotImplementedException();
		}

		public void UpdateSpel(Spel spel)
		{
			throw new NotImplementedException();
		}

		private string GetNextAvailableToken()
		{
			string token = KeyHelper.GenerateBase64String(50);

			if (_context.Spel.Count(x => x.Speler1Token == token || x.Speler2Token == token) > 0)
			{
				return GetNextAvailableToken();
			}

			return token;
		}
	}
}
