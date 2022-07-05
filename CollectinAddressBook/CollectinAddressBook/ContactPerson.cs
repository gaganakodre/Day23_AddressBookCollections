using System;
using System.Collections.Generic;
using System.Text;

namespace CompleteAddressBook
{
	public class ContactPerson
	{
		public String firstName;
		public String lastName;
		public String address;
		public String city;
		public String state;
		public String zip;
		public String contact;
		public String email;


		public ContactPerson(String firstName, String lastName, String address, String city, String state, String zip, String contact, String email)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.address = address;
			this.city = city;
			this.state = state;
			this.zip = zip;
			this.contact = contact;
			this.email = email;
		}
		public void print()
		{
			Console.WriteLine(firstName + " \t  " + lastName + " \t  " + address + " \t  " + city + " \t  " + state + " \t " + zip + "\t " + contact + " \t  " + email);
		}
	}
}