using Booking.Domain.SeedWork;

namespace Booking.Domain.AggregatesModel.BookingAggregate
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Booking Add(Booking booking);
        Booking Update(Booking booking);
        Task<Booking> GetByIdAsync(Guid id);
        Task<List<Booking>> GetBookings();
    }
}
