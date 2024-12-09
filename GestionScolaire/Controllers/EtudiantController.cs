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
    public class EtudiantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtudiantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etudiant
        public async Task<IActionResult> Index()
        {
            return View(await _context.etudiant.ToListAsync());
        }

        // GET: Etudiant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.etudiant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // GET: Etudiant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etudiant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Matricule,Nom,addresse,CreateAt,UpdateAt")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etudiant);
        }

        // GET: Etudiant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.etudiant.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        public async Task<IActionResult> Cours(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the student by ID
            var etudiant = await _context.etudiant.FindAsync(id);


            // Get all courses
            List<Cours>? courses = await _context.cours.ToListAsync();

            // Initialize the list for the student's courses
            List<Cours> coursEtudiant = new List<Cours>();

            // Get the student's class and detail courses
            Classe classe = etudiant.classe;

            if (classe.detailCours != null)
            {
                foreach (var details in classe.detailCours)
                {
                    // Check if the course is in the list of all courses
                    if (courses.Any(item => item.Id == details.Id))
                    {
                        coursEtudiant.Add(details);
                    }
                }
            }

            // Return the list of courses as JSON or pass it to a View
            return View(coursEtudiant); // Or use 'return View(coursEtudiant);' if rendering a view
        }



        public async Task<IActionResult> Absences(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the student by ID
            Etudiant? etudiant = await _context.etudiant.FindAsync(id);

            if (etudiant == null)
            {
                return NotFound();
            }

            // Fetch absences for the specific student directly from the database
            List<Absences> absEtudiant = await _context.absences
                .Where(a => a.etudiant.Id == etudiant.Id)
                .ToListAsync();

            // Return the view with the list of absences
            return View(absEtudiant);
        }







        // POST: Etudiant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Matricule,Nom,addresse,CreateAt,UpdateAt")] Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantExists(etudiant.Id))
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
            return View(etudiant);
        }

        // GET: Etudiant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.etudiant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // POST: Etudiant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etudiant = await _context.etudiant.FindAsync(id);
            if (etudiant != null)
            {
                _context.etudiant.Remove(etudiant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantExists(int id)
        {
            return _context.etudiant.Any(e => e.Id == id);
        }
    }
}
