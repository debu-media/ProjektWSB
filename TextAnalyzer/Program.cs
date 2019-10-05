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
            int Menu_option = Convert.ToInt32(Console.ReadLine());
            string Text = "Null";
            while (Program_run == 1)
            {
                switch (Menu_option)
                {
                    case 1:
                        Text = GetFileFromInternet();
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 2:
                        if (Text != "Null")
                        {
                            int SumOfLetters = CountLetters(Text);
                            Console.WriteLine("Number of letters in the file: " + SumOfLetters);
                        }
                        else
                        {
                            Console.WriteLine("Sorry, the file does not exist. \n \n Choose option no. 1 and try again \n\n");
                        }
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        if (Text != "Null")
                        {
                            int SumOfWords = CountWords(Text);
                            Console.WriteLine("Number of words in the file: " + SumOfWords);
                        }
                        else
                        {
                            Console.WriteLine("Sorry, the file does not exist. \n \n Choose option no. 1 and try again \n\n");
                        }
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("You must select an option from the menu \n");
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

        public static int CountLetters(String text)
        {
            int CountLetters = text.Count(char.IsLetter);
            return CountLetters;
        }

        public static int CountWords(String text)
        {
            string s = text;
            int c = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (char.IsWhiteSpace(s[i - 1]) == true)
                {
                    if (char.IsLetterOrDigit(s[i]) == true ||
                        char.IsPunctuation(s[i]))
                    {
                        c++;
                    }
                }
            }
            if (s.Length > 2)
            {
                c++;
            }
            return c;
        }

    }
}
