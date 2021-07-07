using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Services
{
	public interface ISpelService
	{
		public List<Spel> GetSpellen();
		public Spel GetSpel(string token);
		public Spel StartSpel(Spel spel);

		public Spel DoeZet(Spel spel, int X, int Y);

		public Spel GeefOp(Spel spel);
	}
}
