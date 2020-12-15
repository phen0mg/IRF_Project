using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project2
{
    public partial class Form1 : Form
    {
        AdatokEntities context = new AdatokEntities();
        List<Table_1> adatok;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            adatok = context.Table_1.ToList();
        }
    }
}
