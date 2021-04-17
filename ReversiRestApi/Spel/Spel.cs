using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.Spel
{
	public class Spel : ISpel
	{
		public int ID { get; set; }
		public string Omschrijving { get; set; }
		public string Token { get; set; }
		public string Speler1Token { get; set; }
		public string Speler2Token { get; set; }
		public Kleur[,] Bord { get; set; }
		public Kleur AandeBeurt { get; set; }

		public bool Afgelopen()
		{
			return false;
		}

		public bool DoeZet(int rijZet, int kolomZet)
		{
			return true;
		}

		public Kleur OverwegendeKleur()
		{
			return Kleur.Zwart;
		}

		public bool Pas()
		{
			if(AandeBeurt == Kleur.Zwart)
			{
				AandeBeurt = Kleur.Wit;
			}else if(AandeBeurt == Kleur.Wit)
			{
				AandeBeurt = Kleur.Zwart;
			}
			return true;
		}

		public bool ZetMogelijk(int rijZet, int kolomZet)
		{
			return true;
		}
	}
}
