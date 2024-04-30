namespace BE_MusicStreaming.DTOs
{
    public class EditPlaylistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool Public { get; set; }
        public bool IsFavorite { get; set; }
    }
}
