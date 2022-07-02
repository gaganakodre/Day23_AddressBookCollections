using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23_CollectionAddressBook
{
    internal class AddressBook
    {
        //Creating Object Of Class
        Contact tempContact = new Contact();
        //Creating Dictionary
        public Dictionary<string, Contact> contacts;

        //Initializing Dictionary
        public AddressBook()
        {
            contacts = new Dictionary<string, Contact>();
        }

        //Method Used To Create Contacts
        public void CreateContact()
        {
            tempContact.GetUserInfo();
            string name = tempContact.GetName();
            if (contacts.ContainsKey(name) is false)
            {
                contacts.Add(name, tempContact);
            }
            else
            {
                Console.WriteLine("erorr");
            }
        }

        //Method Used To Add Contacts
        public void AddContacts()
        {
            tempContact.GetUserInfo();
            string name = tempContact.GetName();
            if (contacts.ContainsKey(name) is false)
            {
                contacts.Add(name, tempContact);
                Console.WriteLine("Successfully Added A New Contact!!!");
            }
            else
            {
                Console.WriteLine("erorr");
            }

        }

        //Method Used To Edit Contacts
        public void EditContact()
        {
            Console.WriteLine("Enter name of contact to edit: ");
            string name = Console.ReadLine();
            if (contacts.ContainsKey(name) is true)
            {
                Contact tempContact = new Contact();
                tempContact.GetUserInfo();
                string editName = tempContact.GetName();
                if (contacts.ContainsKey(editName) is false || editName == name)
                {
                    contacts.Remove(name);
                    contacts.Add(editName, tempContact);
                    Console.WriteLine("Successfully Edited And Saved!!!");
                    Display();
                }
                else
                    Console.WriteLine("Edited name is invalid");
            }
            else
                Console.WriteLine("Name does not exist");
        }


        //Method Used To Display The Contacts
        public void Display()
        {
            foreach (string name in contacts.Keys)
            {
                contacts[name].Display();
            }
        }
    }
}