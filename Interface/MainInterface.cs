using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Domain.Abstractions;
using Domain.Repositories;
using Domain.Services;
using Domain.Entities.Animals;
using Domain.Entities.Things;



namespace Interface
{
    public class MainInterface
    {
        /// <summary>
        /// This method implements the main menu.
        /// </summary>
        /// <param name="zoo"></param>

        public void ShowMenu(Zoo zoo)
        {
            SayHello();
            Console.WriteLine("Welcome to Moscow Zoo!\n");
            
            bool exit = false;
            while (!exit)
            {
                // Main menu.
                Menu menu = new Menu("Use up/down keys to choose menu item.",
                    new string[]
                    {
                        "1. Add animal", "2. Add thing", "3. Print all animals", "4. Print all things",
                        "5. Print contact animals", "6. Print food cunsumption", "7. Exit"
                    });
                
                // Getting user's choice.
                int num = menu.ActMenu();
                switch (num)
                {
                    // Adding animal.
                    case 1:
                        Menu animalMenu = new Menu("Choose animal",
                            new string[] { "1. Monkey", "2. Rabbit", "3. Tiger", "4. Wolf" });
                        int animalNum = animalMenu.ActMenu();
                        Console.WriteLine("Enter name of your animal");
                        
                        // Fields of animal.
                        string? name;
                        int food;
                        int kindness;
                        bool state;

                        // Checking correctness of name.
                        while ((name = Console.ReadLine()) == null || name.Length == 0)
                        {
                            Console.WriteLine("Please try again");
                        }

                        Console.WriteLine("Enter the amount of consuming food in kilograms");
                        
                        // Checking correctness of food enter.
                        while (!int.TryParse(Console.ReadLine(), out food))
                        {
                            Console.WriteLine("Please try again");
                        }

                        // Asking about health.
                        Menu isHealth = new Menu("Is the animal healthy?", new string[] { "1. Yes", "2. No" });
                        state = isHealth.ActMenu() == 1 ? true : false;
                        if (!state)
                        {
                            Console.WriteLine("Animal won't be added in the zoo");
                            break;
                        }
                        // If animal is herbo ask for kindness value.
                        if (animalNum == 1 || animalNum == 2)
                        {
                            Console.WriteLine("Enter kindness: the number from 0 to 10");
                            while (!int.TryParse(Console.ReadLine(), out kindness) || kindness < 0 || kindness > 10)
                            {
                                Console.WriteLine("Please try again");
                            }

                            if (animalNum == 1)
                            {
                                zoo.AddAnimal(new Monkey(name, food, state, kindness));
                            }
                            else
                            {
                                zoo.AddAnimal(new Rabbit(name, food, state, kindness));
                            }
                        }
                        else if (animalNum == 3)
                        {
                            zoo.AddAnimal(new Tiger(name, food, state));
                        }
                        else
                        {
                            zoo.AddAnimal(new Wolf(name, food, state));

                        }

                        break;
                    // Adding thing.
                    case 2:
                        Menu thingMenu = new Menu("Choose animal",
                            new string[] { "1. Table", "2. Computer" });
                        int thingNum = thingMenu.ActMenu();
                        
                        // Adding table.
                        if (thingNum == 1)
                        {
                            zoo.AddThing(new Table());
                        }
                        
                        // Adding computer.
                        else
                        {
                            zoo.AddThing(new Computer());
                        }

                        break;
                    
                    // Printing animals.
                    case 3:
                        var animals = zoo.GetAnimals();
                        
                        // Checking existency of any animal.
                        if (!animals.Any())
                        {
                            Console.WriteLine("There are no animals");
                        }
                        for (int i = 0; i < animals.Count(); i++)
                        {
                            Console.WriteLine(animals[i]);
                        }

                        break;
                    
                    // Printing things.
                    case 4:
                        var things = zoo.GetThings();
                        
                        // Checking existency of any thing.
                        if (!things.Any())
                        {
                            Console.WriteLine("There are no things");
                        }
                        for (int i = 0; i < things.Count(); i++)
                        {
                            Console.WriteLine(things[i]);
                        }

                        break;
                    
                    // Printing contact animals.
                    case 5:
                        var contactAnimals = zoo.GetContactAnimals();
                        
                        // Checking existency of contact animals.
                        if (!contactAnimals.Any())
                        {
                            Console.WriteLine("There are no contact animals");
                        }
                        for (int i = 0; i < contactAnimals.Count(); i++)
                        {
                            Console.WriteLine(contactAnimals[i]);
                        }
                        break;
                    case 6:
                        Console.WriteLine($"Animals consume {zoo.Food()}");
                        break;
                    case 7:
                        exit = true;
                        break;

                }
                Menu isContinue = new Menu("Do you want to exit?", new string[] {"1. Yes", "2. No"});
                if (isContinue.ActMenu() == 1)
                {
                    exit = true;
                    
                    
                }
            }
        }
        /// <summary>
        /// This method prints greeting according to date.
        /// </summary>
        private void SayHello()
        {
            if (DateTime.Now.Hour < 12 && DateTime.Now.Hour >= 5)
                PrintColor("Good morning!", ConsoleColor.Yellow, ConsoleColor.Yellow);

            else if (DateTime.Now.Hour < 17 && DateTime.Now.Hour >= 12)
                PrintColor("Good afternoon!", ConsoleColor.Magenta, ConsoleColor.Magenta);

            else if (DateTime.Now.Hour < 22 && DateTime.Now.Hour >= 17)
                PrintColor("Good evening!", ConsoleColor.Blue, ConsoleColor.Blue);

            else
                PrintColor("Good night!", ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);
        }

        /// <summary>
        /// This method prints colorful text
        /// </summary>
        /// <param name="str"></param>
        /// <param name="colorDay"></param>
        /// <param name="colorNight"></param>
        public static void PrintColor(string str, ConsoleColor colorDay, ConsoleColor colorNight)
        {
            // Day time colors.
            if (DateTime.Now.Hour <= 20 && DateTime.Now.Hour >= 7)
            {
                Console.ForegroundColor = colorDay;
                Console.WriteLine(str);
                Console.ResetColor();
            }
            // Night time colors.
            else
            {
                Console.ForegroundColor = colorNight;
                Console.WriteLine(str);
                Console.ResetColor();
            }
        }
    }
}