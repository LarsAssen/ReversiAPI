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
			List <Direction> directions = getDirections(rijZet, kolomZet);
			if(AandeBeurt == Kleur.Zwart)
			{
				int wit = 0;
				foreach(Direction direction in directions)
				{
					//check of de richting buiten de bord valt
					if(rijZet + direction._row < 0 || rijZet + direction._row > 7)
					{
						continue;
					}
					//check of de richting buiten de bord valt
					if (kolomZet + direction._column < 0 || kolomZet + direction._column > 7)
					{
						continue;
					}

					//check of er witte stenen om de zwate zet zijn
					if (Bord[rijZet + direction._row, kolomZet + direction._column] == Kleur.Wit)
					{
						wit++;
					}
				}
				//als er geen witte stenen om de zet zijn
				if(wit == 0)
				{
					return false;
				}
			}
			if(AandeBeurt == Kleur.Wit)
			{
				int zwart = 0;
				foreach (Direction direction in directions)
				{
					if (rijZet + direction._row < 0 || rijZet + direction._row > 7)
					{
						continue;
					}

					if (kolomZet + direction._column < 0 || kolomZet + direction._column > 7)
					{
						continue;
					}
					if (Bord[rijZet + direction._row, kolomZet + direction._column] == Kleur.Zwart)
					{
						zwart++;
					}
				}
				//als er geen zwarte stenen om de zet zijn
				if (zwart == 0)
				{
					return false;
				}
			}
			return true;
		}


		public void TraverseDirection(int row, int column, Direction direction, Kleur kleur)
		{
			while(Bord[row + direction._row, column + direction._column] != kleur && Bord[row + direction._row, column + direction._column] != Kleur.Geen)
			{
				if(Bord[row, column] == kleur)
				{
					return;
				}
			}
		}

		public List<Direction> getDirections(int row, int column)
		{
			List<Direction> directionList = new List<Direction>();
			Direction North = new Direction(row - 1, column);
			Direction NorthEast = new Direction(row - 1, column + 1);
			Direction NorthWest = new Direction(row - 1, column - 1);
			Direction East = new Direction(row, column + 1);
			Direction SouthEast = new Direction(row + 1, column + 1);
			Direction South = new Direction(row + 1, column);
			Direction SouthWest = new Direction(row + 1, column -1);
			Direction West = new Direction(row, column -1);
			
			directionList.Add(North);
			directionList.Add(NorthEast);
			directionList.Add(NorthWest);
			directionList.Add(East);
			directionList.Add(SouthEast);
			directionList.Add(South);
			directionList.Add(SouthWest);
			directionList.Add(West);
			return directionList;
		}
	}
}
