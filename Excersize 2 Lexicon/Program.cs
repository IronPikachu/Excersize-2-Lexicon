using System;
using System.Linq;
using System.Text;

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

            //Enter the options, remember to add them to the case!
            string[] options = { "Exit program", "Fictionary Cinema(TM)", "Repeater", "The third word" };
            //Make things more efficient. In a program of this caliber, it wont matter, but for large projects it'd be better
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < options.Length; i++)
            {
                sb.Append($"{i}\t- {options[i]}\n");
            }

            //Create a string to be shown each time the loop iterates
            string menu = sb.ToString();

            while (loop)
            {
                Console.WriteLine(menu);
                
                string input = Console.ReadLine();
                if(int.TryParse(input, out int option))
                {
                    switch (option)
                    {   
                        //Exit Program
                        case 0:
                            ExitProgram(ref loop);
                            break;
                        //Fictionary Cinema(TM)
                        case 1:
                            FictionaryCinema();
                            break;
                        //Repeater
                        case 2:
                            Repeater();
                            break;
                        //The third word
                        case 3:
                            TheThirdWord();
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
                if (loop)
                {
                    Console.WriteLine("\n----------");
                }
            }
        }

        static void ExitProgram(ref bool b)
        {
            b = false;
            Console.WriteLine("Good Bye.");
        }

        static void FictionaryCinema()
        {
            Console.WriteLine("Welcome to Fictionary Cinema(TM)\nHow many are there?");
            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                
                int money = 0;
                bool printSummary = true;
                bool[] easterEgg = new bool[amount];

                Console.WriteLine(FCAmountResponse(amount));

                for (int i = 0; i < amount; i++)
                {
                    if (int.TryParse(Console.ReadLine(), out int age))
                    {
                        FCMoneyHandler(age, ref money, out easterEgg[i]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid integer for age; terminating...");
                        printSummary = false;
                        break;
                    }
                }

                amount -= easterEgg.Count(x => x);

                Console.WriteLine(FCSummaryResponse(amount, money, printSummary, easterEgg.Length));

            }
            else
            {
                Console.WriteLine("Invalid integer. Terminating...");
            }
        }

        private static string FCAmountResponse(int a)
        {
            if (a == 1)
            {
                return "Please tell me your age...";
            }
            else if (a == 0)
            {
                return "";
            }
            else if (a < 0)
            {
                return "U 'avin a laugh m8?";
            }
            //More than 1 person
            return "Please give ages of everyone...";
        }

        private static void FCMoneyHandler(int a, ref int money, out bool e)
        {
            if (a < 0)
            {
                Console.WriteLine("Unborn child:\tfree entry");
                e = true;
                return;
            }
            else if (a < 5)
            {
                Console.WriteLine("Toddler:\tfree entry");
            }
            else if (a < 20)
            {
                Console.WriteLine("Youth:\t80kr");
                money += 80;
            }
            else if (a > 100)
            {
                Console.WriteLine("Super old pensioneer:\tfree entry");
            }
            else if (a > 64)
            {
                Console.WriteLine("Pensioneer:\t90kr");
                money += 90;
            }
            else
            {
                Console.WriteLine("Regular:\t120kr");
                money += 120;
            }
            e = false;
        }

        private static string FCSummaryResponse(int amount, int money, bool printSummary = true, int eegg = 0)
        {
            if (printSummary && amount > 1)
            {
                return $"A party of {amount} for a total price of {money}kr\nPlease enjoy your stay!\n";
            }
            else if (printSummary && amount == 1)
            {
                return $"For you alone it will cost {money}kr\nPlease enjoy your stay sweetie!\n";
            }
            else if (printSummary && eegg > 0)
            {
                return "Nobody's born yet...";
            }
            else if (printSummary)
            {
                return "Staying at home saves money.";
            }
            return "Aliquid erravit, me paenitet ...";
        }

        static void Repeater()
        {
            Console.WriteLine("Enter anything you like:");
            string userInput = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(string.Format("{0}. {1}, ", i + 1, userInput));
            }
            Console.WriteLine(); //Newline after the repeater
        }

        static void TheThirdWord()
        {
            Console.WriteLine("Write three words separated by spaces, and I'll tell you the third word!");
            //A one-liner. First, read user input. Second, split ' '.
            //Third, Lambda function to remove empty strings from array.
            //Lastly, make it an array again
            string[] inpoot = Console.ReadLine().Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

            if (inpoot.Length == 3) //Correct input
            {
                Console.WriteLine($"Yout third word is...\n{inpoot[2]}!!!");
            }
            else //Incorrect input
            {
                Console.WriteLine("You didn't write three words, so I'll terminate this section and you'll have to try again...");
            }
        }
    }
}
