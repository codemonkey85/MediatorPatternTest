using DemoApi.Endpoints;
using DemoLibrary.Behaviors;
using DemoLibrary.DataAccess;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services
    .AddOpenApi();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services
    .AddSingleton<IDataAccess, DemoDataAccess>()
    .AddMediatR(mediatRServiceConfig => mediatRServiceConfig.RegisterServicesFromAssemblyContaining<DemoDataAccess>())
    .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
    .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var apiGroup = app.MapGroup("api");
apiGroup.MapPersonEndpoints();

app.Run();
