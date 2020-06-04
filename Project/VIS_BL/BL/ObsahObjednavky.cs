using System.Collections.Generic;
using VIS_BL.DB;

namespace VIS_BL.BL
{
    public class ObsahObjednavky
    {
        public int ZboziID { get; set; }
        public int ObjednavkaID { get; set; }
        public int Pocet { get; set; }

        public void Vytvor(int idz,int ido, int pocet)
        {


            ZboziID = idz;
            ObjednavkaID = ido;
            Pocet = pocet;



        }

        public void Vlozit()
        {
            List<object> polozka = new List<object>();

            polozka.Add(ZboziID);
            polozka.Add(ObjednavkaID);
            polozka.Add(Pocet);

            ObsahGateway.Insert(polozka);
        }

    }
}
