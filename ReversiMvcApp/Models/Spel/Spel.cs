using ReversiMvcApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Spel
{
	public class Spel
	{
		public int ID { get; set; }
		public string Omschrijving { get; set; }
		public string Token { get; set; }
		public string Speler1Token { get; set; }
		public Speler Speler1 { get; set; }
		public string Speler2Token { get; set; }
		public Speler Speler2 { get; set; }
	}
}
