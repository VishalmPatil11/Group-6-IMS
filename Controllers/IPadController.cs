using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Inventory_Management_System
{
    public static class IPadController
    {
        static InventoryDbContext ctx = new InventoryDbContext();

        public static void HandleIPadMenu()
        {
            bool flag = true;

            int choice;

            do
            {
                Console.WriteLine("\nEnter your choice : \n1.Add IPad\n2.List all IPads\n3.Update IPad\n4.Delete IPad\n5.Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    //Adding IPads
                    case 1:

                        try
                        {
                            Console.WriteLine("Enter IPad details : ");

                            Console.WriteLine("Model Name : ");
                            string modelname = Console.ReadLine();

                            Console.WriteLine("Color : ");
                            string color = Console.ReadLine();

                            Console.WriteLine("Processor Name : ");
                            string processor = Console.ReadLine();

                            Console.WriteLine("Quantity : ");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Price : ");
                            decimal price = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("Screen Size : ");
                            float screenSize = float.Parse(Console.ReadLine());

                            Console.WriteLine("Storage Space : ");
                            int storageSpace = Convert.ToInt32(Console.ReadLine());

                            IPadController.AddIPad(modelname, color, processor, quantity, price, screenSize, storageSpace);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    //Listing down all IPads
                    case 2:

                        IPadController.ListAllIPads();

                        break;

                    //Updating IPad
                    case 3:

                        Console.WriteLine("\nEnter the Model Id of the IPad to be updated : ");

                        int modelIdToBeUpdated = Convert.ToInt32(Console.ReadLine());

                        IPadController.UpdateIPad(modelIdToBeUpdated);

                        break;

                    //Deleting IPad
                    case 4:

                        Console.WriteLine("\nEnter the Model Id of the IPad to be deleted : ");

                        int modelIdToBeDeleted = Convert.ToInt32(Console.ReadLine());

                        IPadController.DeleteIPad(modelIdToBeDeleted);

                        break;

                    //Exit Case
                    case 5:

                        flag = false;

                        break;

                    default:

                        Console.WriteLine("\nInvalid Choice");

                        break;
                }
            } while (flag);
        }

        public static void AddIPad(string modelname, string color, string processor, int quantity, decimal price, float screenSize, int storageSpace)
        {
            IPad newIPad = new IPad()
            {
                ModelName = modelname,
                Color = color,
                Processor = processor,
                AvailableQuantity = quantity,
                Price = price,
                ScreenSize = screenSize,
                StorageSpace = storageSpace
            };

            ctx.IPads.Add(newIPad);

            ctx.SaveChanges();

            Console.WriteLine("\nIPad added successfully!");
        }

        public static void ListAllIPads()
        {
            Console.WriteLine("\nAll IPads :\n");

            foreach (IPad ipad in ctx.IPads)
            {
                Console.WriteLine($"Model Id : {ipad.ModelId}\nModel Name : {ipad.ModelName}\nColor : {ipad.Color}" +
                    $"\nProcessor : {ipad.Processor}\nQuantity : {ipad.AvailableQuantity}\nPrice : Rs {ipad.Price}" +
                    $"\nScreen Size : {ipad.ScreenSize} inches\nStorage Space : {ipad.StorageSpace} GB");
            }
        }

        public static void UpdateIPad(int ModelId)
        {
            IPad ipadToBeUpdated = ctx.IPads.Find(ModelId);

            if (ipadToBeUpdated != null)
            {
                Console.WriteLine("\nSelect the field to be updated : \n1.Available Quantity\n2.Price");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("\nEnter updated Quantity : ");
                        int updatedQuantity = Convert.ToInt32(Console.ReadLine());

                        ipadToBeUpdated.AvailableQuantity = updatedQuantity;

                        ctx.SaveChanges();

                        Console.WriteLine("\nQuantity updated successfully.");

                        break;

                    case 2:

                        Console.WriteLine("\nEnter updated Price : ");
                        decimal updatedPrice = Convert.ToDecimal(Console.ReadLine());

                        ipadToBeUpdated.Price = updatedPrice;

                        ctx.SaveChanges();

                        Console.WriteLine("\nPrice updated successfully.");

                        break;

                    default:

                        Console.WriteLine("\nInvalid Choice!");

                        break;
                }
            }
            else
            {
                Console.WriteLine("\nProvided Model Id doesn't exist!");
            }
        }

        public static void DeleteIPad(int ModelId)
        {
            IPad ipadToBeDeleted = ctx.IPads.Find(ModelId);

            if (ipadToBeDeleted != null)
            {
                ctx.IPads.Remove(ipadToBeDeleted);

                ctx.SaveChanges();

                Console.WriteLine("\nIPad deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nProvided Model Id doesn't exist!");
            }
        }
    }
}