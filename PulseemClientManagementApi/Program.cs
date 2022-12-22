using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PulseemClientManagementApi.Behavior;
using PulseemClientManagementApi.FluentValidation;
using PulseemClientManagementApi.Implementation;
using PulseemClientManagementApi.Interfaces.Repository;
using PulseemClientManagementApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Pulseem_ClientsContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IDataRepository<Client, string>), typeof(ClientManager));
builder.Services.AddScoped(typeof(IDataRepository<ErrorLog, string>), typeof(ErrologManager));
builder.Services.AddScoped(typeof(IDataRepository<Trace, string>), typeof(TraceManager));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseMiddleware(typeof(ErrorHandlingMiddleware));
app.MapControllers();

app.Run();
