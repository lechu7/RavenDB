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
        DodawanieUczen du;
        DodawaniePrzedmiot dp;
        DodajOcene doc;

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
                du = new DodawanieUczen();
                du.Show();
            }
            if (trybIndex == 1)
            {
                dp = new DodawaniePrzedmiot();
                dp.Show();
            }
            if (trybIndex == 2)
            {
                doc = new DodajOcene();
                doc.Show();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex ==3)
                {
                    du = new DodawanieUczen();
                    du.button1.Text = "Edytuj";
                    du.Text = "Edytuj ucznia";
                    du.textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    du.textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    du.ID= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    du.Show();
                    this.Hide();
                }
                if (e.ColumnIndex == 4)
                {
                    DialogResult dialogResult = MessageBox.Show("Czy chcesz usunąć "+ dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() +" "+ dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()+"?", "Potwierdzenie", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Librarycs.UsunStudent(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        uzupelnianieListyUczniowie();
                    }
                   
                }
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    dp = new DodawaniePrzedmiot();
                    dp.button1.Text = "Edytuj";
                    dp.Text = "Edytuj Przedmiot";
                    dp.textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    dp.textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                    dp.textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    dp.ID= dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    dp.Show();
                    this.Hide();
                }
                if (e.ColumnIndex == 5)
                {
                    DialogResult dialogResult = MessageBox.Show("Czy chcesz usunąć " + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString()+"?", "Potwierdzenie", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Librarycs.UsunPrzedmiot(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                        uzupelnianieListyPrzedmioty();
                    }

                }
            }
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 7)
                {
                    doc = new DodajOcene();
                    doc.button1.Text = "Edytuj";
                    doc.Text = "Edytuj Ocenę";
                    doc.textBox1.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
                    doc.ID = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                    doc.Show();
                    this.Hide();
                }
                if (e.ColumnIndex == 8)
                {
                    DialogResult dialogResult = MessageBox.Show("Czy chcesz usunąć ocenę " + dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString()+" z przedmiotu " + dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString() +" ucznia " + dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString() +" " + dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString() + "?", "Potwierdzenie", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Librarycs.UsunOceny(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                        uzupelnianieListyOceny();
                    }

                }
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

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
