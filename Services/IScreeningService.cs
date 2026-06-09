using APBD_TEST2.DTOs;

namespace APBD_TEST2.Services
{
    public interface IScreeningService
    {
        Task<List<ScreeningResponseDto>> GetScreeningsAsync(DateOnly? date);
        Task PurchaseTicketAsync(int screeningId, PurchaseTicketRequestDto dto);
    }
}
