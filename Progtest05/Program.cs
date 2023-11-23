using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Progtest05
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            String result = "";
            String pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Desktop";
            TestDataGenerator testDataGenerator = new TestDataGenerator();

            Console.WriteLine("Will generate reviews in format \' + YYYY-MM-DD num randomString\'");
            Console.WriteLine(
                "Dates are input in chronological order. Numbers will be >0. Random string will be <=4096 chars");
            Console.WriteLine();
            Console.WriteLine("How many reviews?");
            int entryCount = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Generating");
            for (int i = 0; i < entryCount; i++)
            {
                if (i == entryCount / 4 || i == (entryCount / 4) * 2 || i == (entryCount / 4) * 3)
                {
                    Console.Write(".");
                }

                result += testDataGenerator.GetNewReview();
            }

            Console.WriteLine(" Done!");

            Console.WriteLine("Will generate queries in format '# number'");
            Console.WriteLine("Number will be less than 1/4 of Int32 max value");
            Console.WriteLine();
            Console.WriteLine("How many queries?");
            entryCount = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Generating");
            for (int i = 0; i < entryCount; i++)
            {
                if (i == entryCount / 4 || i == (entryCount / 4) * 2 || i == (entryCount / 4) * 3)
                {
                    Console.Write(".");
                }
                
                result += testDataGenerator.GetNewQuery();
            }

            Console.WriteLine(" Done!");
            result += "\n";
            Console.WriteLine("Print to file or to console? (F/C)");
            switch (Console.Read())
            {
                case 'c':
                case 'C':
                    Console.WriteLine();
                    Console.WriteLine("\n");
                    Console.WriteLine(result);
                    break;

                case 'f':
                case 'F':
                    Console.WriteLine();
                    if (File.Exists(pathToDesktop + "/testdata.txt"))
                    {
                        Console.WriteLine("Overwrite exising data? (Y/N)");

                        switch (Console.Read())
                        {
                            case 'n':
                            case 'N':
                                Console.WriteLine();
                                Console.WriteLine("Print to console or abort? (C/A)");
                                switch (Console.Read())
                                {
                                    case 'c':
                                    case 'C':
                                        Console.WriteLine();

                                        Console.WriteLine("\n");
                                        Console.WriteLine(result);
                                        break;

                                    case 'a':
                                    case 'A':
                                        Console.WriteLine();
                                        Console.WriteLine("Ok, nothing has been changed.");
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            case 'y':
                            case 'Y':
                                Console.WriteLine();
                                Console.Write("Deleting...");
                                File.Delete(pathToDesktop + "./testdata.txt");
                                Console.WriteLine(" Done!");
                                break;
                        }
                    }

                    Console.Write("Writing to " + pathToDesktop + "/testdata.txt ...");
                    File.WriteAllText(pathToDesktop + "/testdata.txt", result);
                    Console.WriteLine(" Done!");
                    break;
            }
        }
    }
}