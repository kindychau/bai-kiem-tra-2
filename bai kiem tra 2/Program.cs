using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Final
{
    internal class Program
    {
        private static int x = 0;
        private static int y = 0;
        private static ArrayList m1 = new ArrayList();
        private static void Reprint()
        {
        }

        static void Main(string[] args)

        {
          
            MenuOrginal();

            var readKeys = new Task(ReadKeys);
            readKeys.Start();

            var tasks = new[] { readKeys };

            Task.WaitAll(tasks);

            Console.CancelKeyPress += (sender, e) =>
            {
                Environment.Exit(0);
            };
        }
        private static int N = 7;
        private static void MenuOrginal()
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("1.Nhap day so");
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("2.Sap xep tang dan");
            Console.WriteLine("3.Sap xep giam dan");
            Console.WriteLine("4.In ket qua");
            Console.WriteLine("5.Demo se tang dan");
            Console.WriteLine("6.thoat");

          
        }
        private static void Menu()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Menu:");
            Console.WriteLine("1.Nhap day so");
            Console.WriteLine("2.Sap xep tang dan");
            Console.WriteLine("3.sắp xếp giam dan");
            Console.WriteLine("4.In ket qua");
            Console.WriteLine("5.Demo sẽ tang dan");
            Console.WriteLine("6.thoat");

        }
        private static int Y;
        private static void ReadKeys()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y != 7)
                        {
                            switch (Y)
                            {
                                case 1:
                                    Menu();
                                    Y--;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("1.Nhap day so");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 2:
                                    Menu();
                                    Y--;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("2.Sap xep tang dan");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;

                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (Y != 4)
                        {
                            switch (Y)
                            {
                                case 3:
                                    Menu();
                                    Y++;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("3.Sap xep giam dan");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 4:
                                    Menu();
                                    Y++;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("4.In ket qua");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 5:
                                    Menu();
                                    Y++;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("5.demo so tang dan");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 6:
                                    Menu();
                                    Y++;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("6.thoat");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;

                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (Y)
                        {
                            case 2:
                                Reprint();
                                break;
                            case 3:
                                Sort();
                                Console.SetCursorPosition(x + 12, Y);
                                Console.Write("SORT COMPLETED! hit enter to delete");
                                Console.ReadLine();
                                Console.SetCursorPosition(x + 12, Y);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("SORT COMPLETED! hit enter to delete");
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                            case 4:
                                Print();
                                break;
                        }
                        break;
                }
            }
        }
        private static int[] sorted = new int[12];
        private static void Reprint()
        {
            Console.CursorVisible = true;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        again:
            Console.Clear();
            Console.Write("ban muong nhap bao nhieu so: ");
            int n = int.Parse(Console.ReadLine());

            if (n < 5 || n > 10)
            {
                Console.WriteLine("Xin loi, ban chi duoc nhap tu 5 den 10 thoi");
                Thread.Sleep(2000);
                goto again;
            }

            m1.Clear();
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap vao so {0} cua day so cua ban: ", i);
                int t = int.Parse(Console.ReadLine());
                m1.Add(t);
            }

            for (int i = 3; i >= 0; i--)
            {
                Console.SetCursorPosition(x, y + (n + 1));
                Console.WriteLine("Screen will clear in {0}", i);
                Thread.Sleep(1000);
            }
            Console.CursorVisible = false;

            MenuOrginal();
        }
        private static void Sort()
        {
            Array.Clear(sorted, 0, sorted.Length);

            for (int i = 0; i < m1.Count; i++)
            {
                sorted[i] = Convert.ToInt32(m1[i]);
            }

            for (int i = 0; i < m1.Count; i++)
            {
                for (int j = i; j < m1.Count; j++)
                {
                    if (sorted[i] > sorted[j])
                    {
                        int tmp = sorted[i];

                        sorted[i] = sorted[j];

                        sorted[j] = tmp;
                    }
                }
            }

        }
        private static void Print()
        {
            Console.SetCursorPosition(x + 16, Y);
            for (int i = 0; i < m1.Count; i++)
            {
                Console.Write(sorted[i] + " | ");
            }
        }

    }
}








