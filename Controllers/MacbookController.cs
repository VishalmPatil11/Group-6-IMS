using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Inventory_Management_System
{
    public static class MacbookController
    {
        static InventoryDbContext ctx = new InventoryDbContext();

        public static void HandleMacbookMenu()
        {
            bool flag = true;

            int choice;

            do
            {
                Console.WriteLine("\nEnter your choice : \n1.Add Macbook\n2.List all Macbooks\n3.Update Macbook\n4.Delete Macbook\n5.Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    //Adding Macbooks
                    case 1:

                        try
                        {
                            Console.WriteLine("Enter Macbook details : ");

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

                            MacbookController.AddMacbook(modelname, color, processor, quantity, price, screenSize, storageSpace);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    //Listing down all Macbooks
                    case 2:

                        MacbookController.ListAllMacbooks();

                        break;

                    //Updating Macbook
                    case 3:

                        Console.WriteLine("\nEnter the Model Id of the Macbook to be updated : ");

                        int modelIdToBeUpdated = Convert.ToInt32(Console.ReadLine());

                        MacbookController.UpdateMacbook(modelIdToBeUpdated);

                        break;

                    //Deleting Macbook
                    case 4:

                        Console.WriteLine("\nEnter the Model Id of the Macbook to be deleted : ");

                        int modelIdToBeDeleted = Convert.ToInt32(Console.ReadLine());

                        MacbookController.DeleteMacbook(modelIdToBeDeleted);

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

        public static void AddMacbook(string modelname, string color, string processor, int quantity, decimal price, float screenSize, int storageSpace)
        {
            Macbook newMacbook = new Macbook()
            {
                ModelName = modelname,
                Color = color,
                Processor = processor,
                AvailableQuantity = quantity,
                Price = price,
                ScreenSize = screenSize,
                StorageSpace = storageSpace
            };

            ctx.Macbooks.Add(newMacbook);

            ctx.SaveChanges();

            Console.WriteLine("\nMacbook added successfully!");
        }

        public static void ListAllMacbooks()
        {
            Console.WriteLine("\nAll Macbooks :\n");

            foreach (Macbook macbook in ctx.Macbooks)
            {
                Console.WriteLine($"Model Id : {macbook.ModelId}\nModel Name : {macbook.ModelName}\nColor : {macbook.Color}" +
                    $"\nProcessor : {macbook.Processor}\nQuantity : {macbook.AvailableQuantity}\nPrice : Rs {macbook.Price}" +
                    $"\nScreen Size : {macbook.ScreenSize} inches\nStorage Space : {macbook.StorageSpace} GB");
            }
        }

        public static void UpdateMacbook(int ModelId)
        {
            Macbook macbookToBeUpdated = ctx.Macbooks.Find(ModelId);

            if (macbookToBeUpdated != null)
            {
                Console.WriteLine("\nSelect the field to be updated : \n1.Available Quantity\n2.Price");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("\nEnter updated Quantity : ");
                        int updatedQuantity = Convert.ToInt32(Console.ReadLine());

                        macbookToBeUpdated.AvailableQuantity = updatedQuantity;

                        ctx.SaveChanges();

                        Console.WriteLine("\nQuantity updated successfully.");

                        break;

                    case 2:

                        Console.WriteLine("\nEnter updated Price : ");
                        decimal updatedPrice = Convert.ToDecimal(Console.ReadLine());

                        macbookToBeUpdated.Price = updatedPrice;

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

        public static void DeleteMacbook(int ModelId)
        {
            Macbook macbookToBeDeleted = ctx.Macbooks.Find(ModelId);

            if (macbookToBeDeleted != null)
            {
                ctx.Macbooks.Remove(macbookToBeDeleted);

                ctx.SaveChanges();

                Console.WriteLine("\nMacbook deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nProvided Model Id doesn't exist!");
            }
        }
    }
}