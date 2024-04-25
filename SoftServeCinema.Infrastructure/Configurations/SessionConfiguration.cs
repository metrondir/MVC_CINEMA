using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeCinema.Core.Entities;

namespace SoftServeCinema.Infrastructure.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<SessionEntity>
    {
        public void Configure(EntityTypeBuilder<SessionEntity> builder)
        {
            builder
                .HasKey(s => s.Id)
            ;

            builder
                .Property(s => s.StartDate)
                .HasColumnType("datetime")
                .IsRequired()
            ;

            builder
                .Property(s => s.BasicPrice)
                .HasColumnType("decimal(10,2)")
                .IsRequired()
            ;

            builder
                .Property(s => s.VipPrice)
                .HasColumnType("decimal(10,2)")
                .IsRequired()
            ;

            builder
                .HasOne(s => s.Movie)
                .WithMany(m => m.Sessions)
                .HasForeignKey(s => s.MovieId)
            ;

            builder
                .HasMany(s => s.Tickets)
                .WithOne(t => t.Session)
                .HasForeignKey(t => t.SessionId)
            ;
        }
    }
}
