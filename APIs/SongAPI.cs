using BE_MusicStreaming.Models;
using BE_MusicStreaming.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BE_MusicStreaming.APIs
{
    public class SongAPI
    {
        public static void Map(WebApplication app)
        {
            //get all songs
            app.MapGet("/api/songs", (BE_MusicStreamingDbContext db) =>
            {
                return db.Songs
                         .Include(s => s.Genre).Include(s => s.Artist);
            });

            //get single song
            app.MapGet("/api/songs/{songId}", (BE_MusicStreamingDbContext db, int songId) =>
            {
                Song song = db.Songs
                              .Include(s => s.Genre).Include(s => s.Artist).Include(s => s.Playlists)
                              .SingleOrDefault(s => s.Id == songId);
                if (song != null)
                {
                    return Results.Ok(song);
                }
                return Results.NotFound("no song found");
            });

            //get songs by genreId
            app.MapGet("/api/songs/genre/{genreId}", (BE_MusicStreamingDbContext db, int genreId) =>
            {
                List<Song> genreSongs = db.Songs
                              .Include(s => s.Genre).Include(s => s.Artist)
                              .Where(s => s.GenreId == genreId)
                              .ToList();
                if (genreSongs != null)
                {
                    return Results.Ok(genreSongs);
                }
                return Results.NotFound("no songs found");
            });

            //get songs by artistId
            app.MapGet("/api/songs/artist/{artistId}", (BE_MusicStreamingDbContext db, int artistId) =>
            {
                List<Song> artistSongs = db.Songs
                              .Include(s => s.Genre).Include(s => s.Artist)
                              .Where(s => s.ArtistId == artistId)
                              .ToList();
                if (artistSongs != null)
                {
                    return Results.Ok(artistSongs);
                }
                return Results.NotFound("no songs found");
            });

            //add song to playlist
            app.MapPatch("/api/playlists/add/{playlistId}", (BE_MusicStreamingDbContext db, SongPlaylistDTO songToAdd) =>
            {
                Playlist playlist = db.Playlists
                                      .Include(p => p.Songs)
                                      .SingleOrDefault(p => p.Id == songToAdd.PlaylistId);
                if (playlist != null)
                {
                    Song song = db.Songs
                                  .SingleOrDefault(s => s.Id == songToAdd.SongId);
                    if (song != null)
                    {
                        if (playlist.Songs.Contains(song))
                        {
                            return Results.BadRequest("song already on playlist");
                        }
                        playlist.Songs.Add(song);
                        db.SaveChanges();
                        return Results.Ok("song added to playlist");
                    }
                    return Results.BadRequest("song not found");
                }
                return Results.BadRequest("playlist not found");
            });

            //remove song from playlist
            app.MapPatch("/api/playlists/remove/{playlistId}", (BE_MusicStreamingDbContext db, SongPlaylistDTO songToRemove) =>
            {
                Playlist playlist = db.Playlists
                                      .Include(p => p.Songs)
                                      .SingleOrDefault(p => p.Id == songToRemove.PlaylistId);
                if (playlist != null)
                {
                    Song song = playlist.Songs
                                  .SingleOrDefault(s => s.Id == songToRemove.SongId);
                    if (song != null)
                    {
                        playlist.Songs.Remove(song);
                        db.SaveChanges();
                        return Results.Ok("song removed from playlist");
                    }
                    return Results.BadRequest("song not found in playlist");
                }
                return Results.BadRequest("playlist not found");
            });

            //get songs not on playlist
            app.MapGet("/api/playlists/{playlistId}/available", (BE_MusicStreamingDbContext db, int playlistId) =>
            {
                Playlist playlist = db.Playlists
                                      .Include(p => p.Songs)
                                      .SingleOrDefault(p => p.Id == playlistId);
                if (playlist != null)
                {
                    List<Song> songsOnPlaylist = playlist.Songs.ToList();

                    List<Song> songsToAdd = db.Songs
                                          .Include(s => s.Genre)
                                          .Include(s => s.Artist)
                                          .Where(s => !songsOnPlaylist.Contains(s))
                                          .ToList();
                    if (songsToAdd != null)
                        {
                            return Results.Ok(songsToAdd);
                        }
                    return Results.NotFound("no songs found");
                }
                return Results.BadRequest("no playlist found");
            });

            //search songs by name, artist or genre
            app.MapPost("/api/search/{searchObject.PlaylistId}/{searchObject.SearchInput}", (BE_MusicStreamingDbContext db, SearchDTO searchObject) =>
            {
                Playlist playlist = db.Playlists
                                      .Include(p => p.Songs)
                                      .SingleOrDefault(p => p.Id == searchObject.PlaylistId);
                if (playlist != null)
                {
                    List<Song> songsOnPlaylist = playlist.Songs.ToList();

                    List<Song> songsToAdd = db.Songs
                                          .Include(s => s.Genre)
                                          .Include(s => s.Artist)
                                          .Where(s => !songsOnPlaylist.Contains(s))
                                          .ToList();
                    if (songsToAdd != null)
                    {
                        List<Song> searchResults = songsToAdd
                                      .Where(s => s.Name.ToLower().Contains(searchObject.SearchInput)
                                      || s.Artist.Name.ToLower().Contains(searchObject.SearchInput)
                                      || s.Genre.Name.ToLower().Contains(searchObject.SearchInput))
                                      .ToList();
                        if (searchResults != null)
                        {
                            return Results.Ok(searchResults);
                        }
                        return Results.NotFound("no songs found");
                    }
                    return Results.NotFound("no songs found");
                }
                return Results.BadRequest("no playlist found");
            });
        }
    }
}
