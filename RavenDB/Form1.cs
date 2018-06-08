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
    
    public partial class Form1 : Form
    {
        public int trybIndex = 0;
        public Form1()
        {
            InitializeComponent();

            uzupelnianieListyUczniowie();
            uzupelnianieListyPrzedmioty();
            uzupelnianieListyOceny();

            object sender= new object();
            EventArgs e= new EventArgs();
            switch (trybIndex)
            {
                case 0:
                    tryb0();
                    break;
                case 1:
                    tryb1();
                    break;
                case 2:
                    tryb2();
                    break;
                default:
                    break;
            }
            this.Location=new Point(200,100);
            
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tryb0();
        }
        public void tryb0()
        {
            uzupelnianieListyUczniowie();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            this.Width = 590;
            trybIndex = 0;

            uzupelnianieListyUczniowie();
            uzupelnianieListyPrzedmioty();
            uzupelnianieListyOceny();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tryb1();
        }
        public void tryb1()
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            this.Width = 740;
            trybIndex = 1;

            uzupelnianieListyUczniowie();
            uzupelnianieListyPrzedmioty();
            uzupelnianieListyOceny();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tryb2();
        }
        public void tryb2()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            this.Width = 1090;
            trybIndex = 2;

            uzupelnianieListyUczniowie();
            uzupelnianieListyPrzedmioty();
            uzupelnianieListyOceny();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (trybIndex==0)
            {
                DodawanieUczen du = new DodawanieUczen();
                du.Show();
            }
            if (trybIndex == 1)
            {
                DodawaniePrzedmiot dp = new DodawaniePrzedmiot();
                dp.Show();
            }
            if (trybIndex == 2)
            {
                DodajOcene doc = new DodajOcene();
                doc.Show();
            }
        }


        public void uzupelnianieListyUczniowie()
        {
            dataGridView1.Rows.Clear();
            List<Librarycs.Student> tmpList= Librarycs.ListaStudent();
            for (int i = 0; i < tmpList.Count; i++)
            {
                dataGridView1.Rows.Add(tmpList[i].Id, tmpList[i].Imie, tmpList[i].Nazwisko,"Edytuj","Usuń");
                dataGridView1.Rows[i].Cells[3].Style.BackColor= Color.Green;
                dataGridView1.Rows[i].Cells[4].Style.BackColor = Color.Red;
            }
        }
        public void uzupelnianieListyPrzedmioty()
        {
            dataGridView2.Rows.Clear();
            List<Librarycs.Przedmiot> tmpList = Librarycs.ListaPrzedmiot();
            for (int i = 0; i < tmpList.Count; i++)
            {
                dataGridView2.Rows.Add(tmpList[i].Id, tmpList[i].NazwaPrzedmiotu, tmpList[i].ImieProwadzącego, tmpList[i].NazwiskoProwadzącego, "Edytuj", "Usuń");
                dataGridView2.Rows[i].Cells[4].Style.BackColor = Color.Green;
                dataGridView2.Rows[i].Cells[5].Style.BackColor = Color.Red;
            }
        }
        public void uzupelnianieListyOceny()
        {
            dataGridView3.Rows.Clear();
            List<Librarycs.Oceny> tmpList = Librarycs.ListaOceny();
            for (int i = 0; i < tmpList.Count; i++)
            {
                dataGridView3.Rows.Add(tmpList[i].Id, tmpList[i].NazwaPrzedmiotu, tmpList[i].Imie, tmpList[i].Nazwisko, tmpList[i].Ocena,tmpList[i].ImieProwadzącego, tmpList[i].NazwiskoProwadzącego, "Edytuj", "Usuń");
                dataGridView3.Rows[i].Cells[7].Style.BackColor = Color.Green;
                dataGridView3.Rows[i].Cells[8].Style.BackColor = Color.Red;
            }
        }
    }
}
