using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endava.iAcademy.Domain
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }

    public class LessonMapper : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Link).IsRequired();
            builder.Property(x => x.Description);
            builder.HasOne(x => x.Course).WithMany(c => c.Lessons).HasForeignKey(x => x.CourseId);
        }
    }
}
