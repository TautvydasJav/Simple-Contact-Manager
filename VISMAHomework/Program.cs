using System;

namespace VISMAHomework
{
    public class VISMAHomework
    {
        static void Main(string[] args)
        {
            Initialize();
        }
        private static void Initialize()
        {
            Console.Title = "Contact Manager";
            Console.WriteLine("Hello {0}, and welcome to a simple contact manager by Tautvydas Javaisis.", Environment.UserName);
            Console.Write("Press Q to exit or any other key to continue: ");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Q) { Environment.Exit(0); }
            else
            {
                Console.Title = $"{Environment.UserName}'s Contacts";
                Console.Clear();
                Menu menu = new Menu();
                menu.runMenu();
            }
        }
    }
}
