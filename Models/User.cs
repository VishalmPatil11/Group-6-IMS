using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is mandatory!", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is mandatory!", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is mandatory!", AllowEmptyStrings = false)]
        [MaxLength(25)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is mandatory!", AllowEmptyStrings = false)]
        [MaxLength(25)]
        public string Password { get; set; }

        [Required(ErrorMessage = "CategoryId is mandatory!")]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required(ErrorMessage = "Role is mandatory!")]
        public Role Role { get; set; }
    }
}
