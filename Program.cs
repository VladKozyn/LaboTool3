using System;
using System.Collections.Generic;

namespace LaboTool_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Databeheer databeheer = new Databeheer(@"Data Source =.\SQLEXPRESS; Initial Catalog = Labo; Integrated Security = True");

            //Als gebruiker wil ik een lijst van straatIDs kunnen opvragen voor een opgegeven gemeentenaam.
            #region
            
            string gemeenteNaam = "";
            Console.WriteLine("schijf aub één gemeentenaam");
            gemeenteNaam = Console.ReadLine();
            List<int> lstStraten = databeheer.vraagStraatIdsGebasseerdOpGemeente(gemeenteNaam);
            if (lstStraten == null)
            {
                Console.WriteLine("Ongeldige gemeente naam");
            }
            else
            {
                foreach (int straten in lstStraten)
                {
                    Console.WriteLine(straten + "\n");
                }
            }
            
            #endregion
            //Als gebruiker wil ik een straat kunnen opvragen op basis van een meegegeven straatID.

            #region
            /* 
             string straatId = "";
             Console.WriteLine("schijf aub één straatID aub");
             straatId = Console.ReadLine();


             Console.WriteLine(databeheer.vraagStraatOpBasisVanStraatId(int.Parse(straatId)));

             */
            #endregion

            //Als gebruiker wil ik een straat kunnen opvragen op basis van de straatnaam en de gemeentenaam.

            #region
            /*
            string straatNaam = "";
            string gemeenteNaam = "";

            Console.WriteLine("schijf aub één gemeenteNaam aub");
            gemeenteNaam = Console.ReadLine();
            Console.WriteLine("schijf aub één straatNaam aub");
            straatNaam = Console.ReadLine();

            string prnt = databeheer.vraagStraatOpBasisVanStraatNaamEnGemeenteNaam(straatNaam, gemeenteNaam);
            Console.WriteLine(prnt);
            */
            #endregion

            //Als gebuiker wil ik alle straatnamen van een gemeente kunnen opvragen(alfabetisch gesorteerd).
            #region
            /*
            string gemeenteNaam = "";
            Console.WriteLine("schijf aub één gemeentenaam");
            gemeenteNaam = Console.ReadLine();
            List<string> lstStraten = databeheer.vraagStraatNaamGebasseerdOpGemeente(gemeenteNaam);
            if (lstStraten == null)
            {
                Console.WriteLine("Ongeldige gemeente naam");
            }
            else
            {
                foreach (string straten in lstStraten)
                {
                    Console.WriteLine(straten + "\n");
                }
            }*/
            #endregion
           

        }
    }
}
