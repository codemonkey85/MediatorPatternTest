using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace DemoLibrary.Handlers;

public class GetPersonListHandler(IDataAccess data) : IRequestHandler<GetPersonListQuery, List<PersonModel>>
{
    public Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken) =>
        Task.FromResult(data.GetPeople());
}
