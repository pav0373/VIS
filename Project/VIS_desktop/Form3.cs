using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VIS_BL.BL;
using VIS_BL.DB;



namespace VIS_desktop
{
    public partial class Form3 : Form
    {
        List<Zakaznik> zakaznici;
        List<Objednavka> objednavky;
        private int index = 0;
        private int max;
        private bool boo;
        public Form3(bool zakaznik)
        {
            InitializeComponent();
            boo = zakaznik;
            if (boo)
            {
                zakaznici = new List<Zakaznik>();

                foreach (List<object> attributes in ZakaznikGateway.Select())
                {
                    Zakaznik polozka = new Zakaznik();
                    polozka.Vytvor(attributes);
                    zakaznici.Add(polozka);
                }



                if (zakaznici.Count == 0)
                {
                    label1.Text = "Zadny zakaznik";
                    label2.Hide();
                    label3.Hide();
                    label4.Hide();
                    label5.Hide();
                    label6.Hide();
                    label7.Hide();
                    label8.Hide();
                    label9.Hide();
                    label10.Hide();
                    button1.Hide();
                    button2.Hide();
                }
                else
                {
                    max = zakaznici.Count;
                    SetText();
                }
            }
            else
            {
                objednavky = new List<Objednavka>();

                foreach (List<object> attributes in ObjednavkaGateway.SelectAll())
                {
                    Objednavka polozka = new Objednavka();
                    polozka.Vytvor(attributes);
                    objednavky.Add(polozka);
                }

                if(objednavky.Count==0)
                {
                    label1.Text = "Zadna objednavka";
                    label2.Hide();
                    label3.Hide();
                    label4.Hide();
                    label5.Hide();
                    label6.Hide();
                    label7.Hide();
                    label8.Hide();
                    label9.Hide();
                    label10.Hide();
                    button1.Hide();
                    button2.Hide();
                }
                else
                {
                    max = objednavky.Count;
                    SetText();
                }

            }

        }


        public void SetText()
        {
            if(boo)
            { 

                label1.Text = "ID zakaznika: " + zakaznici.ElementAt(index).Idu.ToString();
                label2.Text = "Login zakaznika: " + zakaznici.ElementAt(index).Login;
                label3.Text = "Email zakaznika: " + zakaznici.ElementAt(index).Email;
                label4.Text = "Heslo zakaznika: " + zakaznici.ElementAt(index).Heslo;
                label5.Text = "Krestni zakaznika: " + zakaznici.ElementAt(index).Krestni;
                label6.Text = "Prijmeni zakaznika: " + zakaznici.ElementAt(index).Prijmeni;
                label7.Text = "Ulice zakaznika: " + zakaznici.ElementAt(index).Ulice;
                label8.Text = "Mesto zakaznika: " + zakaznici.ElementAt(index).Mesto;
                label9.Text = "Psc " + zakaznici.ElementAt(index).Psc;
                label10.Text = "Tel " + zakaznici.ElementAt(index).Tel;
            }
            else
            {
                label1.Text = "ID objednavky: " + objednavky.ElementAt(index).Ido.ToString();
                label2.Text = "Datum objednavky: " + objednavky.ElementAt(index).Datum.ToString();
                label3.Text = "ID zakaznika: " + objednavky.ElementAt(index).ZakaznikID.ToString();
                label4.Hide();
                label5.Hide();
                label6.Hide();
                label7.Hide();
                label8.Hide();
                label9.Hide();
                label10.Hide();
                button1.Hide();
                button2.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                --index;
                SetText();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index < max-1)
            {
                ++index;
                SetText();
            }
        }
    }
}
