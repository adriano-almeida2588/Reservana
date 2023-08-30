namespace Booking.Domain.AggregatesModel.BookingAggregate
{
    public interface IBookingRepository
    {
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(Booking booking);
        Task<Booking> GetByIdAsync(Guid id);
        Task<List<Booking>> GetBookings();
    }
}
