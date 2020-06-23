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
        static string wordString;
        static char[] word, wordInvisible;
        static int score = 0;
        static int hangmanLife;
        static bool cond = false;
        static void Main(string[] args)
        {
            while(true)
            {
                MainMenu();
            }
            
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
        static void InGameIfCheck() // wybieranie litery lub chęci zgadywania słowa przez gracza
        {
            Console.WriteLine("Enter character or 'check' if you want to enter the whole word:");
            int x = 0;
            string input = Console.ReadLine();
            if (input == "check")
                {
                Console.WriteLine("Enter the word:");
                    WordCheck(Console.ReadLine());

                }
            else
                {
                Console.Clear();
                for (int i = 0; i < word.Length; i++)
                    {
                        if (input == word[i].ToString())
                        {
                            char.TryParse(input, out wordInvisible[i]);
                            x++;
                        }
                    }
                if (x == 0)
                {
                    Console.Clear();
                    hangmanLife--;
                    Hangman(hangmanLife);
                }
                }
            
            checkWord();

        }
        static void WordCheck(string input) // zgadywanie całego słowa
        {
            if (input.ToLower()==wordString)
            {
                Console.Clear();
                Win();
            }
            else
            {
                hangmanLife--;
                Hangman(hangmanLife);
            }
        }
        static void Hangman(int input)
        {
            switch (input)
            {
                case 6:
                    break;
                case 5:
                    {
                        Console.WriteLine("--------");
                        Console.WriteLine("|      |");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        Console.WriteLine("/|\\");
                        
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
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("--------");
                        Console.WriteLine("|      |");
                        Console.WriteLine("|      @");
                        Console.WriteLine("|     /|\\ ");
                        Console.WriteLine("|     / \\ ");
                        Console.WriteLine("/|\\");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("--------");
                        Console.WriteLine("|      |");
                        Console.WriteLine("|      X");
                        Console.WriteLine("|     /|\\ ");
                        Console.WriteLine("|     / \\ ");
                        Console.WriteLine("/|\\");
                        Console.WriteLine("@@ YOU LOSE @@");
                        Lose();
                        break;
                    }
                default:
                    break;
            }
        } // wyświetlanie wisielca i odejmowanie szans do wygranej
        static void Win() // info o wygranej i zwiększanie wyniku
        {
            Console.Clear();
            score++;
            Console.WriteLine("Congratulations, '{0}' is the correct word!", wordString);
            Console.WriteLine("Your score is {0}.\n", score);
            cond = true;
        }
        static void Lose() // info i przegranej i zmniejszanie wyniku
        {
            score--;
            Console.WriteLine("Your score is {0}.\n", score);
        }
        static void checkWord()
        {
            if (wordString == new string(wordInvisible)) Win();
        } // sprawdza, czy słowo zawiera się w podanych przez gracza literach
        static bool MainMenu() // menu główne
        {
            Console.WriteLine("Welcome to the Hangman Game.");
            Console.WriteLine("Choose your option");
            Console.WriteLine("1) Play the game.");
            Console.WriteLine("2) Exit.");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.Clear();
                        Game();
                        return true;
                    }
                case "2":
                    {
                        Environment.Exit(0);
                        return false;
                    }
                default:
                    return true;
            }
        }
        static void Game() // rozgrywka
        {
            cond = false;
            wordString = DrawAWord(words).ToLower();
            word = wordString.ToCharArray();
            wordInvisible = InvisibilityWord(word).ToCharArray();
            hangmanLife = 6;
            while (hangmanLife > 1 && cond == false)
            {
                Console.Write("The word is: ");
                Console.WriteLine(wordInvisible);
                InGameIfCheck();
            }

        }

    }
}
