using MediatR;

namespace Booking.API.Commands
{
    public record CreateBookingCommand(
        Guid CustomerId,
        Guid ServiceId,
        string? Comment,
        DateTime StartTime,
        TimeSpan Duration) : IRequest<bool>;
}
