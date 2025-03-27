using Microsoft.EntityFrameworkCore;
using SMS_R_FoodApi.Models;
using System.Collections.Generic;

namespace SMS_R_FoodApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleParameter> SaleParameters { get; set; }
        public DbSet<ItemCategory> Category { get; set; }
    }
}
