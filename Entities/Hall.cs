using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TEST2.Entities
{
    [Table("Halls")]
    public class Hall
    {
        [Key]
        public int HallId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }

        [MaxLength(50)]
        public string Type { get; set; } = null!;

        public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    }
}
