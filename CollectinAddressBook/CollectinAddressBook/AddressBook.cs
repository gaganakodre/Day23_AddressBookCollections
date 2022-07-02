using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23_CollectionAddressBook
{

    internal class AddressBook
    {

        public Dictionary<string, Contact> contacts;

        public AddressBook()
        {
            contacts = new Dictionary<string, Contact>();
        }

        public void CreateContact()
        {
            Contact tempContact = new Contact();
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

        public void Display()
        {
            foreach (string name in contacts.Keys)
                contacts[name].Display();
        }
    }

}