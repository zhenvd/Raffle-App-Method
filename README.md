# Raffle(Method Version)

You are hosting a party and want to give a lucky guest a prize before the party is over. You ask your friend Roger to help you create a console app to do that.

**_The app should allow you to collect everyone name and give each person a numbered ticket (4 digits)._**

***
1. Fork this repo
1. Clone it on you local machine in the folder you want it.
***

### Variables
1. Declare a private static empty Dictionary<int, string> named **guests**
1. Declare and initialize a private static integer named **min** with value 1000
2. Declare and initialize a private static integer named **max** with value 9999
3. Create a private static integer named **raffleNumber**
4. Create an instance of the random class and store it a variable name **rdm** ``` private static Random _rdm = new Random();```

***
### Methods

_**You will need to create 7 methods for this assignment**_

1. Create a method that return a string and name it **GetUserInput**. This method will take a string parameter called message
    * This method should make it easier for you to get input from the user.
    * instead of using Console.WriteLine and Console.ReadLine all the time just call this method and pass the string message as an argument. This method should return the data you collect from the user, just like console.Readline return a string as output.
  
2. Create a method that returns nothing and name it **GetUserInfo().**
   1. Inside your method use a loop to ask the user to enter the name of the guest. You should call the method **GetUserInput** to do that and store it in the name variable that you created
   2. The loop will end when the user type "yes". use a separate variable to store the input ex: ```Console.WriteLine("Do you want to add another name? ) moreGuest = Console.Readline()```
   3. create a 4 digits random number by calling the **GenerateRandomNumber()**(see description for this method below) and store it in the **raffleNumber** variable that you created.
   4. **Validate your input.** Keep asking for the guest's name if user enter an empty string
   5. Same thing for your random number, validate the data. You can't have the same raffleNumber. You can use a loop to keep calling **GenerateRandomNumber()** method.
   6. Add both the raffleNumber and guest name in the dictionary by calling **AddGuestsInRaffle()** method (see description below)

3. Create a method that return an integer and name it **GenerateRandomNumber().**
    * This method should take **_2 parameters int min, and int max_**, This method should return an integer number between min and max.

4. Create a method that returns nothing and name it **AddGuestsInRaffle().** This method should take **2 parameters int raffleNumber and string guest**
    * Add the raffleNumber and the guest name that you collect from the user and store them in the guests dictionary that you created.

5. Create a void method and name it **PrintGuestsName()**
    * Use a loop to print the name of all your guests with their assigned raffleNumber

6. Create a method and call it **GetRaffleNumber().** This method should take a Dictionary<int, string> as parameters you can call it anything, people for example.
    * This method should allow you to get a random key value from the dictionary and return it as winner number.**(I'll let you do the work here. If stuggled for more than 30 mns, ask your TA for hints)**

7. Create a void static method and name it **PrintWinner()**
    * This method should print the name of the winner and the raffleNumber
    * You should be able to call the **GetRaffleNumber().** method and store it in an int variable named winnerNumber
    * You should be able to get the winnerName once you have the winnerNumber.
    * ``` Console.WriteLine($"The Winner is: {WinnerName} with the #{winnerNumber}"); ```
***
### Main method

Please add this code in your main method once you are finished writing all your code.

```
 static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            
          //  Thread.Sleep(2300);

          MultiLineAnimation();
          PrintGuestsName();
            
            PrintWinner();
            
        }

```

### <ins>Important points:</ins>
* Follow DRY principles **(DO NOT REPEAT YOURSELF)** as much as possible. Call your methods when necessary
* All your methods should be private static
* When you declare any variable in class level(outside your method) and want to use it inside a static method, this varibale has to be also static
