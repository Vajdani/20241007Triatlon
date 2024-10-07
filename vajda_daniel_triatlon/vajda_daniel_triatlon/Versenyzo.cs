using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vajda_daniel_triatlon
{
    internal class Versenyzo
    {
        public string Nev { get; set; }
        public int SzuletesiEv { get; set; }
        public int Rajtszam { get; set; }
        public bool Nem { get; set; }
        public string Kategoria { get; set; }

        public TimeSpan UszasIdo { get; set; }
        public TimeSpan Depo1Ido { get; set; }
        public TimeSpan KerekparIdo { get; set; }
        public TimeSpan Depo2Ido { get; set; }
        public TimeSpan FutasIdo { get; set; }

        public Versenyzo(string line)
        {
            string[] split = line.Split(';');
            Nev = split[0];
            SzuletesiEv = int.Parse(split[1]);
            Rajtszam = int.Parse(split[2]);
            Nem = split[3] == "f";
            Kategoria = split[4];

            UszasIdo = TimeSpan.Parse(split[5]);
            Depo1Ido = TimeSpan.Parse(split[6]);
            KerekparIdo = TimeSpan.Parse(split[7]);
            Depo2Ido = TimeSpan.Parse(split[8]);
            FutasIdo = TimeSpan.Parse(split[9]);
        }

        public override string ToString()
        {
            return $"{Nev} (Született: {SzuletesiEv}; Rajtszám: {Rajtszam}; Kategória: {Kategoria})";
        }
    }
}
