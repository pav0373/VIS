using Microsoft.AspNetCore.Mvc;
using VIS_BL.BL;

namespace VIS_web.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string login,string email, string heslo, string krestni, string prijmeni, string ulice, string mesto, string psc, string tel)
        {
            Zakaznik z = new Zakaznik();
            z.Login = login;
            z.Email = email;
            z.Heslo = heslo;
            z.Krestni = krestni;
            z.Prijmeni = prijmeni;
            z.Ulice = ulice;
            z.Mesto = mesto;
            z.Psc = psc;
            z.Tel = tel;
            bool result= z.Registrace();
            

            if(!result)
            {
                ViewData["Result"] = "Formular nebyl vyplnen korektne";
            }
            else
            {
                ViewData["Result"] = "Registrace uspesna";
            }

            return View();
        }

    }
}