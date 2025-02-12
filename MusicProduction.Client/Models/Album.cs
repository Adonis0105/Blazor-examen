using System;
using System.Collections.Generic;

namespace MusicProduction.Client.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}