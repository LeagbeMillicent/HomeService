using HomeService.Application.DTOs.Categories;
using HomeService.Application.DTOs.Customers;
using HomeService.Application.DTOs.Requests;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.DTOs.WorkUnits;
using HomeService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Infrastructure.Persistence.Data
{
    public class HomeServiceDbContext : DbContext
    {

        public HomeServiceDbContext(DbContextOptions<HomeServiceDbContext> options) : base(options)
        {

        }


        
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Worker>? Workers { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Request>? Requests { get; set; }
        public DbSet<WorkUnit>? WorkUnits { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(sc => sc.CategoryId);
            modelBuilder.Entity<Customer>().HasKey(sc => sc.CustomerId);
            modelBuilder.Entity<Worker>().HasKey(sc => sc.WorkerId);
            modelBuilder.Entity<Request>().HasKey(sc => sc.RequestId);
            modelBuilder.Entity<WorkUnit>().HasKey(sc => sc.WorkUnitsId);
        }




        
    }
}
