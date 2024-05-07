using HomeService.Application.DTOs.Customers;
using HomeService.Application.DTOs.NotificationDto;
using HomeService.Application.DTOs.PayMent;
using HomeService.Application.DTOs.Requests;
using HomeService.Application.DTOs.Services;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.DTOs.WorkSchedule;
using HomeService.Application.DTOs.WorkUnits;
using HomeService.Domain;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infrastructure.Persistence.Data
{
    public class HomeServiceDbContext : DbContext
    {
        public HomeServiceDbContext(DbContextOptions<HomeServiceDbContext> options) : base(options)
        {
        }

        // DbSet properties for entities
        public DbSet<tblCustomer>? Customers { get; set; }
        public DbSet<tblWorker>? Workers { get; set; }
        public DbSet<tblServices>? Services { get; set; }
        public DbSet<tblRequest>? Requests { get; set; }
        public DbSet<tblWorkUnit>? WorkUnits { get; set; }
        public DbSet<tblAdmin>? Admins { get; set; }
        public DbSet<tblNotification>? Notifications { get; set; }
        public DbSet<tblPayment>? Payments { get; set; }
        public DbSet<tblWorkSchedule>? WorkSchedules { get; set; }
        public DbSet<tblServiceArea>? ServiceAreas { get; set; }

        // Virtual DbSet properties for DTOs
        public virtual DbSet<ReadCustomersDto> ReadCustomers { get; set; }
        public virtual DbSet<ReadWorkersDetailsDto> ReadWorkersDetails { get; set; }
        public virtual DbSet<ReadRequestsDto> ReadRequests { get; set; }
        public virtual DbSet<GetAllNotificationsDto> GetAllNotifications { get; set; }
        public virtual DbSet<GetAllPaymentDto> GetAllPayment { get; set; }
        public virtual DbSet<ReadAllServicesDto> ReadAllServices { get; set; }
        public virtual DbSet<GetAllScheduleDto> GetAllSchedule { get; set; }
        public virtual DbSet<ReadWorkUnitsDto> ReadWorkUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity configurations
            modelBuilder.Entity<tblServices>().HasKey(sc => sc.CategoryId);
            modelBuilder.Entity<tblCustomer>().HasKey(sc => sc.CustomerId);
            modelBuilder.Entity<tblWorker>().HasKey(sc => sc.WorkerId);
            modelBuilder.Entity<tblRequest>().HasKey(sc => sc.ReqId);
            modelBuilder.Entity<tblWorkUnit>().HasKey(sc => sc.UnitId);
            modelBuilder.Entity<tblAdmin>().HasKey(sc => sc.AdminId);
            modelBuilder.Entity<tblNotification>().HasKey(sc => sc.NotId);
            modelBuilder.Entity<tblPayment>().HasKey(sc => sc.PaymentId);
            modelBuilder.Entity<tblWorkSchedule>().HasKey(sc => sc.ScheduleId);
            modelBuilder.Entity<tblServiceArea>().HasKey(sc => sc.AreaId);

            // DTO configurations
            modelBuilder.Entity<ReadCustomersDto>().HasNoKey();
            modelBuilder.Entity<ReadWorkersDetailsDto>().HasNoKey();
            modelBuilder.Entity<ReadRequestsDto>().HasNoKey();
            modelBuilder.Entity<GetAllNotificationsDto>().HasNoKey();
            modelBuilder.Entity<GetAllPaymentDto>().HasNoKey();
            modelBuilder.Entity<ReadAllServicesDto>().HasNoKey();
            modelBuilder.Entity<GetAllScheduleDto>().HasNoKey();
            modelBuilder.Entity<ReadWorkUnitsDto>().HasNoKey();

            // Property configurations
            modelBuilder.Entity<tblWorkUnit>().Property(w => w.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<tblPayment>().Property(w => w.Amount).HasColumnType("decimal(18,2)");
        }
    }
}
