using Microsoft.AspNetCore.Mvc;
using VIS_BL.BL;

namespace VIS_web.Controllers
{
    public class KomentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int user, int zbozi , string predmet, string txt)
        {
            Komentar k = new Komentar();

            k.ZakaznikID = user;
            k.ZboziID = zbozi;
            k.Predmet = predmet;
            k.Text = txt;

            bool result=k.Vlozit();
            if (!result)
            {
                ViewData["Result"] = "Formular nebyl vyplnen korektne";
            }
            else
            {
                ViewData["Result"] = "Komentar uspesne vlozen";
            }
            return View();
        }
    }
}