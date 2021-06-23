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
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            PrintWinner();
            MultiLineAnimation();
        }

    //Start writing your code here
        
        
        //for all user string input related activities
        static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;
        }

        //generates a random number. also validates to make sure the number hasn't been used before by checking the dictionary
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

        //actually adds the name of the guest and their raffle number into the dictionary
        static void AddGuestsInRaffle(int raffleNumber, string name)
        {
            guests.Add(raffleNumber, name); //adds to dictionary
        }

        //prints all raffle participants and their number
        static void PrintGuestsName()
        {
            foreach(KeyValuePair<int,string> name in guests)
            {
                Console.WriteLine($"Name: {name.Value} | Raffle Number: {name.Key}");
            }
        }

        //picks a random winning raffle number from the existing pool of participants
        static int GetRaffleNumber(Dictionary<int,string> guests)
        {
            //List<int> numberPicker = guests.Keys.ToList();
            int numberIndex = rdm.Next(guests.Count);
            //int numberSelected = guests.Keys[numberIndex];
            KeyValuePair<int, string> winningPair = guests.ElementAt(numberIndex);
            int numberSelected = winningPair.Key;
            return numberSelected;
        }

        //outputs the winner by comparing the number randomly selected from GetRaffleNumber method to the Keys in the dictionary
        static void PrintWinner()
        {
            int numberWinner = GetRaffleNumber(guests);
            foreach(KeyValuePair<int,string> person in guests)
            {
                if(person.Key.Equals(numberWinner))
                {
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine($"The Winner is: {person.Value} with the #{person.Key}");
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine("Press enter to exit");
                    Console.ReadLine(); //so the debug console wouldn't leave me
                }
            }
        }

        //this is the method that ask for user name input as well as performs most input validations
        //and also repeats question until appropriate input is entered.
        static void GetUserInfo()
        {
            string otherGuest;
            
            do
            {
                string yesNoValidation = "again";
                string name = GetUserInput("Please enter your name: "); //calls the GetUserInput method
                if (!string.IsNullOrEmpty(name))
                {
                    AddGuestsInRaffle(GenerateRandomNumber(min, max), name);
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

        //a really nice animation that I did not make
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
