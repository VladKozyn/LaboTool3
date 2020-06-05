using System;
using System.Collections.Generic;
using System.Text;

namespace LaboTool_3.Model
{
    public class Straat
    {
        public string straatNaam { get; set; }
        public double lengteStraat { get; set; }


        public Straat(string straatNaam, double lengteStraat)
        {
            this.straatNaam = straatNaam;
            this.lengteStraat = lengteStraat;
        }
    }
}
