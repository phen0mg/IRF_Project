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
                p.Gender = item.Gender;
                jatekosok.Add(p);
            }
            dataGridView1.DataSource = jatekosok;

            label1.Text = jatekosok[k].Name;
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
                label1.Text = jatekosok[k].Name;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (k < jatekosok.Count-1)
            {
                k++;
                label1.Text = jatekosok[k].Name;
            }
        }
    }

}
