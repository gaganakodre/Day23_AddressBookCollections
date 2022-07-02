using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23_CollectionAddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===================Welcome To Address Book===================");
            //Object Of Class
            AddressBook address = new AddressBook();


            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nEnter Number to Execute the Address book Program \n1. Create contacts \n2. Add contact \n3. Edit contact \n4. Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Creating A New Contact");
                        address.CreateContact();
                        address.Display();
                        break;

                    case 2:
                        Console.WriteLine("Adding A New Contact");
                        address.AddContacts();
                        address.Display();
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("Editing Existing Contact");
                        address.EditContact();
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine("If You Want To Exit Then Press Enter");
                        flag = false;
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}