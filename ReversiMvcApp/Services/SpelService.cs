using Microsoft.EntityFrameworkCore;
using ReversiMvcApp.ClassHelpers;
using ReversiMvcApp.Data;
using ReversiMvcApp.Models;
using ReversiMvcApp.Services.Authentication;
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
			var spel = _context.Spel.Include(x => x.Speler1).Include(x => x.Speler2).Include(x => x.Stones).FirstOrDefault(x => x.Speler1Token == token || x.Speler2Token == token);
			return spel;
		
		}

		public Spel GetSpel(int id)
		{
			var spel = _context.Spel.FirstOrDefault(x => x.ID == id);
			return spel;
		}

		public List<Spel> GetSpellen()
		{
			var spellen = _context.Spel.Include(c => c.Speler1).Include(c => c.Speler2).Include(c => c.Stones).ToList();
			return spellen;
		}

		public List<Spel> GetSpellen(Speler speler)
		{
			Speler spelerAuth = _context.Speler.FirstOrDefault(x => x.GUID == _authService.Get().GUID);

			List<Spel> speler1Spellen = _context.Spel.Where(c => c.Speler1 == spelerAuth).Include(c => c.Speler1).Include(c => c.Speler2).Include(c => c.Stones).ToList();
			List<Spel> speler2Spellen = _context.Spel.Where(c => c.Speler2 == spelerAuth).Include(c => c.Speler1).Include(c => c.Speler2).Include(c => c.Stones).ToList();

			var spellen = speler1Spellen.Union(speler2Spellen).ToList();
			return spellen;
		}

		public Spel JoinSpel(Spel spel)
		{
			spel.Speler2 = _context.Speler.FirstOrDefault(x => x.GUID == _authService.Get().GUID);
			spel.Speler2Token = GetNextAvailableToken();

			_context.SaveChanges();
			return spel;
		}

		public void UpdateSpel(Spel spel, bool removeOldStones = true)
		{
			if (removeOldStones)
			{
				_context.SaveChanges();

				_context.Stone.RemoveRange(_context.Stone.Where(c => c.Spel == null));
			}

			_context.SaveChanges();
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
