using Microsoft.EntityFrameworkCore;
using BE_MusicStreaming.Models;
using BE_MusicStreaming.Data;

namespace BE_MusicStreaming
{
    public class BE_MusicStreamingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }

        public BE_MusicStreamingDbContext(DbContextOptions<BE_MusicStreamingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(UserData.Users);
            modelBuilder.Entity<Artist>().HasData(ArtistData.Artists);
            modelBuilder.Entity<Genre>().HasData(GenreData.Genres);
            modelBuilder.Entity<Playlist>().HasData(PlaylistData.Playlists);
            modelBuilder.Entity<Song>().HasData(SongData.Songs);
        }

    }
}
