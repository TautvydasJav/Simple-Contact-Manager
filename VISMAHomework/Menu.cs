using System;

namespace VISMAHomework
{
    class Menu
    {
        public string firstName;
        public string lastName;
        public string phoneNumber;
        public string Address;
        public bool doExit;
        ConsoleKeyInfo keypress;
        private Tasks tasks = new Tasks();

        public void runMenu()
        {
            while (!doExit)
            {
                displayOptions();
                int choice = getSelection();
                performAction(choice);
            }
        }
        private void displayOptions() 
        {
            Console.Title = "Contact Manager";
            Console.WriteLine("Press 1 : To add a new contact", Environment.UserName);
            Console.WriteLine("Press 2 : To update contact information", Environment.UserName);
            Console.WriteLine("Press 3 : To delete a contact", Environment.UserName);
            Console.WriteLine("Press 4 : To view all contacts", Environment.UserName);
            Console.WriteLine("Press 5 : To exit");   
        }
        private int getSelection()
        {
            string input;
            int choice;

            while (true)
            {
                Console.Write("\nEnter your choice using numbers only: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    if (choice < 1 || choice > 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe selection {0} is out of range, please try again.\n", choice);
                        Console.ResetColor();
                        continue;
                    }
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n{0} is not a number, please use numbers only.\n", input);
                    Console.ResetColor();
                }
            }
            return choice;
        }
        private void performAction(int choice)
        {
            switch (choice)
            {
                // adding new contact
                case 1:                 
                    Console.WriteLine("Enter first name, last name, phone number and address (separately) of a contact you want to add : ");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Write("Phone number: ");
                    phoneNumber = Console.ReadLine();
                    while(tasks.checkIfPhoneNumberExists(phoneNumber))
                    {
                        Console.WriteLine("\nPhone number is already in use");
                        Console.Write("Phone number: ");
                        phoneNumber = Console.ReadLine();
                    }
                    Address = null;
                    Console.Write("If you want to add address press 'y' if no 'n' ");
                    keypress = Console.ReadKey();
                    if (keypress.Key.ToString() == "Y")
                    {
                        Console.Write("\nAddress: ");
                        Address = Console.ReadLine();
                    }
                    tasks.addContact(firstName, lastName, phoneNumber, Address);
                    break;
                // updating contact
                case 2:
                    string newFirstName, newLastName, newPhoneNumber;
                    Console.WriteLine("Enter the first name,the last name and the phone number of the contact whose information you want to update: ");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Write("Phone number: ");
                    phoneNumber = Console.ReadLine();

                    Console.Write("\nIf you want to change this contact's first name press 'y' ");
                    keypress = Console.ReadKey();
                    if (keypress.Key.ToString() == "Y")
                    {
                        Console.Write("\nNew first name: ");
                        newFirstName = Console.ReadLine();
                    }
                    else 
                        newFirstName = null;

                    Console.Write("\nIf you want to change this contact's last name press 'y' ");
                    keypress = Console.ReadKey();
                    if (keypress.Key.ToString() == "Y")
                    {
                        Console.Write("\nNew last number: ");
                        newLastName = Console.ReadLine();
                    }
                    else
                        newLastName = null;

                    // asks if new phone number will be added
                    Console.Write("\nIf you want to add new phone number press 'y' ");
                    keypress = Console.ReadKey();
                    if (keypress.Key.ToString() == "Y")
                    {
                        Console.Write("\nNew phone number: ");
                        newPhoneNumber = Console.ReadLine();
                        while (tasks.checkIfPhoneNumberExists(newPhoneNumber))
                        {
                            Console.WriteLine("\nPhone number is already in use");
                            Console.Write("Phone number: ");
                            Console.Write("\n");
                            phoneNumber = Console.ReadLine();
                        }
                    }
                    else
                        newPhoneNumber = null;

                    // asks if address will be added
                    Console.Write("\nIf you want to update address press 'y'");
                    keypress = Console.ReadKey();
                    if (keypress.Key.ToString() == "Y")
                    {
                        Console.Write("\nAddress: ");
                        Address = Console.ReadLine();
                    }
                    else 
                        Address = null;

                    if (newFirstName == null && newLastName == null && newPhoneNumber == null && Address == null)
                        Console.Write("There is nothing to change");
                    else
                        tasks.updateContact(firstName, newFirstName, lastName, newLastName, phoneNumber, newPhoneNumber, Address);
                    break;
                // deleting contact
                case 3:
                    Console.WriteLine("Enter the first name,the last name and the phone number of the contact whom you want to delete: ");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Write("Phone number: ");
                    phoneNumber = Console.ReadLine();
                    tasks.removeContact(firstName, lastName, phoneNumber);
                    Console.WriteLine("{0} {1} deleted successfully", firstName, lastName);
                    break;
                // printing all contacts
                case 4:
                    tasks.printAllContacts();
                    break;
                // exiting and saving all information to a file
                case 5:
                    tasks.outputToFile();
                    doExit = true;
                    break;
            }
        }
    }
}
