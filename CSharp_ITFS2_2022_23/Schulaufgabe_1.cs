using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ITFS2_2022_23
{
    internal class Schulaufgabe_1
    {
        public static List<string> CorrectData(List<string> stringList)
        {
            List<string> returnList = new List<string>();
            foreach(var element in stringList)
            {
                Console.WriteLine("Wert:" + element);
                Console.WriteLine("Ist dieser Wert okay?");
                string input = Console.ReadLine();
                if (input == string.Empty)
                    returnList.Add(element);
                else
                    returnList.Add(input);
                Console.Clear();
            }
            return returnList;
        }
    }
}
