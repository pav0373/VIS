using System.Collections.Generic;

namespace VIS_BL.BL
{
    public class KosikPolozka
    {
        public int ZakaznikID { get; set; }
        public int ZboziID { get; set; }
        public int Pocet { get; set; }


        public void Vytvor(List<object> attributes)
        {


            ZakaznikID = (int)attributes[0];
            ZboziID = (int)attributes[1];
            Pocet = (int)attributes[2];



        }



    }
}
