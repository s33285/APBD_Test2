using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TEST2.Entities
{
    [Table("Tickets")]
    public class Ticket
    {
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; } = null!;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        [MaxLength(10)]
        public string SeatNumber { get; set; } = null!;
        public DateTime PurchasedAt { get; set; }
    }
}
