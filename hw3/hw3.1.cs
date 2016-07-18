using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[5] { "Vlad", "Stas", "Ivan", "Andrey", "Roman" };
            string[] passwords = new string[5] { "123", "234", "345", "456", "567" };
            string[] roles = new string[5] { "Admin", "User", "Moderator", "User", "User" };

            byte numberAttemptsInput = 3;

            string role = Login(names, passwords, roles, numberAttemptsInput);

            Action(names, passwords, roles, role);

            Console.ReadKey();
        }

        static string Login(string[] names, string[] passwords, string[] roles, byte numberAttemptsInput)
        {
            for (int i = 0; i < numberAttemptsInput; i++)
            {
                string name = InputName();
                string password = InputPassword();
                string role = CheckInput(names, passwords, roles, name, password);
                Console.WriteLine();
                if (role != null)
                {
                    Console.WriteLine("Congratulations! You are logged in as " + role);
                    Console.WriteLine();
                    return role;
                } else
                {
                    Console.WriteLine("Incorrect name or password!");
                    if (i < numberAttemptsInput - 1)
                    {
                        Console.WriteLine("Try again. You have " + (numberAttemptsInput - 1 - i) + " attempts");
                    } else
                    {
                        Console.WriteLine("Unfortunately, it was your last attempt");
                    }
                }
                Console.WriteLine();
            }
            return null;
        }

        static void Action(string[] names, string[] passwords, string[] roles, string role)
        {
            if (role.Equals("Admin"))
            {
                ActionAdmin(names, passwords, roles);
            }
            if (role.Equals("User"))
            {
                ActionUser(names, roles);
            }
            if (role.Equals("Moderator"))
            {
                ActionModerator(names);
            }
        }

        static void ActionModerator(string[] curNames)
        {
            Console.WriteLine("In all " + curNames.Length + " members");
        }

        static void ActionUser(string[] curNames, string[] curRoles)
        {
            byte usersNumber = 0;
            for (int i = 0; i < curRoles.Length; i++)
            {
                if (curRoles[i].Equals("User"))
                {
                    usersNumber++;
                    Console.WriteLine(curNames[i]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("In all " + usersNumber + " users");
        }

        static void ActionAdmin(string[] curNames, string[] curPasswords, string[] curRoles)
        {
            Console.WriteLine("Name | password | role");
            for (int i = 0; i < curNames.Length; i++)
            {
                Console.WriteLine(curNames[i] + "\t" + curPasswords[i] + "\t" + curRoles[i]);
            }
        }

        static string InputName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }

        static string InputPassword()
        {
            Console.Write("Password: ");
            return Console.ReadLine();
        }

        static string CheckInput(string[] curNames, string[] curPasswords, string[] curRoles, string curName, string curPassword)
        {
            for (int i = 0; i < curNames.Length; i++)
            {
                if (curName.Equals(curNames[i]))
                {
                    if (curPassword.Equals(curPasswords[i]))
                    {
                        return curRoles[i];
                    }
                }
            }
            return null;
        }
    }
}
