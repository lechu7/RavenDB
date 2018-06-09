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
        public DodawaniePrzedmiot()
        {
            InitializeComponent();
        }
        Form1 f = new Form1(); //= Form1.getInstance();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != ""&&textBox3.Text!="")
            {
                Librarycs.Przedmiot tmp = new Librarycs.Przedmiot();
                tmp.ImieProwadzącego = textBox1.Text;
                tmp.NazwiskoProwadzącego = textBox2.Text;
                tmp.NazwaPrzedmiotu = textBox3.Text;
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
