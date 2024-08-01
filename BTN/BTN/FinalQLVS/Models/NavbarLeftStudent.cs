using Microsoft.AspNetCore.Mvc;

namespace FinalQLVS.Models
{
    public class NavbarLeftStudent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
