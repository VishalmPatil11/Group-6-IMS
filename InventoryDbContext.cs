using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public class InventoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = VISHALMIL-VD\\SQL2017; Database = IMSDataBase; User Id = sa; Password = cybage@123456");
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<IPhone> IPhones { get; set; }

        public virtual DbSet<IPad> IPads { get; set; }

        public virtual DbSet<Macbook> Macbooks { get; set; }

        public virtual DbSet<IWatch> IWatches { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
    }
}