using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System
{
    public static class AdminController
    {
        static InventoryDbContext ctx = new InventoryDbContext();

        public static void HandleAdminMenu()
        {
            bool flag = true;

            int choice;

            //method calls for Admin Operations
            do
            {
                Console.WriteLine("\nEnter your choice : \n1.Add User\n2.List all Users\n3.Update User" +
                    "\n4.Delete User\n5.Perform CRUD on IPad\n6.Perform CRUD on IPhone\n7.Perform CRUD on IWatch" +
                    "\n8.Perform CRUD on Macbook\n9.Logout\n");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    //Adding Users
                    case 1:

                        try
                        {
                            Console.WriteLine("\nEnter User details : ");

                            Console.WriteLine("Name : ");
                            string name = Console.ReadLine();

                            Console.WriteLine("Email : ");
                            string email = Console.ReadLine();

                            Console.WriteLine("Username : ");
                            string uname = Console.ReadLine();

                            Console.WriteLine("Password : ");
                            Console.BackgroundColor = ConsoleColor.Gray;
                            string passwd = Console.ReadLine();
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.WriteLine("\nSelect Category ID to be maintained:\nIPhone (1)\nIPad (2)\nIWatch (3)\nMacbook (4)");

                            int categoryId = Convert.ToInt32(Console.ReadLine());

                            AdminController.AddUser(name, email, uname, passwd, categoryId, Role.User);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    //Listing down all Users
                    case 2:

                        AdminController.ListAllUsers();

                        break;

                    //Updating User
                    case 3:

                        Console.WriteLine("\nEnter the username of the user to be updated : ");

                        string usernameToBeUpdated = Console.ReadLine();

                        AdminController.UpdateUser(usernameToBeUpdated.ToLower());

                        break;

                    //Deleting User
                    case 4:

                        Console.WriteLine("\nEnter the username of the user to be deleted : ");

                        string usernameToBeDeleted = Console.ReadLine();

                        AdminController.DeleteUser(usernameToBeDeleted.ToLower());

                        break;

                    //Perform CRUD on IPad
                    case 5:

                        IPadController.HandleIPadMenu();

                        break;

                    //Perform CRUD on IPhone
                    case 6:

                        IPhoneController.HandleIPhoneMenu();

                        break;

                    //Perform CRUD on IWatch
                    case 7:

                        IWatchController.HandleIWatchMenu();

                        break;

                    //Perform CRUD on Macbook
                    case 8:

                        MacbookController.HandleMacbookMenu();

                        break;

                    //Exit Case
                    case 9:

                        flag = false;

                        break;

                    default:

                        Console.WriteLine("\nInvalid Choice");

                        break;
                }
            } while (flag);
        }

        public static void ListAllUsers()
        {
            Console.WriteLine("\nAll Users :\n");

            foreach (User user in ctx.Users)
            {
                Console.WriteLine($"User Id : {user.UserId} | Name : {user.Name} | Email : {user.Email} | Username : {user.Username} | Role : {user.Role}");
            }
        }

        public static void AddUser(string name, string email, string username, string password, int categoryIdToBeManaged, Role role)
        {
            bool isNew = true;

            //checking if the username is already present or not
            foreach(User user in ctx.Users)
            {
                if(user.Username.Equals(username.ToLower()) || user.Email.Equals(email.ToLower()))
                {
                    Console.WriteLine("\nUsername/Email already exists! Try with different username.");

                    isNew = false;
                }
            }

            //checking if the Category provided by user is present or not
            var category = ctx.Categories.Find(categoryIdToBeManaged);

            if(category == null)
            {
                Console.WriteLine("\nProvided Category doesn't exist!");
            }

            if(category != null && isNew)
            {
                User newUser = new User()
                {
                    Name = name,
                    Email = email.ToLower(),
                    Username = username.ToLower(),
                    Password = password,
                    CategoryId = categoryIdToBeManaged,
                    Role = role
                };

                ctx.Users.Add(newUser);

                ctx.SaveChanges();

                Console.WriteLine("\nUser added successfully!");
            }
        }

        public static void DeleteUser(string username)
        {
            try
            {
                var userToBeDeleted = ctx.Users.First(x => x.Username.Equals(username));

                if (userToBeDeleted != null)
                {
                    ctx.Users.Remove(userToBeDeleted);

                    ctx.SaveChanges();

                    Console.WriteLine("\nUser deleted successfully!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("\nUsername not found!");
            }
        }

        public static void UpdateUser(string username)


        {
            try
            {
                var userToBeUpdated = ctx.Users.First(x => x.Username.Equals(username));

                if (userToBeUpdated != null)
                {
                    Console.WriteLine("\nSelect the field to be updated : \n1.Name\n2.Password\n3.Role\n");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:

                            Console.WriteLine("\nEnter updated Name : ");
                            string updatedName = Console.ReadLine();

                            userToBeUpdated.Name = updatedName;

                            ctx.SaveChanges();

                            Console.WriteLine("\nName updated successfully.");

                            break;

                        case 2:

                            Console.WriteLine("\nEnter updated Password : ");
                            Console.BackgroundColor = ConsoleColor.Gray;
                            string updatedPassword = Console.ReadLine();
                            Console.BackgroundColor = ConsoleColor.Black;

                            userToBeUpdated.Password = updatedPassword;

                            ctx.SaveChanges();

                            Console.WriteLine("\nPassword updated successfully.");

                            break;

                        case 3:

                            Console.WriteLine("\nEnter updated Role : (Admin / User)");
                            string updatedRole = Console.ReadLine().ToLower();

                            if (updatedRole == "admin")
                            {
                                userToBeUpdated.Role = Role.Admin;

                                ctx.SaveChanges();

                                Console.WriteLine("\nRole updated successfully.");
                            }
                            else if (updatedRole == "user")
                            {
                                userToBeUpdated.Role = Role.User;

                                ctx.SaveChanges();

                                Console.WriteLine("\nRole updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("\nRole is undefined.");
                            }

                            break;

                        default:

                            Console.WriteLine("\nInvalid Choice!");

                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("\nUser Id not found!");
            }
        }
    }
}