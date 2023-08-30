using Booking.Domain.SeedWork;

namespace Booking.Domain.AggregatesModel.BookingAggregate
{
    public class BookingStatus: Enumeration
    {
        public static BookingStatus Confirmed = new(1, "CONFIRMADO");
        public static BookingStatus Canceled = new(2, "CANCELADO");
        public static BookingStatus Pending = new(3, "PENDENTE");
        public static BookingStatus Done = new(4, "REALIZADA");

        public BookingStatus(int id, string name) : base(id, name)
        {
        }
    }
}
