namespace APBD_TEST2.DTOs
{
    public class ScreeningResponseDto
    {
        public int ScreeningId { get; set; }
        public MovieDto Movie { get; set; } = null!;
        public HallDto Hall { get; set; } = null!;
        public DateTime ScreeningDate { get; set; }

        public decimal TicketPrice { get; set; }
        public int? AvailableSeats { get; set; }
        public List<TicketResponseDto> Tickets { get; set; } = new();
    }
}
