using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    class Context: DbContext
    {
        public DbSet<User> user { get; set; }
        public DbSet<Devices> devices { get; set; }
        public DbSet<Component> component { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=Comax;Trusted_Connection=True");
        }

    }
}
