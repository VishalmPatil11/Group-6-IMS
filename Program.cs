using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;

            int choice;

            string username, password;
            //User user = new User() { Name = "vishal", Email="vishal@cyb.com", Category=5, CategoryId=5, Password=1234,};
            

            do
            {
                Console.WriteLine("INVENTORY MANAGEMENT SYSTEM\n\nEnter your choice:\n1.User Login\n2.Admin Login\n3.Exit\n");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    //for user login
                    case 1:

                        Console.WriteLine("\nEnter Username :");
                        username = Console.ReadLine();

                        Console.WriteLine("\nEnter Password :");
                        Console.BackgroundColor = ConsoleColor.Gray;
                        password = Console.ReadLine();
                        Console.BackgroundColor = ConsoleColor.Black;

                        LoginController.UserLogin(username.ToLower(), password);

                        break;

                    //for admin login
                    case 2:

                        Console.WriteLine("\nEnter Username :");
                        username = Console.ReadLine();

                        Console.WriteLine("\nEnter Password :");
                        Console.BackgroundColor = ConsoleColor.Gray;
                        password = Console.ReadLine();
                        Console.BackgroundColor = ConsoleColor.Black;

                        LoginController.AdminLogin(username.ToLower(), password);

                        break;

                    //for exit
                    case 3:

                        flag = false;

                        break;

                    default:

                        Console.WriteLine("\nInvalid Choice!");
                        break;
                }
            } while (flag);
        }
    }
}