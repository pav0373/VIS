using System.Windows.Forms;
using VIS_BL.BL;

namespace VIS_desktop
{
    public partial class Form2 : Form
    {
        public Form2(int idk)
        {
            InitializeComponent();

            Kategorie kat = new Kategorie();
            kat.Vytvor(idk);

            label1.Text = "ID kategorie: " + idk;
            label2.Text = "Nazev kategorie: " + kat.Nazev;
            label3.Text = "Popis kategorie: " + kat.Popis;
        }


    }
}
