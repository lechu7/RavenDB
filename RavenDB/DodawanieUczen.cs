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
    public partial class DodawanieUczen : Form
    {
        Form1 f = new Form1();
        public string ID = "";

        public DodawanieUczen()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" && textBox2.Text!="")
            {
                Librarycs.Student tmp;
                if (button1.Text == "Edytuj")
                {
                     tmp = Librarycs.WczytajStudent(ID);
                    tmp.Imie = textBox1.Text;
                    tmp.Nazwisko = textBox2.Text;
                }
                else
                {
                    tmp = new Librarycs.Student();
                    tmp.Imie = textBox1.Text;
                    tmp.Nazwisko = textBox2.Text;
                }
                Librarycs.ZapiszStudent(tmp);

                this.Hide();
                f.uzupelnianieListyUczniowie();
                f.tryb0();
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
            f.Show();
            f.tryb0();
        }
    }
}
