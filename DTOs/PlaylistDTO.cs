﻿namespace BE_MusicStreaming.DTOs
{
    public class PlaylistDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool Public { get; set; }
        public bool IsFavorite { get; set; }
    }
}
