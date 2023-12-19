using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static List<int> Godrok = new List<int>();
        static int FirstElement;
        static int LastElement;
        static void Main(string[] args)
        {
            Read();
            //1
            Console.WriteLine($"1.Feladat: A fájl adatainak száma: {Godrok.Count()}");
            //2
            Console.Write("2.Feladat: Adjon meg egy távolság értéket: ");
            int Bekert = int.Parse(Console.ReadLine());
            Console.WriteLine($"Ezen a helyen a felszín {Godrok[Bekert-1]} méter mélyen van!");
            //3
            double Counter = 0;
            Godrok.ForEach(x =>
            {
                if(x == 0)
                {
                    Counter++;
                }
            });
            double sum = (Counter / Godrok.Count()) * 100.00;
            Console.WriteLine($"3.Feladat: A felszín {Math.Round(sum,2)}% maradt érintetlen");
            //4
            StreamWriter sw = new StreamWriter("Godrok.txt");
                for(int i = 0; i < Godrok.Count(); i++)
                {

                    if (Godrok[i] > 0)
                    {
                        if (Godrok[i-1] == 0)
                        {
                            sw.WriteLine();
                            sw.Write($"{Godrok[i]} ");
                        }
                    else
                    {
                        sw.Write($"{Godrok[i]} ");
                    }
                    }
                }
            sw.Close();

            //5
            List<string> list = new List<string>();
            StreamReader sr = new StreamReader("Godrok.txt");

            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine());
            }
            Console.WriteLine($"5.Feladat: Összesen {list.Count()-1} db gödör van.");
            //6
            Console.WriteLine(Bekert);
            for (int i = 0; i < Godrok.Count(); i++)
            {
                Console.WriteLine(Godrok[Bekert]);
                if (Godrok[Bekert] == 0)
                {
                    Console.WriteLine("6.Feladat: Az adott helyen nincs gödör!");
                }
                else if (Godrok[Bekert] > 0)
                {
                    if (Godrok[Bekert - 1] == 0)
                    {
                        FirstElement = Godrok[Bekert];
                        Console.WriteLine(Godrok[Bekert]);
                        Console.WriteLine(Bekert);
                    }
                    else if (Godrok[Bekert + 1] == 0)
                    {
                        LastElement = Godrok[Bekert];
                    }
                }
            }
                    Console.WriteLine($"6.Feladat: A gödör kezdőpontja:{FirstElement}, végpontja: {LastElement}");
        }
        static void Read()
        {
            StreamReader sr = new StreamReader ("melyseg.txt");
            while (!sr.EndOfStream)
            {
                Godrok.Add(int.Parse(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}