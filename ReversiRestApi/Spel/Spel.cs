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
			bool pas1 = Pas();
			bool pas2 = Pas();

			return (pas1 && pas2);
		}

		public bool DoeZet(int rijZet, int kolomZet)
		{
			if(ZetMogelijk(rijZet, kolomZet))
			{
				bool[] zetRichtingen = new bool[8];
				for(int i = 0; i < richtingen.Length; i++)
				{
					zetRichtingen[i] = (CheckRichting(rijZet, kolomZet, Array.IndexOf(richtingen, richtingen[i]), false));
				}
				for(int i = 0; i < zetRichtingen.Length; i++)
				{
					if (zetRichtingen[i] == true)
					{
						VeranderKleuren(rijZet, kolomZet, Array.IndexOf(richtingen, richtingen[i]));
					}
				}
				WisselBeurt();
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
			ArrayList zetRichtingen = new ArrayList();



			for (int i = 0; i < Bord.GetLength(0); i++)
			{
				for (int j = 0; j < Bord.GetLength(1); j++)
				{
					if (Bord[i, j] == Kleur.Geen)
					{
						zetRichtingen.Add(ZetMogelijk(i, j));
					}
				}
			}
			if (zetRichtingen.Contains(true))
			{
				return false;
			}
			else
			{
				WisselBeurt();
				return true;
			}
		}

		private void WisselBeurt()
		{
			if(AandeBeurt == Kleur.Wit)
			{
				AandeBeurt = Kleur.Zwart;
			}
			else
			{
				AandeBeurt = Kleur.Wit;
			}
		}


		public bool ZetMogelijk(int rijZet, int kolomZet)
		{
			//if zet is buiten de bord
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

		private void VeranderKleuren(int rijZet, int kolomZet, int richting)
		{
			int rij = rijZet;
			int kolom = kolomZet;

			Kleur einde = Bord[rij, kolom];
			if (einde == AandeBeurt)
			{
				return;
			}
			else
			{
				Bord[rij, kolom] = AandeBeurt;
				Kleur k = Bord[rij, kolom];


			//als de richting naar het oosten gaat
			if (richting == 1 || richting == 2 || richting == 3)
			{
				rij++;
			}
			//Als de richting naar het westen gaat
			if (richting == 5 || richting == 6 || richting == 7)
			{
				rij--;
			}
			//Als de richting naar het noorden gaat
			if (richting == 0 || richting == 1 || richting == 7)
			{
				kolom--;
			}
			//Als de richting naar het zuiden gaat
			if (richting == 3 || richting == 4 || richting == 5)
			{
				kolom++;
			}
				VeranderKleuren(rij, kolom, richting);
			}
		}

		private bool CheckRichting(int rijZet, int kolomZet, int richting, bool line)
		{
			int rij = rijZet;
			int kolom = kolomZet;

			//check of de zet buiten de bord plaatsvind
			if(rij > 7 || rij < 0 || kolom > 7 || rij < 0)
			{
				return false;
			}
			//als de richting naar het oosten gaat
			if(richting == 1 || richting == 2 || richting == 3)
			{
				if(rij == 7)
				{
					return false;
				}
				rij++;
			}
			//Als de richting naar het westen gaat
			if(richting == 5 || richting == 6 || richting == 7)
			{
				if(rij == 0)
				{
					return false;
				}
				rij--;
			}
			//Als de richting naar het noorden gaat
			if(richting == 0 || richting == 1 || richting == 7)
			{
				if(kolom == 0)
				{
					return false;
				}
				kolom--;
			}
			//Als de richting naar het zuiden gaat
			if (richting == 3 || richting == 4 || richting == 5)
			{
				if (kolom == 7)
				{
					return false;
				}
				kolom++;
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

		public string[] richtingen = { "N", "NO", "O", "ZO", "Z", "ZW", "W", "NW" };

		
	}
}
