using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaidBugTracker.Data;
using RaidBugTracker.Models;

namespace RaidBugTracker.Controllers
{
    public class BugPageController : Controller
    {
        private readonly RaidContext _context;

        public BugPageController(RaidContext context)
        {
            _context = context;
        }

        // GET: BugPage
        public async Task<IActionResult> Index()
        {
            return View(await _context.BugPage.ToListAsync());
        }

        // GET: BugPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugPage = await _context.BugPage
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bugPage == null)
            {
                return NotFound();
            }

            return View(bugPage);
        }

        // GET: BugPage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BugPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Status,Priority")] BugPage bugPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bugPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bugPage);
        }

        // GET: BugPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugPage = await _context.BugPage.FindAsync(id);
            if (bugPage == null)
            {
                return NotFound();
            }
            return View(bugPage);
        }

        // POST: BugPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Status,Priority")] BugPage bugPage)
        {
            if (id != bugPage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bugPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugPageExists(bugPage.ID))
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
            return View(bugPage);
        }

        // GET: BugPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugPage = await _context.BugPage
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bugPage == null)
            {
                return NotFound();
            }

            return View(bugPage);
        }

        // POST: BugPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bugPage = await _context.BugPage.FindAsync(id);
            _context.BugPage.Remove(bugPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BugPageExists(int id)
        {
            return _context.BugPage.Any(e => e.ID == id);
        }
    }
}
