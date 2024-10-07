using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmaEtterem
{
    class Desszert
    {
        public string Nev { get; set; }
        public string Tipus { get; set; }
        public bool Dijazott { get; set; }
        public int Ar {  get; set; }
        public string Egyseg { get; set; }

        public Desszert(string s)
        {
            var d = s.Split(';');
            Nev = d[0];
            Tipus = d[1];

                if (d[2] == "false")
                {
                    Dijazott = false;
                }
                else
                {
                    Dijazott= true;
                }

            Ar = Convert.ToInt32(d[3]);
            Egyseg = d[4];
        }
    }
}
