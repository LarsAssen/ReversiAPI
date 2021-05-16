using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReversiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ReversiRestApi.Spel.Spel;


namespace ReversiRestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpelController : ControllerBase
	{
		private readonly ISpelRepository iRepository;

		public SpelController(ISpelRepository repository)
		{
			iRepository = repository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<string>> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
		{
			var spellen = iRepository.GetSpellen();

			foreach(Spel.Spel spel in spellen)
			{
				if (String.IsNullOrEmpty(spel.Speler2Token))
				{
					spellen.Remove(spel);
				}
			}
			var omschrijvingen = new List<string>();
			foreach(Spel.Spel spel in spellen)
			{
				omschrijvingen.Add(spel.Omschrijving);
			}
			return omschrijvingen;
		}

		[HttpGet]
		public ActionResult<string> GetToken()
		{
			string token = "";

			return token;
		}

		[HttpPost]
		public ActionResult<string> SetToken()
		{
			string token = "";

			return token;
		}

		[HttpGet]
		public ActionResult<string> Beurt()
		{
			return "1";
		}

		[HttpPost]
		public void Zet()
		{

		}


	}
}
