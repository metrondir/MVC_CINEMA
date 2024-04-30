using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeCinema.Core.Entities;

namespace SoftServeCinema.Infrastructure.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<TicketEntity>
    {
        public void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            builder
                .HasKey(t => t.Id)
            ;

            builder
                .Property(t => t.RowNumber)
                .HasColumnType("smallint")
                .IsRequired()
            ;

            builder
                .Property(t => t.SeatNumber)
                .HasColumnType("smallint")
                .IsRequired()
            ;

            builder
                .Property(t => t.ReservationDate)
                .HasColumnType("datetime")
                .IsRequired()
            ;

            builder
                .Property(t => t.Status)
                .HasMaxLength(50)
                .IsRequired()
            ;

            builder
                .HasOne(t => t.Session)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.SessionId)
            ;

            builder
               .HasOne(t => t.User)
               .WithMany(s => s.Tickets)
               .HasForeignKey(t => t.UserId)
           ;
        }
    }
}
