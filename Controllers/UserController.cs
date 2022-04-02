using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System
{
    public static class UserController
    {
        public static void HandleUserMenu(int CategoryId)
        {
            switch(CategoryId)
            {
                case 1:

                    IPhoneController.HandleIPhoneMenu();

                    break;

                case 2:

                    IPadController.HandleIPadMenu();

                    break;

                case 3:

                    IWatchController.HandleIWatchMenu();

                    break;

                case 4:

                    MacbookController.HandleMacbookMenu();

                    break;

                default:

                    Console.WriteLine("\nInvalid Choice!");

                    break;
            }
        }
    }
}
