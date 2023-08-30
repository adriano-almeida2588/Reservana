using Booking.Domain.AggregatesModel.BookingAggregate;
using Booking.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public BookingRepository(BookingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Domain.AggregatesModel.BookingAggregate.Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        public Task DeleteAsync(Domain.AggregatesModel.BookingAggregate.Booking booking)
        {
            _context.Bookings.Remove(booking);

            return Task.CompletedTask;
        }

        public async Task<List<Domain.AggregatesModel.BookingAggregate.Booking>> GetBookings()
        {
            var bookings = await _context.Bookings.ToListAsync();

            return bookings;
        }

        public async Task<Domain.AggregatesModel.BookingAggregate.Booking> GetByIdAsync(Guid id)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == id);

            return booking;
        }

        public Task UpdateAsync(Domain.AggregatesModel.BookingAggregate.Booking booking)
        {
            _context.Bookings.Update(booking);

            return Task.CompletedTask;
        }
    }
}
