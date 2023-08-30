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

        public Domain.AggregatesModel.BookingAggregate.Booking Add(Domain.AggregatesModel.BookingAggregate.Booking booking)
        {
            return _context.Bookings.Add(booking).Entity;
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

        public Domain.AggregatesModel.BookingAggregate.Booking Update(Domain.AggregatesModel.BookingAggregate.Booking booking)
        {
            return _context.Bookings.Update(booking).Entity;
        }
    }
}
