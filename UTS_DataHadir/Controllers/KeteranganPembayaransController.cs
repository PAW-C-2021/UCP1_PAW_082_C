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
    public class KeteranganPembayaransController : Controller
    {
        private readonly DataHadirContext _context;

        public KeteranganPembayaransController(DataHadirContext context)
        {
            _context = context;
        }

        // GET: KeteranganPembayarans
        public async Task<IActionResult> Index()
        {
            return View(await _context.KeteranganPembayarans.ToListAsync());
        }

        // GET: KeteranganPembayarans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keteranganPembayaran = await _context.KeteranganPembayarans
                .FirstOrDefaultAsync(m => m.IdKetBayar == id);
            if (keteranganPembayaran == null)
            {
                return NotFound();
            }

            return View(keteranganPembayaran);
        }

        // GET: KeteranganPembayarans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KeteranganPembayarans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKetBayar,KetBayar")] KeteranganPembayaran keteranganPembayaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keteranganPembayaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keteranganPembayaran);
        }

        // GET: KeteranganPembayarans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keteranganPembayaran = await _context.KeteranganPembayarans.FindAsync(id);
            if (keteranganPembayaran == null)
            {
                return NotFound();
            }
            return View(keteranganPembayaran);
        }

        // POST: KeteranganPembayarans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKetBayar,KetBayar")] KeteranganPembayaran keteranganPembayaran)
        {
            if (id != keteranganPembayaran.IdKetBayar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keteranganPembayaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeteranganPembayaranExists(keteranganPembayaran.IdKetBayar))
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
            return View(keteranganPembayaran);
        }

        // GET: KeteranganPembayarans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keteranganPembayaran = await _context.KeteranganPembayarans
                .FirstOrDefaultAsync(m => m.IdKetBayar == id);
            if (keteranganPembayaran == null)
            {
                return NotFound();
            }

            return View(keteranganPembayaran);
        }

        // POST: KeteranganPembayarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keteranganPembayaran = await _context.KeteranganPembayarans.FindAsync(id);
            _context.KeteranganPembayarans.Remove(keteranganPembayaran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeteranganPembayaranExists(int id)
        {
            return _context.KeteranganPembayarans.Any(e => e.IdKetBayar == id);
        }
    }
}
