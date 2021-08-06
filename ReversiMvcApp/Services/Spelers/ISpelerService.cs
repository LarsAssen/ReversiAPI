using ReversiMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Services.Spelers
{
	public interface ISpelerService
	{
		List<Speler> GetUsers();
		Speler GetUser(int id);
		void CreateUser(Speler user);
		void UpdateUser(Speler user);
		void DeleteUser(Speler user);
		int GetNextAvailableId();
	}
}
