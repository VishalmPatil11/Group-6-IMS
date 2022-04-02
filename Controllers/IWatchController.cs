using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Inventory_Management_System
{
    public static class IWatchController
    {
        static InventoryDbContext ctx = new InventoryDbContext();

        public static void HandleIWatchMenu()
        {
            bool flag = true;

            int choice;

            do
            {
                Console.WriteLine("\nEnter your choice : \n1.Add IWatch\n2.List all IWatches\n3.Update IWatch\n4.Delete IWatch\n5.Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    //Adding IWatches
                    case 1:

                        try
                        {
                            Console.WriteLine("Enter IWatch details : ");

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

                            IWatchController.AddIWatch(modelname, color, processor, quantity, price, screenSize, storageSpace);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    //Listing down all IWatches
                    case 2:

                        IWatchController.ListAllIWatches();

                        break;

                    //Updating IWatch
                    case 3:

                        Console.WriteLine("\nEnter the Model Id of the IWatch to be updated : ");

                        int modelIdToBeUpdated = Convert.ToInt32(Console.ReadLine());

                        IWatchController.UpdateIWatch(modelIdToBeUpdated);

                        break;

                    //Deleting IWatch
                    case 4:

                        Console.WriteLine("\nEnter the Model Id of the IWatch to be deleted : ");

                        int modelIdToBeDeleted = Convert.ToInt32(Console.ReadLine());

                        IWatchController.DeleteIWatch(modelIdToBeDeleted);

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

        public static void AddIWatch(string modelname, string color, string processor, int quantity, decimal price, float screenSize, int storageSpace)
        {
            IWatch newIWatch = new IWatch()
            {
                ModelName = modelname,
                Color = color,
                Processor = processor,
                AvailableQuantity = quantity,
                Price = price,
                ScreenSize = screenSize,
                StorageSpace = storageSpace
            };

            ctx.IWatches.Add(newIWatch);

            ctx.SaveChanges();

            Console.WriteLine("\nIWatch added successfully!");
        }

        public static void ListAllIWatches()
        {
            Console.WriteLine("\nAll IWatches :\n");

            foreach (IWatch iwatch in ctx.IWatches)
            {
                Console.WriteLine($"Model Id : {iwatch.ModelId}\nModel Name : {iwatch.ModelName}\nColor : {iwatch.Color}" +
                    $"\nProcessor : {iwatch.Processor}\nQuantity : {iwatch.AvailableQuantity}\nPrice : Rs {iwatch.Price}" +
                    $"\nScreen Size : {iwatch.ScreenSize} inches\nStorage Space : {iwatch.StorageSpace} GB");
            }
        }

        public static void UpdateIWatch(int ModelId)
        {
            IWatch iwatchToBeUpdated = ctx.IWatches.Find(ModelId);

            if (iwatchToBeUpdated != null)
            {
                Console.WriteLine("\nSelect the field to be updated : \n1.Available Quantity\n2.Price");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("\nEnter updated Quantity : ");
                        int updatedQuantity = Convert.ToInt32(Console.ReadLine());

                        iwatchToBeUpdated.AvailableQuantity = updatedQuantity;

                        ctx.SaveChanges();

                        Console.WriteLine("\nQuantity updated successfully.");

                        break;

                    case 2:

                        Console.WriteLine("\nEnter updated Price : ");
                        decimal updatedPrice = Convert.ToDecimal(Console.ReadLine());

                        iwatchToBeUpdated.Price = updatedPrice;

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

        public static void DeleteIWatch(int ModelId)
        {
            IWatch iwatchToBeDeleted = ctx.IWatches.Find(ModelId);

            if (iwatchToBeDeleted != null)
            {
                ctx.IWatches.Remove(iwatchToBeDeleted);

                ctx.SaveChanges();

                Console.WriteLine("\nIWatch deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nProvided Model Id doesn't exist!");
            }
        }
    }
}