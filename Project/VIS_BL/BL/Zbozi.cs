using System.Collections.Generic;
using VIS_BL.DB;

namespace VIS_BL.BL
{
    public class Zbozi
    {
        public int Idz { get; set; }
        public string Nazev { get; set; }
        public string Kratky_popis { get; set; }
        public string Dlouhy_popis { get; set; }
        public int Sklad { get; set; }
        public int Cena { get; set; }
        public int KategorieID { get; set; }

        public void Vytvor(List<object> attributes)
        {


            Idz = (int)attributes[0];
            Nazev = attributes[1].ToString();
            Kratky_popis = attributes[2].ToString();
            Dlouhy_popis = attributes[3].ToString();
            Sklad = (int)attributes[4];
            Cena = (int)attributes[5];
            KategorieID = (int)attributes[6];


        }


        public void Vytvor(int id)
        {
            List<object> attributes = ZboziGateway.SelectID(id);

            Idz = (int)attributes[0];
            Nazev = attributes[1].ToString();
            Kratky_popis = attributes[2].ToString();
            Dlouhy_popis = attributes[3].ToString();
            Sklad = (int)attributes[4];
            Cena = (int)attributes[5];
            KategorieID = (int)attributes[6];
        }


    }

}
