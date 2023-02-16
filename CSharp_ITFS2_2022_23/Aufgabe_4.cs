using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ITFS2_2022_23
{
    class Aufgabe_4
    {
        static List<string> stringList = new List<string>();
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("Bitte einen String eingeben:");
                stringList.Add(Console.ReadLine());
                Console.WriteLine("Wollen Sie einen weiteren String eingeben? (y = JA, ich will)");
                if (Console.ReadLine().ToLower() != "y")
                {
                    break;
                }
            }

            int sum = 0;
            foreach(var element in stringList)
            {
                if(int.TryParse(element, out int value))
                {
                    sum += value;
                    Console.WriteLine("Eingabe: {0} - Wert: {1}", element, value);
                }
                else
                {
                    sum += element.Length;
                    Console.WriteLine("Eingabe: {0} - Wert: {1}", element, element.Length);
                }
            }

            Console.WriteLine("Gesamtsumme: " + sum);

        }
    }
}
