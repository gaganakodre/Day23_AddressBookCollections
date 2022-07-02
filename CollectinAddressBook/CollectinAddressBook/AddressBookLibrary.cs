using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAddressBook
{
    internal class AddressBookLibrary
    {
        //Creating Dictionary For AddressBooks
        public Dictionary<string, AddressBook> Library;
        bool flag = true;
        int count;

        //Initializing Dictionary
        public AddressBookLibrary()
        {
            Library = new Dictionary<string, AddressBook>();
        }

        //Menu fo multiple address book
        public void AddressBookMenu()
        {
            do
            {
                Console.WriteLine("1.Add Addressbook \n2.Open Addressbook \n3.Display list of Addressbook \n4.Filter by city or state \n5. Filter person \n6.Exit");
                Console.Write("Enter the option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Write("Enter the name of Addressbook = ");
                        string name = Console.ReadLine();
                        if (Library.ContainsKey(name))
                            Console.WriteLine("Already Exist..");
                        else
                            Console.WriteLine("Successfully Added...");
                        Library.Add(name, new AddressBook());
                        break;

                    case 2:
                        Console.Write("Enter the name of Addressbook which you want to open = ");
                        string nameOfAddressbook = Console.ReadLine();
                        if (Library.ContainsKey(nameOfAddressbook))
                            Library[nameOfAddressbook].ContactMenu();
                        else
                            Console.WriteLine("No such Addressbook is available");
                        break;

                    case 3:
                        foreach (var book in Library.Keys)
                            Console.WriteLine(book);
                        break;

                    case 4:
                        DisplayFilteredList();
                        break;

                    case 5:
                        SearchAndFilter();
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
                Console.Write("Enter any key to continue:");
                Console.ReadKey();
                Console.Clear();
            } while (flag == true);
        }

        public void DisplayFilteredList()
        {
            List<Contact> filteredList = LocationFilter();
            foreach (Contact contact in filteredList)
                contact.Display();
            count++;
            Console.WriteLine("Total count = " + count);
        }

        //Creating method to filter by location
        public List<Contact> LocationFilter()
        {

            List<Contact> filteredList = new List<Contact>();
            Console.WriteLine("Filter Contact list in full library of AddressBooks:");
            Console.WriteLine("\n1.Filter by state  \n2.Filter by city");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter state: ");
                    string state = Console.ReadLine();
                    StateFilter(state, filteredList);
                    break;
                case 2:
                    Console.WriteLine("Enter City: ");
                    string city = Console.ReadLine();
                    CityFilter(city, filteredList);
                    break;
                default:
                    Console.WriteLine("Error!!!");
                    break;
            }
            return filteredList;

        }

        //Creating method to filter by city
        public void CityFilter(string city, List<Contact> filteredList)
        {
            Dictionary<string, AddressBook>.Enumerator enumerator = Library.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.CityFilter(city, filteredList);

            }
        }

        //Creating method to filter by state
        public void StateFilter(string State, List<Contact> filteredList)
        {
            Dictionary<string, AddressBook>.Enumerator enumerator = Library.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.StateFilter(State, filteredList);
            }
        }

        //Creating method to search person
        public void SearchAndFilter()
        {
            Console.Write("Enter name of person to search: ");
            string fullName = Console.ReadLine();
            List<Contact> filteredList = LocationFilter();
            var searchResults = filteredList.FindAll(contact => contact.GetName() == fullName);
            Console.WriteLine("Filtered Search Results: ");
            foreach (Contact contact in searchResults)
                contact.Display();
        }
    }
}