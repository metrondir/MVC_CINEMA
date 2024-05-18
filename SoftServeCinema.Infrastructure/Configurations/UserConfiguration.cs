using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeCinema.Core.Entities;

namespace SoftServeCinema.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasKey(t => t.Id)
            ;
            builder
                .Property(t => t.Email)
                .HasMaxLength(50)
                .IsRequired()
                ;

            builder
                .Property(t => t.FirstName)
                .HasMaxLength(50)
                .IsRequired()
                ;
            builder
                .Property(t => t.LastName)
                .HasMaxLength(50)
                .IsRequired()
                ;
            builder
                .Property(t => t.RoleName)
                .HasMaxLength(50)
                .IsRequired()
                ;
            builder
               .HasMany(s => s.Tickets)
               .WithOne(t => t.User)
               .HasForeignKey(t => t.UserId)
                ;
            builder
                .HasMany(s => s.Payments)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                ;


        }
    }
}
