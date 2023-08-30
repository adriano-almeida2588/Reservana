using Booking.Domain.SeedWork;

namespace Booking.Domain.AggregatesModel.BookingAggregate
{
    public class Booking : Entity, IAggregateRoot
    {
        private Booking() { }

        public Booking(Guid customerId, Guid serviceId, 
            Schedule schedule, BookingStatus bookingStatus)
        {
            _customerId = customerId;
            _serviceId = serviceId;
            Schedule = schedule;
            BookingStatus = bookingStatus;
        }

        private Guid _customerId;
        private Guid _serviceId;
        public Guid CustomerId => _customerId;
        public Guid ServiceId => _serviceId;
        public Schedule Schedule { get; private set; }
        public BookingStatus BookingStatus { get; private set; }
        public string Comment { get; private set; }
    }
}
