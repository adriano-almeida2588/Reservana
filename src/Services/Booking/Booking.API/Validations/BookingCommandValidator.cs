using Booking.API.Commands;
using FluentValidation;

namespace Booking.API.Validations
{
    public class BookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public BookingCommandValidator(ILogger<BookingCommandValidator> logger) 
        {
            RuleFor(command => command.CustomerId).NotEmpty().WithMessage("Informe um cliente");
            RuleFor(command => command.ServiceId).NotEmpty().WithMessage("Informe um serviço");
            RuleFor(command => command.StartTime).NotEmpty().WithMessage("Informe o horário de ínicio");
            RuleFor(command => command.CustomerId).NotEmpty().WithMessage("Informe a duração");

            logger.LogTrace("INSTÂNCIA CRIADA - {ClassName}", GetType().Name);
        }
    }
}
