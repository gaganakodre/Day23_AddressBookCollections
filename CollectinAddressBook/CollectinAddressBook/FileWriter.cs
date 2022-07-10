using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CompleteAddressBook
{
    class FileWriter
    {
        public static string path = @"G:\FellowShip517\Dya23_CollectionAddressBook\Day23_AddressBookCollections\CollectinAddressBook\AddressBookFile.txt";
        public static string csvPath = @"G:\FellowShip517\Dya23_CollectionAddressBook\Day23_AddressBookCollections\CollectinAddressBook\CSV_AddressBook.csv";
        public static string jsonPath = @"G:\FellowShip517\Dya23_CollectionAddressBook\Day23_AddressBookCollections\CollectinAddressBook\JSON_AddressBook.json";
        public static void WriteUsingStreamWriter(List<ContactPerson> data)
        {

            if (File.Exists(path))
            {
                File.WriteAllText(path, String.Empty);
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine("FirstName\tLastName\t Address\t City\t State\t Zip\t Contact\t Email");
                    foreach (ContactPerson contacts in data)
                    {
                        streamWriter.WriteLine(contacts.firstName + "\t" + contacts.lastName + "\t" + contacts.address + "\t" + contacts.city + "\t" + contacts.state + "\t" + contacts.zip + "\t" + contacts.contact + "\t" + contacts.email);
                    }
                    streamWriter.Close();
                }
            }
            else
            {
                Console.WriteLine("File not avilable..");
            }
        }

        public static void readFile()
        {
            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string data = "";
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(data);
                    }
                }
            }
            else
            {
                Console.WriteLine("File not avilable..");
            }
        }
        public static void csvFileWriter(List<ContactPerson> dataa)
        {

            if (File.Exists(csvPath))
            {
                File.WriteAllText(csvPath, String.Empty);
                using (StreamWriter streamWriter = File.AppendText(csvPath))
                {
                    streamWriter.WriteLine("FirstName,LastName,Address,City,State,Zip,Contact,Email");
                    foreach (ContactPerson contacts in dataa)
                    {
                        streamWriter.WriteLine(contacts.firstName + "," + contacts.lastName + "," + contacts.address + "," + contacts.city + "," + contacts.state + "," + contacts.zip + "," + contacts.contact + "," + contacts.email);
                    }
                    streamWriter.Close();
                    Console.WriteLine("Contacts Stored in Csv_File.");
                }
            }
            else
            {
                Console.WriteLine("File not avilable..");
            }
        }
        public static void readFromCSVFile()
        {
            if (File.Exists(csvPath))
            {
                using (StreamReader streamReader = File.OpenText(csvPath))
                {
                    string data = "";
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        string[] csv = data.Split(",");
                        foreach (string dataCsv in csv)
                        {
                            Console.Write(dataCsv + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("File not avilable..");
            }
        }

        public static void WriteContactsInJSONFile(List<ContactPerson> contacts)
        {
            if (File.Exists(jsonPath))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(jsonPath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, contacts);
                }
                Console.WriteLine("Conatact stored in Json File...");
            }
            else
            {
                Console.WriteLine("File not found...");
            }
        }
        public static void ReadContactsFromJSONFile()
        {
            if (File.Exists(jsonPath))
            {
                IList<ContactPerson> contactsRead = JsonConvert.DeserializeObject<IList<ContactPerson>>(File.ReadAllText(jsonPath));
                foreach (ContactPerson contact in contactsRead)
                {
                    contact.print();
                }
            }
            else
            {
                Console.WriteLine("File not found...");
            }
        }
    }
}