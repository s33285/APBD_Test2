using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace APBD_TEST2.Entities
{
    [Table("Screenings")]
    public class Screening
    {
        [Key]
        public int ScreeningId { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; } = null!;

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        public DateTime ScreeningDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TicketPrice { get; set; }

        public int? AvailableSeats { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
