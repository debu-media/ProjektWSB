using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            string adres = "Null";
            while (Program_run == 1)
            {
                switch (Menu_option)
                {
                    case 1:
                        Console.WriteLine("Get file from internet? T/N");
                        String odp = Console.ReadLine();
                        if (odp == "T" || odp == "t")
                        {
                            Console.WriteLine("Give a adress");
                            adres = Console.ReadLine();
                            Text = GetFileFromInternet(adres);
                        }
                        else
                        {
                            Console.WriteLine("Give adress from local stoarge:");
                            adres = Console.ReadLine();
                            Text=GetFileFromInternet(adres);
                        }
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 2:
                        if (Text != "Null")
                        {
                            string SumOfLetters = CountLetters(Text);
                            Console.WriteLine(SumOfLetters);
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
                    case 4:
                        if (Text != "Null")
                        {
                            int SumOfPunctationMarks = CountpunctuationmarksLetters(Text);
                            Console.WriteLine("Number of Puntactionsmark in the file: " + SumOfPunctationMarks);
                        }
                        else
                        {
                            Console.WriteLine("Sorry, the file does not exist. \n \n Choose option no. 1 and try again \n\n");
                        }
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 5:
                        if (Text != "Null")
                        {
                            int SumOfSentences = CountSentences(Text);
                            Console.WriteLine("Number of Sentences in the file: " + SumOfSentences);
                        }
                        else
                        {
                            Console.WriteLine("Sorry, the file does not exist. \n \n Choose option no. 1 and try again \n\n");
                        }
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());

                        break;
                    case 6:
                        if (Text != "Null")
                        {
                            GenerateRaport(Text);
                        }
                        else
                        {
                            Console.WriteLine("Sorry, the file does not exist. \n \n Choose option no. 1 and try again \n\n");
                        }
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());

                        break;
                    case 7:
                        SaveStatistic(adres);
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("You must select an option from the menu \n");
                        GetMenu();
                        Menu_option = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 8:
                        Program_run = 0;
                        ProgramExit();
                        break;
                }

            }
        }
        static void GetMenu()
        {
            Console.WriteLine("   Menu \n==========\n");
            Console.WriteLine("1 - Chose input file");
            Console.WriteLine("2 - Count letters");
            Console.WriteLine("3 - Count words");
            Console.WriteLine("4 - Count punctuation marks");
            Console.WriteLine("5 - Count sentences");
            Console.WriteLine("6 -  Generate report about count of every letter in the file");
            Console.WriteLine("7 - Save statistics to the file");
            Console.WriteLine("8 - Exit");
        }
        public static String GetFileFromInternet(String adres)
        {
            
            WebClient webClient = new WebClient();
            string text = "Null";
            try
            {
                webClient.DownloadFile(adres, @"stringfile.txt");
                text = System.IO.File.ReadAllText(@"stringfile.txt");
                File.Delete("stringfile.txt");
               
               
            }
            catch (Exception)
            {
                Console.WriteLine("Nie udalo sie otworzyc pliku wejsciowego");
                GetMenu();
                
            }
           
            return text;


        }

        public static string CountLetters(String text)
        {
            int CountLetters = text.Count(char.IsLetter);


            int vowels = 0;
            int consonant = 0;
            int space = 0;

            Console.WriteLine("Enter a Sentence or a Character");
            string v = text;

            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == 'a' || v[i] == 'e' || v[i] == 'i' || v[i] == 'o' || v[i] == 'u' || v[i] == 'A' || v[i] == 'E' || v[i] == 'I' || v[i] == 'O' || v[i] == 'U')
                {
                    vowels++;
                }

                else if (char.IsWhiteSpace(v[i]))

                {
                    space++;
                }

                else
                {
                    consonant++;
                }
            }

            Console.WriteLine("Your total number of vowels is: {0}", vowels);
            Console.WriteLine("Your total number of constant is: {0}", consonant);
            Console.WriteLine("Your total number of space is: {0}", space);
            string count = "Your total number of vowels is: " + vowels + " Your total number of constant is: " + consonant + " Your total number of space is: " + space;
            return count;

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
                        if(!(char.IsLetter(s[i])))
                        {
                            c++;
                        }
                        
                    }
                }
            }
            if (s.Length > 2)
            {
                c++;
            }
            return c;
        }
        public static int CountpunctuationmarksLetters(String text)
        {
            int CountOfPunctuationMarksLetters = 0;

            string pattern = @"[.?]";
            Regex rg = new Regex(pattern);
            MatchCollection matchedR = rg.Matches(text);
            for (int count = 0; count < matchedR.Count; count++)
                CountOfPunctuationMarksLetters++;
            return CountOfPunctuationMarksLetters;
        }
        public static int CountSentences(String text)
        {
            var translateArraySourceTexts = text.Split(new string[] { ".", "!?", "!", "?", "...", "?!", ".!" }, StringSplitOptions.RemoveEmptyEntries);
            var count = translateArraySourceTexts.Length;
            return count;
        }
        public static void GenerateRaport(string text)
        {
            string pattern = @"[Aa]";
            int A = 0, B = 0, C = 0, D = 0, E = 0, F = 0, G = 0, H = 0, I = 0, J = 0, K = 0, L = 0, M = 0, N = 0, O = 0, P = 0, Q = 0, R = 0, S = 0, T = 0, U = 0, V = 0, W = 0, X = 0, Y = 0, Z = 0;
            Regex rg = new Regex(pattern);
            MatchCollection matchedA = rg.Matches(text);
            for (int count = 0; count < matchedA.Count; count++)
                A++;
            pattern = @"[Bb]";
            rg = new Regex(pattern);
            MatchCollection matchedB = rg.Matches(text);
            for (int count = 0; count < matchedB.Count; count++)
                B++;
            pattern = @"[Cc]";
            rg = new Regex(pattern);
            MatchCollection matchedC = rg.Matches(text);
            for (int count = 0; count < matchedC.Count; count++)
                C++;
            pattern = @"[Dd]";
            rg = new Regex(pattern);
            MatchCollection matchedD = rg.Matches(text);
            for (int count = 0; count < matchedD.Count; count++)
                D++;
            pattern = @"[Ee]";
            rg = new Regex(pattern);
            MatchCollection matchedE = rg.Matches(text);
            for (int count = 0; count < matchedE.Count; count++)
                E++;
            pattern = @"[Ff]";
            rg = new Regex(pattern);
            MatchCollection matchedF = rg.Matches(text);
            for (int count = 0; count < matchedF.Count; count++)
                F++;
            pattern = @"[Gg]";
            rg = new Regex(pattern);
            MatchCollection matchedG = rg.Matches(text);
            for (int count = 0; count < matchedG.Count; count++)
                G++;
            pattern = @"[Hh]";
            rg = new Regex(pattern);
            MatchCollection matchedH = rg.Matches(text);
            for (int count = 0; count < matchedH.Count; count++)
                H++;
            pattern = @"[Ii]";
            rg = new Regex(pattern);
            MatchCollection matchedI = rg.Matches(text);
            for (int count = 0; count < matchedI.Count; count++)
                I++;
            pattern = @"[Jj]";
            rg = new Regex(pattern);
            MatchCollection matchedJ = rg.Matches(text);
            for (int count = 0; count < matchedJ.Count; count++)
                J++;
            pattern = @"[Kk]";
            rg = new Regex(pattern);
            MatchCollection matchedK = rg.Matches(text);
            for (int count = 0; count < matchedK.Count; count++)
                K++;
            pattern = @"[Ll]";
            rg = new Regex(pattern);
            MatchCollection matchedL = rg.Matches(text);
            for (int count = 0; count < matchedL.Count; count++)
                L++;
            pattern = @"[Mm]";
            rg = new Regex(pattern);
            MatchCollection matchedM = rg.Matches(text);
            for (int count = 0; count < matchedM.Count; count++)
                M++;
            pattern = @"[Nn]";
            rg = new Regex(pattern);
            MatchCollection matchedN = rg.Matches(text);
            for (int count = 0; count < matchedN.Count; count++)
                N++;
            pattern = @"[Oo]";
            rg = new Regex(pattern);
            MatchCollection matchedO = rg.Matches(text);
            for (int count = 0; count < matchedO.Count; count++)
                O++;
            pattern = @"[Pp]";
            rg = new Regex(pattern);
            MatchCollection matchedP = rg.Matches(text);
            for (int count = 0; count < matchedP.Count; count++)
                P++;
            pattern = @"[Bb]";
            rg = new Regex(pattern);
            MatchCollection matchedQ = rg.Matches(text);
            for (int count = 0; count < matchedQ.Count; count++)
                Q++;
            pattern = @"[Rr]";
            rg = new Regex(pattern);
            MatchCollection matchedR = rg.Matches(text);
            for (int count = 0; count < matchedR.Count; count++)
                R++;
            pattern = @"[Ss]";
            rg = new Regex(pattern);
            MatchCollection matchedS = rg.Matches(text);
            for (int count = 0; count < matchedS.Count; count++)
                S++;
            pattern = @"[Tt]";
            rg = new Regex(pattern);
            MatchCollection matchedT = rg.Matches(text);
            for (int count = 0; count < matchedT.Count; count++)
                T++;
            pattern = @"[Uu]";
            rg = new Regex(pattern);
            MatchCollection matchedU = rg.Matches(text);
            for (int count = 0; count < matchedU.Count; count++)
                U++;
            pattern = @"[Vv]";
            rg = new Regex(pattern);
            MatchCollection matchedV = rg.Matches(text);
            for (int count = 0; count < matchedV.Count; count++)
                V++;
            pattern = @"[Ww]";
            rg = new Regex(pattern);
            MatchCollection matchedW = rg.Matches(text);
            for (int count = 0; count < matchedW.Count; count++)
                W++;
            pattern = @"[Xx]";
            rg = new Regex(pattern);
            MatchCollection matchedX = rg.Matches(text);
            for (int count = 0; count < matchedX.Count; count++)
                X++;
            pattern = @"[Yy]";
            rg = new Regex(pattern);
            MatchCollection matchedY = rg.Matches(text);
            for (int count = 0; count < matchedY.Count; count++)
                Y++;
            pattern = @"[Zz]";
            rg = new Regex(pattern);
            MatchCollection matchedZ = rg.Matches(text);
            for (int count = 0; count < matchedZ.Count; count++)
                Z++;
            Console.WriteLine("A: " + A);
            Console.WriteLine("B: " + B);
            Console.WriteLine("C: " + C);
            Console.WriteLine("D: " + D);
            Console.WriteLine("E: " + E);
            Console.WriteLine("F: " + F);
            Console.WriteLine("G: " + G);
            Console.WriteLine("H: " + H);
            Console.WriteLine("I: " + I);
            Console.WriteLine("J: " + J);
            Console.WriteLine("K: " + K);
            Console.WriteLine("L: " + L);
            Console.WriteLine("M: " + M);
            Console.WriteLine("N: " + N);
            Console.WriteLine("O: " + O);
            Console.WriteLine("P: " + P);
            Console.WriteLine("Q: " + Q);
            Console.WriteLine("R: " + R);
            Console.WriteLine("S: " + S);
            Console.WriteLine("T: " + T);
            Console.WriteLine("U: " + U);
            Console.WriteLine("V: " + V);
            Console.WriteLine("W: " + W);
            Console.WriteLine("X: " + X);
            Console.WriteLine("Y: " + Y);
            Console.WriteLine("Z: " + Z);

        }
        public static void SaveStatistic(string adres)
        {
            string match;
           
            if (adres!="Null")
            {
                string Text = GetFileFromInternet(adres);
                string SumOfLetters = CountLetters(Text);
                int SumOfWords = CountWords(Text);
                int SumOfPunctationMarks = CountpunctuationmarksLetters(Text);
                int SumOfSentences = CountSentences(Text);
                match = "Number of letters in the file: " + SumOfLetters + "\n" + "Number of words in the file: " + SumOfWords + "\n" + "Number of Puntactionsmark in the file: " + SumOfPunctationMarks + "\n" + "Number of Sentences in the file: " + SumOfSentences;
                string path = @"statystyki.txt";
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, match);
                }
                if (File.Exists(path))
                {
                    File.Delete(path);
                    File.WriteAllText(path, match);
                }
                Console.WriteLine("File saved successfully");
            }
            
        }
        public static void ProgramExit()
        {
            string statystyki = @"statystyki.txt";
            string stringfile = @"stringfile.txt";
            if (File.Exists(statystyki))
            {
                File.Delete(statystyki);
            }
            if (File.Exists(stringfile))
            {
                File.Delete(stringfile);
            }
            Console.WriteLine("bye.");
        }
    }
}
