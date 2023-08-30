using Booking.Domain.SeedWork;

namespace Booking.Domain.AggregatesModel.BookingAggregate
{
    public class Booking : Entity, IAggregateRoot
    {
        private Booking() { }

        public Booking(Guid customerId, Guid serviceId, string? comment)
        {
            _customerId = customerId;
            _serviceId = serviceId;
            Comment = comment;
        }

        private Guid _customerId;
        private Guid _serviceId;
        public Guid CustomerId => _customerId;
        public Guid ServiceId => _serviceId;
        public Schedule Schedule { get; private set; }
        public BookingStatus BookingStatus { get; private set; }
        public string Comment { get; private set; }

        public Booking AddSchedule(DateTime startTime, TimeSpan duration)
        {
            var schedule = new Schedule(startTime, duration);

            Schedule = schedule;

            return this;
        }

        public Booking AddBookingStatus(int id, string name)
        {
            var bookingStatus = new BookingStatus(id, name);

            BookingStatus = bookingStatus;

            return this;
        }
    }
}
