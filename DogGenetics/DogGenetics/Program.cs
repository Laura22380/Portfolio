using System;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dog Breed Results Company Name");

            var random = new Random();
            var numberOne = random.Next(0, 100);
            var numberTwo = random.Next(0, 100 - numberOne);
            var numberThree = random.Next(0, (100 - numberOne - numberTwo));
            var numberFour = random.Next(0, (100 - numberOne - numberTwo - numberThree));
            var numberFive = (100 - numberOne - numberTwo - numberThree - numberFour);

            string[] breedArray = { "Yorkshire Terrier", "German Shepherd", "Poodle", "Husky", "Golden Retriever", "Pitbull", "French Bulldog", "Labrador Retriever", "Australian Shepherd", "Border Collie", "Shih Tzu", "Boxer" };

            Console.WriteLine("Input your dog's name:");
            var dogName = (Console.ReadLine());
            Console.WriteLine("Well, I have this highly reliable report on " + dogName + "'s prestigious genetic background.");
            Console.WriteLine(dogName + " is:");

            int index = random.Next(breedArray.Length);
            // Want to learn how to make sure all dog breeds are different

            Console.WriteLine(breedArray[index] + ": " + numberOne + "%");
            int breed2 = random.Next(breedArray.Length);
            Console.WriteLine(breedArray[breed2] + ": " + numberTwo +"%");
            int breed3 = random.Next(breedArray.Length);
            Console.WriteLine(breedArray[breed3] + ": " + numberThree + "%");
            int breed4 = random.Next(breedArray.Length);
            Console.WriteLine(breedArray[breed4] + ": " + numberFour + "%");
            int breed5 = random.Next(breedArray.Length);
            Console.WriteLine(breedArray[breed5] + ": " + numberFive + "%");


            Console.WriteLine("Wow! That's quite the dog. " + dogName + " is " + (numberOne + numberTwo + numberThree + numberFour + numberFive) + "% your dog.");

            Console.ReadLine();
        }
    }
}
