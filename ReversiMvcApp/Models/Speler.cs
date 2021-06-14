using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ReversiMvcApp.Spel;
using ReversiRestApi;

namespace ReversiMvcApp.Models
{
	public class Speler
	{
		[Key]
		public string GUID { get; set; }
		public string Naam { get; set; }
		public string Email { get; set; }

		[DisplayName("Aantal Gewonnen")]
		public int AantalGewonnen { get; set; }
		[DisplayName("Aantal Verloren")]
		public int AantalVerloren { get; set; }
		[DisplayName("Aantal Gelijk Gespeeld")]
		public int AantalGelijk { get; set; }
		public Spel.Spel Spel { get; set; }
		public Kleur Kleur { get; set; }
	}
}
