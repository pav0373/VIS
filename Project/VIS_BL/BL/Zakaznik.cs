using System.Collections.Generic;
using VIS_BL.DB;

namespace VIS_BL.BL
{
    public class Zakaznik
    {
        public int Idu { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Heslo { get; set; }
        public string Krestni { get; set; }
        public string Prijmeni { get; set; }
        public string Ulice { get; set; }
        public string Mesto { get; set; }
        public string Psc { get; set; }
        public string Tel { get; set; }


    
        public void Vytvor(List<object> attributes)
        {


            Idu = (int)attributes[0];
            Login = attributes[1].ToString();
            Email = attributes[2].ToString();
            Heslo = attributes[3].ToString();
            Krestni = attributes[4].ToString();
            Prijmeni = attributes[5].ToString();
            Ulice = attributes[6].ToString();
            Mesto = attributes[7].ToString();
            Psc = attributes[8].ToString();
            Tel = attributes[9].ToString();


        }


        public void Vytvor(int id)
        {
            List<object> attributes = ZakaznikGateway.Select(id);


            Idu = id;
            Login = attributes[1].ToString();
            Email = attributes[2].ToString();
            Heslo = attributes[3].ToString();
            Krestni = attributes[4].ToString();
            Prijmeni = attributes[5].ToString();
            Ulice = attributes[6].ToString();
            Mesto = attributes[7].ToString();
            Psc = attributes[8].ToString();
            Tel = attributes[9].ToString();

        }


        public bool Registrace()
        {
            List<object> zakaznik = new List<object>();

          

            Idu = 0;
            zakaznik.Add(Idu);
            zakaznik.Add(Login);
            zakaznik.Add(Email);
            zakaznik.Add(Heslo);
            zakaznik.Add(Krestni);
            zakaznik.Add(Prijmeni);
            zakaznik.Add(Ulice);
            zakaznik.Add(Mesto);
            zakaznik.Add(Psc);
            zakaznik.Add(Tel);


            ZakaznikGateway.Insert(zakaznik);

            return true;
           
        }


    }



   
}


