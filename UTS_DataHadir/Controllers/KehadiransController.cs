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
    public class KehadiransController : Controller
    {
        private readonly DataHadirContext _context;

        public KehadiransController(DataHadirContext context)
        {
            _context = context;
        }

        // GET: Kehadirans
        public async Task<IActionResult> Index()
        {
            var dataHadirContext = _context.Kehadirans.Include(k => k.IdEmpNavigation).Include(k => k.IdStatusNavigation);
            return View(await dataHadirContext.ToListAsync());
        }

        // GET: Kehadirans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kehadiran = await _context.Kehadirans
                .Include(k => k.IdEmpNavigation)
                .Include(k => k.IdStatusNavigation)
                .FirstOrDefaultAsync(m => m.IdKehadiran == id);
            if (kehadiran == null)
            {
                return NotFound();
            }

            return View(kehadiran);
        }

        // GET: Kehadirans/Create
        public IActionResult Create()
        {
            ViewData["IdEmp"] = new SelectList(_context.Employees, "IdEmp", "IdEmp");
            ViewData["IdStatus"] = new SelectList(_context.Statushadirs, "IdStatus", "IdStatus");
            return View();
        }

        // POST: Kehadirans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKehadiran,IdEmp,IdStatus,TanggalHadir")] Kehadiran kehadiran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kehadiran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmp"] = new SelectList(_context.Employees, "IdEmp", "IdEmp", kehadiran.IdEmp);
            ViewData["IdStatus"] = new SelectList(_context.Statushadirs, "IdStatus", "IdStatus", kehadiran.IdStatus);
            return View(kehadiran);
        }

        // GET: Kehadirans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kehadiran = await _context.Kehadirans.FindAsync(id);
            if (kehadiran == null)
            {
                return NotFound();
            }
            ViewData["IdEmp"] = new SelectList(_context.Employees, "IdEmp", "IdEmp", kehadiran.IdEmp);
            ViewData["IdStatus"] = new SelectList(_context.Statushadirs, "IdStatus", "IdStatus", kehadiran.IdStatus);
            return View(kehadiran);
        }

        // POST: Kehadirans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKehadiran,IdEmp,IdStatus,TanggalHadir")] Kehadiran kehadiran)
        {
            if (id != kehadiran.IdKehadiran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kehadiran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KehadiranExists(kehadiran.IdKehadiran))
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
            ViewData["IdEmp"] = new SelectList(_context.Employees, "IdEmp", "IdEmp", kehadiran.IdEmp);
            ViewData["IdStatus"] = new SelectList(_context.Statushadirs, "IdStatus", "IdStatus", kehadiran.IdStatus);
            return View(kehadiran);
        }

        // GET: Kehadirans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kehadiran = await _context.Kehadirans
                .Include(k => k.IdEmpNavigation)
                .Include(k => k.IdStatusNavigation)
                .FirstOrDefaultAsync(m => m.IdKehadiran == id);
            if (kehadiran == null)
            {
                return NotFound();
            }

            return View(kehadiran);
        }

        // POST: Kehadirans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kehadiran = await _context.Kehadirans.FindAsync(id);
            _context.Kehadirans.Remove(kehadiran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KehadiranExists(int id)
        {
            return _context.Kehadirans.Any(e => e.IdKehadiran == id);
        }
    }
}
