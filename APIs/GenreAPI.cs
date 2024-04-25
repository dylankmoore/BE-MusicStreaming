namespace BE_MusicStreaming.APIs
{
    public class GenreAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/genres", (BE_MusicStreamingDbContext db) => {
                return db.Genres;
            });

            app.MapGet("/api/genres/{id}", (BE_MusicStreamingDbContext db, int id) => {
                var genreDetails = db.Genres.FirstOrDefault(a => a.Id == id);
                if (genreDetails is null)
                {
                    return Results.NotFound(id);
                }
                return Results.Ok(genreDetails);
            });
        }
    }
}
