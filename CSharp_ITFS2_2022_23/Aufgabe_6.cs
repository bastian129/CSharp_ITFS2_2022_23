using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ITFS2_2022_23
{
    internal class Aufgabe_6
    {
        enum Countries { Deutschland, Schweiz, Österreich, Legoland, Gauland}
        static List<Countries> CountryList = new List<Countries>();

        public static void Start()
        {
            while(true)
                AddCountryToList(userInput());
        }

        static Countries userInput()
        {
            while (true)
            {
                Console.WriteLine("Bitte geben Sie ein Land ein:");
                string userinput = Console.ReadLine();
                //Ausgabe der Liste
                if(userinput == string.Empty)
                {
                    ShowList();
                    continue;
                }
                foreach (Countries element in Enum.GetValues(typeof(Countries)))
                {
                    if (userinput.ToUpper() == element.ToString().ToUpper())
                        return element;
                }
                Console.WriteLine("Leider war die Eingabe nicht in Ordnung :(");
            }
        }
        static void AddCountryToList(Countries country)
        {
            for(int i = 0; i < CountryList.Count; i++)
            {
                if (CountryList[i] == country)
                {
                    Console.WriteLine("Soll das Land gelöscht werden? (y = JA)");
                    if (Console.ReadLine() == "y")
                        CountryList.RemoveAt(i);
                    return;
                }
            }
            CountryList.Add(country);

        }
        static void ShowList()
        {
            Console.WriteLine("Hier sind Ihre Länder:");
            for(int i = 1; i < CountryList.Count + 1; i++)
            {
                Console.WriteLine(i + ".) " + CountryList[i-1]);
            }

            //oder
            //int i = 1;
            //foreach(var element in CountryList)
            //{
            //  Console.WriteLine(i + ".) " + element);
            //  i++;
            //}
        }
    }
}
