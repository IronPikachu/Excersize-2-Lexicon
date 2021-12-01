using System;

namespace Excersize_2_Lexicon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Main Menu!\nYou will be navigating by typing in numbers to test different funktions.");
            string[] options = {"Exit program" };
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i}\t- {options[i]}");
            }
            bool loop = true;

            while (loop)
            {
                string input = Console.ReadLine();
                if(int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 0:
                            loop = false;
                            Console.WriteLine("Good Bye.");
                            break;
                        default:
                            Console.WriteLine("Wrong integer!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please type an integer.");
                }
            }
        }
    }
}
