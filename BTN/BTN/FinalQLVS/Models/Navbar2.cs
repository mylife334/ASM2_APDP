using Microsoft.AspNetCore.Mvc;

namespace FinalQLVS.Models
{
    public class Navbar2 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
