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
            Console.WriteLine("Pizza Creator Menu");
            Console.WriteLine("------------------");
            Console.WriteLine("N)ew Order");
            Console.WriteLine("M)odify Order");
            Console.WriteLine("D)isplay Order");
            Console.WriteLine("Q)uit");

            Console.WriteLine("Please type the first letter of the option you would like to do:");
            ConsoleKeyInfo choice = Console.ReadKey(true);

            while (true)
            {                
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
            if (existing)
            {
                string message = "Would you like to modify the pizza more?";

                do
                {
                    bool valid = false;

                    while (!valid)
                    {
                        Console.WriteLine("Modify: S)ize, M)eats, V)egetables, S(a)uce, C)heese, or D)elivery\n");
                        ConsoleKeyInfo choice = Console.ReadKey(true);

                        switch (choice.KeyChar)
                        {
                            case 'S':
                            case 's':
                                {
                                    Console.WriteLine("Size: " + sizeTotal);
                                    GetSize();
                                    valid = true;
                                    break;
                                }

                            case 'M':
                            case 'm':
                                {
                                    if (meatsTotal == "")
                                    {
                                        Console.WriteLine("You currently have: No Meat\n");
                                    } else
                                    {
                                        Console.WriteLine("You currently have: " + meatsTotal + "\n");
                                    }
                                    GetMeats();
                                    valid = true;
                                    break;
                                }
                            case 'V':
                            case 'v':
                                {
                                    if (vegTotal == "")
                                    {
                                        Console.WriteLine("You currently have: No Vegetables\n");
                                    } else
                                    {
                                        Console.WriteLine("You currently have: " + vegTotal + "\n");
                                    }
                                    GetVegetables();
                                    valid = true;
                                    break;
                                }

                            case 'A':
                            case 'a':
                                {
                                    Console.WriteLine("Sauce: " + sauceTotal);
                                    GetSauce();
                                    valid = true;
                                    break;
                                }

                            case 'C':
                            case 'c':
                                {
                                    Console.WriteLine("Cheese: " + cheeseTotal);
                                    GetCheese();
                                    valid = true;
                                    break;
                                }

                            case 'D':
                            case 'd':
                                {
                                    Console.WriteLine("Take out or Delivery : " + deliveryTotal);
                                    GetDelivery();
                                    valid = true;
                                    break;
                                }

                            default:
                            Console.WriteLine("Please enter a valid option.\n");
                            break;
                        };                     
                    };

                    DisplayOrder();

                } while (ConfirmChoice(message));
            }
            else
            {
                Console.WriteLine("There is no currently existing order.\n");
                return;
            }
        }

        private static void DisplayOrder()
        {

            Console.WriteLine("\n\nCurrent Pizza Order");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Size: {sizeTotal}   ${size}" );
            Console.WriteLine($"Meats: {meatsTotal}   ${meats}");
            Console.WriteLine($"Vegetables: {vegTotal}   ${vegetables}");
            Console.WriteLine($"Sauce: {sauceTotal}   ${sauce}");
            Console.WriteLine($"Cheese: {cheeseTotal}   ${cheese}");
            Console.WriteLine($"Delivery or Take out: {deliveryTotal}   ${delivery}");
            Console.WriteLine("------------------------");
            GetCartPrice();          
        }

        private static void GetCartPrice()
        {
            // Format to 2 decimal places. ToString("0.00"), ("c2")?
            cartPrice = (size + (meats * .5) + (vegetables * .5) + sauce + cheese + delivery);
            Console.WriteLine($"Total Price: ${cartPrice} \n");

        }

        private static void GetSize()
        {
            string message = "Are you satisfied with your choice?";

            Console.WriteLine("\nWhat size pizza would you like?");

            do 
            {
                bool valid = false;

                while (!valid)
                {
                    Console.WriteLine("S)mall($5.00)\nM)edium($6.25)\nL)arge($8.75)\n");
                    ConsoleKeyInfo choice = Console.ReadKey(true);

                    switch (choice.KeyChar)
                    {
                        case 'S':
                        case 's':
                        sizeTotal = "Small";
                        size = 5.00;
                        valid = true;
                        break;


                        case 'M':
                        case 'm':
                        sizeTotal = "Medium";
                        size = 6.25;
                        valid = true;
                        break;


                        case 'L':
                        case 'l':
                        sizeTotal = "Large";
                        size = 8.75;
                        valid = true;
                        break;


                        default:
                        Console.WriteLine("Please enter a valid option.\n");
                        break;
                    };

                    Console.WriteLine("Size: " + sizeTotal);
                };
            } while (!ConfirmChoice(message));

            GetCartPrice();
        }

        private static void GetDelivery()
        {
            string message = "Are you satisfied with your choice?";

            Console.WriteLine("T)ake out($0) or D)elivery($2.50)?");
            ConsoleKeyInfo choice = Console.ReadKey(true);

            do
            {
                bool valid = false;

                while (!valid)
                {
                    switch (choice.KeyChar)
                    {
                        case 'T':
                        case 't':
                        deliveryTotal = "Take out";
                        delivery = 0;
                        valid = true;
                        break;

                        case 'D':
                        case 'd':
                        deliveryTotal = "Delivery";
                        delivery = 2.50;
                        valid = true;
                        break;

                        default:
                        Console.WriteLine("Please enter a valid option.");
                        choice = Console.ReadKey(true);
                        break;
                    };
                    Console.WriteLine("\nTake out or Delivery : " + deliveryTotal);
                };
            } while (!ConfirmChoice(message));
        }

        private static void GetSauce()
        {
            string message = "Are you satisfied with your choice?";

            Console.WriteLine("Would you like T)raditional($0.00), G)arlic ($1.00), or O)regano($1.00) sauce?");
            ConsoleKeyInfo choice = Console.ReadKey(true);

            do
            {
                bool valid = false;

                while (!valid)
                {
                    switch (choice.KeyChar)
                    {
                        case 'T':
                        case 't':
                        sauceTotal = "Traditional";
                        sauce = 0;
                        valid = true;
                        break;

                        case 'G':
                        case 'g':
                        sauceTotal = "Garlic";
                        sauce = 1.00;
                        valid = true;
                        break;

                        case 'O':
                        case 'o':
                        sauceTotal = "Oregano";
                        sauce = 1.00;
                        valid = true;
                        break;

                        default:
                        Console.WriteLine("Please enter a valid option.");
                        choice = Console.ReadKey(true);
                        break;
                    };

                    Console.WriteLine("\nSauce: " + sauceTotal);
                };
            } while (!ConfirmChoice(message));

            GetCartPrice();
        }

        private static void GetCheese()
        {
            string message = "Are you satisfied with your choice?";

            Console.WriteLine("R)egular($0) or E)xtra cheese($1.25)?");
            ConsoleKeyInfo choice = Console.ReadKey(true);

            do
            {
                bool valid = false;

                while (!valid)
                {
                    switch (choice.KeyChar)
                    {
                        case 'R':
                        case 'r':
                        cheeseTotal = "Regular";
                        cheese = 0;
                        valid = true;
                        break;

                        case 'E':
                        case 'e':
                        cheeseTotal = "Extra";
                        cheese = 1.25;
                        valid = true;
                        break;

                        default:
                        Console.WriteLine("Please enter a valid option.");
                        choice = Console.ReadKey(true);
                        break;
                    };

                    Console.WriteLine("\nCheese: " + cheeseTotal);
                };
            } while (!ConfirmChoice(message));

            GetCartPrice();
        }

        private static void GetVegetables()
        {
            string message = "Would you like any vegetables? Every vegetable adds $0.50 to your order. ";    
            string olives = "Black Olives ";
            string mushrooms = "Mushrooms ";
            string onions = "Onions ";
            string peppers = "Peppers ";

            bool olivesCheck = false;
            bool mushroomsCheck = false;
            bool onionsCheck = false;
            bool peppersCheck = false;

            if (ConfirmChoice(message))
            {
                message = "Do you wish to add more vegetables?";
                
                do
                {
                    Console.WriteLine("Would you like: \nB)lack Olives \nM)ushrooms \nO)nions \nP)eppers ");
                    ConsoleKeyInfo choice = Console.ReadKey(true);

                    bool valid = false;

                    while (!valid)
                    {
                        switch (choice.KeyChar)
                        {
                            case 'B':
                            case 'b':
                                {
                                    valid = true;
                                    if (olivesCheck)
                                    {
                                        olivesCheck = false;
                                        vegTotal = vegTotal.Replace("Black Olives ", "");
                                        vegetables--;
                                        break;
                                    } else
                                    {
                                        olivesCheck = true;
                                        vegetables++;
                                        vegTotal += olives;
                                        break;
                                    }                                  
                                }

                            case 'M':
                            case 'm':
                                {
                                    valid = true;
                                    if (mushroomsCheck)
                                    {
                                        mushroomsCheck = false;
                                        vegTotal = vegTotal.Replace("Mushrooms ", "");
                                        vegetables--;
                                        break;
                                    } else
                                    {
                                        mushroomsCheck = true;
                                        vegetables++;
                                        vegTotal += mushrooms;
                                        break;
                                    }
                                }
                            case 'O':
                            case 'o':
                                {
                                    valid = true;
                                    if (onionsCheck)
                                    {
                                        onionsCheck = false;
                                        vegTotal = vegTotal.Replace("Onions ", "");
                                        vegetables--;
                                        break;
                                    } else
                                    {
                                        onionsCheck = true;
                                        vegetables++;
                                        vegTotal += onions;
                                        break;
                                    }
                                }
                            case 'P':
                            case 'p':
                                {
                                    valid = true;
                                    if (peppersCheck)
                                    {
                                        peppersCheck = false;
                                        vegTotal = vegTotal.Replace("Peppers ", "");
                                        vegetables--;
                                        break;
                                    } else
                                    {
                                        peppersCheck = true;
                                        vegetables++;
                                        vegTotal += peppers;
                                        break;
                                    }
                                }

                            default:
                            Console.WriteLine("Please enter a valid option.\n");
                            choice = Console.ReadKey(true);
                            break;
                        };
                    };

                    if (vegTotal == "")
                    {
                        Console.WriteLine("You currently have: No Vegetables\n");
                    } 
                    else
                    {
                        Console.WriteLine("You currently have: " + vegTotal + "\n");
                    }

                } while (ConfirmChoice(message));
            } else
            {
                vegetables = 0;
            }

            GetCartPrice();
        }

        private static void GetMeats()
        {
            string message = "Would you like any meat? Every meat adds $0.50 to your order.";
            string bacon = "Bacon ";
            string ham = "Ham ";
            string pepperoni = "Pepperoni ";
            string sausage = "Sausage ";

            bool baconCheck = false;
            bool hamCheck = false;
            bool pepperoniCheck = false;
            bool sausageCheck = false;

            if (ConfirmChoice(message))
            {

                message = "Do you wish to add or remove meat? To remove meat, select the same option previously selected.";
                do
                {
                    Console.WriteLine("Would you like: \nB)acon \nH)am \nP)epperoni \nS)ausage \n");
                    ConsoleKeyInfo choice = Console.ReadKey(true);

                    bool valid = false;

                    while (!valid)
                    {
                        switch (choice.KeyChar)
                        {
                            case 'B':
                            case 'b':
                                {
                                    valid = true;
                                    if (baconCheck)
                                    {
                                        baconCheck = false;
                                        meatsTotal = meatsTotal.Replace("Bacon ", "");
                                        meats--;
                                        break;
                                    } else
                                    {
                                        baconCheck = true;
                                        meatsTotal += bacon;
                                        meats++;
                                        break;
                                    }
                                }

                            case 'H':
                            case 'h':
                                {
                                    valid = true;
                                    if (hamCheck)
                                    {
                                        hamCheck = false;
                                        meatsTotal = meatsTotal.Replace("Ham ", "");
                                        meats--;
                                        break;
                                    } else
                                    {
                                        hamCheck = true;
                                        meatsTotal += ham;
                                        meats++;
                                        break;
                                    }
                                }

                            case 'P':
                            case 'p':
                                {
                                    valid = true;
                                    if (pepperoniCheck)
                                    {
                                        pepperoniCheck = false;
                                        meatsTotal = meatsTotal.Replace("Pepperoni ", "");
                                        meats--;
                                        break;
                                    } else
                                    {
                                        pepperoniCheck = true;
                                        meatsTotal += pepperoni;
                                        meats++;
                                        break;
                                    }

                                }

                            case 'S':
                            case 's':
                                {
                                    valid = true;
                                    if (sausageCheck)
                                    {
                                        sausageCheck = false;
                                        meatsTotal = meatsTotal.Replace("Sausage ", "");
                                        meats--;
                                        break;
                                    } else
                                    {
                                        sausageCheck = true;
                                        meatsTotal += sausage;
                                        meats++;
                                        break;
                                    }
                                }

                            default:
                            Console.WriteLine("Please enter a valid option.\n");
                            choice = Console.ReadKey(true);
                            break;
                        };
                    };

                    if (meatsTotal == "")
                    {
                        Console.WriteLine("You currently have: No Meat\n");
                    } 
                    else
                    {
                        Console.WriteLine("You currently have: " + meatsTotal + "\n");
                    }

                } while (ConfirmChoice(message));
            } 
            else
            {
                meats = 0;
            }

            GetCartPrice();
        }

        private static bool ConfirmChoice( string message )
        {
            
            do
            {
                Console.WriteLine($"{message} (Y/N)\n");
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;

                    default:
                    Console.WriteLine("Please enter Y)es or N)o.");
                    break;

                };
            } while (true);
        }

        private static string sizeTotal = "";       
        private static string meatsTotal = "";
        private static string vegTotal = "";
        private static string sauceTotal = "";
        private static string cheeseTotal = "";
        private static string deliveryTotal = "";
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

