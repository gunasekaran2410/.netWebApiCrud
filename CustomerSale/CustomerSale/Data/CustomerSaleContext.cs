using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerSale.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CustomerSale.Data
{
    public class CustomerSaleContext : DbContext
    {
        public CustomerSaleContext (DbContextOptions<CustomerSaleContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //master tables

           
            builder.Entity<StudentModel>().Property(x => x.StudentId).HasDefaultValueSql("NEWID()");
            builder.Entity<AttendanceModel>().Property(x => x.AttendanceId).HasDefaultValueSql("NEWID()");
            builder.Entity<CollegeModel>().Property(x => x.CollegeId).HasDefaultValueSql("NEWID()");
            builder.Entity<SectionModel>().Property(x => x.SectionId).HasDefaultValueSql("NEWID()");
            builder.Entity<ScheduleModel>().Property(x => x.ScheduleId).HasDefaultValueSql("NEWID()");
            builder.Entity<DepartmentModel>().Property(x => x.DepartmentId).HasDefaultValueSql("NEWID()");
            builder.Entity<EnrollmentModel>().Property(x => x.EnrollmentId).HasDefaultValueSql("NEWID()");
            builder.Entity<InstructorModel>().Property(x => x.InstructorId).HasDefaultValueSql("NEWID()");
            builder.Entity<CourseModel>().Property(x => x.CourseId).HasDefaultValueSql("NEWID()");
            // builder.Entity<userroles>().Property(s => s.created_date).HasDefaultValueSql("GETDATE()");
            // builder.Entity<userroles>().Property(b => b.flag).HasDefaultValue(true);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<CustomerSale.Models.StudentModel> StudentModel { get; set; } = default!;
        public DbSet<CustomerSale.Models.AttendanceModel>? AttendanceModel { get; set; }
        public DbSet<CustomerSale.Models.CollegeModel>? CollegeModel { get; set; }
        public DbSet<CustomerSale.Models.SectionModel>? SectionModel { get; set; }
        public DbSet<CustomerSale.Models.ScheduleModel>? ScheduleModel { get; set; }
        public DbSet<CustomerSale.Models.DepartmentModel>? DepartmentModel { get; set; }
        public DbSet<CustomerSale.Models.EnrollmentModel>? EnrollmentModel { get; set; }
        public DbSet<CustomerSale.Models.InstructorModel>? InstructorModel { get; set; }
        public DbSet<CustomerSale.Models.CourseModel>? CourseModel { get; set; }
    }
}
