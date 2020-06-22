using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static string[] words = new string[]
        {
            "something", "graduate", "cosmos", "pleasure", "elephant", "balls", "failure", "skateboarding", "cinema", "gargoyle", "kitchen",
            "crocodile", "pursue", "widow", "quantum", "venom", "robotic", "magician", "building", "quarry", "ethos", "terrific", "minion"
        };
        static string wordString = DrawAWord(words).ToLower();
        static char[] word = wordString.ToCharArray();
        static char[] wordInvisible = InvisibilityWord(word).ToCharArray();
        static int score = 0;
        static int hangmanLife = 5;
        static void Main(string[] args)
        {

            Console.WriteLine(wordInvisible);
            Console.WriteLine(word);
            do
            {
                InGameIfCheck(Console.ReadLine());
            } while (hangmanLife>0);

            Console.WriteLine(wordInvisible);
            Console.WriteLine(word);
        }
        

        static string DrawAWord(string[] a)
        {
            Random rnd = new Random();
            return a[rnd.Next(0, a.Length)];
        } // losowanie słowa
        static string InvisibilityWord(char[] b)
        {
            string x = String.Empty;
            for (int i = 0; i < b.Length; i++)
            {
                x += "*";
            }
            return x;
        } // podmienianie słowa na gwiazdki
        static void InGameIfCheck(string input) // wybieranie litery lub chęci zgadywania słowa przez gracza
        {
            int x = 0;
            if (input=="check")
            {
                Console.WriteLine("Enter the word:");
                WordCheck(Console.ReadLine());

            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (input == word[i].ToString())
                    {
                        char.TryParse(input, out wordInvisible[i]);
                        x++;
                    }
                }
                if (x==0) Hangman(hangmanLife);

            }
            Console.WriteLine("Enter character:");
        }
        static void WordCheck(string input) // zgadywanie całego słowa
        {
            if (input.ToLower()==wordString)
            {
                score++;
                Console.WriteLine("Congratulations, that is the correct word!");
                Console.WriteLine("Your score is {0}", score);
            }
            else
            {
                Hangman(hangmanLife);
            }
        }
        static void Hangman(int input)
        {
            switch (input)
            {
                case 5:
                    {
                        Console.WriteLine("--------");
                        Console.WriteLine("|      |");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        Console.WriteLine("/|\\");
                        hangmanLife--;
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("--------");
                        Console.WriteLine("|      |");
                        Console.WriteLine("|      @");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        Console.WriteLine("/|\\");
                        hangmanLife--;
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("--------");
                        Console.WriteLine("|      |");
                        Console.WriteLine("|      @");
                        Console.WriteLine("|     /|\\ ");
                        Console.WriteLine("|");
                        Console.WriteLine("/|\\");
                        hangmanLife--;
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("--------");
                        Console.WriteLine("|      |");
                        Console.WriteLine("|      @");
                        Console.WriteLine("|     /|\\ ");
                        Console.WriteLine("|      |");
                        Console.WriteLine("/|\\   /|\\ ");
                        hangmanLife--;
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("--------");
                        Console.WriteLine("|      |");
                        Console.WriteLine("|      X");
                        Console.WriteLine("|     /|\\ ");
                        Console.WriteLine("|      |");
                        Console.WriteLine("/|\\   /|\\ ");
                        Console.WriteLine("@@ YOU LOSE @@");
                        hangmanLife--;
                        break;
                    }
                default:
                    break;
            }
        } // wyświetlanie wisielca i odejmowanie szans do wygranej
    }
}
