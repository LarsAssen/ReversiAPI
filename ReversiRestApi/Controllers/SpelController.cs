﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReversiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReversiRestApi.Spel;


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

		[HttpPost]
		public void AddNieuwSpel(string spelerToken, string spelToken, string omschrijving)
		{
			Spel.Spel spel = new Spel.Spel();
			spel.Token = spelToken;
			spel.Speler1Token = spelerToken;
			spel.Omschrijving = omschrijving;

			iRepository.AddSpel(spel);
		}

		[HttpGet]
		public ActionResult<Spel.Spel> GetSpel(string spelToken)
		{
			var spel = iRepository.GetSpel(spelToken);

			return spel;
		}

		[HttpGet]
		public ActionResult<Spel.Spel> GetSpelFromSpelerToken(string spelerToken)
		{
			var spellen = iRepository.GetSpellen();
			var spel = spellen.Where(spel => spel.Speler1Token == spelerToken).FirstOrDefault();

			return spel;
		}

		[HttpGet]
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