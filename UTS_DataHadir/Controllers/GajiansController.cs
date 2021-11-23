using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UTS_DataHadir.Models;

namespace UTS_DataHadir.Controllers
{
    public class GajiansController : Controller
    {
        private readonly DataHadirContext _context;

        public GajiansController(DataHadirContext context)
        {
            _context = context;
        }

        // GET: Gajians
        public async Task<IActionResult> Index()
        {
            var dataHadirContext = _context.Gajians.Include(g => g.IdEmpNavigation).Include(g => g.IdKehadiranNavigation).Include(g => g.IdKetBayarNavigation);
            return View(await dataHadirContext.ToListAsync());
        }

        // GET: Gajians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gajian = await _context.Gajians
                .Include(g => g.IdEmpNavigation)
                .Include(g => g.IdKehadiranNavigation)
                .Include(g => g.IdKetBayarNavigation)
                .FirstOrDefaultAsync(m => m.IdGaji == id);
            if (gajian == null)
            {
                return NotFound();
            }

            return View(gajian);
        }

        // GET: Gajians/Create
        public IActionResult Create()
        {
            ViewData["IdEmp"] = new SelectList(_context.Employees, "IdEmp", "IdEmp");
            ViewData["IdKehadiran"] = new SelectList(_context.Kehadirans, "IdKehadiran", "IdKehadiran");
            ViewData["IdKetBayar"] = new SelectList(_context.KeteranganPembayarans, "IdKetBayar", "IdKetBayar");
            return View();
        }

        // POST: Gajians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGaji,IdEmp,IdKehadiran,NominalGaji,IdKetBayar")] Gajian gajian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gajian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmp"] = new SelectList(_context.Employees, "IdEmp", "IdEmp", gajian.IdEmp);
            ViewData["IdKehadiran"] = new SelectList(_context.Kehadirans, "IdKehadiran", "IdKehadiran", gajian.IdKehadiran);
            ViewData["IdKetBayar"] = new SelectList(_context.KeteranganPembayarans, "IdKetBayar", "IdKetBayar", gajian.IdKetBayar);
            return View(gajian);
        }

        // GET: Gajians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gajian = await _context.Gajians.FindAsync(id);
            if (gajian == null)
            {
                return NotFound();
            }
            ViewData["IdEmp"] = new SelectList(_context.Employees, "IdEmp", "IdEmp", gajian.IdEmp);
            ViewData["IdKehadiran"] = new SelectList(_context.Kehadirans, "IdKehadiran", "IdKehadiran", gajian.IdKehadiran);
            ViewData["IdKetBayar"] = new SelectList(_context.KeteranganPembayarans, "IdKetBayar", "IdKetBayar", gajian.IdKetBayar);
            return View(gajian);
        }

        // POST: Gajians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGaji,IdEmp,IdKehadiran,NominalGaji,IdKetBayar")] Gajian gajian)
        {
            if (id != gajian.IdGaji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gajian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GajianExists(gajian.IdGaji))
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
            ViewData["IdEmp"] = new SelectList(_context.Employees, "IdEmp", "IdEmp", gajian.IdEmp);
            ViewData["IdKehadiran"] = new SelectList(_context.Kehadirans, "IdKehadiran", "IdKehadiran", gajian.IdKehadiran);
            ViewData["IdKetBayar"] = new SelectList(_context.KeteranganPembayarans, "IdKetBayar", "IdKetBayar", gajian.IdKetBayar);
            return View(gajian);
        }

        // GET: Gajians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gajian = await _context.Gajians
                .Include(g => g.IdEmpNavigation)
                .Include(g => g.IdKehadiranNavigation)
                .Include(g => g.IdKetBayarNavigation)
                .FirstOrDefaultAsync(m => m.IdGaji == id);
            if (gajian == null)
            {
                return NotFound();
            }

            return View(gajian);
        }

        // POST: Gajians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gajian = await _context.Gajians.FindAsync(id);
            _context.Gajians.Remove(gajian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GajianExists(int id)
        {
            return _context.Gajians.Any(e => e.IdGaji == id);
        }
    }
}
