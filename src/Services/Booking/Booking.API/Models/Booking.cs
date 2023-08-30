namespace Booking.API.Models
{
    public record Booking(
        Guid CustomerId, 
        Guid ServiceId, 
        string? Comment, 
        DateTime StarTime, 
        TimeSpan Duration);
}