﻿using BE_MusicStreaming.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace BE_MusicStreaming.Data
{
    public class SongData
    {
        public static List<Song> Songs = new List<Song>
        {
            new Song { Id = 1, Name = "Hey Ya!", ArtistId = 1, Duration = "3:55", Year = 2003, GenreId = 2 },
            new Song { Id = 2, Name = "Crazy In Love", ArtistId = 2, Duration = "3:56", Year = 2003, GenreId = 4 },
            new Song { Id = 3, Name = "Stan", ArtistId = 3, Duration = "6:44", Year = 2000, GenreId = 2 },
            new Song { Id = 4, Name = "Mr. Brightside", ArtistId = 4, Duration = "3:42", Year = 2003, GenreId = 8 },
            new Song { Id = 5, Name = "Beautiful Day", ArtistId = 5, Duration = "4:08", Year = 2000, GenreId = 3 },
            new Song { Id = 6, Name = "Clocks", ArtistId = 6, Duration = "5:07", Year = 2002, GenreId = 3 },
            new Song { Id = 7, Name = "Hips Don't Lie", ArtistId = 7, Duration = "3:39", Year = 2006, GenreId = 1 },
            new Song { Id = 8, Name = "Viva La Vida", ArtistId = 6, Duration = "4:01", Year = 2008, GenreId = 3 },
            new Song { Id = 9, Name = "Umbrella", ArtistId = 8, Duration = "4:35", Year = 2007, GenreId = 4 },
            new Song { Id = 10, Name = "Lose Yourself", ArtistId = 3, Duration = "5:20", Year = 2002, GenreId = 2 },
            new Song { Id = 11, Name = "Chasing Cars", ArtistId = 9, Duration = "4:28", Year = 2006, GenreId = 3 },
            new Song { Id = 12, Name = "I Gotta Feeling", ArtistId = 10, Duration = "4:49", Year = 2009, GenreId = 1 },
            new Song { Id = 13, Name = "Crazy", ArtistId = 11, Duration = "2:58", Year = 2006, GenreId = 6 },
            new Song { Id = 14, Name = "Empire State of Mind", ArtistId = 12, Duration = "4:36", Year = 2009, GenreId = 2 },
            new Song { Id = 15, Name = "Rehab", ArtistId = 13, Duration = "3:35", Year = 2006, GenreId = 6 },
            new Song { Id = 16, Name = "Chop Suey!", ArtistId = 14, Duration = "3:30", Year = 2001, GenreId = 7 },
            new Song { Id = 17, Name = "Boulevard of Broken Dreams", ArtistId = 15, Duration = "4:20", Year = 2004, GenreId = 10 },
            new Song { Id = 18, Name = "Bleeding Love", ArtistId = 16, Duration = "4:23", Year = 2007, GenreId = 1 },
            new Song { Id = 19, Name = "Single Ladies (Put a Ring on It)", ArtistId = 2, Duration = "3:13", Year = 2008, GenreId = 4 },
            new Song { Id = 20, Name = "The Way You Move", ArtistId = 1, Duration = "3:55", Year = 2003, GenreId = 2 },
            new Song { Id = 21, Name = "Hot N Cold", ArtistId = 17, Duration = "3:40", Year = 2008, GenreId = 1 },
            new Song { Id = 22, Name = "I Kissed a Girl", ArtistId = 17, Duration = "3:00", Year = 2008, GenreId = 1 },
            new Song { Id = 23, Name = "Bring Me to Life", ArtistId = 18, Duration = "3:56", Year = 2003, GenreId = 7 },
            new Song { Id = 24, Name = "My Immortal", ArtistId = 18, Duration = "4:24", Year = 2003, GenreId = 8 },
            new Song { Id = 25, Name = "Hollaback Girl", ArtistId = 19, Duration = "3:19", Year = 2005, GenreId = 1 },
            new Song { Id = 26, Name = "Seven Nation Army", ArtistId = 20, Duration = "3:52", Year = 2003, GenreId = 8 },
            new Song { Id = 27, Name = "Fallin'", ArtistId = 21, Duration = "3:30", Year = 2001, GenreId = 4 },
            new Song { Id = 28, Name = "Stronger", ArtistId = 22, Duration = "5:12", Year = 2007, GenreId = 2 },
            new Song { Id = 29, Name = "Love Story", ArtistId = 23, Duration = "3:55", Year = 2008, GenreId = 9 },
            new Song { Id = 30, Name = "Cry Me a River", ArtistId = 24, Duration = "4:48", Year = 2002, GenreId = 4 },
            new Song { Id = 31, Name = "Bleed It Out", ArtistId = 25, Duration = "2:44", Year = 2007, GenreId = 7 },
            new Song { Id = 32, Name = "Paper Planes", ArtistId = 26, Duration = "3:25", Year = 2007, GenreId = 2 },
            new Song { Id = 33, Name = "Disturbia", ArtistId = 8, Duration = "3:59", Year = 2008, GenreId = 5 },
            new Song { Id = 34, Name = "Poker Face", ArtistId = 27, Duration = "3:58", Year = 2008, GenreId = 5 },
            new Song { Id = 35, Name = "Ignition (Remix)", ArtistId = 28, Duration = "3:06", Year = 2002, GenreId = 4 },
            new Song { Id = 36, Name = "Complicated", ArtistId = 29, Duration = "4:04", Year = 2002, GenreId = 10 },
            new Song { Id = 37, Name = "Sk8er Boi", ArtistId = 29, Duration = "3:23", Year = 2002, GenreId = 10 },
            new Song { Id = 38, Name = "I'm with You", ArtistId = 29, Duration = "3:43", Year = 2002, GenreId = 10 },
            new Song { Id = 39, Name = "Oops!... I Did It Again", ArtistId = 30, Duration = "3:30", Year = 2000, GenreId = 1 },
            new Song { Id = 40, Name = "Toxic", ArtistId = 30, Duration = "3:18", Year = 2003, GenreId = 5 },
            new Song { Id = 41, Name = "Stronger", ArtistId = 30, Duration = "3:23", Year = 2000, GenreId = 1 },
            new Song { Id = 42, Name = "Gimme More", ArtistId = 30, Duration = "4:11", Year = 2007, GenreId = 5 },
            new Song { Id = 43, Name = "Womanizer", ArtistId = 30, Duration = "3:44", Year = 2008, GenreId = 5 },
            new Song { Id = 44, Name = "Piece of Me", ArtistId = 30, Duration = "3:32", Year = 2007, GenreId = 1 },
            new Song { Id = 45, Name = "Circus", ArtistId = 30, Duration = "3:12", Year = 2008, GenreId = 1 },
            new Song { Id = 46, Name = "3", ArtistId = 30, Duration = "3:33", Year = 2009, GenreId = 1 },
            new Song { Id = 47, Name = "In da Club", ArtistId = 31, Duration = "3:13", Year = 2003, GenreId = 2 },
            new Song { Id = 48, Name = "Get Low", ArtistId = 32, Duration = "5:34", Year = 2003, GenreId = 2 },
            new Song { Id = 49, Name = "Get Crunk", ArtistId = 32, Duration = "4:03", Year = 2003, GenreId = 2 },
            new Song { Id = 50, Name = "Yeah!", ArtistId = 33, Duration = "4:10", Year = 2004, GenreId = 2 },
            new Song { Id = 51, Name = "London Bridge", ArtistId = 34, Duration = "3:28", Year = 2006, GenreId = 4 },
            new Song { Id = 52, Name = "Fergalicious", ArtistId = 34, Duration = "4:52", Year = 2006, GenreId = 5 },
            new Song { Id = 53, Name = "Where Is the Love?", ArtistId = 10, Duration = "4:33", Year = 2003, GenreId = 1 },
            new Song { Id = 54, Name = "Let's Get It Started", ArtistId = 10, Duration = "3:37", Year = 2004, GenreId = 1 },
            new Song { Id = 55, Name = "My Humps", ArtistId = 10, Duration = "5:27", Year = 2005, GenreId = 2 }
        };

    }
}
