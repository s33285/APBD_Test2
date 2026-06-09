using System.ComponentModel.DataAnnotations;

namespace APBD_TEST2.DTOs
{
    public class PurchaseTicketRequestDto
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required, MaxLength(9)]
        public string Phone { get; set; } = null!;

        [Required, MaxLength(10)]
        public string SeatNumber { get; set; } = null!;
    }
}
