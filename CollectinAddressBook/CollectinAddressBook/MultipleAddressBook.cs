using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompleteAddressBook
{
	class MultipleAddressBook
	{
		public List<ContactPerson> userList;
		public MultipleAddressBook()
		{
			this.userList = new List<ContactPerson>();
		}
		public void AddContact(String firstName, String lastName, String address, String city, String state, String zip, String contact, String email)
		{
			bool duplicate = equals(firstName);
			if (duplicate)//here we chcek for duplicate data if not it will add new details
			{
				Console.WriteLine($"Duplicate Contact not allowed '{0}' is already in address book", firstName);
			}
			else
			{
				ContactPerson user = new ContactPerson(firstName, lastName, address, city, state, zip, contact, email);
				userList.Add(user);//here we add user by going to the Contactperson class
			}
		}
		public bool equals(string first_name)
		{
			if (userList.Any(e => e.firstName == first_name))//if entred first name is equal to entred name 
				//it is derived from the enumarable class enum is like contant strings group of constants
				return true;
			else
				return false;
		}

		public void Display()
		{
			if (userList.Count() > 0)//it will check with the count also in the list
			{
				Console.WriteLine("----------------------------------------------------------------------");
				Console.WriteLine("FirstName  LastName  Address,  City,  State,  Zip,   Contact,   Email");
				Console.WriteLine("----------------------------------------------------------------------");
				foreach (ContactPerson cont in userList)
				{
					cont.print();
				}
				Console.WriteLine("-----------------------------End_of_book------------------------------");
			}
			else
			{
				Console.WriteLine("Address_Book is Empty...!!!!!");
			}
		}
		public void EditContact(string fname)
		{
			int size = userList.Count;
			int check = 0;
			foreach (ContactPerson user in userList)
			{
				check++;
				if (user.firstName.Equals(fname))
				{
					userList.Remove(user);
					Console.Write("Enter FirstName: ");
					string firstName = Console.ReadLine();
					Console.Write("Enter LastName: ");
					string lastName = Console.ReadLine();
					Console.Write("Enter Address : ");
					string address = Console.ReadLine();
					Console.Write("Enter City : ");
					string city = Console.ReadLine();
					Console.Write("Enter State : ");
					string state = Console.ReadLine();
					Console.Write("Enter zip : ");
					string zip = Console.ReadLine();
					Console.Write("Enter Contact No: ");
					string contact = Console.ReadLine();
					Console.Write("Enter Email: ");
					string email = Console.ReadLine();
					AddContact(firstName, lastName, address, city, state, zip, contact, email);
					break;
				}
				else if (size == check)
				{
					Console.WriteLine(fname + " not found in addressbook...");
					break;
				}
			}
		}

		public void DeletContact(string Fname)//here we will delete contact by first name
		{
			int size = userList.Count;
			int check = 0;
			foreach (ContactPerson user in userList)
			{
				check++;
				if (user.firstName.Equals(Fname))//checking both entered and list name are equal
				{
					userList.Remove(user);//remove method we are removing it
					Console.WriteLine("Contact Deleted Successfully...");

					break;
				}
				else if (size == check)
				{
					Console.WriteLine(Fname + " not found in addressbook...");
					break;
				}
			}
		}
		public void SerchContact(string place)
		{
			List<string> person = new List<string>();
			bool exits = isPlaceExist(place);//checking with the placeexist method
			if (exits)
			{
				Console.WriteLine("Contacts From Place: " + place);
				foreach (ContactPerson user in userList.FindAll(x => x.address.Equals(place)).ToList())//findall returns all the lements tha t stisfies the condiiton
				{
					string name = user.firstName + " " + user.lastName;
					person.Add(name);//added address 
				}
				foreach (ContactPerson user in userList.FindAll(x => x.state.Equals(place)).ToList())
				{
					string name = user.firstName + " " + user.lastName;
					person.Add(name);//compare state ane retued the first name and last name 
				}
				foreach (string val in person)
				{
					Console.WriteLine(val);//here printing those in the person list
				}
			}
			else
			{
				Console.WriteLine($"Contect not Found From {0}", place);
			}
		}
		public bool isPlaceExist(string place)
		{
			if (this.userList.Any(e => e.city == place) || this.userList.Any(e => e.state == place))//lambda expression
				return true;//checking for the city and state
			else
				return false;
		}
		public void CountContact(string countPlace)
		{
			int count = 0;
			bool exits = isPlaceExist(countPlace);
			if (exits)
			{
				Console.WriteLine("Contacts From Place: " + countPlace);
				foreach (ContactPerson user in userList.FindAll(x => x.address.Equals(countPlace)).ToList())
				{
					count++;
				}
				foreach (ContactPerson user in userList.FindAll(x => x.state.Equals(countPlace)).ToList())
				{
					count++;
				}
				Console.WriteLine($"Total Contacts From {countPlace} : {count}");
			}
			else
			{
				Console.WriteLine($"Contect not Found From {0}", countPlace);
			}
		}
		public void SortAlphabetically(int choice1)
		{
			Console.WriteLine("----------------------------------------------------------------------");
			Console.WriteLine("FirstName   LastName   Address,  City,  State,  Zip,   Contact,  Email");
			Console.WriteLine("----------------------------------------------------------------------");
			switch (choice1)
			{
				case 1:
					userList.Sort(new Comparison<ContactPerson>((x, y) => string.Compare(x.firstName, y.firstName)));//deletages compare the two object of same type
					foreach (ContactPerson contact in userList)
					{
						contact.print();
					}
					break;

				case 2:
					userList.Sort(new Comparison<ContactPerson>((x, y) => string.Compare(x.city, y.city)));
					foreach (ContactPerson contact in userList)
					{
						contact.print();
					}
					break;

				case 3:
					userList.Sort(new Comparison<ContactPerson>((x, y) => string.Compare(x.state, y.state)));
					foreach (ContactPerson contact in userList)
					{
						contact.print();
					}
					break;
				case 4:
					userList.Sort(new Comparison<ContactPerson>((x, y) => string.Compare(x.zip, y.zip)));
					foreach (ContactPerson contact in userList)
					{
						contact.print();
					}
					break;
			}
		}
		public void writeInTxtFile()
		{
			FileWriter.WriteUsingStreamWriter(userList);
			Console.WriteLine("Contacts Stored in TextFile.");
		}
		public void readFromTxtFile()
		{
			FileWriter.readFile();
		}
		public void writeInCsvFile()
		{
			FileWriter.csvFileWriter(userList);
		}

		public void readFromCsvFile()
		{
			FileWriter.readFromCSVFile();
		}
	}
}