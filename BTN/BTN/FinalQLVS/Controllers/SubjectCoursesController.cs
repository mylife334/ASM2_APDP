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
    public class SubjectCoursesController : Controller
    {
        private readonly FinalQLVSContext _context;

        public SubjectCoursesController(FinalQLVSContext context)
        {
            _context = context;
        }

        // GET: SubjectCourses
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubjectCourse.ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {
            return View(await _context.SubjectCourse.ToListAsync());
        }
        public async Task<IActionResult> Index3()
        {
            return View(await _context.SubjectCourse.ToListAsync());
        }

        // GET: SubjectCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectCourse = await _context.SubjectCourse
                .FirstOrDefaultAsync(m => m.SubjectCourseId == id);
            if (subjectCourse == null)
            {
                return NotFound();
            }

            return View(subjectCourse);
        }

        // GET: SubjectCourses/Create
        public IActionResult Create()
        {
            ViewData["Category"] = new SelectList(_context.Set<Course>(), "Category", "Category");
            ViewData["CourseName"] = new SelectList(_context.Set<Course>(), "CourseName", "CourseName");
            ViewData["StudentCode"] = new SelectList(_context.Set<Student>(), "StudentCode", "StudentCode");
            ViewData["LectureCode"] = new SelectList(_context.Set<Lecture>(), "LectureCode", "LectureCode");

            return View();
        }

        // POST: SubjectCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectCourseId,Category,CourseName,NameStudent,lecturer,point,Status")] SubjectCourse subjectCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category"] = new SelectList(_context.Course, "Category", "Category", subjectCourse.Category);
            ViewData["CourseName"] = new SelectList(_context.Course, "CourseName", "CourseName", subjectCourse.CourseName);
            ViewData["StudentCode"] = new SelectList(_context.Student, "StudentCode", "StudentCode", subjectCourse.NameStudent);
            ViewData["LectureCode"] = new SelectList(_context.Set<Lecture>(), "LectureCode", "LectureCode" , subjectCourse.lecturer);

            return View(subjectCourse);
        }

        // GET: SubjectCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectCourse = await _context.SubjectCourse.FindAsync(id);
            if (subjectCourse == null)
            {
                return NotFound();
            }
            ViewData["Category"] = new SelectList(_context.Course, "Category", "Category", subjectCourse.Category);
            ViewData["CourseName"] = new SelectList(_context.Course, "CourseName", "CourseName", subjectCourse.CourseName);
            ViewData["StudentCode"] = new SelectList(_context.Student, "StudentCode", "StudentCode", subjectCourse.NameStudent);
            ViewData["LectureCode"] = new SelectList(_context.Set<Lecture>(), "LectureCode", "LectureCode", subjectCourse.lecturer);
            return View(subjectCourse);
        }

        // POST: SubjectCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectCourseId,Category,CourseName,NameStudent,lecturer,point,Status")] SubjectCourse subjectCourse)
        {
            if (id != subjectCourse.SubjectCourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectCourseExists(subjectCourse.SubjectCourseId))
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
            return View(subjectCourse);
        }

        // GET: SubjectCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectCourse = await _context.SubjectCourse
                .FirstOrDefaultAsync(m => m.SubjectCourseId == id);
            if (subjectCourse == null)
            {
                return NotFound();
            }

            return View(subjectCourse);
        }

        // POST: SubjectCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subjectCourse = await _context.SubjectCourse.FindAsync(id);
            if (subjectCourse != null)
            {
                _context.SubjectCourse.Remove(subjectCourse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectCourseExists(int id)
        {
            return _context.SubjectCourse.Any(e => e.SubjectCourseId == id);
        }
        public async Task<IActionResult> Search(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return RedirectToAction(nameof(Index));
            }

            var SubjectCourse = await _context.SubjectCourse
                .Where(s => EF.Functions.Like(s.Category, $"%{searchString}%") ||
                            EF.Functions.Like(s.CourseName, $"%{searchString}%") ||
                            EF.Functions.Like(s.NameStudent, $"%{searchString}%") ||
                            EF.Functions.Like(s.lecturer, $"%{searchString}%"))
                .ToListAsync();

            return View("Index", SubjectCourse);
        }
    }
}
