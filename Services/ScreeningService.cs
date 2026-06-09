using APBD_TEST2.Data;
using APBD_TEST2.DTOs;
using APBD_TEST2.Entities;
using APBD_TEST2.Repositories;

namespace APBD_TEST2.Services
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _repository;
        private readonly AppDbContext _context;

        public ScreeningService(IScreeningRepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<List<ScreeningResponseDto>> GetScreeningsAsync(DateOnly? date)
        {
            var screenings = await _repository.GetScreeningsAsync(date);

            var result = screenings.Select(s => new ScreeningResponseDto
            {
                ScreeningId = s.ScreeningId,
                ScreeningDate = s.ScreeningDate,
                TicketPrice = s.TicketPrice,
                AvailableSeats = s.AvailableSeats,
                Movie = new MovieDto

                {
                    Title = s.Movie.Title,
                    Director = s.Movie.Director,
                    DurationMinutes = s.Movie.DurationMinutes,
                    Genre = s.Movie.Genre
                },
                Hall = new HallDto
                {
                    Name = s.Hall.Name,
                    Capacity = s.Hall.Capacity,
                    Type = s.Hall.Type
                },
                Tickets = s.Tickets.Select(t => new TicketResponseDto
                {
                    SeatNumber = t.SeatNumber,
                    PurchasedAt = t.PurchasedAt,
                    Customer = new CustomerDto
                    {
                        FirstName = t.Customer.FirstName,
                        LastName = t.Customer.LastName,
                        Email = t.Customer.Email,
                        Phone = t.Customer.Phone
                    }
                }).ToList()
            }).ToList();
            return result;
        }

        public async Task PurchaseTicketAsync(int screeningId, PurchaseTicketRequestDto dto)
        {
            var screeningEntity = await _repository.GetScreeningByIdAsync(screeningId);

            if (screeningEntity == null)
                throw new KeyNotFoundException($"Screening with ID {screeningId} was not found.");

            if (screeningEntity.ScreeningDate < DateTime.Now)
                throw new ArgumentException("Cannot purchase a ticket for a screening that has already passed.");

            await using var transaction = await _context.Database.BeginTransactionAsync();

            var newCustomer = new Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone
            };

            await _repository.AddCustomerAsync(newCustomer);
            await _repository.SaveChangesAsync();


            var ticket = new Ticket
            {
                ScreeningId = screeningId,
                CustomerId = newCustomer.CustomerId,
                SeatNumber = dto.SeatNumber,
                PurchasedAt = DateTime.Now
            };

            await _repository.AddTicketAsync(ticket);
            await _repository.SaveChangesAsync();
            await transaction.CommitAsync();
        }
    }
}
