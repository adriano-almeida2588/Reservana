using Booking.Domain.AggregatesModel.BookingAggregate;
using MediatR;

namespace Booking.API.Commands
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, bool>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateBookingCommandHandler> _logger;

        public CreateBookingCommandHandler(
            IBookingRepository bookingRepository, 
            IMediator mediator, 
            ILogger<CreateBookingCommandHandler> logger)
        {
            _bookingRepository = bookingRepository;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Domain.AggregatesModel.BookingAggregate.Booking(request.CustomerId, request.ServiceId, request?.Comment)
                                                                     .AddSchedule(request.StartTime, request.Duration)
                                                                     .AddBookingStatus(3, BookingStatus.Pending.Name);

            _logger.LogInformation("Criando Reserva - Booking: {@Booking}", booking);

            _bookingRepository.Add(booking);

            return await _bookingRepository.UnitOfWork.AddAsync(cancellationToken);
        }
    }
}
