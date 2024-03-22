using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalapacsvetess
{
    internal class Sportolo
    {
        public int helyezes { get; set; }
        public double eredmeny { get; set; }
        public string sportolo { get; set; }
        public string orszagkod { get; set; }
        public string helyszin { get; set; }
        public DateOnly datum { get; set; }
        public Sportolo(string s)
        {
            string[] v = s.Split(";");
            helyezes = int.Parse(v[0]);
            eredmeny = double.Parse(v[1]);
            sportolo= v[2];
            orszagkod = v[3];
            helyszin = v[4];
            datum = DateOnly.Parse(v[5]);
        }
        public override string ToString()
        {
            return $"Helyezés:{helyezes}, Eredmény:{eredmeny}, Sportoló:{sportolo},Ország kódja:{orszagkod},Helyszín:{helyszin},Dátum:{datum}";
        }
    }
}
