using Booking.Domain.SeedWork;

namespace Booking.Domain.AggregatesModel.BookingAggregate
{
    public class BookingStatus: Enumeration
    {
        public static BookingStatus Confirmed = new(1, nameof(Confirmed));
        public static BookingStatus Canceled = new(2, nameof(Canceled));
        public static BookingStatus Pending = new(3, nameof(Pending));
        public static BookingStatus Done = new(4, nameof(Done));

        public BookingStatus(int id, string name) : base(id, name)
        {
        }
    }
}
