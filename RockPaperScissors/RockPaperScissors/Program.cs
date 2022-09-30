using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var rng = new Random();
            int numberTurns = 0;
            int ties = 0;
            int userWin = 0;
            int computerWin = 0;
            bool isValidTurns = false;
            bool isPlayAgain = true;

            
            Console.WriteLine("Let's play rock, paper, scissors.");
            do
            {

            

                while (!isValidTurns)
                {
                Console.WriteLine("How many turns would you like to play?");
                isValidTurns = int.TryParse(Console.ReadLine(), out numberTurns);

                if (!isValidTurns || numberTurns > 10 || numberTurns < 1)
                {
                    Console.WriteLine("Invalid Entry - Go Home");
                    Console.ReadKey();
                    isValidTurns = false;
                }
                }

            Console.WriteLine("You selected " + numberTurns + " rounds.");

            for (int i = 0; i < numberTurns; i++)
            {
                Console.WriteLine("Choose your weapon: \n(either rock, paper, or scissors) ");
                string userInput = Console.ReadLine().ToUpper().Trim();
                int userWeapon = 0;
                switch (userInput)
                {
                    case "ROCK":
                        userWeapon = 1;
                        break;
                    case "PAPER":
                        userWeapon = 2;
                        break;
                    case "SCISSORS":
                        userWeapon = 3;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry.");
                        i--;
                        continue;
                }
                int cpuWeapon = rng.Next(1, 4);

                if (userWeapon == cpuWeapon)
                {
                    Console.WriteLine("I also picked " + userInput);
                    Console.WriteLine("It was a Tie");
                    ties++;
                }
                else if ((cpuWeapon == 1 && userWeapon == 3) || (cpuWeapon == 2 && userWeapon == 1)|| (cpuWeapon == 3 && userWeapon == 2))
                {
                        string cpuWeaponString;
                        switch (cpuWeapon)
                        {
                            case 1:
                                cpuWeaponString = "ROCK";
                                break;
                            case 2:
                                cpuWeaponString = "PAPER";
                                break;
                            case 3:
                                cpuWeaponString = "SCISSORS";
                                break;
                            default:
                                Console.WriteLine("Something went wrong.");
                                continue;
                        }
                        Console.WriteLine("Computer chose " + cpuWeaponString);
                    Console.WriteLine("Computer wins");
                    computerWin++;
                }
                else
                {
                        string cpuWeaponString;
                        switch (cpuWeapon)
                        {
                            case 1:
                                cpuWeaponString = "ROCK";
                                break;
                            case 2:
                                cpuWeaponString = "PAPER";
                                break;
                            case 3:
                                cpuWeaponString = "SCISSORS";
                                break;
                            default:
                                Console.WriteLine("Something went wrong.");
                                continue;
                        }
                        Console.WriteLine("You Win!");
                    Console.WriteLine("Computer chose " + cpuWeaponString);
                    userWin++;
                }

                Console.WriteLine("Wins: " + userWin + " Losses: " + computerWin + " Ties: " + ties);         
                Console.ReadLine();
            }
            Console.WriteLine("GAME IS OVER");
            Console.WriteLine("--------");

            if (userWin > computerWin)
            {
                Console.WriteLine("YOU WIN!");
            }
            else if (userWin < computerWin)
            {
                Console.WriteLine("You lose. Better luck next time.");
            }
            else
            {
                Console.WriteLine("It's a tie!");
  
            }

                Console.WriteLine("Do you want to play again?");
                string playAgain = Console.ReadLine().ToUpper().Trim();

                if (playAgain != "YES" || playAgain != "Y")
                {
                    isPlayAgain = false;
                }
               
            } while (isPlayAgain);

            Console.ReadLine();
        }

    }
}
    

