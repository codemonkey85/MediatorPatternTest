using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace BlazorUi.Components.Pages;

public partial class Home(IMediator mediator)
{
    private List<PersonModel> people = [];

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        people = await mediator.Send(new GetPersonListQuery());
    }
}
