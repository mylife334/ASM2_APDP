using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalQLVS.Data;
using FinalQLVS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace FinalQLVS.Controllers
{
    public class Login_pageController : Controller
    {
        private readonly FinalQLVSContext _context;
        public Login_pageController(FinalQLVSContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model, string? ReturnUrl)
        {
            var staff = _context.Staff.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
            var student = _context.Student.FirstOrDefault(s => s.Email == model.Email && s.Password == model.Password);
            var leacture = _context.Lecture.FirstOrDefault(s => s.Email == model.Email && s.Password == model.Password);


            if (staff != null)
            {
                // Xử lý đăng nhập thành công cho staff
                return RedirectToAction("AdminDashboard");
            }
            else if (student != null)
            {
                // Xử lý đăng nhập thành công cho student

                // Redirect đến action của SubjectCoursesController để hiển thị thông tin chỉ điểm của Student
                return RedirectToAction("StudentDashboard");
            }
            else if (leacture != null)
            {
                // Xử lý đăng nhập thành công cho student
                return RedirectToAction("LeactureDashboard");
            }
            else
            {
                // Xử lý đăng nhập thất bại
                ViewBag.Message = "Invalid username or password";
                return View("Index");
            }
        }

        public IActionResult AdminDashboard()
        {
            // Trang điều khiển dành cho staff
            return View();
        }

        public IActionResult StudentDashboard()
        {
            // Trang điều khiển dành cho student
            return View();
        }
        public IActionResult LeactureDashboard()
        {
            // Trang điều khiển dành cho student
            return View();
        }  
        
    }
}
