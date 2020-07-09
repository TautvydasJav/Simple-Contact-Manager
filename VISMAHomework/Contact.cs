using System;

namespace VISMAHomework
{
    class Contact
    {
        private string firstName, lastName, phoneNumber, Address;

        // constructor without address
        public Contact(string firstName, string lastName, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.Address = null;
        }
        // constructor with address
        public Contact(string firstName, string lastName, string phoneNumber, string Address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.Address = Address;
        }
        // get data from class
        public string getFirstName() 
        {
            return firstName;
        }
        public string getLastName()
        {
            return lastName;
        }
        public string getPhoneNumber()
        {
            return phoneNumber;
        }
        public string getAddress()
        {
            return Address;
        }
        // update data in class
        public void updateFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }
        public void updateLastName(string newLastName)
        {
            lastName = newLastName;
        }
        public void updatePhoneNumber(string newPhoneNumber)
        {
            phoneNumber = newPhoneNumber;
        }
        public void updateAddress(string newAddress)
        {
            Address = newAddress;
        }
    }
}
