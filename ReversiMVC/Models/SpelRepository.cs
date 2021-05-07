using ReversiRestApi.Spel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMVC.Models
{
	public class SpelRepository : ISpelRepository
	{
		public int GUID { get; set; }
		public string Omschrijving { get; set; }
		public int Speler1Token { get; set; }
		public int Speler2Token { get; set; }
		public int GameState { get; set; }
		public List<Spel> Spellen { get; set; }

		public void AddSpel(Spel spel)
		{
			Spellen.Add(spel);
		}

		public Spel GetSpel(string spelToken)
		{
			return Spellen.Find(x => x.Token == spelToken);
		}
	}
}
