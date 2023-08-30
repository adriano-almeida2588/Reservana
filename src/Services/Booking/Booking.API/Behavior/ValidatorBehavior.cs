using Booking.Domain.Exceptions;
using FluentValidation;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace Booking.API.Behavior
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorBehavior(
            ILogger<ValidatorBehavior<TRequest, TResponse>> logger, 
            IEnumerable<IValidator<TRequest>> vallidators)
        {
            _logger = logger;
            _validators = vallidators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

            if (failures.Any())
            {
                _logger.LogWarning("Erros de validação - {CommandType} - Command: {@Command} - Erros: {@ValidationErrors}", "", request, failures);

                throw new BookingDomainException(
                    $"Command Erros de validação para o tipo {typeof(TRequest).Name}", new ValidationException("Validação exception", failures));
            }

            return await next();
        }
    }
}
