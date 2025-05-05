using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Commands;

public record CreatePersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;
