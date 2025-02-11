using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicProduction.API.Models
{
    [Table("songs")]
    public class Song
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [Column("artist")]
        [StringLength(200)]
        public string Artist { get; set; }

        [Column("duration")]
        public TimeSpan Duration { get; set; }

        [Column("album_id")]
        public int AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }
    }
}