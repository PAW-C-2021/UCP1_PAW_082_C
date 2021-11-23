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
    public class StatushadirsController : Controller
    {
        private readonly DataHadirContext _context;

        public StatushadirsController(DataHadirContext context)
        {
            _context = context;
        }

        // GET: Statushadirs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Statushadirs.ToListAsync());
        }

        // GET: Statushadirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statushadir = await _context.Statushadirs
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statushadir == null)
            {
                return NotFound();
            }

            return View(statushadir);
        }

        // GET: Statushadirs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Statushadirs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatus,Keterangan")] Statushadir statushadir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statushadir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statushadir);
        }

        // GET: Statushadirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statushadir = await _context.Statushadirs.FindAsync(id);
            if (statushadir == null)
            {
                return NotFound();
            }
            return View(statushadir);
        }

        // POST: Statushadirs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatus,Keterangan")] Statushadir statushadir)
        {
            if (id != statushadir.IdStatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statushadir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatushadirExists(statushadir.IdStatus))
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
            return View(statushadir);
        }

        // GET: Statushadirs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statushadir = await _context.Statushadirs
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statushadir == null)
            {
                return NotFound();
            }

            return View(statushadir);
        }

        // POST: Statushadirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statushadir = await _context.Statushadirs.FindAsync(id);
            _context.Statushadirs.Remove(statushadir);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatushadirExists(int id)
        {
            return _context.Statushadirs.Any(e => e.IdStatus == id);
        }
    }
}
