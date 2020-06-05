using System;
using System.Collections.Generic;
using System.Text;

namespace LaboTool_3.Model
{
    public class Gemeente
    {
    public    string gemeenteNaam { get; set; }
        public int totaalAantalStraten { get; set; }

        private List<Straat> lstStraten;
    public Gemeente(string gemeenteNaam, int totaalAantalStraten)
        {
            this.gemeenteNaam = gemeenteNaam;
            this.totaalAantalStraten = totaalAantalStraten;
             List<Straat> lstStraten = new List<Straat>();
            this.lstStraten = lstStraten;
        }
        public void voegStraatToe(Straat straat)
        {
            this.lstStraten.Add(straat);
        }
    }
}
