using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalQLVS.Data;
using FinalQLVS.Models;

namespace FinalQLVS.Controllers
{
    public class NoticeLecturesController : Controller
    {
        private readonly FinalQLVSContext _context;

        public NoticeLecturesController(FinalQLVSContext context)
        {
            _context = context;
        }

        // GET: NoticeLectures
        public async Task<IActionResult> Index()
        {
            return View(await _context.NoticeLecture.ToListAsync());
        }

        // GET: NoticeLectures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticeLecture = await _context.NoticeLecture
                .FirstOrDefaultAsync(m => m.NoticeLId == id);
            if (noticeLecture == null)
            {
                return NotFound();
            }

            return View(noticeLecture);
        }

        // GET: NoticeLectures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NoticeLectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoticeLId,LectureCode,Title,Content,PostedDate")] NoticeLecture noticeLecture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticeLecture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticeLecture);
        }

        // GET: NoticeLectures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticeLecture = await _context.NoticeLecture.FindAsync(id);
            if (noticeLecture == null)
            {
                return NotFound();
            }
            return View(noticeLecture);
        }

        // POST: NoticeLectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoticeLId,LectureCode,Title,Content,PostedDate")] NoticeLecture noticeLecture)
        {
            if (id != noticeLecture.NoticeLId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticeLecture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticeLectureExists(noticeLecture.NoticeLId))
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
            return View(noticeLecture);
        }

        // GET: NoticeLectures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticeLecture = await _context.NoticeLecture
                .FirstOrDefaultAsync(m => m.NoticeLId == id);
            if (noticeLecture == null)
            {
                return NotFound();
            }

            return View(noticeLecture);
        }

        // POST: NoticeLectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticeLecture = await _context.NoticeLecture.FindAsync(id);
            if (noticeLecture != null)
            {
                _context.NoticeLecture.Remove(noticeLecture);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeLectureExists(int id)
        {
            return _context.NoticeLecture.Any(e => e.NoticeLId == id);
        }
    }
}
