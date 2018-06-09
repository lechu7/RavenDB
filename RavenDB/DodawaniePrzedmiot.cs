using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenDB
{
    public partial class DodawaniePrzedmiot : Form
    {
        Form1 f = new Form1();
        public string ID = "";

        public DodawaniePrzedmiot()
        {
            InitializeComponent();
  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != ""&&textBox3.Text!="")
            {
                Librarycs.Przedmiot tmp;
                if (button1.Text == "Edytuj")
                {
                    tmp= Librarycs.WczytajPrzedmiot(ID);
                    tmp.ImieProwadzącego = textBox1.Text;
                    tmp.NazwiskoProwadzącego = textBox2.Text;
                    tmp.NazwaPrzedmiotu = textBox3.Text;
                }
                else
                {
                    tmp = new Librarycs.Przedmiot();
                    tmp.ImieProwadzącego = textBox1.Text;
                    tmp.NazwiskoProwadzącego = textBox2.Text;
                    tmp.NazwaPrzedmiotu = textBox3.Text;
                }
                Librarycs.ZapiszPrzedmiot(tmp);

              
                this.Hide();
                f.uzupelnianieListyPrzedmioty();
                f.tryb1();
                f.Show();
            }
            else
            {
                MessageBox.Show("Podaj wszystkie potrzebne dane!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f.tryb1();
            f.Show();
        }
    }
}
