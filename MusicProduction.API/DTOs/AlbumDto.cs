namespace MusicProduction.API.DTOs
{
    public class AlbumDto
    {
        public string Title { get; set; }
        private DateTime _releaseDate;

        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set => _releaseDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        public string Description { get; set; }
    }
}


