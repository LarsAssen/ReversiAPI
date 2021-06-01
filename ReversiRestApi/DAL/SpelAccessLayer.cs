using ReversiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.DAL
{
	public class SpelAccessLayer : ISpelRepository
	{
		public void AddSpel(Spel.Spel spel)
		{
			throw new NotImplementedException();
		}

		public Spel.Spel GetSpel(string spelToken)
		{
			throw new NotImplementedException();
		}

		public List<Spel.Spel> GetSpellen()
		{
			var spelList = new List<Spel.Spel>();

			string sqlQuery = "";
			return spelList;
		}
	}
}
