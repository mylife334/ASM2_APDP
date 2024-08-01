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
    public class NoticeClassesController : Controller
    {
        private readonly FinalQLVSContext _context;

        public NoticeClassesController(FinalQLVSContext context)
        {
            _context = context;
        }

        // GET: NoticeClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.NoticeClass.ToListAsync());
        }

        // GET: NoticeClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticeClass = await _context.NoticeClass
                .FirstOrDefaultAsync(m => m.NoticeCId == id);
            if (noticeClass == null)
            {
                return NotFound();
            }

            return View(noticeClass);
        }

        // GET: NoticeClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NoticeClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoticeCId,ClassName,Title,Content,PostedDate")] NoticeClass noticeClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticeClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticeClass);
        }

        // GET: NoticeClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticeClass = await _context.NoticeClass.FindAsync(id);
            if (noticeClass == null)
            {
                return NotFound();
            }
            return View(noticeClass);
        }

        // POST: NoticeClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoticeCId,ClassName,Title,Content,PostedDate")] NoticeClass noticeClass)
        {
            if (id != noticeClass.NoticeCId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticeClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticeClassExists(noticeClass.NoticeCId))
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
            return View(noticeClass);
        }

        // GET: NoticeClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticeClass = await _context.NoticeClass
                .FirstOrDefaultAsync(m => m.NoticeCId == id);
            if (noticeClass == null)
            {
                return NotFound();
            }

            return View(noticeClass);
        }

        // POST: NoticeClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticeClass = await _context.NoticeClass.FindAsync(id);
            if (noticeClass != null)
            {
                _context.NoticeClass.Remove(noticeClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeClassExists(int id)
        {
            return _context.NoticeClass.Any(e => e.NoticeCId == id);
        }
    }
}
