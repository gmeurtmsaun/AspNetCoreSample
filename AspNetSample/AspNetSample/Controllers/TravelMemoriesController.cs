using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetSample.Data;
using AspNetSample.Models;

namespace AspNetSample.Controllers
{
    public class TravelMemoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelMemoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TravelMemories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TravelMemories.Include(t => t.TravelDestination);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TravelMemories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelMemory = await _context.TravelMemories
                .Include(t => t.TravelDestination)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelMemory == null)
            {
                return NotFound();
            }

            return View(travelMemory);
        }

        // GET: TravelMemories/Create
        public IActionResult Create()
        {
            ViewData["TravelDestinationId"] = new SelectList(_context.TravelDestinations, "Id", "Id");
            return View();
        }

        // POST: TravelMemories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Comment,TravelDestinationId")] TravelMemory travelMemory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelMemory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TravelDestinationId"] = new SelectList(_context.TravelDestinations, "Id", "Id", travelMemory.TravelDestinationId);
            return View(travelMemory);
        }

        // GET: TravelMemories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelMemory = await _context.TravelMemories.FindAsync(id);
            if (travelMemory == null)
            {
                return NotFound();
            }
            ViewData["TravelDestinationId"] = new SelectList(_context.TravelDestinations, "Id", "Id", travelMemory.TravelDestinationId);
            return View(travelMemory);
        }

        // POST: TravelMemories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,Comment,TravelDestinationId")] TravelMemory travelMemory)
        {
            if (id != travelMemory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelMemory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelMemoryExists(travelMemory.Id))
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
            ViewData["TravelDestinationId"] = new SelectList(_context.TravelDestinations, "Id", "Id", travelMemory.TravelDestinationId);
            return View(travelMemory);
        }

        // GET: TravelMemories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelMemory = await _context.TravelMemories
                .Include(t => t.TravelDestination)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelMemory == null)
            {
                return NotFound();
            }

            return View(travelMemory);
        }

        // POST: TravelMemories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelMemory = await _context.TravelMemories.FindAsync(id);
            _context.TravelMemories.Remove(travelMemory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelMemoryExists(int id)
        {
            return _context.TravelMemories.Any(e => e.Id == id);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyTravelDate(DateTime StartDate, DateTime EndDate)
        {
            if (StartDate > EndDate)
            {
                return Json($"帰宅日は出発日より後にしてください");
            }

            return Json(true);
        }

    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyComment(DateTime StartDate, DateTime EndTime, string Comment, int Id)
    {
        var memory = _context.TravelMemories.FirstOrDefault(t => t.StartDate == StartDate && t.EndDate == EndTime && t.Id != Id);
        if(memory != null)
        {
            return Json($"このコメントはすでに存在します。");
        }      

        return Json(true);
    }
    }
}
