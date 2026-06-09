using Microsoft.EntityFrameworkCore;
using APBD_TEST2.Data;
using APBD_TEST2.Entities;

namespace APBD_TEST2.Repositories
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly AppDbContext _context;

        public ScreeningRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Screening>> GetScreeningsAsync(DateOnly? date)
        {
            var query = _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .Include(s => s.Tickets)
                    .ThenInclude(t => t.Customer)
                .AsQueryable();

            if (date.HasValue)
            {
                var dateValue = date.Value;
                query = query.Where(s => DateOnly.FromDateTime(s.ScreeningDate) == dateValue);
            }

            var screeningsList = await query.ToListAsync();
            return screeningsList;
        }

        public async Task<Screening?> GetScreeningByIdAsync(int screeningId)
        {
            var screening = await _context.Screenings
                .FirstOrDefaultAsync(s => s.ScreeningId == screeningId);
            return screening;
        }


        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
