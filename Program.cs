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
        static void Skracivanje(int[,] Polje,int n)
        {
            int Pomagac;
            int[] Dodatak = new int[n];
            int[,,] Determinanta = new int[n+4, n+4, n+4];
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Determinanta[0, i, j] = Polje[i, j];
                }
            }
            for (int z = 0; z < n; z++)
            {
                for (int i = 1; i < n; i++)
                {
                    for (int j = 0; j < n - 1; j++)
                    {
                        Pomagac = z;
                        if (Pomagac == n && i == 3) Pomagac++; else if (Pomagac == n && i == 4) Pomagac += 2;
                        Determinanta[z, i, j] = Determinanta[0, i, j + Pomagac];
                        Dodatak[z] = Convert.ToInt32(Math.Pow(-1, i + 2)) * Convert.ToInt32(Math.Pow(Determinanta[z, i, j],j));
                    }
                }
            }
            if (n == 3)
            {
                for(int i = 0; i < 3; i++)
                {
                    Zbrajanje += Dodatak[i] * (Determinanta[i, 0, 0] * Determinanta[i, 1, 1] - Determinanta[i, 0, 1] * Determinanta[i, 1, 0]);
                }
            }
            else
            {
                for (int z = 0; z < n; z++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Polje[i, j] = Determinanta[z, i, j];
                        }
                    }
                    n--;
                    Skracivanje(Polje, n);
                }
            }
        }
        static void Main(string[] args)
        {
            int n;
            Console.Write("Upišite broj redova:");
            n = Convert.ToInt32(Console.ReadLine());
            int[,] Polje = new int[n, n];
            for (int i = 0; n > i; i++)
            {
                for (int j = 0; n > j; j++)
                {
                    Console.Write("Upišite broj " + i + " " + j + "=");
                    Polje[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            if (n == 2)
            {
                Console.WriteLine(Polje[0, 0] * Polje[1, 1] - Polje[0, 1] * Polje[1, 0]);
            } else { 
            Skracivanje(Polje, n);
            Console.WriteLine(Zbrajanje);
            }
            Console.ReadKey();
        }
    }
}
