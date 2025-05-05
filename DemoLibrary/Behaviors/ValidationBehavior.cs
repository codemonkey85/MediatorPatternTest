using DemoLibrary.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DemoLibrary.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Console.WriteLine("Hello from the Validation Behavior 1st time");

        if (request is CreatePersonCommand person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) ||
                string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("First Name and Last Name must not be empty.");
            }
        }

        return await next(cancellationToken);
    }
}
