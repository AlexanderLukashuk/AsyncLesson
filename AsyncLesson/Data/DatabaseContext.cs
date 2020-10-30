using AsyncLesson.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncLesson.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.Migrate();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = AsyncLesson; Trusted_Connection = true").UseLazyLoadingProxies();
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var chemestry = new Category
            {
                Name = "Химия"
            };

            var products = new Category
            {
                Name = "Продукты"
            };

            modelBuilder.Entity<Category>().HasData(new List<Category>
            {
                chemestry,
                products
            });

            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                        new Product
                        {
                            Name = "Ariel автомат",
                            Price = 850,
                            CategoryId = chemestry.Id
                        },
                        new Product
                        {
                            Name = "Ariel ручной",
                            Price = 750,
                            CategoryId = chemestry.Id
                        },
                        new Product
                        {
                            Name = "Мыло",
                            Price = 200,
                            CategoryId = chemestry.Id
                        },
                        new Product
                        {
                            Name = "Хлеб",
                            Price = 120,
                            CategoryId = products.Id
                        },
                        new Product
                        {
                            Name = "Nuts",
                            Price = 450,
                            CategoryId = chemestry.Id
                        },
                        new Product
                        {
                            Name = "Сливки 25%",
                            Price = 650,
                            CategoryId = chemestry.Id
                        }
                    });
        }
    }
}
