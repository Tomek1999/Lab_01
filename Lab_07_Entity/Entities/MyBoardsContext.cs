using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07_Entity.Entities
{
    class MyBoardsContext : DbContext
    {
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Address>Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\;Database=MyBoard;Trusted_Connection=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(x => x.UpdateddDate).ValueGeneratedOnUpdate();
            });
             
            // One to One
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(u => u.User)
                .HasForeignKey<Address>(a => a.UserId);
            // One to Many
            modelBuilder.Entity<WorkItem>()
                .HasMany(x => x.Coments)
                .WithOne(c => c.WorkItem)
                .HasForeignKey(x => x.WorkItemId);

            modelBuilder.Entity<WorkItem>(eb =>
            {
                eb.HasOne(x => x.Author)
                .WithMany(x => x.WorkItems)
                .HasForeignKey(x => x.AuthorId);
                // Many to Many
                eb.HasMany(w => w.Tags)
                .WithMany(t => t.WorkItems)
                .UsingEntity<WorkItemTag>(
                    w => w.HasOne(wit => wit.Tag)
                    .WithMany()
                    .HasForeignKey(wit => wit.TagId),

                      w => w.HasOne(wit => wit.WorkItem)
                    .WithMany()
                    .HasForeignKey(wit => wit.WorkItemId),

                      wit=> 
                      {
                          wit.HasKey(x => new { x.TagId, x.WorkItemId });
                          wit.Property(x => x.PublicationDate).HasDefaultValueSql("getutcdate()");
                      }
                    ); 
            });


                
        }

    }
}
