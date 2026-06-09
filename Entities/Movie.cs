using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TEST2.Entities
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Director { get; set; } = null!;
        public int DurationMinutes { get; set; }

        [MaxLength(50)]
        public string Genre { get; set; } = null!;

        public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    }
}
