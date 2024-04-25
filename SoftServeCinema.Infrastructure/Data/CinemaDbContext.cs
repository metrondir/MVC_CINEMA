using Microsoft.EntityFrameworkCore;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Infrastructure.Configurations;

namespace SoftServeCinema.Infrastructure.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            modelBuilder.SeedMoviesWithRelations();
        }

        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<ActorEntity> Actors { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<SessionEntity> Sessions { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
    }
}
