using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using VIS_BL.BL;
using VIS_BL.DB;

namespace VIS_desktop
{
    public partial class Form4 : Form
    {
        List<KosikPolozka> polozky;
        private int index = 0;
        public Form4(int id)
        {
            InitializeComponent();
            Collection<List<object>> kosiky;
            kosiky = KosikGateway.Select(id);
            polozky = new List<KosikPolozka>();

            foreach(List<object> e in kosiky)
            {
                KosikPolozka polozka = new KosikPolozka();
                polozka.Vytvor(e);
                polozky.Add(polozka);
            }

            if (polozky.Count == 0)
            {
                label1.Text = "Zadne zbozi v kosiku";
                label2.Hide();
                label3.Hide();
                button1.Hide();
                button2.Hide();
            }
            else
            {
                SetText();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index >0)
            {
                --index;
                SetText();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (index < polozky.Count-1)
            {
                ++index;
                SetText();

            }

        }


        public void SetText()
        {


            label1.Text = "ID zakaznika: " + polozky.ElementAt(index).ZakaznikID.ToString();
            label2.Text = "ID zbozi: " + polozky.ElementAt(index).ZboziID.ToString();
            label3.Text = "Pocet kusu: " + polozky.ElementAt(index).Pocet.ToString();
           
        }


    }
}
