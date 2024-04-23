namespace BE_MusicStreaming.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Public { get; set; }
        public bool IsFavorite { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
