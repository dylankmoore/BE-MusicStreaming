using BE_MusicStreaming.Models;

namespace BE_MusicStreaming.Data
{
    public class PlaylistData
    {
        public static List<Playlist> Playlists = new List<Playlist>
        {
            new Playlist
            {
                Id = 1,
                Name = "Y2K Alt Anthems",
                DateCreated = new DateTime(2024, 4, 01),
                Public = true,
                IsFavorite = false,
                UserId = 1
            },
            new Playlist
            {
                Id = 2,
                Name = "Pop Princesses",
                DateCreated = new DateTime(2024, 3, 15),
                Public = true,
                IsFavorite = true,
                UserId = 1
            },
            new Playlist
            {
                Id = 3,
                Name = "Love & Heartbreak",
                DateCreated = new DateTime(2024, 4, 20),
                Public = false,
                IsFavorite = true,
                UserId = 1
            }
        };
    }
}