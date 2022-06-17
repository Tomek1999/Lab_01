using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07_Entity.Homework
{
    class HomeWorkContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Roles>Roles { get; set; }
        public DbSet<Tasks>Tasks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=HomeWork;Trusted_Connection=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to one relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Roles)
                .WithOne(u => u.User)
                .HasForeignKey<Roles>(a => a.UserId);

            //one to many relationship
            modelBuilder.Entity<Roles>()
                .HasMany(r => r.Tasks)
                .WithOne(r => r.Roles)
                .HasForeignKey(r=>r.RolesId);
        }


    }
}
