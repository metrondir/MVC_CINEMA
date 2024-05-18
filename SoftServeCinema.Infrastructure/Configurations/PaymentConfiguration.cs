using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SoftServeCinema.Core.Entities;

public class PaymentConfiguration : IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.TotalAmount)
               .HasColumnType("decimal(18, 2)")
               .IsRequired();

        builder.Property(t => t.PaymentDate)
               .IsRequired();

        builder.HasOne(p => p.User)
               .WithMany(u => u.Payments)
               .HasForeignKey(p => p.UserId)
               .IsRequired(false);

     
    }
}
