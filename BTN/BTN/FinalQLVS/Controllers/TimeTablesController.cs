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
    public class TimeTablesController : Controller
    {
        private readonly FinalQLVSContext _context;

        public TimeTablesController(FinalQLVSContext context)
        {
            _context = context;
        }

        // GET: TimeTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeTable.ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {
            return View(await _context.TimeTable.ToListAsync());
        }
        public async Task<IActionResult> Index3()
        {
            return View(await _context.TimeTable.ToListAsync());
        }
        // GET: TimeTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTable = await _context.TimeTable
                .FirstOrDefaultAsync(m => m.TimeTableId == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }

        // GET: TimeTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeTableId,CourseName,LectureName,Room,StartTime,EndTime,DayOfWeek")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeTable);
        }

        // GET: TimeTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTable = await _context.TimeTable.FindAsync(id);
            if (timeTable == null)
            {
                return NotFound();
            }
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeTableId,CourseName,LectureName,Room,StartTime,EndTime,DayOfWeek")] TimeTable timeTable)
        {
            if (id != timeTable.TimeTableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeTableExists(timeTable.TimeTableId))
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
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTable = await _context.TimeTable
                .FirstOrDefaultAsync(m => m.TimeTableId == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeTable = await _context.TimeTable.FindAsync(id);
            if (timeTable != null)
            {
                _context.TimeTable.Remove(timeTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeTableExists(int id)
        {
            return _context.TimeTable.Any(e => e.TimeTableId == id);
        }
        public async Task<IActionResult> Search(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return RedirectToAction(nameof(Index));
            }

            var timeTables = await _context.TimeTable
                .Where(s => EF.Functions.Like(s.CourseName, $"%{searchString}%") ||
                EF.Functions.Like(s.LectureName, $"%{searchString}%") ||
                EF.Functions.Like(s.Room, $"%{searchString}%"))
                .ToListAsync();
            return View("Index", timeTables);
        }
    }
}
