﻿/*
 * ITSE 1430
 * Sample implementation
 */
using System;

namespace Section1
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

            //PlayWithStrings();
        }

        private static void PlayWithArrays()
        {
            //Console.WriteLine("How many names?");
            int count = ReadInt32("How many names? ", 1);

            string[] names = new string[count];
            for (int index = 0; index < count; ++index)
            {
                Console.WriteLine("Name? ");
                names[index] = Console.ReadLine();
            };

            foreach (string name in names)
            //for (int index = 0; index < names.Length; ++index)
            {
                //read only - not allowed
                // name = "";
                string str = name;
                str = "";
                //Console.WriteLine(Names[index]);
                Console.WriteLine(names);
            };

        }

        private static void PlayWithStrings()
        {
            string hoursString = "10";

            //int hours = Int32.Parse(hoursString);
            //int hours;
            //bool result = Int32.TryParse(hoursString, out hours);
            //bool result = Int32.TryParse(hoursString, out int hours);

            //hoursString = hours.ToString();
            //4.75.ToString();
            //457.ToString();
            //Console.ReadLine().ToString();

            string message = "Hello\tworld";
            string filePath = "C:\\Temp\\Test";

            //Verbatim strings
            filePath = @"C:\Temp\Test";

            //Concat
            string firstName = "Bob";
            string lastName = "Smith";
            string name = firstName + " " + lastName;

            //Strings are immutable - this produces a new string
            //name = "Hello " + name;
            Console.WriteLine("Hello " + name); // Approach 1
            Console.WriteLine("Hello {0} {1}", firstName, lastName); // Approach 2
            string str = String.Format("Hello {0}", name); // Approach 3
            Console.WriteLine(str); // Approach 4

            //Approach 4
            Console.WriteLine($"Hello {firstName} {lastName}");

            // Null vs empty
            string missing = null;
            string empty = "";
            string empty2 = String.Empty;

            //Checking for empty strings
            //if (firstName.Length == 0)
            //if(firstName != null && firstName != "")
            if (!String.IsNullOrEmpty(firstName))
                Console.WriteLine(firstName);

            //Other stuff
            string upperName = firstName.ToUpper();
            string lowername = firstName.ToLower();

            //Comparison
            bool areEqual = firstName == lastName;
            areEqual = firstName.ToLower() == lastName.ToLower();
            areEqual = String.Compare(firstName, lastName, true) == 0;

            bool starsWithA = firstName.StartsWith("A");
            bool endsWithA = firstName.EndsWith("A");
            bool hasA = firstName.IndexOf("A") >= 0;
            string subset = firstName.Substring(4);

            //Clean up
            string cleanMe = firstName.Trim();
            string makeLonger = firstName.PadLeft(20); //PadRight

        }

        private static bool DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("A)dd Movie");
                Console.WriteLine("E)edit Movie");
                Console.WriteLine("D)elete Movie");
                Console.WriteLine("V)iew Movies");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();
                switch (input[0])
                {
                    case 'a':
                    case 'A':
                    AddMovie();
                    return true;

                    case 'e':
                    case 'E':
                    EditMovie();
                    return true;

                    case 'd':
                    case 'D':
                    DeleteMovie();
                    return true;

                    case 'v':
                    case 'V':
                    ViewMovies();
                    return true;

                    case 'q':
                    case 'Q':
                    return false;

                    default:
                    Console.WriteLine("Please enter a valid value.");
                    break;

                };
            };
        }

        private static void AddMovie()
        {
            name = ReadString("Enter a name: ", true);
            description = ReadString("Enter a description: ");
            runLength = ReadInt32("Enter a run length (in minutes): ", 0);
        }

        private static void EditMovie()
        {
            ViewMovies();

            var newName = ReadString("Enter a name ( or press ENTER for default): ", false);
            if (!string.IsNullOrEmpty(newName))
                name = newName;

            var newDescription = ReadString("Enter a description: ");
            if (!string.IsNullOrEmpty(newDescription))
                description = newDescription;

            var newRunLength = ReadInt32("Enter a run length (in minutes): ", 0);
            if (newRunLength > 0)
                runLength = newRunLength;
        }

        private static void DeleteMovie()
        {
            if (Confirm("Are you sure you want to delete this movie?"))
            {
                // "Delete" the movie
                name = null;
                description = null;
                runLength = 0;
            };
        }

        private static bool Confirm( string message )
        {
            Console.WriteLine($"{message} (Y/N)");

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;
                };
            } while (true);

            //if (key.KeyChar == 'Y')
            //    return true;
            //else if (key.KeyChar == 'N')
            //   return false;
        }

        private static void ViewMovies()
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("No movies available");
                return;
            }
            Console.WriteLine(name);

            if (!String.IsNullOrEmpty(description))
                Console.WriteLine(description);

            //Console.WriteLine("Run length (mins) = ", runLength);
            Console.WriteLine($"Run length = {runLength} mins");


        }
        private static int ReadInt32( string message, int minValue )
        {
            while (true)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out var result))
                {
                    if (result >= minValue)
                        return result;
                };

                Console.WriteLine($"You must enter an integer value >= {minValue}");

            }

        }

        private static string ReadString( string message )
        {
            return ReadString(message, false);
        }

        private static string ReadString( string message, bool required )
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                Console.WriteLine("You must enter a value");
            }
        }

        //A movie
        static string name;
        static string description;
        static int runLength;
        //static DateTime releaseDate;
    }
}