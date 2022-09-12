using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterCatManager.View
{
    public class UserIO
    {
        public string ReadString(string prompt)
        {
            string userInput = "";
            while (userInput == "")
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine().Trim();
                if (userInput == "")
                {
                    Console.WriteLine("That was not a valid input. Please try again.");
                }
            }
            return userInput;
        }

        public bool ReadBool(string prompt)
        {
            string userInput = "";
            while (userInput == "")
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine().Trim().ToUpper();
                if (userInput != "Y")
                {
                    return false;
                }
            }
            return true;
        }

        public int ReadInt(string prompt, int min, int max)
        {
            int output;
            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out output))
                {
                    if (output >= min && output <= max)
                    {
                        break;

                    }
                    else
                    {
                        Console.WriteLine("That was not a number between {0} and {1}. Please try again.", min, max);
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid input. Please try again.");
                }
            }
            return output;
        }
    }
}
