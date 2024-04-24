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
                ImageUrl = " https://townsquare.media/site/443/files/2013/06/vid1.jpg?w=1200&h=0&zc=1&s=0&a=t&q=89",
                Public = true,
                IsFavorite = false,
                UserId = 1
            },
            new Playlist
            {
                Id = 2,
                Name = "Pop Princesses",
                DateCreated = new DateTime(2024, 3, 15),
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/81gEr9Kx1LL._AC_SL1417_.jpg",
                Public = true,
                IsFavorite = true,
                UserId = 1
            },
            new Playlist
            {
                Id = 3,
                Name = "Love & Heartbreak",
                DateCreated = new DateTime(2024, 4, 20),
                ImageUrl = "https://i2-prod.mirror.co.uk/incoming/article20126256.ece/ALTERNATES/s615b/0_Britney-Spears-07.jpg",
                Public = false,
                IsFavorite = true,
                UserId = 1
            }
        };
    }
}