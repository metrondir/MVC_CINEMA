using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeCinema.Core.Entities;

namespace SoftServeCinema.Infrastructure.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<DirectorEntity>
    {
        public void Configure(EntityTypeBuilder<DirectorEntity> builder)
        {
            builder
                .HasKey(d => d.Id)
            ;

            builder
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired()
            ;

            builder
                .HasMany(d => d.Movies)
                .WithMany(m => m.Directors)
            ;
        }
    }
}
