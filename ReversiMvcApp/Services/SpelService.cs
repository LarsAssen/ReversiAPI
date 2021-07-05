using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Services
{
	public class SpelService : ISpelService
	{
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
