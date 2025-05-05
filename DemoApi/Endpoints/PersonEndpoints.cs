using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace DemoApi.Endpoints;

public static class PersonEndpoints
{
    public static IEndpointRouteBuilder MapPersonEndpoints(this IEndpointRouteBuilder apiGroup)
    {
        var peopleGroup = apiGroup.MapGroup("people");

        peopleGroup.MapGet(string.Empty, GetPeople);
        peopleGroup.MapGet("{id:int}", GetPerson);
        peopleGroup.MapPost(string.Empty, CreatePerson);

        return apiGroup;
    }

    private static async Task<List<PersonModel>> GetPeople(IMediator mediator) =>
        await mediator.Send(new GetPersonListQuery());

    private static async Task<PersonModel?> GetPerson(IMediator mediator, int id) =>
        await mediator.Send(new GetPersonByIdQuery(id));

    private static async Task<PersonModel> CreatePerson(IMediator mediator, PersonModel person) =>
        await mediator.Send(new CreatePersonCommand(person.FirstName, person.LastName));
}
