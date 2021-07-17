using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Models
{
	public class Stone
	{
		public int ID { get; set; }
		public Spel Spel { get; set; }
		public Kleur Kleur { get; set; }
		public int xLocation { get; set; }
		public int yLocation { get; set; }

		public Stone(int X, int Y, Kleur kleur)
		{
			xLocation = X;
			yLocation = Y;
			Kleur = kleur;
		}

	}
}
