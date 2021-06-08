using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endava.iAcademy.Domain
{
    public class User 
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserPoints { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
        public IEnumerable<UserToCourse> UserToCourses { get; set; }
    }
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.UserPoints).IsRequired();
            builder.HasMany(x => x.UserToCourses);
            builder.HasOne(x => x.Role).WithMany(x => x.Users);

        }
    }
}
