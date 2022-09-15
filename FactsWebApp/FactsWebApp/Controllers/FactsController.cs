using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactsWebApp.Data;
using FactsWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace FactsWebApp.Controllers
{
    public class FactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Facts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fact.ToListAsync());
        }

        // GET: Facts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await _context.Fact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fact == null)
            {
                return NotFound();
            }

            return View(fact);
        }

        [Authorize]
        // GET: Facts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FactQuestion,FactAnswer,SubmittedBy")] Fact fact)
        {
            if (ModelState.IsValid)
            {
                fact.SubmittedBy = User.Identity.Name;
                _context.Add(fact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fact);
        }

        [Authorize]
        // GET: Facts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await _context.Fact.FindAsync(id);
            if (fact == null)
            {
                return NotFound();
            }
            return View(fact);
        }

        // POST: Facts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FactQuestion,FactAnswer")] Fact fact)
        {
            if (id != fact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactExists(fact.Id))
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
            return View(fact);
        }
        [Authorize]
        // GET: Facts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await _context.Fact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fact == null)
            {
                return NotFound();
            }

            return View(fact);
        }

        // POST: Facts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fact = await _context.Fact.FindAsync(id);
            _context.Fact.Remove(fact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactExists(int id)
        {
            return _context.Fact.Any(e => e.Id == id);
        }
        //ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {

            return View("Index", await _context.Fact.Where(f => f.FactQuestion.Contains(SearchPhrase)).ToListAsync());
        }
    }
}
