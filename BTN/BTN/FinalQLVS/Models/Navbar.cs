using Microsoft.AspNetCore.Mvc;

namespace QLSV.Models
{
    public class Navbar: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
