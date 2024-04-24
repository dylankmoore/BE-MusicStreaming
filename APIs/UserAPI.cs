using BE_MusicStreaming.DTOs;

namespace BE_MusicStreaming.APIs
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/checkuser", (BE_MusicStreamingDbContext db, UserDTO userAuthDto) => {
                var userUid = db.Users.SingleOrDefault(user => user.Uid == userAuthDto.Uid);

                if (userUid == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(userUid);
                }
            });

            app.MapGet("/user/{id}", (BE_MusicStreamingDbContext db, int id) => {
                var userDetails = db.Users.SingleOrDefault(u => u.Id == id);
                if (userDetails is null)
                { 
                    return Results.NotFound(id);
                }
                return Results.Ok(userDetails);
            });
        }
    }
}
