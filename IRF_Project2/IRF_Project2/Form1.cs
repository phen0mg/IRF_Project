using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project2
{
    public partial class Form1 : Form
    {
        AdatokEntities context = new AdatokEntities();
        List<Table_1> adatok = new List<Table_1>();
        List<Players> jatekosok = new List<Players>();
        List<Players> hobbi = new List<Players>();
        int k = 0;
        public Form1()
        {
            InitializeComponent();
            adatok = context.Table_1.ToList();
            LoadData();
        }

        private void LoadData()
        {
            
            foreach (var item in adatok)
            {
                Players p = new Players();
                p.Name = item.Name;
                p.Age = item.Age;
                p.Streamer = item.Streamer.ToString();
                p.Nationality = item.Nationality;
                p.Gender = (Nem)item.Gender;
                jatekosok.Add(p);
            }
            comboBox1.DataSource = (from x in jatekosok select x.Streamer).Distinct().ToList();
            label1.Text = hobbi[k].Name;
            label5.Text = hobbi[k].Age.ToString();
            label6.Text = hobbi[k].Nationality;
            label7.Text = hobbi[k].Gender.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("players.csv");
           
                foreach (Players item in jatekosok)
                {
                    sw.Write(item.Name);
                    sw.Write(";");
                    sw.Write(item.Age);
                    sw.Write(";");
                    sw.Write(item.Streamer);
                    sw.Write(";");
                    sw.Write(item.Nationality);
                    sw.Write(";");
                    sw.Write(item.Gender);
                    sw.WriteLine();
                }
                sw.Close();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (k>0)
            {
                k--;
                label1.Text = hobbi[k].Name;
                label5.Text = hobbi[k].Age.ToString();
                label6.Text = hobbi[k].Nationality;
                label7.Text = hobbi[k].Gender.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (k < hobbi.Count-1)
            {
                k++;
                label1.Text = hobbi[k].Name;
                label5.Text = hobbi[k].Age.ToString();
                label6.Text = hobbi[k].Nationality;
                label7.Text = hobbi[k].Gender.ToString();
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            k = 0;
            hobbi = (List<Players>)(from x in jatekosok where x.Streamer == (string)comboBox1.SelectedItem select x).ToList();
        }
    }

}
