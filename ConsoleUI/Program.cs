using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random rdm = new Random();

        static void Main(string[] args)
        {
            GetUserInfo();
            PrintGuestsName();
            Console.ReadLine();
        }

    //Start writing your code here
        
        

        static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;
        }

        static int GenerateRandomNumber(int min, int max)
        {
            raffleNumber = rdm.Next(min, max);
            //repeat validator
            if(guests.ContainsKey(raffleNumber)) //if the random number is already in the dictionary
            {
                GenerateRandomNumber(min, max); //do it again until a number that hasn't been used is found
            }
                return raffleNumber;

        }

        static void AddGuestsInRaffle(int raffleNumber, string name)
        {
            //guests.Add(GenerateRandomNumber(min, max), name);
            guests.Add(raffleNumber, name);
        }

        static void PrintGuestsName()
        {
            foreach(KeyValuePair<int,string> name in guests)
            {
                Console.WriteLine($"Name: {name.Value} | Raffle Number: {name.Key}");
            }
        }
        static void GetUserInfo()
        {
            string otherGuest;
            
            do
            {
                string yesNoValidation = "again";
                string name = GetUserInput("Please enter your name: ");
                if (!string.IsNullOrEmpty(name))
                {
                    AddGuestsInRaffle(GenerateRandomNumber(min, max), name);
                    //guests.Add(GenerateRandomNumber(min, max), name); //add to dictionary
                    //yes no validation
                    do
                    {
                        otherGuest = GetUserInput("Do you want to add another name? Yes or No").ToLower();
                        //empty string validator
                        if(string.IsNullOrEmpty(otherGuest))
                        {
                            yesNoValidation = "again";
                        }
                        else if(otherGuest.Equals("yes") || otherGuest.Equals("no"))
                        {
                            yesNoValidation = "no"; //exits out of empty string/yes-no validator loop   
                        }

                    } while (yesNoValidation == "again");
                    
                }
                else
                {
                    otherGuest = "yes";
                }
            } while (otherGuest == "yes");
        }
    static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
