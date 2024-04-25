using BE_MusicStreaming.DTOs;
using BE_MusicStreaming.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_MusicStreaming.APIs
{
    public class PlaylistAPI
    {
        public static void Map(WebApplication app)
        {
            // GET ALL PLAYLISTS
            app.MapGet("/playlists", (BE_MusicStreamingDbContext db, int userId) =>
            {
                // get all playlists, including public playlists & playlists belonging to the user
                var playlists = db.Playlists
                    .Include(p => p.Songs).ThenInclude(s => s.Artist)
                    .Where(p => p.Public || p.UserId == userId);

                // select relevant playlist details
                var playlistData = playlists.Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.DateCreated,
                    p.Public,
                    UserName = p.User.Username,
                    Songs = p.Songs.Select(s => new
                    {
                        s.Id,
                        s.Name,
                        ArtistName = s.Artist.Name
                    })
                }).ToList();

                return Results.Ok(playlistData);
            });

            // GET ALL FAV PLAYLISTS
            app.MapGet("/playlists/favorite", (BE_MusicStreamingDbContext db, int userId) =>
            {
                // get all fav playlists, including those public 
                var playlists = db.Playlists
                    .Include(p => p.Songs).ThenInclude(s => s.Artist)
                    .Where(p => (p.IsFavorite && p.Public) || (p.IsFavorite && p.UserId == userId));

                // select relevant playlist details
                var playlistData = playlists.Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.DateCreated,
                    p.Public,
                    UserName = p.User.Username,
                    Songs = p.Songs.Select(s => new
                    {
                        s.Id,
                        s.Name,
                        ArtistName = s.Artist.Name
                    })
                }).ToList();

                return Results.Ok(playlistData);
            });

            // GET PLAYLIST BY ID
            app.MapGet("/playlists/{id}", (BE_MusicStreamingDbContext db, int id, int userId) =>
            {
                var playlist = db.Playlists
                    .Include(p => p.Songs).ThenInclude(s => s.Artist)
                    .Where(p => p.Id == id && (p.Public || p.UserId == userId))
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.DateCreated,
                        p.Public,
                        IsFavorite = p.IsFavorite,
                        ImageUrl = p.ImageUrl,
                        Songs = p.Songs.Select(s => new
                        {
                            s.Id,
                            s.Name,
                            ArtistName = s.Artist.Name,
                            GenreName = s.Genre.Name,
                            Duration = s.Duration
                        })
                    }).FirstOrDefault();

                if (playlist == null)
                {
                    return Results.NotFound("Playlist not found or access is restricted.");
                }

                return Results.Ok(playlist);
            });

            // GET USER'S PLAYLISTS
            app.MapGet("/playlists/mine", (BE_MusicStreamingDbContext db, int userId) =>
            {
                // get playlists that only belong to current user
                var myPlaylists = db.Playlists
                    .Include(p => p.Songs).ThenInclude(s => s.Artist)
                    .Where(p => p.UserId == userId)
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.DateCreated,
                        p.Public,
                        UserName = p.User.Username,
                        Songs = p.Songs.Select(s => new
                        {
                            s.Id,
                            s.Name,
                            ArtistName = s.Artist.Name
                        })
                    }).ToList();

                return Results.Ok(myPlaylists);
            });

            // CREATE A PLAYLIST
            app.MapPost("/playlists", (BE_MusicStreamingDbContext db, PlaylistDTO playlistDto, int userId) =>
            {
                // verify that the user exists
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    return Results.NotFound("User not found.");
                }

                // create a new playlist and associate it with the user
                var newPlaylist = new Playlist
                {
                    Name = playlistDto.Name,
                    ImageUrl = playlistDto.ImageUrl,
                    Public = playlistDto.Public,
                    IsFavorite = playlistDto.IsFavorite,
                    DateCreated = DateTime.Now,
                    UserId = userId
                };

                // add the playlist to the db & save changes
                db.Playlists.Add(newPlaylist);
                db.SaveChanges();

                return Results.Created($"/playlists/{newPlaylist.Id}", newPlaylist);
            });

            // UPDATE A PLAYLIST
            app.MapPut("/playlists/{id}", (BE_MusicStreamingDbContext db, int id, PlaylistDTO playlistDto) =>
            {
                var playlist = db.Playlists.FirstOrDefault(p => p.Id == id);

                if (playlist == null)
                {
                    return Results.NotFound("Playlist not found.");
                }

                // update playlist properties
                playlist.Name = playlistDto.Name ?? playlist.Name;
                playlist.Public = playlistDto.Public;
                playlist.IsFavorite = playlistDto.IsFavorite;
                playlist.ImageUrl = playlistDto.ImageUrl ?? playlist.ImageUrl;

                db.SaveChanges();

                // return updated playlist details
                return Results.Ok(new
                {
                    Id = playlist.Id,
                    Name = playlist.Name,
                    Public = playlist.Public,
                    IsFavorite = playlist.IsFavorite,
                    ImageUrl = playlist.ImageUrl
                });
            });

            // DELETE A PLAYLIST
            app.MapDelete("/playlists/{Id}", (BE_MusicStreamingDbContext db, int Id) =>
            {
                var playlist = db.Playlists.FirstOrDefault(p => p.Id == Id);

                if (playlist == null)
                {
                    return Results.NotFound("Playlist not found.");
                }

                db.Playlists.Remove(playlist);
                db.SaveChanges();

                return Results.Ok($"Playlist {Id} has been deleted.");
            });


        }
    }
}
 
    