using System.Collections.Generic;
using VIS_BL.DB;

namespace VIS_BL.BL
{
    public class Kategorie
    {
        public int Idk { get; set; }
        public string Nazev { get; set; }
        public string Popis { get; set; }


        public void Vytvor(int id)
        {


            List<object> attributes = KategorieGateway.Select(id);

            Idk = id;
            Nazev = attributes[1].ToString();
            Popis = attributes[2].ToString();



        }
    }
}
