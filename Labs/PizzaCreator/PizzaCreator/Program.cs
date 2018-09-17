/* Jeremy Lynch
 * ITSE 1430 - 20630
 * Pizza Creator
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreator
{
    class Program
    {
        static void Main( string[] args )
        {
            bool notQuit;
            do
            {
                notQuit = DisplayMenu();
            } while (notQuit);
        }

        private static bool DisplayMenu()
        {            
            Console.WriteLine("Please type the first letter of the option you would like to do:");
            ConsoleKeyInfo choice = Console.ReadKey(true);

            while (true)
            {
                Console.WriteLine("Pizza Creator Menu");
                Console.WriteLine("------------------");
                Console.WriteLine("N)ew Order");
                Console.WriteLine("M)odify Order");
                Console.WriteLine("D)isplay Order");
                Console.WriteLine("Q)uit");

                switch (choice.KeyChar)
                {
                    case 'N':
                    case 'n':
                    NewOrder();
                    return true;

                    case 'M':
                    case 'm':
                    ModifyOrder();
                    return true;

                    case 'D':
                    case 'd':
                    DisplayOrder();
                    return true;

                    case 'Q':
                    case 'q':
                    return false;

                    default:
                    Console.WriteLine("Please enter a valid menu option: ");
                    choice = Console.ReadKey(true);
                    break;
                };
            };
        }

        private static void NewOrder()
        {
            if (existing)
            {

                string message = "There is a currently existing order. Would you like to replace it?";
                if (ConfirmChoice(message))
                {
                    existing = false;
                } 
                else
                {
                    return;
                }
            };


            GetSize();
            GetMeats();
            GetVegetables();
            GetSauce();
            GetCheese();
            GetDelivery();


            DisplayOrder();
            existing = true;
        }

        private static void ModifyOrder()
        {
            throw new NotImplementedException();
        }

        private static void DisplayOrder()
        {

            Console.WriteLine("Current Pizza Order");
            Console.WriteLine("-------------------");
            Console.WriteLine("Size:  " + size);
            Console.WriteLine("Meats: " + meats);
            Console.WriteLine("Vegetables: " + vegetables);
            Console.WriteLine("Sauce: " + sauce);
            Console.WriteLine("Cheese: " + cheese);
            Console.WriteLine("Delievery or Take out: " + delivery);
            GetCartPrice();
        }

        private static void GetCartPrice()
        {
            // Format to 2 decimal places. ToString("0.00"), ("c2")?
            cartPrice = (size + (meats * .5) + (vegetables * .5) + sauce + cheese + delivery);
            Console.WriteLine($"\nCurrent cart price is: ${cartPrice}");

        }

        private static void GetSize()
        {
            string message = "Are you satisfied with your choice?";

            Console.WriteLine("\nWhat size pizza would you like?");
            Console.WriteLine("S)mall (5.00) \nM)edium($6.25)\nL)arge($8.75)");
            ConsoleKeyInfo choice = Console.ReadKey(true);

            do
            {
                switch (choice.KeyChar)
                {
                    case 'S':
                    case 's':
                    size = 5.00;
                    break;

                    case 'M':
                    case 'm':
                    size = 6.25;
                    break;


                    case 'L':
                    case 'l':
                    size = 8.75;
                    break;

                    default:
                    Console.WriteLine("Please enter a valid menu option: ");
                    choice = Console.ReadKey(true);
                    break;
                };

            } while (!ConfirmChoice(message));

            GetCartPrice();
        }

        private static void GetDelivery()
        {
            string message = "Are you satisfied with your choice?";

            Console.WriteLine("\nT)ake out($0) or D)elivery($2.50)?");
            ConsoleKeyInfo choice = Console.ReadKey(true);

            do
            {
                switch (choice.KeyChar)
                {
                    case 'T':
                    case 't':
                    delivery = 0;
                    break;

                    case 'D':
                    case 'd':
                    delivery = 2.50;
                    break;

                    default:
                    Console.WriteLine("Please enter a valid option.");
                    choice = Console.ReadKey(true);
                    break;
                };
            } while (!ConfirmChoice(message));
        }

        private static void GetSauce()
        {
            string message = "Are you satisfied with your choice?";

            Console.WriteLine("\nWould you like T)raditional, G)arlic ($1.00), or O)regano($1.00) sauce?");
            ConsoleKeyInfo choice = Console.ReadKey(true);

            do
            {
                switch (choice.KeyChar)
                {
                    case 'T':
                    case 't':
                    sauce = 1.00;
                    break;

                    case 'D':
                    case 'd':
                    sauce = 1.00;
                    break;

                    case 'O':
                    case 'o':
                    sauce = 1.00;
                    break;

                    default:
                    Console.WriteLine("Please enter a valid option.");
                    choice = Console.ReadKey(true);
                    break;
                };
            } while (!ConfirmChoice(message));
        }

        private static void GetCheese()
        {
            string message = "Are you satisfied with your choice?";

            Console.WriteLine("\nR)egular($0) or E)xtra cheese($1.25)?");
            ConsoleKeyInfo choice = Console.ReadKey(true);

            do
            {
                switch (choice.KeyChar)
                {
                    case 'R':
                    case 'r':
                    cheese = 0;
                    break;

                    case 'E':
                    case 'e':
                    cheese = 1.25;
                    break;

                    default:
                    Console.WriteLine("Please enter a valid option.");
                    choice = Console.ReadKey(true);
                    break;
                };
            } while (!ConfirmChoice(message));


        }

        private static void GetVegetables()
        {
            string message = "\nWould you like any vegetables? Every vegetable adds $0.50 to your order. ";
            string vegTotal = "";
            string olives = "Black Olives ";
            string mushrooms = "Mushrooms ";
            string onions = "Onions ";
            string peppers = "Peppers ";

            if (ConfirmChoice(message))
            {
                message = "Do you wish to add more vegetables?";
                
                do
                {
                    Console.WriteLine("Would you like: \nB)lack Olives \nM)ushrooms \nO)nions \nP)eppers ");
                    ConsoleKeyInfo choice = Console.ReadKey(true);

                    switch (choice.KeyChar)
                    {
                        case 'B':
                        case 'b':
                        vegetables++;
                        vegTotal += olives;
                        break;

                        case 'M':
                        case 'm':
                        vegetables++;
                        vegTotal += mushrooms;
                        break;

                        case 'O':
                        case 'o':
                        vegetables++;
                        vegTotal += onions;
                        break;

                        case 'P':
                        case 'p':
                        vegetables++;
                        vegTotal += peppers;
                        break;

                        default:
                        Console.WriteLine("Please enter a valid option.");
                        choice = Console.ReadKey(true);
                        break;
                    };
                } while (ConfirmChoice(message));
            } else
            {
                vegetables = 0;
            }
        }

        private static void GetMeats()
        {
            string message = "\nWould you like any meat? Every meat adds $0.50 to your order.";
            string bacon = "Bacon ";
            string ham = "Ham ";
            string pepperoni = "Pepperoni ";
            string sausage = "Sausage ";
            string meatsTotal = "";

            if (ConfirmChoice(message))
            {

                message = "Do you wish to add more meat?";
                do
                {
                    Console.WriteLine("Would you like: \nB)acon \nH)am \nP)epperoni \nS)ausage ");
                    ConsoleKeyInfo choice = Console.ReadKey(true);

                    switch (choice.KeyChar)
                    {
                        case 'B':
                        case 'b':
                        meatsTotal += bacon;
                        meats++;
                        break;

                        case 'H':
                        case 'h':
                        meatsTotal += ham;
                        meats++;
                        break;

                        case 'P':
                        case 'p':
                        meatsTotal += pepperoni;
                        meats++;
                        break;

                        case 'S':
                        case 's':
                        meatsTotal += sausage;
                        meats++;
                        break;

                        default:
                        Console.WriteLine("Please enter a valid option.");
                        choice = Console.ReadKey(true);
                        break;
                    };

                    Console.WriteLine("You currently have: " + meatsTotal);
                } while (ConfirmChoice(message));
            } else
            {
                meats = 0;
            }

            GetCartPrice();
        }

        private static bool ConfirmChoice( string message )
        {
            Console.WriteLine($"{message} (Y/N)");
            ConsoleKeyInfo key = Console.ReadKey(true);
            do
            {
                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;

                    default:
                    Console.WriteLine("Please enter a valid option.");
                    break;
                };
            } while (true);
        }

        private static double size;
        private static double meats = 0;
        private static double vegetables = 0;
        private static double sauce;
        private static double cheese;
        private static double delivery;
        private static double cartPrice;
        private static bool existing = false;
    }
}

