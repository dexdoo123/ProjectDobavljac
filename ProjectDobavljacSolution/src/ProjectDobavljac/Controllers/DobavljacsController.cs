using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectDobavljac;
using ProjectDobavljac.Model;

namespace ProjectDobavljac.Controllers
{
    public class DobavljacsController : Controller
    {
        private readonly DomainModelPostgreSqlContext _context;

        public DobavljacsController(DomainModelPostgreSqlContext context)
        {
            _context = context;    
        }

        // GET: Dobavljacs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dobavljac.ToListAsync());
        }

        // GET: Dobavljacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dobavljac = await _context.Dobavljac.SingleOrDefaultAsync(m => m.dobavljacId == id);
            if (dobavljac == null)
            {
                return NotFound();
            }

            return View(dobavljac);
        }

        // GET: Dobavljacs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dobavljacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dobavljacId,dobavljacAdresa,dobavljacNaziv")] Dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dobavljac);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dobavljac);
        }

        // GET: Dobavljacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dobavljac = await _context.Dobavljac.SingleOrDefaultAsync(m => m.dobavljacId == id);
            if (dobavljac == null)
            {
                return NotFound();
            }
            return View(dobavljac);
        }

        // POST: Dobavljacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dobavljacId,dobavljacAdresa,dobavljacNaziv")] Dobavljac dobavljac)
        {
            if (id != dobavljac.dobavljacId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dobavljac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DobavljacExists(dobavljac.dobavljacId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(dobavljac);
        }

        // GET: Dobavljacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dobavljac = await _context.Dobavljac.SingleOrDefaultAsync(m => m.dobavljacId == id);
            if (dobavljac == null)
            {
                return NotFound();
            }

            return View(dobavljac);
        }

        // POST: Dobavljacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dobavljac = await _context.Dobavljac.SingleOrDefaultAsync(m => m.dobavljacId == id);
            _context.Dobavljac.Remove(dobavljac);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DobavljacExists(int id)
        {
            return _context.Dobavljac.Any(e => e.dobavljacId == id);
        }
    }
}
