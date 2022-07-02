using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAddressBook
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
            Console.WriteLine("Enter PhonNumber: ");
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

        //Creating override equal method
        public override bool Equals(object obj)
        {
            if (!(obj.GetType() is Contact))
                return false;
            else if (GetName() == ((Contact)obj).GetName())
                return true;
            return false;
        }
        public new string ToString()
        {
            return $"First Name: {FirstName},\nLast Name: {LastName}, \nAddress: {Address},\nCity:{City} , \nState{State}, \nZip:{Zip}, \nPhone Number:{PhoneNumber}, \nEmailId:{EmailId}";
        }
    }
}