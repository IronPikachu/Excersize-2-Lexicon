using System;

namespace Excersize_2_Lexicon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Main Menu!\nYou will be navigating by typing in numbers to test different funktions.");
            
            bool loop = true;

            while (loop)
            {
                string[] options = { "Exit program", "Youth or pensioneer" };
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i}\t- {options[i]}");
                }
                string input = Console.ReadLine();
                if(int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 0:
                            loop = false;
                            Console.WriteLine("Good Bye.");
                            break;
                        case 1:
                            Console.WriteLine("How many are there?");
                            if(int.TryParse(Console.ReadLine(), out int amount))
                            {
                                Console.WriteLine("Please gib ages");
                                int money = 0;
                                bool printSummary = true;
                                for(int i = 0; i < amount; i++)
                                {
                                    if (int.TryParse(Console.ReadLine(), out int age))
                                    {
                                        if (age < 20)
                                        {
                                            Console.WriteLine("Youth:\t80kr");
                                            money += 80;
                                        }
                                        else if(age > 64)
                                        {
                                            Console.WriteLine("Pensioneer:\t90kr");
                                            money += 90;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Regular:\t120kr");
                                            money += 120;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid integer for age; terminating...");
                                        printSummary = false;
                                        break;
                                    }
                                }
                                if (printSummary)
                                {
                                    Console.WriteLine($"A party of {amount} for a total price of {money}kr");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid integer.");
                            }
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
