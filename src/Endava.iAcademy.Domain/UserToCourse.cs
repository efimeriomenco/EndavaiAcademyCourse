using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endava.iAcademy.Domain
{
    public class UserToCourse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }

    public class UserToCourseMapper : IEntityTypeConfiguration<UserToCourse>
    {
        public void Configure(EntityTypeBuilder<UserToCourse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.User).WithMany(x => x.UserToCourses).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Course).WithMany(x => x.CourseToUsers).HasForeignKey(x => x.CourseId);
        }
    }
}

