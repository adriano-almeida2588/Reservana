using Booking.Domain.SeedWork;

namespace Booking.Domain.AggregatesModel.BookingAggregate
{
    public class Schedule: ValueObject
    {
        public Schedule(DateTime startTime, TimeSpan duration)
        {
            StartTime = startTime;
            Duration = duration;
        }

        public Schedule() { }

        public DateTime StartTime { get; private set; }
        public TimeSpan Duration { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartTime;
            yield return Duration;
        }
    }
}
