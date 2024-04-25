using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeCinema.Core.Entities;

namespace SoftServeCinema.Infrastructure.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder
                .HasKey(m => m.Id)
            ;

            builder
                .Property(m => m.ImagePath)
                .HasMaxLength(255)
                .IsRequired()
            ;

            builder
                .Property(m => m.TrailerUrl)
                .HasMaxLength(255)
                .IsRequired()
            ;

            builder
                .Property(m => m.Title)
                .HasMaxLength(255)
                .IsRequired()
            ;

            builder
                .Property(m => m.Desc)
                .HasColumnType("text")
                .IsRequired()
            ;

            builder
                .Property(m => m.GraduationYear)
                .HasColumnType("smallint unsigned")
                .IsRequired()
            ;

            builder
                .Property(m => m.Duration)
                .HasColumnType("smallint unsigned")
                .IsRequired()
            ;

            builder
                .Property(m => m.StartRentalDate)
                .HasColumnType("datetime")
                .IsRequired()
            ;

            builder
                .Property(m => m.EndRentalDate)
                .HasColumnType("datetime")
                .IsRequired()
            ;

            builder
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
            ;

            builder
                .HasMany(m => m.Tags)
                .WithMany(t => t.Movies)
            ;

            builder
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
            ;

            builder
                .HasMany(m => m.Directors)
                .WithMany(d => d.Movies)
            ;

            builder
                .HasMany(m => m.Sessions)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId)
            ;
        }
    }
}