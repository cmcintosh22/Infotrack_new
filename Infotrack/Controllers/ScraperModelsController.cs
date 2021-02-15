using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Infotrack.Data;
using Infotrack.Models;

namespace Infotrack.Controllers
{
    public class ScraperModelsController : Controller
    {
        private readonly ScraperContext _context;

        public ScraperModelsController(ScraperContext context)
        {
            _context = context;
        }

        // GET: ScraperModels
        public async Task<IActionResult> Index(string sortOrder)
        {
            
            return View(await _context.ScraperData.ToListAsync());
        }

        // GET: ScraperModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scraperModel = await _context.ScraperData
                .FirstOrDefaultAsync(m => m.ID == id);
            if (scraperModel == null)
            {
                return NotFound();
            }

            return View(scraperModel);
        }

        // GET: ScraperModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScraperModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,input,position,paid_ads,date")] ScraperModel scraperModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scraperModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scraperModel);
        }

        // GET: ScraperModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scraperModel = await _context.ScraperData.FindAsync(id);
            if (scraperModel == null)
            {
                return NotFound();
            }
            return View(scraperModel);
        }

        // POST: ScraperModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,input,position,paid_ads,date")] ScraperModel scraperModel)
        {
            if (id != scraperModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scraperModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScraperModelExists(scraperModel.ID))
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
            return View(scraperModel);
        }

        // GET: ScraperModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scraperModel = await _context.ScraperData
                .FirstOrDefaultAsync(m => m.ID == id);
            if (scraperModel == null)
            {
                return NotFound();
            }

            return View(scraperModel);
        }

        // POST: ScraperModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scraperModel = await _context.ScraperData.FindAsync(id);
            _context.ScraperData.Remove(scraperModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScraperModelExists(int id)
        {
            return _context.ScraperData.Any(e => e.ID == id);
        }
    }
}
