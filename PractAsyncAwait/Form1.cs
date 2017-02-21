using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PractAsyncAwait
{
    public partial class Form1 : Form
    {
        Stopwatch Clock = new Stopwatch();
        List<Class1> items = new List<Class1>();
        public Form1()
        {
            InitializeComponent();
            carregaPais();
        }
        private void carregaPais()
        {
            items = Class1.LeerJsonPropiedades();

            var llistaPais = new List<string>();
            var NoRepes = new List<string>();
            foreach (var c in items)
            {
                llistaPais.Add(c.country);
            }
            llistaPais = llistaPais.Distinct().ToList();

            comboBox3.DataSource = llistaPais;
        }
        private async Task<List<string>> Paralelo(string country)
        {
            List<string> lista = new List<string>();
            var nombre = "";
            var apellido = "";
            var email = "";

            var infoTotal = "";
            Clock.Restart();
            items = Class1.LeerJsonPropiedades();
            Parallel.ForEach(items, item =>
            {
                if (item.country.Equals(country))
                {
                    if (comboBox4.Equals("female") && item.gander.Equals("female"))
                    {

                        nombre = item.Name;
                        apellido = item.Surname;
                        email = item.email;
                        infoTotal = nombre + ", " + apellido + ", " + email;
                        lista.Add(infoTotal);
                    }
                    else if (comboBox4.Equals("male") && item.gander.Equals("male"))
                    {
                        nombre = item.Name;
                        apellido = item.Surname;
                        email = item.email;
                        infoTotal = nombre + ", " + apellido + ", " + email;
                        lista.Add(infoTotal);
                    }
                    else
                    {
                        nombre = item.Name;
                        apellido = item.Surname;
                        email = item.email;
                        infoTotal = nombre + ", " + apellido + ", " + email;
                        lista.Add(infoTotal);
                    }
                }
            });
            Clock.Stop();
            lblTiempo.Text = Clock.Elapsed.TotalMilliseconds.ToString();
            return lista;
        }
        private async Task<List<string>> Sequencial(string country)
        {
            List<string> lista = new List<string>();
            var nombre = "";
            var apellido = "";
            var email = "";

            var infoTotal = "";
            Clock.Restart();
            items = Class1.LeerJsonPropiedades();
            foreach (var item in items)
            {
                if (item.country.Equals(country))
                {
                    if (comboBox4.Equals("female") && item.gander.Equals("female"))
                    {

                        nombre = item.Name;
                        apellido = item.Surname;
                        email = item.email;
                        infoTotal = nombre + ", " + apellido + ", " + email;
                        lista.Add(infoTotal);
                    }
                    else if (comboBox4.Equals("male") && item.gander.Equals("male")) {
                      
                    nombre = item.Name;
                    apellido = item.Surname;
                    email = item.email;
                    infoTotal = nombre + ", " + apellido + ", " + email;
                    lista.Add(infoTotal);
                    }else
                    {
                        nombre = item.Name;
                        apellido = item.Surname;
                        email = item.email;
                        infoTotal = nombre + ", " + apellido + ", " + email;
                        lista.Add(infoTotal);
                    }
                }
            }
            Clock.Stop();
            lblTiempo.Text = Clock.Elapsed.TotalMilliseconds.ToString();
            return lista;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string pais = comboBox3.SelectedItem.ToString();
            var llista = await Paralelo(pais);
            listBox2.DataSource = llista;
        }

        private async  void button4_Click(object sender, EventArgs e)
        {
            string pais = comboBox3.SelectedItem.ToString();
            var llista = await Sequencial(pais);
            listBox2.DataSource = llista;
        }
    }
}
