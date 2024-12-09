using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionScolaire.Models;

namespace GestionScolaire.Controllers
{
    public class AbsencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbsencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Absences
        public async Task<IActionResult> Index()
        {
            return View(await _context.absences.ToListAsync());
        }

        // GET: Absences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absences = await _context.absences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (absences == null)
            {
                return NotFound();
            }

            return View(absences);
        }

        // GET: Absences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("date,Id,CreateAt,UpdateAt")] Absences absences)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(absences);
        }

        // GET: Absences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absences = await _context.absences.FindAsync(id);
            if (absences == null)
            {
                return NotFound();
            }
            return View(absences);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("date,Id,CreateAt,UpdateAt")] Absences absences)
        {
            if (id != absences.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsencesExists(absences.Id))
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
            return View(absences);
        }

        // GET: Absences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absences = await _context.absences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (absences == null)
            {
                return NotFound();
            }

            return View(absences);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var absences = await _context.absences.FindAsync(id);
            if (absences != null)
            {
                _context.absences.Remove(absences);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsencesExists(int id)
        {
            return _context.absences.Any(e => e.Id == id);
        }
    }
}
