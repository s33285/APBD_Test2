using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace APBD_TEST2.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = null!;

        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [MaxLength(9)]
        public string Phone { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
