using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeCinema.Core.Entities;

namespace SoftServeCinema.Infrastructure.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder
                .HasKey(g => g.Id)
            ;

            builder
                .Property(g => g.Name)
                .HasMaxLength(50)
                .IsRequired()
            ;

            builder
                .HasMany(g => g.Movies)
                .WithMany(m => m.Genres)
            ;
        }
    }
}
