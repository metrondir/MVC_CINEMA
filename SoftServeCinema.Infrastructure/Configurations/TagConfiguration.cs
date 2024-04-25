using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeCinema.Core.Entities;

namespace SoftServeCinema.Infrastructure.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder
                .HasKey(t => t.Id)
            ;

            builder
                .Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired()
            ;

            builder
                .HasMany(t => t.Movies)
                .WithMany(m => m.Tags)
            ;
        }
    }
}
