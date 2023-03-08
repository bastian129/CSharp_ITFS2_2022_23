using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ITFS2_2022_23
{
    internal class Schiffe_versenken
    {
        static int[,] GameField = new int[10, 10];
        static string lastMessage = string.Empty;
        static int AmountShips = 0;
        static int NumberOfShots = 0;
        static int ShotShips = 0;

        public static void Start()
        {
            SetShips();
            while (true)
            {
                ShowField();
                Fire(UserInput());
                if (GameEnds())
                    break;
            }
        }

        static void ShowField()
        {
            Console.Clear();
            Console.WriteLine("Schüsse gesamt: {0}  -  Schüsse getroffen: {1}  -  Gesamte Ziele: {2}", NumberOfShots, ShotShips, AmountShips);
            Console.WriteLine(lastMessage + "\n");
            int ch = 65;
            int numbers = 0;
            Console.Write("     ");
            while (numbers < GameField.GetLength(1))
            {
                numbers++;
                if(numbers < 10)
                    Console.Write(numbers + "  ");
                else
                    Console.Write(numbers + " ");
            }
            Console.WriteLine();
            Console.Write("     ");
            while(numbers > 0)
            {
                numbers--;
                    Console.Write("|  ");
            }
            Console.WriteLine();

            for(int i = 0; i < GameField.GetLength(0); i++)
            {
                int t = (ch - 65) / 26;
                if(t == 0)
                    Console.Write(" " + (char)ch);
                else while(t >= 0)
                    {
                        Console.Write((char)(ch - 26));
                        t--;
                    }
                Console.Write(" - ");
                ch++;
                for(int k = 0; k < GameField.GetLength(1); k++)
                {
                    Console.Write(GameField[i, k] == 0 ? "O" : GameField[i, k] == 1 ? "O" : GameField[i, k] == 2 ? "$" : "X");
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
        }
        static Tuple<int,int> UserInput()
        {
            //Vorsicht! Die Eingabe wird nicht auf Validität geprüft!!!!
            string tempChar = string.Empty;
            string tempNumbers = string.Empty;
            string input = Console.ReadLine() ?? "";
            foreach(var element in input)
            {
                if (!int.TryParse(element.ToString(), out _))
                    tempChar += element;
                else
                    tempNumbers += element;
            }
            //Buchstabe zu Koordinate
            int ch = ((int)tempChar[0]) - 65;
            ch += (tempChar.Length - 1) * 26;
            //Zahl zur Koordinate
            int num = Convert.ToInt32(tempNumbers);

            return new Tuple<int, int>(ch, num - 1);
        }
        static void SetShips()
        {
            SetShip(1);
            SetShip(2);
            SetShip(3);
            SetShip(4);
            SetShip(5);
        }
        static Random rand = new Random();
        static void SetShip(int länge)
        {
            AmountShips += länge;
            while (true)
            {
                bool conflict = false;
                int dir = rand.Next() % 2;
                if (dir == 0) //Waagrecht
                {
                    int x = rand.Next() % (GameField.GetLength(0) - (länge - 1));
                    int y = rand.Next() % GameField.GetLength(1);

                    //Prüfung, ob schon ein Schiff vorhanden
                    int run = 0;
                    while (run < länge)
                    {
                        if (GameField[x + run, y] != 0)
                        {
                            conflict = true;
                            break;
                        }
                        run++;
                    }
                    if (conflict)
                        continue;
                    //Schiff setzen
                    run = 0;
                    while (run < länge)
                    {
                        GameField[x + run, y] = 1;
                        run++;
                    }
                    return;
                }
                else //Senkrecht
                {
                    int x = rand.Next() % GameField.GetLength(0);
                    int y = rand.Next() % (GameField.GetLength(1) - (länge - 1));

                    //Prüfung, ob schon ein Schiff vorhanden
                    int run = 0;
                    while (run < länge)
                    {
                        if (GameField[x, y + run] != 0)
                        {
                            conflict = true;
                            break;
                        }
                        run++;
                    }
                    if (conflict)
                        continue;
                    //Schiff setzen
                    run = 0;
                    while (run < länge)
                    {
                        GameField[x, y +run] = 1;
                        run++;
                    }
                    return;
                }
            }
        }

        static void Fire(Tuple<int,int> Koordinate)
        {
            NumberOfShots++;

            //Wasser getroffen
            if (GameField[Koordinate.Item1, Koordinate.Item2] == 0)
            {
                GameField[Koordinate.Item1, Koordinate.Item2] = 2;
                lastMessage = "Nichts getroffen :(";
            }
            //Schiff getroffen
            else if(GameField[Koordinate.Item1, Koordinate.Item2] == 1)
            {
                GameField[Koordinate.Item1, Koordinate.Item2] = 3;
                lastMessage = "Schiff getroffen!";
                ShotShips++;
            }
        }
        static bool GameEnds()
        {
            if(ShotShips >= AmountShips)
            {
                Console.Clear();
                Console.WriteLine("Das Spiel ist beendet! Die feindliche Flotte wurde elemeniniert!");
                Console.WriteLine("Ihre Statistik:");
                Console.WriteLine("Schüsse gesamt: {0}  -  Schüsse getroffen: {1}  -  Gesamte Ziele: {2}", NumberOfShots, ShotShips, AmountShips);
                Console.WriteLine("Statistik: {0} %", ((double)ShotShips / (double)NumberOfShots) * 100);

                return true;
            }

            return false;
        }
    }
}
