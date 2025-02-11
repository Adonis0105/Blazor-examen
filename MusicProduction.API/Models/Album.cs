using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicProduction.API.Models
{
    [Table("albums")]
    public class Album
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        [StringLength(200)]
        public string Title { get; set; }

        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}