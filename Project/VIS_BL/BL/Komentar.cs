using System.Collections.Generic;
using VIS_BL.DB;

namespace VIS_BL.BL
{
    public class Komentar
    {
        public int Idc { get; set; }
        public string Predmet { get; set; }
        public string Text { get; set; }
        public int ZakaznikID { get; set; }
        public int ZboziID { get; set; }



        public void Vytvor(List<object> attributes)
        {


            Idc = (int)attributes[0];
            Predmet = attributes[1].ToString();
            Text = attributes[2].ToString();
            ZakaznikID = (int)attributes[3];
            ZboziID = (int)attributes[4];


        }


        public void Vytvor(int id)
        {
            List<object> attributes = KomentarGateway.SelectID(id);

            Idc = id;
            Predmet = attributes[1].ToString();
            Text = attributes[2].ToString();
            ZakaznikID = (int)attributes[3];
            ZboziID = (int)attributes[4];

        }


        public bool Vlozit()
        {
            List<object> komentar = new List<object>();

            Idc = 0;

            komentar.Add(Idc);
            komentar.Add(Predmet); 
            komentar.Add(Text); 
            komentar.Add(ZakaznikID); 
            komentar.Add(ZboziID); 

            KomentarGateway.Insert(komentar);
            return true;

        }

    }
}
