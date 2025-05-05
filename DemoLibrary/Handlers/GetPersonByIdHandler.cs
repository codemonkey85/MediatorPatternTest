using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace DemoLibrary.Handlers;

public class GetPersonByIdHandler(IMediator mediator) : IRequestHandler<GetPersonByIdQuery, PersonModel?>
{
    public async Task<PersonModel?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var people = await mediator.Send(new GetPersonListQuery(), cancellationToken);

        return people.SingleOrDefault(p => p.Id == request.Id);
    }
}
