using System;
using System.Linq;

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
                string[] options = { "Exit program", "Fictionary Cinema(TM)", "Repeater", "The third word" };
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
                                bool[] easterEgg = new bool[amount];
                                
                                for(int i = 0; i < amount; i++)
                                {
                                    if (int.TryParse(Console.ReadLine(), out int age))
                                    {
                                        if (age < 0)
                                        {
                                            Console.WriteLine("Unborn child:\tfree entry");
                                            easterEgg[i] = true;
                                        }
                                        else if (age < 5)
                                        {
                                            Console.WriteLine("Toddler:\tfree entry");
                                        }
                                        else if (age < 20)
                                        {
                                            Console.WriteLine("Youth:\t80kr");
                                            money += 80;
                                        }
                                        else if (age > 100)
                                        {
                                            Console.WriteLine("Super old pensioneer:\tfree entry");
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

                                amount -= easterEgg.Count(x => x);
                                
                                if (printSummary && amount > 0)
                                {
                                    Console.WriteLine($"A party of {amount} for a total price of {money}kr\nPlease enjoy your stay!\n");
                                }
                                else if (printSummary && easterEgg.Length > 0)
                                {
                                    Console.WriteLine("Nobody's born yet...");
                                }
                                else if (printSummary)
                                {
                                    Console.WriteLine("Staying at home saves money.");
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
                        //The third word
                        case 3:
                            Console.WriteLine("Write three words separated by spaces, and I'll tell you the third word!");
                            //A one-liner. First, read user input. Second, split ' '.
                            //Third, Lambda function to remove empty strings from array.
                            //Lastly, make it an array again
                            string[] inpoot = Console.ReadLine().Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            
                            if(inpoot.Length == 3) //Correct input
                            {
                                Console.WriteLine($"Yout third word is...\n{inpoot[2]}!!!");
                            }
                            else //Incorrect input
                            {
                                Console.WriteLine("You didn't write three words, so I'll terminate this section and you'll have to try again...");
                            }
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
                Console.WriteLine("\n----------");
            }
        }
    }
}
