namespace BE_MusicStreaming.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Year { get; set; }
        public string Duration { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
