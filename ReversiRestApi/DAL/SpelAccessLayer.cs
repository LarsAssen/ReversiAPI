using ReversiMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.DAL
{
	public class SpelAccessLayer : ISpelRepository
	{
		private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ReversiDbRestApi;Integrated Security=True;";
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

			string sqlQuery = "SELECT * FROM Game";

			using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
			{
				sqlCon.Open();
				SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
				SqlDataReader rdr = sqlCmd.ExecuteReader();

				while (rdr.Read())
				{
					var spel = new Spel.Spel();
					spel.ID = Convert.ToInt32(rdr["GUID"]);
					spel.Omschrijving = rdr["Omschrijving"].ToString();
					spel.Speler1Token = rdr["Speler1Token"].ToString();
					spel.Speler2Token = rdr["Speler2Token"].ToString();
					//TODO Convert this string into a gameboard
					var gameState = rdr["GameState"].ToString();
					spelList.Add(spel);
				}
				sqlCon.Close();
			}

			return spelList;
		}
	}
}
