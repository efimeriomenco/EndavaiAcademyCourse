using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endava.iAcademy.Domain
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public float Rating { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        
        public virtual List<Lesson> Lessons { get; set; }
       
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public IEnumerable<UserToCourse> CourseToUsers { get; set; }
    }

    public class CourseMapper : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Title).IsUnique(true);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Price).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Author).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description);
            builder.HasMany(x => x.Lessons).WithOne(x => x.Course).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.Category).WithMany(x => x.Courses).HasForeignKey(x => x.CategoryId);
        }
    }
}
