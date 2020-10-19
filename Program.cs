using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Determinante
{
    class Program
    {
        static int Zbrajanje;
        static void Skracivanje(int[,] Polje, int n, int faktor)
        {
            int[,] SkracenoPolje = new int[n, n];
            if (n == 2)
            {
                Zbrajanje += (faktor * (Polje[0, 0] * Polje[1, 1] - Polje[0, 1] * Polje[1, 0]));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    SkracenoPolje = Polje;
                    for (int y = 0; y < n - 1; y++)
                    {
                        for (int x = 0; x < n; x++)
                        {
                            SkracenoPolje[y, x] = SkracenoPolje[y + 1, x];
                        }
                    }
                    for (int y = 0; y < n; y++)
                    {
                        for (int x = 0; x < n - 1; x++)
                        {
                            if (i != 1 || i != 0)
                            {
                                SkracenoPolje[y, x] = SkracenoPolje[y + i + 1, x];
                            }
                            else
                                SkracenoPolje[y, x] = SkracenoPolje[y + i, x];
                        }
                    }
                    faktor = Convert.ToInt32(Math.Pow(-1, i + 1)) * Polje[0, i];
                    Skracivanje(SkracenoPolje, n - 1, faktor);
                }
            }
        }
        static void Main(string[] args)
        {
            int n, faktor = 1;
            Console.Write("Upišite broj redova:");
            n = Convert.ToInt32(Console.ReadLine());
            int[,] Polje = new int[n, n];
            for (int y = 0; n > y; y++)
            {
                for (int x = 0; n > x; x++)
                {
                    Console.Write("Upišite broj " + y + " " + x + "=");
                    Polje[y, x] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (int y = 0; n > y; y++)
            {
                for (int x = 0; n > x; x++)
                {
                    Console.Write(Polje[y, x] + " ");
                }
                Console.WriteLine();
            }
            Skracivanje(Polje, n, faktor);
            Console.WriteLine("Rezultat = " + Zbrajanje);
            Console.ReadKey();
        }
    }
}
