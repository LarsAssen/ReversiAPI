using ReversiMVC.Models;
using ReversiRestApi.Spel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMVC.DAL
{
	public class SpelAccessLayer : ISpelRepository
	{
		private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Game;Integrated Security=True;";

		public List<Spel> GetSpellen()
		{
			var SpelList = new List<Spel>();

			string sqlQuery = "SELECT * FROM Game";

			using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
			{
				sqlCon.Open();
				SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
				SqlDataReader rdr = sqlCmd.ExecuteReader();

				while (rdr.Read())
				{
					var spel = new Spel();
					spel.ID = Convert.ToInt32(rdr["GUID"]);
					spel.Omschrijving = rdr["Omschrijving"].ToString();
					spel.Speler1Token = rdr["Speler1Token"].ToString();
					spel.Speler2Token = rdr["Speler2Token"].ToString();
					SpelList.Add(spel);
				}
				sqlCon.Close();
			}
			return SpelList;
		}
		public void AddSpel(Spel spel)
		{
			int result;
			using(SqlConnection sqlCon = new SqlConnection(ConnectionString))
			{
				string sqlQuery = "INSERT INTO Game(@GUID, @Omschrijving, @Speler1Token, @Speler2Token)";
				SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
				sqlCmd.Parameters.AddWithValue("@GUID", spel.ID);
				sqlCmd.Parameters.AddWithValue("@Omschrijving", spel.Omschrijving);
				sqlCmd.Parameters.AddWithValue("@Speler1Token", spel.Speler1Token);
				sqlCmd.Parameters.AddWithValue("@Speler2Token", spel.Speler2Token);

				sqlCon.Open();
				result = sqlCmd.ExecuteNonQuery();
				sqlCon.Close();
			}
		}

		public Spel GetSpel(string spelToken)
		{
			var Spel = new Spel();
			using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
			{
				string sqlQuery = "SELECT * FROM Game WHERE GUID = " + spelToken;
				sqlCon.Open();
				SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
				SqlDataReader rdr = sqlCmd.ExecuteReader();

				while (rdr.Read())
				{
					Spel.ID = Convert.ToInt32(rdr["GUID"]);
					Spel.Omschrijving = rdr["Omschrijving"].ToString();
					Spel.Speler1Token = rdr["Speler1Token"].ToString();
					Spel.Speler2Token = rdr["Speler2Token"].ToString();
				}
				sqlCon.Close();
			}
			return Spel;
		}
	}
}
