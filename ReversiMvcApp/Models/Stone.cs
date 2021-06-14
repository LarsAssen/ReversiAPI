using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Models
{
	public class Stone
	{
		public int ID { get; set; }
		public string Kleur { get; set; }
		public int xLocation { get; set; }
		public int yLocation { get; set; }

	}
}
