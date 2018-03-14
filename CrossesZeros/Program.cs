using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossesZeros
{
    class Program
    {
        public static string[] visual = new string[3] { " ", "x", "o" };
        public static string[] namex = new string[3] { "ничьей", "крестиков", "ноликов" };
        public static string[] name = new string[2] { "Крестики", "Нолики" };
        public static int[] matrix = new int[9] { 0,0,0,0,0,0,0,0,0 };
        public static int _hod = 1;
        public static bool _game = true;
        public static int _winner = 0;



        public static void setHod()
        {
            if (_hod == 1) _hod = 2;
            else _hod = 1;
        }

        public static bool checkMatrix()
        {
            int summ = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] != 0)
                    summ++;
            if (summ == 9)
                return false;
            return true;
        }

        public static void checkGame()
        {
            if (matrix[0] == matrix[1] && matrix[1] == matrix[2] && matrix[0]!=0)
            {
                _winner = matrix[0];
                _game = false;
            }
            else if (matrix[3] == matrix[4] && matrix[4] == matrix[5] && matrix[3] != 0)
            {
                _winner = matrix[3];
                _game = false;
            }
            else if (matrix[6] == matrix[7] && matrix[7] == matrix[8] && matrix[6] != 0) {
                _winner = matrix[6];
                _game = false;
            }
            else if (matrix[0] == matrix[3] && matrix[3] == matrix[6] && matrix[0] != 0)
            {
                _winner = matrix[0];
                _game = false;
            }
            else if (matrix[1] == matrix[4] && matrix[4] == matrix[7] && matrix[1] != 0)
            {
                _winner = matrix[1];
                _game = false;
            }
            else if (matrix[2] == matrix[5] && matrix[5] == matrix[8] && matrix[2] != 0)
            {
                _winner = matrix[2];
                _game = false;
            }

            else if (matrix[6] == matrix[4] && matrix[4] == matrix[2] && matrix[6] != 0)
            {
                _winner = matrix[6];
                _game = false;
            }
            else if (matrix[0] == matrix[4] && matrix[4] == matrix[8] && matrix[0] != 0)
            {
                _winner = matrix[0];
                _game = false;
            }
            else if(checkMatrix() == false)
            {
                _winner = 0;
                _game = false;
            }
        }

                            public static string setPosition(int pos)
                            {
                                if (matrix[pos] == 0)
                                {
                                    matrix[pos] = _hod;
                                    checkGame();
                                    setHod();
                                    return "Следующий ход: " + name[_hod - 1];
                                } else
                                {
                                    return "";
                                }
                            }

                            public static int toPos(ConsoleKey cki)
                            {
                                if (cki == ConsoleKey.NumPad1)
                                    return 0;
                                else if (cki == ConsoleKey.NumPad2)
                                    return 1;
                                else if (cki == ConsoleKey.NumPad3)
                                    return 2;
                                else if (cki == ConsoleKey.NumPad4)
                                    return 3;
                                else if (cki == ConsoleKey.NumPad5)
                                    return 4;
                                else if (cki == ConsoleKey.NumPad6)
                                    return 5;
                                else if (cki == ConsoleKey.NumPad7)
                                    return 6;
                                else if (cki == ConsoleKey.NumPad8)
                                    return 7;
                                else if (cki == ConsoleKey.NumPad9)
                                    return 8;
                                return 9;
                            }

                            static int catchKey()
                            {
                                ConsoleKey cki;
                                do
                                {
                                    cki = Console.ReadKey().Key;
                                } while (toPos(cki) == 9);
                                return toPos(cki);
                            }

        static void Main(string[] args)
        {
            do
            {
                matrix = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                _hod = 1;
                _game = true;
                _winner = 0;
                string qq = "";
                while (_game)
                {

                    Console.Clear();
                    Console.WriteLine("{0}\n", qq);
                    Console.WriteLine("{0}█{1}█{2}", visual[matrix[6]], visual[matrix[7]], visual[matrix[8]]);
                    Console.WriteLine("▀▀▀▀▀");
                    Console.WriteLine("{0}█{1}█{2}", visual[matrix[3]], visual[matrix[4]], visual[matrix[5]]);
                    Console.WriteLine("▀▀▀▀▀");
                    Console.WriteLine("{0}█{1}█{2}", visual[matrix[0]], visual[matrix[1]], visual[matrix[2]]);
                    int pos = 9;
                    do
                    {
                        pos = catchKey();
                    } while ((qq = setPosition(pos)) == "");
                }
                Console.Clear();
                Console.WriteLine("{0}\n", qq);
                Console.WriteLine("{0}█{1}█{2}", visual[matrix[6]], visual[matrix[7]], visual[matrix[8]]);
                Console.WriteLine("▀▀▀▀▀");
                Console.WriteLine("{0}█{1}█{2}", visual[matrix[3]], visual[matrix[4]], visual[matrix[5]]);
                Console.WriteLine("▀▀▀▀▀");
                Console.WriteLine("{0}█{1}█{2}", visual[matrix[0]], visual[matrix[1]], visual[matrix[2]]);

                Console.WriteLine("\nМатч завершён в пользу: {0}\n\nВведите quit для выхода", namex[_winner]);
            } while (Console.ReadLine().ToLower() != "quit");
        }
    }
}
