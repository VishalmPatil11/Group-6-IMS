using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System
{
    public class Macbook
    {
        [Key]
        public int ModelId { get; set; }

        [Required(ErrorMessage = "Model Name is required!")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "Color is required!")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Processor is required!")]
        public string Processor { get; set; }

        [Required(ErrorMessage = "Quantity is required!")]
        public int AvailableQuantity { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Screen Size is required!")]
        public float ScreenSize { get; set; }

        [Required(ErrorMessage = "Storage Space is required!")]
        public int StorageSpace { get; set; }
    }
}
