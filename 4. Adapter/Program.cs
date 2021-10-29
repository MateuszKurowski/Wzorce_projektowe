using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Linq;
using System.Text;

namespace WzorzecAdapter
{
    //KOD Z ZEWNĘTRZNEJ BIBLIOTEKI
    public class UsersApi
    {
        public async Task<string> GetUsersXmlAsync()
        {
            var apiResponse = "<?xml version= \"1.0\" encoding= \"UTF-8\"?><users><user name=\"John\" surname=\"Doe\"/><user name=\"John\" surname=\"Wayne\"/><user name=\"John\" surname=\"Rambo\"/></users>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(apiResponse);

            return await Task.FromResult(doc.InnerXml);
        }
    }


    // tu trzeba dopisać klasę zwracającą zawartość pliku csv w postaci stringa (jednego długiego, rozdzielanego znakami nowego wiersza)
    public static class  Read
    {
        public static string ReadCSV() => string.Join("\n", File.ReadAllLines("users.csv"));
    }

    public interface IUserRepository
    {
        List<string> GetUserNames();
    }

    public class UsersRepositoryAdapter : IUserRepository
    {
        private UsersApi _adaptee = null;

        public UsersRepositoryAdapter(UsersApi adaptee)
        {
            _adaptee = adaptee;
        }

        public List<string> GetUserNames()
        {
            string incompatibleApiResponse = this._adaptee
              .GetUsersXmlAsync()
              .GetAwaiter()
              .GetResult();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(incompatibleApiResponse);

            var rootEl = doc.LastChild;

            List<string> userNames = new();

            if (rootEl.HasChildNodes)
            {
                foreach (XmlNode user in rootEl.ChildNodes)
                {
                    userNames.Add(user.Attributes["name"].InnerText + user.Attributes["surname"].InnerText);
                }
            }
            return userNames;
        }
    }

    // tu trzeba dopisać własny adapter implementujący odpowiedni interfejs
    public class UsersRepositoryTest : IUserRepository
    {
        public List<string> GetUserNames() => Read.ReadCSV().Replace(',', ' ').Split('\n').ToList();
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            //UsersApi userRepository = new UsersApi();

            //IUserRepository adapter = new UsersRepositoryAdapter(userRepository);

            //List<string> users = adapter.GetUserNames();
            //foreach (var userName in users)
            //{
            //    Console.WriteLine(userName);
            //}

            //string[] source = File.ReadAllLines("users.csv");
            //int i = 1;
            //foreach (var item in source)
            //{
            //    var values = item.Split(",");
            //    Console.WriteLine(i + ". " + values[0] + values[1]);
            //}


            IUserRepository adapterCsv = new UsersRepositoryTest();
            List<string> usersName = adapterCsv.GetUserNames();

            // TODO: wyświetl w konsoli
            for (int i = 0; i < usersName.Count; i++)
            {
                Console.WriteLine(i+1 + ". " + usersName[i]);
            }
        }
    }
}