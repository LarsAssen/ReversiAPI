using ReversiMvcApp;
using ReversiRestApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.Services
{
	public interface ISpelRepository
	{
		public void AddSpel(Spel spel);
		public List<Spel> GetSpellen();
		public Spel GetSpel(string spelToken);
	}
}
