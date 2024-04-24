namespace BE_MusicStreaming.APIs
{
    public class ArtistAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/artists", (BE_MusicStreamingDbContext db) => {
                return db.Artists;
            });

            app.MapGet("/api/artists/{id}", (BE_MusicStreamingDbContext db, int id) => {
                var artistDetails = db.Artists.FirstOrDefault(a => a.Id == id);
                if (artistDetails is null) 
                { 
                    return Results.NotFound(id);
                }
                return Results.Ok(artistDetails);
            });
        }
    }
}
