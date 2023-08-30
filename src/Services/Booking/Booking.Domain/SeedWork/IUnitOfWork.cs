namespace Booking.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<bool> AddAsync(CancellationToken cancellationToken = default);
    }
}
