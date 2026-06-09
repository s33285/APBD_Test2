using APBD_TEST2.Entities;

namespace APBD_TEST2.Repositories
{
    public interface IScreeningRepository
    {
        Task<List<Screening>> GetScreeningsAsync(DateOnly? date);
        Task<Screening?> GetScreeningByIdAsync(int screeningId);
        Task AddCustomerAsync(Customer customer);
        Task AddTicketAsync(Ticket ticket);
        Task SaveChangesAsync();
    }
}
