using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endava.iAcademy.Domain
{
     public class Category
    {

       public int Id { get; set; }
       public string Title { get; set; }
       public virtual List<Course> Courses {get; set;}

    }

    public class CategoryMapper : IEntityTypeConfiguration<Category>
    {
       public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired();
            builder.HasMany(x => x.Courses).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
