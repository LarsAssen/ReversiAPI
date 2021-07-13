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
		public Spel GetSpel(int id);
		public Spel CreateSpel(Spel spel);

		public Spel JoinSpel(Spel spel);

		public Spel UpdateSpel(Spel spel);
	}
}
