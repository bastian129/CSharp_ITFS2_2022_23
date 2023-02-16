using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ITFS2_2022_23
{
    internal class Übung_Methoden
    {
        public static void Start()
        {
            //a = 97
            //z = 122
            int i = 'z';
            while(true)
            Console.WriteLine(Meth(Console.ReadLine(), Convert.ToInt32(Console.ReadLine())));
        }
        static string Meth(string s, int input)
        {
            if (s.Length <= input)
                return s;

            for(int i = 97; i <= 122; i++)
            {
                char c = (char)i;
                while(true)
                {
                    if (!s.ToLower().Contains(c))
                        break;
                    s = s.Remove(s.ToLower().IndexOf(c), 1);
                    if (s.Length <= input)
                        return s;

                }
            }
            return s;
        }
    }
}
