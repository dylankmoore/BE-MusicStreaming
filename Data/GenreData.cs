using BE_MusicStreaming.Models;

namespace BE_MusicStreaming.Data
{
    public class GenreData
    {
        public static List<Genre> Genres = new List<Genre>
        {
            new Genre { Id = 1, Name = "Pop" },
            new Genre { Id = 2, Name = "Hip Hop" },
            new Genre { Id = 3, Name = "Rock" },
            new Genre { Id = 4, Name = "R&B" },
            new Genre { Id = 5, Name = "Dance" },
            new Genre { Id = 6, Name = "Soul" },
            new Genre { Id = 7, Name = "Nu Metal" },
            new Genre { Id = 8, Name = "Alternative Rock" },
            new Genre { Id = 9, Name = "Country" },
            new Genre { Id = 10, Name = "Pop Punk" }

        };
    }
}
