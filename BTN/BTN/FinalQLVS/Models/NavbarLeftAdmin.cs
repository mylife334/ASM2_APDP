using Microsoft.AspNetCore.Mvc;

namespace FinalQLVS.Models
{
    public class NavbarLeftAdmin : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
