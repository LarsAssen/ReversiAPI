using Microsoft.EntityFrameworkCore;
using ReversiMvcApp;
using ReversiMvcApp.Data;
using ReversiRestApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.Services
{
	public class SpelRepository : ISpelRepository
	{
		private ReversiDbContext _context;
		public List<Spel> Spellen;
		public SpelRepository(ReversiDbContext context)
		{
			_context = context;
		}

		public void AddSpel(Spel spel)
		{
			_context.Add(spel);
		}

		public Spel GetSpel(string spelToken)
		{
			return Spellen.Find(c => c.Token == spelToken);
		}

		public List<Spel> GetSpellen()
		{
			var spellen = _context.Spel.ToList();
			var spellenMet1Speler = new List<Spel>();
			foreach(Spel spel in spellen)
			{
				if(spel.Speler2Token != "")
				{
					spellenMet1Speler.Add(spel);
				}
			}
			return spellenMet1Speler;
		}

		public List<Spel> GetSpellenMet1Speler()
		{
			return Spellen.Where(c => c.Speler2Token != null).ToList();
		}
	}
}
