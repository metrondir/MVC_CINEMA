using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeCinema.Core.Entities;

namespace SoftServeCinema.Infrastructure.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<ActorEntity>
    {
        public void Configure(EntityTypeBuilder<ActorEntity> builder)
        {
            builder
                .HasKey(a => a.Id)
            ;

            builder
                .Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired()
            ;

            builder
                .HasMany(a => a.Movies)
                .WithMany(m => m.Actors)
            ;
        }
    }
}
