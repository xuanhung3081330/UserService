using Microsoft.EntityFrameworkCore;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Infrastructure.EFCore
{
    public class UserDbContext : DbContext
    {
        public DbSet<Retailer> Retailers { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        //public UserDbContext()
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseMySQL("Server=localhost;Database=smallproj.user;Uid=root;Pwd=1234");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Retailer
            modelBuilder.ApplyConfiguration(new RetailerEntityTypeConfiguration());
        }
    }
}
