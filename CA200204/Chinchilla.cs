using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200204
{
    class Chinchilla
    {
        public string Nev { get; set; }
        public DateTime SzuletesNap { get; set; }
        public int Suly { get; set; }
        public bool Simi { get; set; }

        public int Kor => (int)(DateTime.Now - this.SzuletesNap).TotalDays / 365; 

        public Chinchilla(string s)
        {
            var t = s.Split(';');
            Nev = t[0];
            SzuletesNap = DateTime.Parse(t[1]);
            Suly = int.Parse(t[2]);
            Simi = (t[3] == "I");
        }
    }
}
