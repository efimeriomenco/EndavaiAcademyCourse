using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Endava.iAcademy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Endava.iAcademy.Repository
{
    public class EndavaiAcademyDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserToCourse> UserToCourses { get; set; }

        public EndavaiAcademyDbContext(DbContextOptions<EndavaiAcademyDbContext> options) 
            : base(options)
        {
        }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLOCALDB;Database=EndavaIAcademyDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMapper());
            modelBuilder.ApplyConfiguration(new LessonMapper());
            modelBuilder.ApplyConfiguration(new CategoryMapper());
            modelBuilder.ApplyConfiguration(new UserMapper());
            modelBuilder.ApplyConfiguration(new UserToCourseMapper());
        }
    }
}
