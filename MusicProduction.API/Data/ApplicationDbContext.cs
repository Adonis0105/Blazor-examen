using Microsoft.EntityFrameworkCore;
using MusicProduction.API.Models;

namespace MusicProduction.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("albums");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.ReleaseDate).IsRequired();
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("songs");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Artist).IsRequired();

                entity.HasOne(d => d.Album)
                      .WithMany(p => p.Songs)
                      .HasForeignKey(d => d.AlbumId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}