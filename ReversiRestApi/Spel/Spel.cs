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

		public Spel()
		{
			Bord = new Kleur[8, 8];
			for(int i = 0; i < 8; i++)
			{
				for(int j = 0; j < 8; j++)
				{
					Bord[i, j] = Kleur.Geen;
				}
			}
			Bord[3, 3] = Kleur.Wit;
			Bord[4, 4] = Kleur.Wit;
			Bord[3, 4] = Kleur.Zwart;
			Bord[4, 3] = Kleur.Zwart;
		}
		public bool Afgelopen()
		{
			return false;
		}

		public bool DoeZet(int rijZet, int kolomZet)
		{
			if(rijZet > 7 || kolomZet > 7)
			{
				return false;
			}
			if(AandeBeurt == Kleur.Wit)
			{

			}
			if(AandeBeurt == Kleur.Zwart)
			{

			}

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
