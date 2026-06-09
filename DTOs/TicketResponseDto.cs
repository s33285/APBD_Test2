namespace APBD_TEST2.DTOs
{
    public class TicketResponseDto
    {
        public string SeatNumber { get; set; } = null!;
        public DateTime PurchasedAt { get; set; }
        public CustomerDto Customer { get; set; } = null!;

    }
}
