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
			using(SqlConnection sqlCon = new SqlConnection(ConnectionString))
			{
				string query = "INSERT INTO Spel VALUES(@GUID, @Omschrijving, @Speler1Token, @Speler2Token @GameState)";
				SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
				sqlCmd.Parameters.AddWithValue("@GUID", spel.ID);
				sqlCmd.Parameters.AddWithValue("@Omschrijving", spel.Omschrijving);
				sqlCmd.Parameters.AddWithValue("@Speler1Token", spel.Speler1Token);
				sqlCmd.Parameters.AddWithValue("@Speler2Token", spel.Speler2Token);
				sqlCmd.Parameters.AddWithValue("@GameState", spel.Bord);

				sqlCon.Open();
				sqlCmd.ExecuteNonQuery();
				sqlCon.Close();
			}
		}

		public Spel.Spel GetSpel(string spelToken)
		{
			var spel = new Spel.Spel();
			using(SqlConnection sqlCon = new SqlConnection(ConnectionString))
			{
				string query = "SELECT * FROM Spel WHERE GUID = " + spelToken;
				sqlCon.Open();
				SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
				SqlDataReader rdr = sqlCmd.ExecuteReader();

				while (rdr.Read())
				{
					spel.ID = Convert.ToInt32(rdr["GUID"]);
					spel.Omschrijving = rdr["Omschrijving"].ToString();
					spel.Speler1Token = rdr["Speler1Token"].ToString();
					spel.Speler2Token = rdr["Speler2Token"].ToString();
					//TODO Convert this string into a gameboard
					var gameState = rdr["GameState"].ToString();
				}
				sqlCon.Close();
			}
			return spel;
		}

		public List<Spel.Spel> GetSpellen()
		{
			var spelList = new List<Spel.Spel>();

			string sqlQuery = "SELECT * FROM Spel";

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
