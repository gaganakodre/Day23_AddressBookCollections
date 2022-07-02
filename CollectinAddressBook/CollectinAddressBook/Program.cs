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
            AddressBook address = new AddressBook();
            address.CreateContact();
            address.Display();
            Console.ReadKey();
        }
    }
}