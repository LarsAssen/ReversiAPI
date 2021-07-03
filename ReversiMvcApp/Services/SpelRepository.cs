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
			return Spellen;
		}

		public List<Spel> GetSpellenMet1Speler()
		{
			return Spellen.Where(c => c.Speler2 != null).ToList();
		}
	}
}
