using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ITFS2_2022_23
{
    internal class Aufgabe_8
    {
        public static void Start()
        {
            Analyze(22.23);
            
        }

        static void Analyze(string s)
        {
            Console.WriteLine("Hierbei handelt es sich um einen String. Die Länge ist " + s.Length);
        }
        static void Analyze(int i)
        {
            Console.WriteLine("Hierbei handelt es sich um einen Integer. Die Anzahl der Stellen ist " + i.ToString().Length);

        }
        static void Analyze(char c)
        {
            Console.WriteLine("Hierbei handelt es sich um einen Character. Die dezimale Darstellung ist "+ (int)c);

        }
        static void Analyze(double d)
        {
            if(!d.ToString().Contains(','))
            {
                Console.WriteLine("Hierbei handelt es sich um einen Double ohne Nachkommastellen.");
                return;
            }
            var temp = d.ToString().Substring(d.ToString().IndexOf(",") + 1);
            Console.WriteLine("Hierbei handelt es sich um einen Double mit {0} Nachkommastellen.", temp.Length);

        }
    }
}
