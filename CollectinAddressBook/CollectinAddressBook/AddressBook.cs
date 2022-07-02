using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAddressBook
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

        public void ContactMenu()
        {
            bool flag = false;
            do
            {
                Console.WriteLine("1. Create contacts \n2. Add contact \n3. Edit contact \n4. Delete Contact \n5. Add Multiple Contacts \n6.Display contacts in Addressbook \n7.Search using filter \n8. Exit");
                Console.Write("\nEnter Number to Execute the Address book Program : ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Creating A New Contact");
                        CreateContact();
                        tempContact.Display();
                        break;

                    case 2:
                        Console.WriteLine("Adding A New Contact");
                        AddContacts();
                        Console.WriteLine("New Contact:");
                        tempContact.Display();
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("Editing Existing Contact");
                        EditContact();
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine("Deleting Existing Contact");
                        DeleteContact();
                        Console.WriteLine();
                        break;


                    case 5:
                        Console.WriteLine("Adding Multiple Contacts");
                        AddMultiple();
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.WriteLine("Displaying Contacts");
                        foreach (Contact contact in contacts.Values)
                        {
                            tempContact.Display();
                        }
                        break;

                    case 7:
                        DisplayFilteredList();
                        break;

                    case 8:
                        Console.WriteLine("If You Want To Exit Then Press Enter");
                        flag = true;
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (flag == false);
        }

        //Method Used To Create Contacts
        public void CreateContact()
        {
            tempContact.GetUserInfo();
            string name = tempContact.GetName();
            if (contacts.ContainsKey(name) is false)
            {
                contacts.Add(name, tempContact);
                Console.WriteLine("Contact created successfully..");
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
            //UC-7 Ensuring No Duplicates
            try
            {
                if (contacts.Any(e => e.Value.Equals(tempContact)) is false)
                {
                    contacts.Add(tempContact.GetName(), tempContact);
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Contact already exist\n PleaseCheck The Address Book ...");
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
                    tempContact.Display();
                }
                else
                    Console.WriteLine("Edited name is invalid");
            }
            else
                Console.WriteLine("Name does not exist");
        }



        //Method Used To Delete Contact
        public void DeleteContact()
        {
            Console.WriteLine("Enter name of contact to delete: ");
            string name = Console.ReadLine();
            if (contacts.ContainsKey(name) is true)
            {
                contacts.Remove(name);
                Console.WriteLine("Successfully Deleted!!!");
            }
            else
                Console.WriteLine("Name does not exist");
        }

        //Creating method to add multiple contacts
        public void AddMultiple()
        {
            Console.WriteLine("Enter no of contacts to add");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                CreateContact();
            }
            tempContact.Display();
            Console.WriteLine("Successfully Added New Contacts");

        }

        //Filtered list for city or
        public void DisplayFilteredList()
        {
            int option = 0;

            List<Contact> filterredList = new List<Contact>();
            Console.WriteLine("Filter Contact list in this AddressBook:");
            Console.WriteLine("1. Filter by state");
            Console.WriteLine("2. Filter by city");
            Console.Write("Option: ");
            switch (option)
            {
                case 1:
                    Console.Write("Enter state: ");
                    string state = Console.ReadLine();
                    Console.WriteLine($"List of contacts in {state}");
                    StateFilter(state, filterredList);
                    break;
                case 2:
                    Console.WriteLine("Enter City: ");
                    string city = Console.ReadLine();
                    Console.WriteLine($"List of contacts in {city}");
                    CityFilter(city, filterredList);
                    break;
                default:
                    Console.WriteLine("Error!!!");
                    break;
            }
        }

        //Creating method to filter by city
        public void CityFilter(string city, List<Contact> filteredList)
        {
            Dictionary<string, Contact>.Enumerator enumerator = contacts.GetEnumerator();
            while (enumerator.MoveNext())
                if (enumerator.Current.Value.City == city)
                    filteredList.Add(enumerator.Current.Value);
        }

        //Creating method to filter by state
        public void StateFilter(string state, List<Contact> filteredList)
        {
            Dictionary<string, Contact>.Enumerator enumerator = contacts.GetEnumerator();
            while (enumerator.MoveNext())
                if (enumerator.Current.Value.State == state)
                    filteredList.Add(enumerator.Current.Value);
        }
    }
}