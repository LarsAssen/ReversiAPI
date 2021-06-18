using ReversiRestApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.Services
{
	public class SpelRepository : ISpelRepository
	{

		public List<Spel> Spellen { get; set; }

		public SpelRepository()
		{
			Spel spel1 = new Spel();
			Spel spel2 = new Spel();
			Spel spel3 = new Spel();

			spel1.Speler1Token = "abcdef";
			spel1.Omschrijving = "Potje snel reversi, dus niet lang nadenken";


			spel2.Speler1Token = "ghijkl";
			spel2.Speler2Token = "mnopqr";
			spel2.Omschrijving = "Ik zoek een uitdaging";


			spel3.Speler1Token = "stuvwx";
			spel3.Omschrijving = "Met herkansingen";

			Spellen = new List<Spel> { spel1, spel2, spel3 };

		}

		public void AddSpel(Spel spel)
		{
			Spellen.Add(spel);
		}

		public Spel GetSpel(string spelToken)
		{
			return Spellen.Find(x => x.Token == spelToken);
		}

		public List<Spel> GetSpellen()
		{
			return Spellen;
		}
	}
}
