using Microsoft.EntityFrameworkCore;
using ReversiMvcApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Services
{
	public class SpelService : ISpelService
	{
		private readonly ReversiDbContext _context;
		public List<Spel> GetSpellen()
		{
			return new List<Spel>();
		}

		public Spel GetSpel(string token)
		{
			Spel spel = _context.Spel
				.Include(c => c.Speler1)
				.Include(c => c.Speler2)
				.Include(c => c.Stones)
				.FirstOrDefault(c => c.Speler1Token == token || c.Speler2Token == token);

			return spel;
		}

		public Spel StartSpel(Spel spel)
		{
			spel.Speler1.Kleur = Kleur.Zwart;
			spel.Speler2.Kleur = Kleur.Wit;

			spel.AandeBeurt = Kleur.Zwart;
			return spel;
		}
		public Spel DoeZet(Spel spel, int X, int Y)
		{
			spel.DoeZet(X, Y);

			return spel;
		}

		public Spel GeefOp(Spel spel)
		{
			spel.Afgelopen();
			return spel;
		}
	}
}
