using System;

namespace DogBreed
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
            var numberFive = random.Next(0, (100 - numberOne - numberTwo - numberThree - numberFour));

            string[] breedArray = { "Yorkshire Terrier", "German Shepherd", "Poodle", "Husky", "Golden Retriever", "Pitbull", "French Bulldog", "Labrador Retriever", "Australian Shepherd", "Border Collie", "Shih Tzu", "Boxer" };

            Console.WriteLine("Input your dog's name:");
            var dogName = (Console.ReadLine());
            Console.WriteLine("Well, I have this highly reliable report on " + dogName + "'s prestigious genetic background.");
            Console.WriteLine(dogName + " is:");

            int index = random.Next(breedArray.Length);

            



            Console.ReadLine();
        }
    }
}
