using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadLibs.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
                string color, pluralNoun, celebrity;
            Console.WriteLine("Welcome to Mad Libs!");
                Console.Write("Enter a color: ");
                color = Console.ReadLine();
                Console.Write("Enter a plural noun: ");
                pluralNoun = Console.ReadLine();
                Console.Write("Enter a celebrity: ");
                celebrity = Console.ReadLine();

                Console.WriteLine($"Roses are {color}");
                Console.WriteLine($"{pluralNoun} are blue");
                Console.WriteLine("I don't know about you, but");
                Console.WriteLine($"I love {celebrity}");

                Console.WriteLine("/n Would you like to play again?");
                string response = Console.ReadLine().ToString().ToUpper();

                if (response != "Y" || response != "YES")
                {
                System.Environment.Exit(0);
                }

            string adjective, noun, adverb;
            Console.Write("Enter an adjective: ");
            adjective = Console.ReadLine();
            Console.Write("Enter a noun: ");
            noun = Console.ReadLine();
            Console.Write("Enter an adverb: ");
            adverb = Console.ReadLine();

            Console.WriteLine($"The very {adjective} dog decided to walk outside.");
            Console.WriteLine($"The rain started to fall, so the dog decided to go to {noun}.");
            Console.WriteLine("I don't know why, but");
            Console.WriteLine($"The dog ran {adverb} home after that.");

            Console.WriteLine("/n Would you like to play again?");
            response = Console.ReadLine().ToString().ToUpper();

            if (response != "Y" || response != "YES")
            {
                System.Environment.Exit(0);
            }

            Console.Write("Enter an adjective: ");
            adjective = Console.ReadLine();
            Console.Write("Enter a noun: ");
            noun = Console.ReadLine();
            Console.Write("Enter an adverb: ");
            adverb = Console.ReadLine();
            Console.Write("Enter a color: ");
            color = Console.ReadLine();

            Console.WriteLine($"The {adjective} person saw a {noun}.");
            Console.WriteLine($"The {color} {noun} startled the person.");
            Console.WriteLine("I don't know why, but");
            Console.WriteLine($"The person spoke {adverb} to him.");

            Console.WriteLine("/n You've reached the end!");

        }
    }
}
