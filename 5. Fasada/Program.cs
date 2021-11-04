using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WzorzecFasada
{

    interface IUserService
    {
        void CreateUser(string email);
        string UsersCount();
        void RemoveUser(string email);
    }

    static class EmailNotification
    {
        public static void SendEmail(string to, string subject)
        {
            Console.WriteLine(subject + " " + to);
        }
    }

    public class UserRepository
    {
        private readonly List<string> users = new List<string>
        {
            "john.doe@gmail.com", "sylvester.stallone@gmail.com"
        };

        public bool IsEmailFree(string email) => !users.Contains(email);

        public void AddUser(string email)
        {
            users.Add(email);
        }

        public int UsersCount() => users.Count;

        public void RemoveUser(string email)
        {
            users.Remove(email);
            EmailNotification.SendEmail(email, "Goodbye");
        }
    }

    static class Validators
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
        }
    }

    class UserService : IUserService
    {
        private readonly UserRepository userRepository = new UserRepository();
        public void CreateUser(string email)
        {
            if (!Validators.IsValidEmail(email))
            {
                throw new ArgumentException("Błędny email");
            }

            if (!userRepository.IsEmailFree(email))
                throw new Exception("Podany email jest zajęty");

            userRepository.AddUser(email);
            EmailNotification.SendEmail(email, "Welcome to our service");
        }

        public string UsersCount() => $"Aktualna liczba adresow: {userRepository.UsersCount()}";

        public void RemoveUser(string email)
        {
            if (userRepository.IsEmailFree(email))
                throw new Exception("Podany użytkownik nie istnieje");
            userRepository.RemoveUser(email);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();
            Console.WriteLine(userService.UsersCount());
            userService.CreateUser("someemail@gmail.com");
            Console.WriteLine(userService.UsersCount());
            userService.RemoveUser("john.doe@gmail.com");
            Console.WriteLine(userService.UsersCount());
        }
    }

}