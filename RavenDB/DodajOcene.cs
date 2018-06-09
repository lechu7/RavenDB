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
    public partial class DodajOcene : Form
    {
        Form1 f = new Form1();

        List<Librarycs.Student> tmpListStudent = new List<Librarycs.Student>();
        List<Librarycs.Przedmiot> tmpListPrzedmiot = new List<Librarycs.Przedmiot>();
        public string ID="";

        public DodajOcene()
        {
            InitializeComponent();
            uzupelnienieSelectUczen();
            uzupelnienieSelectPrzedmiot();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            if (button1.Text=="Edytuj")
            {
               Librarycs.Oceny tmp= Librarycs.WczytajOceny(ID);
               textBox1.Text = tmp.Ocena.ToString();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

                if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
                {
                    Librarycs.Oceny tmp = new Librarycs.Oceny();
                    try
                    {
                        tmp.Ocena = Convert.ToInt32(textBox1.Text);
                        if (tmp.Ocena < 1 || tmp.Ocena > 6)
                        {
                            throw new Exception();
                        }
                        tmp.Imie = tmpListStudent[comboBox2.SelectedIndex].Imie;
                        tmp.Nazwisko = tmpListStudent[comboBox2.SelectedIndex].Nazwisko;

                        tmp.NazwaPrzedmiotu = tmpListPrzedmiot[comboBox1.SelectedIndex].NazwaPrzedmiotu;
                        tmp.ImieProwadzącego = tmpListPrzedmiot[comboBox1.SelectedIndex].ImieProwadzącego;
                        tmp.NazwiskoProwadzącego = tmpListPrzedmiot[comboBox1.SelectedIndex].NazwiskoProwadzącego;
                        Librarycs.ZapiszOceny(tmp);

                        f.uzupelnianieListyOceny();
                        this.Hide();
                        f.tryb2();
                        f.Show();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Źle wpisana ocena!");
                    }

                }
                else
                {
                    MessageBox.Show("Podaj wszystkie potrzebne dane!");
                }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f.tryb2();
            f.Show();
        }




        public void uzupelnienieSelectUczen()
        {
            tmpListStudent = Librarycs.ListaStudent() ;
            for (int i = 0; i < tmpListStudent.Count(); i++)
            {
                comboBox2.Items.Add(tmpListStudent[i].Imie + " " + tmpListStudent[i].Nazwisko);
            }
            
        }
        public void uzupelnienieSelectPrzedmiot()
        {
            tmpListPrzedmiot = Librarycs.ListaPrzedmiot();
            for (int i = 0; i < tmpListPrzedmiot.Count(); i++)
            {
                comboBox1.Items.Add(tmpListPrzedmiot[i].NazwaPrzedmiotu+" - "+ tmpListPrzedmiot[i].ImieProwadzącego+" "+ tmpListPrzedmiot[i].NazwiskoProwadzącego);
            }
        }

    }
}
