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


        
        public DbSet<tblCustomer>? Customers { get; set; }
        public DbSet<tblWorker>? Workers { get; set; }
        public DbSet<tblServices>? Categories { get; set; }
        public DbSet<tblRequest>? Requests { get; set; }
        public DbSet<tblWorkUnit>? WorkUnits { get; set; }

        public virtual DbSet<ReadCustomersDto> ReadCustomersDto { get; set; }
        public virtual DbSet<ReadWorkersDetailsDto> ReadWorkersDetailsDto { get; set; }
        public virtual DbSet<CreateRequestDto> CreateRequestDto { get; set; }
        public virtual DbSet<AddCustomersDto> AddCustomersDto { get; set; }
        public virtual DbSet<ReadRequestsDto> ReadRequestsDto { get; set; }
        public virtual DbSet<UpdateRequestsDto> UpdateRequestsDto { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblServices>().HasKey(sc => sc.CategoryId);
            modelBuilder.Entity<tblCustomer>().HasKey(sc => sc.CustomerId);
            modelBuilder.Entity<tblWorker>().HasKey(sc => sc.WorkerId);
            modelBuilder.Entity<tblRequest>().HasKey(sc => sc.ReqId);
            modelBuilder.Entity<tblWorkUnit>().HasKey(sc => sc.WorkUnitsId);
            modelBuilder.Entity<ReadCustomersDto>().HasNoKey();
            modelBuilder.Entity<ReadWorkersDetailsDto>().HasNoKey();
            modelBuilder.Entity<CreateRequestDto>().HasNoKey();
            modelBuilder.Entity<ReadRequestsDto>().HasNoKey();
            modelBuilder.Entity<UpdateRequestsDto>().HasNoKey();
            modelBuilder.Entity<AddCustomersDto>().HasNoKey();
        }




        
    }
}
