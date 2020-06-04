using System;
using System.Windows.Forms;

namespace VIS_desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        //Vyber kategorie
        private void button1_Click(object sender, EventArgs e)
        {

            int id =  Int32.Parse(textBox1.Text);
            using (Form2 kategorieForm = new Form2(id))
            {
                this.Hide();
                if (kategorieForm.ShowDialog() == DialogResult.OK)
                {

                }
                this.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Form3 detailForm = new Form3(true))
            {
                this.Hide();
                if (detailForm.ShowDialog() == DialogResult.OK)
                {

                }
                this.Show();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Form3 detailForm = new Form3(false))
            {
                this.Hide();
                if (detailForm.ShowDialog() == DialogResult.OK)
                {

                }
                this.Show();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox2.Text);
            using (Form4 kosikForm = new Form4(id))
            {
                this.Hide();
                if (kosikForm.ShowDialog() == DialogResult.OK)
                {

                }
                this.Show();

            }
        }
    }
}
