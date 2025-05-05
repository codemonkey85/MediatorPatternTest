using DemoLibrary.Commands;
using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Handlers;

public class CreatePersonHandler(IDataAccess data) : IRequestHandler<CreatePersonCommand, PersonModel>
{
    public Task<PersonModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Hello from the {nameof(CreatePersonHandler)} 1st time");
        return Task.FromResult(data.InsertPerson(request.FirstName, request.LastName));
    }
}
