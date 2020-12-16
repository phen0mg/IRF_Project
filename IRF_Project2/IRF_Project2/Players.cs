using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project2
{
    class Players
    {
        public string Name { get; set; }
        public int Age { get; set; }
        private string _category;

        public string Streamer
        {
            get { return _category; }
            set
            {
                if (value=="True")
                {
                    _category = "streamer";
                }
                else
                {
                    _category = "pro player";
                }
            }
        }

        public string Nationality { get; set; }
        private Nem _gender;
        public Nem Gender
        {
            get { return _gender; }
            set
            {
                if (value == Nem.Male)
                {
                    _gender = Nem.Male;
                }
                else
                {
                    _gender = Nem.Female;
                }
            }
        }

    }
}
