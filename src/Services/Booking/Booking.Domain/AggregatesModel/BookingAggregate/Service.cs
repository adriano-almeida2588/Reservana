using Booking.Domain.SeedWork;

namespace Booking.Domain.AggregatesModel.BookingAggregate
{
    public class Service: Entity
    {
        private Service() { }

        public Service(string name, TimeSpan defaultDuration)
        {
            Name = name;
            DefaultDuration = defaultDuration;
        }

        public string Name { get; private set; }
        public TimeSpan DefaultDuration { get; private set; }

        private List<Booking> _bookings = new();
        public IReadOnlyCollection<Booking> GetBookings() => _bookings.AsReadOnly();
    }
}
