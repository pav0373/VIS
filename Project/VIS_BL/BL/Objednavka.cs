using System;
using System.Collections.Generic;
using System.Linq;
using VIS_BL.DB;

namespace VIS_BL.BL
{
    public class Objednavka
    {
        public int Ido { get; set; }
        public DateTime Datum { get; set; }
        public int ZakaznikID { get; set; }


        public void Vytvor(List<object> attributes)
        {
            Ido = (int)attributes[0];
            Datum = (DateTime)attributes[1];
            ZakaznikID = (int)attributes[2];

        }

        public void Vlozit()
        {
            List<object> objednavka = new List<object>();

            objednavka.Add(Ido);
            objednavka.Add(Datum);
            objednavka.Add(ZakaznikID);

            ObjednavkaGateway.Insert(objednavka);
        }


        public void VytvorObjednavku(int zakaznikID)
        {
            Datum = DateTime.Now;
            ZakaznikID = zakaznikID;


            if (ObjednavkaGateway.SelectAll().Count == 0)
            {
                Ido = 1;
            }
            else
            {
                Ido = (int)ObjednavkaGateway.SelectAll().Last()[0] + 1;
            }

            Vlozit();

            foreach (List<object> attributes in KosikGateway.Select(zakaznikID))
            {
                KosikPolozka polozka = new KosikPolozka();
                polozka.Vytvor(attributes);

                ObsahObjednavky obsah = new ObsahObjednavky();
                obsah.Vytvor(polozka.ZboziID, Ido, polozka.Pocet);


                obsah.Vlozit();
               

            }

            KosikGateway.Delete(ZakaznikID);

        }




    }
}
