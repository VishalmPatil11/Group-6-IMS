using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Inventory_Management_System
{
    public static class IPhoneController
    {
        static InventoryDbContext ctx = new InventoryDbContext();

        public static void HandleIPhoneMenu()
        {
            bool flag = true;

            int choice;

            do
            {
                Console.WriteLine("\nEnter your choice : \n1.Add IPhone\n2.List all IPhones\n3.Update IPhone\n4.Delete IPhone\n5.Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    //Adding IPhones
                    case 1:

                        try
                        {
                            Console.WriteLine("Enter IPhone details : ");

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

                            IPhoneController.AddIPhone(modelname, color, processor, quantity, price, screenSize, storageSpace);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    //Listing down all IPhones
                    case 2:

                        IPhoneController.ListAllIPhones();

                        break;

                    //Updating IPhone
                    case 3:

                        Console.WriteLine("\nEnter the Model Id of the IPhone to be updated : ");

                        int modelIdToBeUpdated = Convert.ToInt32(Console.ReadLine());

                        IPhoneController.UpdateIPhone(modelIdToBeUpdated);

                        break;

                    //Deleting IPhone
                    case 4:

                        Console.WriteLine("\nEnter the Model Id of the IPhone to be deleted : ");

                        int modelIdToBeDeleted = Convert.ToInt32(Console.ReadLine());

                        IPhoneController.DeleteIPhone(modelIdToBeDeleted);

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

        public static void AddIPhone(string modelname, string color, string processor, int quantity, decimal price, float screenSize, int storageSpace)
        {
            IPhone newIPhone = new IPhone()
            {
                ModelName = modelname,
                Color = color,
                Processor = processor,
                AvailableQuantity = quantity,
                Price = price,
                ScreenSize = screenSize,
                StorageSpace = storageSpace
            };

            ctx.IPhones.Add(newIPhone);

            ctx.SaveChanges();

            Console.WriteLine("\nIPhone added successfully!");
        }

        public static void ListAllIPhones()
        {
            Console.WriteLine("\nAll IPhones :\n");

            foreach (IPhone iphone in ctx.IPhones)
            {
                Console.WriteLine($"\nModel Id : {iphone.ModelId}\nModel Name : {iphone.ModelName}\nColor : {iphone.Color}" +
                    $"\nProcessor : {iphone.Processor}\nQuantity : {iphone.AvailableQuantity}\nPrice : Rs {iphone.Price}" +
                    $"\nScreen Size : {iphone.ScreenSize} inches\nStorage Space : {iphone.StorageSpace} GB");
            }
        }

        public static void UpdateIPhone(int ModelId)
        {
            IPhone iphoneToBeUpdated = ctx.IPhones.Find(ModelId);

            if (iphoneToBeUpdated != null)
            {
                Console.WriteLine("\nSelect the field to be updated : \n1.Available Quantity\n2.Price");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("\nEnter updated Quantity : ");
                        int updatedQuantity = Convert.ToInt32(Console.ReadLine());

                        iphoneToBeUpdated.AvailableQuantity = updatedQuantity;

                        ctx.SaveChanges();

                        Console.WriteLine("\nQuantity updated successfully.");

                        break;

                    case 2:

                        Console.WriteLine("\nEnter updated Price : ");
                        decimal updatedPrice = Convert.ToDecimal(Console.ReadLine());

                        iphoneToBeUpdated.Price = updatedPrice;

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

        public static void DeleteIPhone(int ModelId)
        {
            IPhone iphoneToBeDeleted = ctx.IPhones.Find(ModelId);

            if(iphoneToBeDeleted != null)
            {
                ctx.IPhones.Remove(iphoneToBeDeleted);

                ctx.SaveChanges();

                Console.WriteLine("\nIPhone deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nProvided Model Id doesn't exist!");
            }
        }
    }
}