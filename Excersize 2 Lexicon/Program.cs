using System;

namespace Excersize_2_Lexicon
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start message
            Console.WriteLine("Welcome to the Main Menu!\nYou will be navigating by typing in numbers to test different funktions.");
            //Run the program while true, false upon exit
            bool loop = true;

            while (loop)
            {
                //Enter the options, remember to add them to the case!
                string[] options = { "Exit program", "Fictionary Cinema(TM)", "Repeater" };
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i}\t- {options[i]}");
                }
                string input = Console.ReadLine();
                if(int.TryParse(input, out int option))
                {
                    switch (option)
                    {   
                        //Exit Program
                        case 0:
                            loop = false;
                            Console.WriteLine("Good Bye.");
                            break;
                        //Fictionary Cinema(TM)
                        case 1:
                            Console.WriteLine("Welcome to Fictionary Cinema(TM)\nHow big is your party?");
                            if(int.TryParse(Console.ReadLine(), out int amount))
                            {
                                Console.WriteLine("Please give ages of everyone...");
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
                                    Console.WriteLine($"A party of {amount} for a total price of {money}kr\nPlease enjoy your stay!\n");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid integer. Terminating...");
                            }
                            break;
                        //Repeater
                        case 2:
                            Console.WriteLine("Enter anything you like:");
                            string userInput = Console.ReadLine();
                            for(int i = 0; i < 10; i++)
                            {
                                Console.Write(string.Format("{0}. {1}, ", i + 1, userInput));
                            }
                            Console.WriteLine(); //Newline after the repeater
                            break;
                        //Bad integer
                        default:
                            Console.WriteLine("Wrong integer!");
                            break;
                    }
                }
                else //Input was not an integer
                {
                    Console.WriteLine("Please type an integer.");
                }
            }
        }
    }
}
