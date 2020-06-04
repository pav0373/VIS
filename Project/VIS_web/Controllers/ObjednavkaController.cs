using Microsoft.AspNetCore.Mvc;
using VIS_BL.BL;

namespace VIS_web.Controllers
{
    public class ObjednavkaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(int user)
        {
            Objednavka o = new Objednavka();

            o.VytvorObjednavku(user);
            return View();
        }
    }
}