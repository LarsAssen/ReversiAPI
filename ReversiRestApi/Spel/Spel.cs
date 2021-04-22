using System;
using System.Collections;
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
			if(ZetMogelijk(rijZet, kolomZet))
			{
				return true;
			}
			return false;
		}

		public Kleur OverwegendeKleur()
		{
			int witCounter = 0;
			int zwartCounter = 0;
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if(Bord[i, j] == Kleur.Wit)
					{
						witCounter++;
					}
					if(Bord[i, j] == Kleur.Zwart)
					{
						zwartCounter++;
					}
				}
			}

			if(witCounter > zwartCounter)
			{
				return Kleur.Wit;
			}
			if(zwartCounter > witCounter)
			{
				return Kleur.Zwart;
			}
			else
			{
				return Kleur.Geen;
			}
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


		//function is veel te lang. splits het verder op in andere function om het duidelijker en overzichtelijker te maken
		public bool ZetMogelijk(int rijZet, int kolomZet)
		{
			if (rijZet > 7 || kolomZet > 7 || rijZet < 0 || kolomZet < 0)
			{
				return false;
			}
			else
			{
				ArrayList zetRichtingen = new ArrayList();



				foreach (string s in richtingen)
				{
					zetRichtingen.Add(CheckRichting(rijZet, kolomZet, Array.IndexOf(richtingen, s), false));
				}



				if (zetRichtingen.Contains(true))
				{
					return true;
				}
				else
				{
					return false;
				}
			}

		}

		private bool CheckRichting(int rijZet, int kolomZet, int richting, bool line)
		{
			if (richting == 4)
			{
				return false;
			}



			int rij = rijZet;
			int kolom = kolomZet;



			if (rijZet == 7 && richting > 5 || rijZet == 0 && richting < 3)
			{
				return false;
			}
			else if (richting > 5)
			{
				rij++;
			}
			else if (richting < 3)
			{
				rij--;
			}



			kolom += (richting % 3) - 1;



			if (kolom > 7 || kolom < 0)
			{
				return false;
			}



			Kleur einde = Bord[rij, kolom];



			if (einde == AandeBeurt && line)
			{
				return true;
			}
			else if (einde == Kleur.Geen || einde == AandeBeurt)
			{
				return false;
			}
			else
			{
				return CheckRichting(rij, kolom, richting, true);
			}
		}

		public string[] richtingen = { "NW", "W", "ZW", "N", "Neutraal", "Z", "NO", "O", "ZO" };

		
	}
}
