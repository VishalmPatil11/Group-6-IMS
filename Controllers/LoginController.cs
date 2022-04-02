using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public static class LoginController
    {
        static InventoryDbContext ctx = new InventoryDbContext();

        public static void AdminLogin(string username, string password)
        {
            bool isFound = false;

            foreach (User user in ctx.Users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password) && user.Role == Role.Admin)
                {
                    isFound = true;

                    Console.WriteLine($"\nHello {user.Name}!");

                    //method that provides a menu for Admin Operations
                    AdminController.HandleAdminMenu();
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("\nInvalid Credentials!");
            }
        }

        public static void UserLogin(string username, string password)
        {
            bool isFound = false;

            foreach (User user in ctx.Users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password) && user.Role == Role.User)
                {
                    isFound = true;

                    Console.WriteLine($"\nHello {user.Name}!");

                    //method that provides a menu for User Operations

                    UserController.HandleUserMenu(user.CategoryId);
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("\nInvalid Credentials!");
            }
        }
    }
}