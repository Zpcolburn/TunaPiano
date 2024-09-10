using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;
using TunaPiano.Data;

namespace TunaPiano
{
    public class TunaPianoDBContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }

        public TunaPianoDBContext(DbContextOptions<TunaPianoDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(ArtistData.Artists);
            modelBuilder.Entity<Genre>().HasData(GenreData.Genres);
            modelBuilder.Entity<Song>().HasData(SongData.Songs);
        }

    }
}