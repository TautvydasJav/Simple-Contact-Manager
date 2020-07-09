using System;
using System.Collections.Generic;
using System.IO;


namespace VISMAHomework
{
    class Tasks
    {
        // File path of .csv file with data
        private string filePath = @"E:\c#Projects\Homework\VISMAHomework\data\contacts.csv";

        private List<Contact> contactsList = new List<Contact>();

        public Tasks() 
        {
            // checks if input file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Input file was not found");
            }

            // fills a list of Contact object with data from input file
            string[] lines = System.IO.File.ReadAllLines(@filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');

                // checks which contructor
                if(fields.Length == 3)
                    contactsList.Add(new Contact(fields[0], fields[1], fields[2]));
                else if(fields.Length == 4)
                    contactsList.Add(new Contact(fields[0], fields[1], fields[2], fields[3]));
                else
                    // for debuging
                    Console.WriteLine("Error while creating a list from input file");
            }
        }
        public void addContact(string firstName, string lastName, string phoneNumber, string address)
        {
            // checks which contructor is needed
            if (address != null)
            {
                contactsList.Add(new Contact(firstName, lastName, phoneNumber, address));
            }
            else
            {
                contactsList.Add(new Contact(firstName, lastName, phoneNumber));
            }
            Console.WriteLine("\n{0} {1} was added successfully", firstName, lastName);
            Console.Write("Press any key to continue: ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();
        }
        public void updateContact(string firstName, string newFirstName, string lastName, string newLastName, string phoneNumber, string newPhoneNumber, string Address)
        {
            // iterates through the list and searches for contact with this first name, last name and phone number
            foreach (Contact contact in contactsList)
            {
                if (contact.getFirstName().Replace(" ", string.Empty).Equals(firstName) && 
                    contact.getLastName().Replace(" ", string.Empty).Equals(lastName) &&
                    contact.getPhoneNumber().Replace(" ", string.Empty).Equals(phoneNumber))
                {
                    // checks which information must be updated and then updates
                    if (newFirstName != null)
                        contact.updateFirstName(newFirstName);
                    if (newLastName != null)
                        contact.updateLastName(newLastName);
                    if (newPhoneNumber != null)
                        contact.updatePhoneNumber(newPhoneNumber);
                    if (Address != null)
                        contact.updateAddress(Address);
                    Console.WriteLine("Contact was updated successfully");
                    Console.Write("Press any key to continue: ");
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }
            Console.WriteLine("Contact was not found");
        }     
        public bool checkIfPhoneNumberExists(string phoneNumber)
        {
            foreach (Contact contact in contactsList)
            {
                if (contact.getPhoneNumber().Replace(" ", string.Empty).Equals(phoneNumber))
                {
                    return true;
                }
            }
            return false;
        }
        public void removeContact(string firstName, string lastName, string phoneNumber)
        {
            int positionCount = 0;
            bool contactFound = false;

            // iterates through the list and counts at wich position contact is
            foreach (Contact contact in contactsList)
            {
                if (contact.getFirstName().Replace(" ", string.Empty).Equals(firstName) &&
                    contact.getLastName().Replace(" ", string.Empty).Equals(lastName) &&
                    contact.getPhoneNumber().Replace(" ", string.Empty).Equals(phoneNumber))
                {
                    contactFound = true;
                    break;
                }
                else
                    positionCount++;
            }
            // if contact was found it is deleted 
            if (contactFound)
            {
                contactsList.RemoveAt(positionCount);
                Console.WriteLine("{0} {1} {2} was deleted successfully", firstName, lastName, phoneNumber);
                Console.Write("Press any key to continue: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("{0} {1} {2} wasn't found", firstName, lastName, phoneNumber);
                Console.Write("Press any key to continue: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
            }
        }
        public void printAllContacts()
        {
            Console.WriteLine("Printing all contacts : ");
            foreach (Contact contact in contactsList)
            {
                Console.WriteLine("{0},{1},{2},{3}", contact.getFirstName(), contact.getLastName(), contact.getPhoneNumber(), contact.getAddress());               
            }
            Console.Write("Press any key to continue: ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();
        }
        public void outputToFile()
        {      
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filePath, false))
            {
                foreach (Contact contact in contactsList)
                {
                    file.WriteLine(contact.getFirstName() + "," + contact.getLastName() + "," + contact.getPhoneNumber() + "," + contact.getAddress());
                }
            }
            Console.Write("Information was saved successfully");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();                  
        }
    }
}
