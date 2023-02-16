using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ITFS2_2022_23
{
    internal class Aufgabe_5
    {
        public static void Start()
        {
            List<string> elementList = new List<string>();

            string input = "123  +     45 * 12 / 34 - 127";
            string temp = string.Empty;
            foreach(var element in input)
            {
                if (element == ' ')
                    continue;
                if(int.TryParse(element.ToString(), out _))
                {
                    temp += element;
                }
                else
                {
                    elementList.Add(temp);
                    temp = string.Empty;
                    elementList.Add(element.ToString());
                }
            }
            elementList.Add(temp);

            if (elementList[1] == "+")
                Console.WriteLine(AddNumbers(elementList[0], elementList[2]));

        }

        public static string AddNumbers(string num1, string num2)
        {
            return (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString();
        }
    }
}
