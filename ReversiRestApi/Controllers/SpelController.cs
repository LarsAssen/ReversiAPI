using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReversiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
		public async Task<ActionResult<IEnumerable<Spel>>> GetSpellen()
		{
			var spellen = iRepository.GetSpellen();
			return spellen;
		}

		[HttpGet]
		[Route("/waiting")]
		public ActionResult<IEnumerable<string>> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
		{
			var spellen = iRepository.GetSpellen();

			foreach(Spel spel in spellen)
			{
				if (String.IsNullOrEmpty(spel.Speler2Token))
				{
					spellen.Remove(spel);
				}
			}
			var omschrijvingen = new List<string>();
			foreach(Spel spel in spellen)
			{
				omschrijvingen.Add(spel.Omschrijving);
			}
			return omschrijvingen;
		}

		[HttpPost]
		public void AddNieuwSpel(string spelerToken, string spelToken, string omschrijving)
		{
			Spel spel = new Spel();
			spel.Token = spelToken;
			spel.Speler1Token = spelerToken;
			spel.Omschrijving = omschrijving;

			iRepository.AddSpel(spel);
		}

		[HttpGet("{spelToken}")]
		public ActionResult<Spel> GetSpel(string spelToken)
		{
			var spel = iRepository.GetSpel(spelToken);

			return spel;
		}

		[HttpGet("{spelerToken}")]
		public ActionResult<Spel> GetSpelFromSpelerToken(string spelerToken)
		{
			var spellen = iRepository.GetSpellen();
			var spel = spellen.Where(spel => spel.Speler1Token == spelerToken).FirstOrDefault();

			return spel;
		}

		[HttpGet]
		[Route("/beurt")]
		public ActionResult<Kleur> Beurt(string speltoken)
		{
			var spel = iRepository.GetSpel(speltoken);
			var kleur = spel.AandeBeurt;
			return kleur;
		}

		[HttpPost]
		public void Zet(string speltoken, string spelertoken, int rij, int kolom)
		{
			var spel = iRepository.GetSpel(speltoken);
			spel.DoeZet(rij, kolom);
		}

		[HttpPut]
		public ActionResult<string> Opgeven(string speltoken, string spelertoken)
		{
			var spel = iRepository.GetSpel(speltoken);
			spel.Afgelopen();
			
			//return winnaar
			if(spelertoken == spel.Speler1Token)
			{
				return spel.Speler2Token;
			}
			else
			{
				return spel.Speler2Token;
			}
		}
	}
}
