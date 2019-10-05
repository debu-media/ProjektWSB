using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class Program
    {

        static void Main(string[] args)
        {
            int Program_run = 1;
            GetMenu();
           int  Menu_option = Convert.ToInt32(Console.ReadLine());
            while (Program_run == 1)
            {
                switch (Menu_option)
                {
                    case 1:
                       string Text = GetFileFromInternet();
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Musisz wybrać opcję \n");
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());
                        break;
                }

            }
        }
        static void GetMenu()
        {
            Console.WriteLine("   Menu \n==========\n");
            Console.WriteLine("1 - Get file from internet");
            Console.WriteLine("2 - Count letters");
            Console.WriteLine("3 - Count words");
            Console.WriteLine("4 - Count punctuation marks");
            Console.WriteLine("5 - Count sentences");
            Console.WriteLine("6 -  Generate report about count of every letter in the file");
            Console.WriteLine("7 - Save statistics to the file");
            Console.WriteLine("8 - Exit");
        }
        public static String GetFileFromInternet()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://s3.zylowski.net/public/input/1.txt", @"stringfile.txt");
            string text = System.IO.File.ReadAllText(@"stringfile.txt");
            File.Delete("stringfile.txt");
            return text;
        }

    }
}
