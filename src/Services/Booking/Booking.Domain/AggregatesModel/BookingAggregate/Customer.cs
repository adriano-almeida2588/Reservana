using Booking.Domain.SeedWork;

namespace Booking.Domain.AggregatesModel.BookingAggregate
{
    public class Customer: Entity
    {
        public Customer(string name, string contact)
        {
            Name = name;
            Contact = contact;
        }

        private Customer() { }

        public string Name { get; private set; }
        public string Contact { get; private set; }

        private List<Booking> _bookings = new();
        public IReadOnlyCollection<Booking> GetBookings() => _bookings.AsReadOnly();
    }
}