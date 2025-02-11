namespace MusicProduction.API.DTOs
{
    public class SongDto
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Duration { get; set; }
        public int AlbumId { get; set; }
    }
}