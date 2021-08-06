using System;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReversiMvcApp.Data;
using ReversiRestApi.Services;
using ReversiMvcApp.ClassHelpers;
using ReversiMvcApp.Services;
using ReversiMvcApp.Services.Authentication;

namespace ReversiMvcApp.Controllers
{
    [Authenticated]
    public class SpelController : Controller
    {
        private readonly IAuthenticationService _authService;
        private readonly ISpelService _spelService;

        public SpelController(IAuthenticationService authService, ISpelService spelService)
        {
            _authService = authService;
            _spelService = spelService;
        }

        // GET: Spel
        [HttpGet]
        public IActionResult Index()
        {
            var spellen = _spelService.GetSpellen().Where(x => !x.Afgelopen() && !x.Cancelled && x.Speler2 == null);
            return View(spellen);
        }

        // GET: Spel/Join/5
        [HttpGet]
        public IActionResult Join(int id)
        {
            Spel spel = _spelService.GetSpel(id);

            if(_spelService.GetSpellen(_authService.Get()).Count(x => !x.Afgelopen() && !x.Cancelled) > 0)
			{
                return new RedirectResult("/spel");
			}
            if(spel.Speler2 != null || spel.Afgelopen() || spel.Cancelled)
			{
                return new RedirectResult("/spel");
			}
            return View(spel);
        }

        [HttpPost, ActionName("Join"), CSRF]
        public IActionResult JoinPost(int id)
		{
            Spel spel = _spelService.GetSpel(id);

            if(_spelService.GetSpellen(_authService.Get()).Count(x => !x.Afgelopen() && !x.Cancelled) > 0)
			{
                return new RedirectResult("/game");
			}

            if(spel.Speler2 != null || spel.Afgelopen() || spel.Cancelled)
			{
                return new RedirectResult("/game");
			}

            spel = _spelService.JoinSpel(spel);

            return new RedirectResult($"/index.html?token={Base64UrlEncoder.Encode(spel.Speler2Token)}");

		}

        // GET: Spel/Create
        [HttpGet]
        public IActionResult Create()
        {
            if(_spelService.GetSpellen(_authService.Get()).Count(x => !x.Afgelopen() && !x.Cancelled) > 0)
			{
                return new RedirectResult("/game");
			}

            return View();
        }

        [HttpPost]
        [CSRF]
        public IActionResult Create(string description)
        {
            if (_spelService.GetSpellen(_authService.Get()).Count(x => !x.Afgelopen() && !x.Cancelled) > 0)
            {
                return new RedirectResult("/game");
            }

            Spel spel = new Spel();
            spel.Omschrijving = description;

            spel = _spelService.CreateSpel(spel);

            return new RedirectResult($"/index.html?token={Base64UrlEncoder.Encode(spel.Speler1Token)}");
        }
    }
}
