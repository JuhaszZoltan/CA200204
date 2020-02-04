using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CA200204
{
    class Program
    {
        static List<Chinchilla> csincsillak;
        static void Main()
        {
            F01();
            F02();
            F03();
            F04();
            F05();
            F06();
            Console.ReadKey();
        }

        private static void F06()
        {
            var sw = new StreamWriter("evek.txt");
            csincsillak.GroupBy(
                x => x.SzuletesNap.Year)
                .ToList()
                .ForEach(x => sw.WriteLine($"{x.Key}: {x.Count()}"));
            sw.Close();
        }

        private static void F05()
        {
            Console.WriteLine("\n5. feladat:");

            //WUT
            csincsillak.OrderByDescending(x => x.Suly)
                .ToList()
                .GetRange(0, 5)
                .ForEach(x => Console.WriteLine(
                    "{0}. {1, -12} {2} g",
                    csincsillak.OrderByDescending(y => y.Suly)
                    .ToList()
                    .GetRange(0, 5)
                    .IndexOf(x) + 1,
                    x.Nev,
                    x.Suly));
        }

        private static void F04()
        {
            var cs = csincsillak.First(x => x.Kor >= 8 && x.Suly < 360);
            if (cs != null) Console.WriteLine($"{cs.Nev} {cs.Kor} éves és {cs.Suly} gramm");
            else Console.WriteLine("nincs ilyen csincsilla");
        }

        private static void F03()
        {
            Console.WriteLine("\n3. feladat:");
            int db = csincsillak.Count(cs => cs.Simi);
            Console.WriteLine("A csincsillák {0:0.00}%-a szereti, ha símogatják",
                db / (float)csincsillak.Count * 100);

        }

        private static void F02()
        {
            Console.WriteLine("2. feladat:");
            Console.WriteLine($"Összesen {csincsillak.Count} db csincsilla van.");
        }

        private static void F01()
        {
            csincsillak = new List<Chinchilla>();
            var sr = new StreamReader("chi.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                csincsillak.Add(new Chinchilla(sr.ReadLine()));
            }
        
        }
    }
}
