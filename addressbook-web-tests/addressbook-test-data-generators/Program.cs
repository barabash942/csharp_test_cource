using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using addressbook_web_tests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(BaseTest.GenerateRandomString(10))
                {
                    Header = BaseTest.GenerateRandomString(25),
                    Footer = BaseTest.GenerateRandomString(30)
                });
            }

            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(BaseTest.GenerateRandomString(10),
                    BaseTest.GenerateRandomString(15)));
            }
            if (dataType == "groups" && format == "csv")
            {
                WriteGroupsToCsvFile(groups, writer);
            }
            else if (dataType == "groups" && format == "xml")
            {
                WriteGroupsToXmlFile(groups, writer);
            }
            if (dataType == "contacts" && format == "xml")
            {
                WriteContactsToXmlFile(contacts, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format: " + format);
            }
            writer.Close();
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
    }
}
