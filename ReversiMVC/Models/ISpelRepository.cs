using ReversiRestApi.Spel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMVC.Models
{
	public interface ISpelRepository
	{
		public void AddSpel(Spel spel);
		public Spel GetSpel(string spelToken);
	}
}
