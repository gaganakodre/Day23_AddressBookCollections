using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23_CollectionAddressBook
{
    internal class Start
    {
        static void Main(string[] args)
        {
            //Object Of Class
            AdressBookSystem adressBookSystem = new AdressBookSystem();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("enter the option: 1.Add AdressBook 2.Edit AddressBook 3.Remove AddressBook");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        adressBookSystem.AddAddressBook();
                        break;
                    case 2:
                        Console.WriteLine("enter the addressbook name you want to edit");
                        string addressBookName = Console.ReadLine();
                        if (adressBookSystem.adressBooks.ContainsKey(addressBookName.ToLower()))
                        {
                            bool flag1 = true;
                            while (flag1)
                            {

                                Console.WriteLine("\nEnter Number to Execute the Address book Program \n1. Create contacts \n2. Add contact \n3. Edit contact \n4. Delete Contact \n5. Add Multiple Person \n6. Exit");
                                int option1 = Convert.ToInt32(Console.ReadLine());
                                switch (option1)
                                {
                                    case 1:
                                        Console.WriteLine("Creating A New Contact");
                                        adressBookSystem.adressBooks[addressBookName.ToLower()].CreateContact();
                                        adressBookSystem.adressBooks[addressBookName.ToLower()].Display();
                                        Console.WriteLine();
                                        break;

                                    case 2:
                                        Console.WriteLine("Adding A New Contact");
                                        adressBookSystem.adressBooks[addressBookName.ToLower()].AddContacts();
                                        adressBookSystem.adressBooks[addressBookName.ToLower()].Display();
                                        Console.WriteLine();
                                        break;

                                    case 3:
                                        Console.WriteLine("Editing Existing Contact");
                                        adressBookSystem.adressBooks[addressBookName.ToLower()].EditContact();
                                        Console.WriteLine();
                                        break;

                                    case 4:
                                        Console.WriteLine("Deleting Existing Contact");
                                        adressBookSystem.adressBooks[addressBookName.ToLower()].DeleteContact();
                                        Console.WriteLine();
                                        break;
                                    case 5:
                                        Console.WriteLine("Adding Multiple Contacts");
                                        adressBookSystem.adressBooks[addressBookName.ToLower()].AddMultiple();
                                        Console.WriteLine();
                                        break;
                                    case 6:
                                        Console.WriteLine("If You Want To Exit Then Press Enter");
                                        flag = false;
                                        Console.ReadKey();
                                        break;

                                    default:
                                        Console.WriteLine("Invalid");
                                        break;

                                }
                            }

                        }
                        break;

                    default:
                        Console.WriteLine("Invaild");
                        break;
                }
            }

        }
    }
}