using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Models
{
	public class Coordinate
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Coordinate(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}

