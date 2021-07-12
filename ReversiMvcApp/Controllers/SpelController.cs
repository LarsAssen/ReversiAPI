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

namespace ReversiMvcApp.Controllers
{
    [Authenticated]
    public class SpelController : Controller
    {
        private readonly ReversiDbContext _context;
        private readonly ISpelRepository _repo; 

        public SpelController(ReversiDbContext context, ISpelRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: Spel
        public IActionResult Index()
        {
            var spellen = _repo.GetSpellen();
            return View(spellen);
        }

        // GET: Spel/Join/5
        public async Task<IActionResult> Join(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spel = await _context.Spel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (spel == null)
            {
                return NotFound();
            }

            //TODO: Set current user as the second player in the game, and start the game.
            return View(spel);
        }

        // GET: Spel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Omschrijving,Token,Speler1Token,Speler2Token,AandeBeurt")] Spel spel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spel);
        }

        // GET: Spel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spel = await _context.Spel.FindAsync(id);
            if (spel == null)
            {
                return NotFound();
            }
            return View(spel);
        }

        // POST: Spel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Omschrijving,Token,Speler1Token,Speler2Token,AandeBeurt")] Spel spel)
        {
            if (id != spel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpelExists(spel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(spel);
        }

        // GET: Spel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spel = await _context.Spel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (spel == null)
            {
                return NotFound();
            }

            return View(spel);
        }

        // POST: Spel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spel = await _context.Spel.FindAsync(id);
            _context.Spel.Remove(spel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpelExists(int id)
        {
            return _context.Spel.Any(e => e.ID == id);
        }
    }
}
