using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23_CollectionAddressBook
{
    internal class Contact
    {
        //Initialising Variables For User Details
        public string FirstName;
        public string LastName;
        public string Address;
        public string City;
        public string State;
        public string Zip;
        public string PhoneNumber;
        public string EmailId;


        public void GetUserInfo()
        {
            Console.WriteLine("Enter First Name: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter Address: ");
            Address = Console.ReadLine();
            Console.WriteLine("Enter City: ");
            City = Console.ReadLine();
            Console.WriteLine("Enter State: ");
            State = Console.ReadLine();
            Console.WriteLine("Enter Zip: ");
            Zip = Console.ReadLine();
            Console.WriteLine("Enter PhoneNumber: ");
            PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter EmailId: ");
            EmailId = Console.ReadLine();

        }

        //Method To Display The Details
        public void Display()
        {
            Console.WriteLine("*First Name:" + FirstName);
            Console.WriteLine("*Last Name:" + LastName);
            Console.WriteLine("*Address:" + Address);
            Console.WriteLine("*City:" + City);
            Console.WriteLine("*State:" + State);
            Console.WriteLine("*Zip:" + Zip);
            Console.WriteLine("*PhoneNumber:" + PhoneNumber);
            Console.WriteLine("*EmailId:" + EmailId);
        }

        public string GetName()
        {
            return FirstName + " " + LastName;
        }
    }
}