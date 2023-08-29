using DiarioDelGelato.Infrastructure.Persistance;
using DiarioDelGelato.Infrastructure.Persistance.Contexts;
using DiarioDelGelato.WebAPI.Startup;

var builder = WebApplication.CreateBuilder(args);

// REGISTER SERVICES HERE
// Extension class Add services to the container.
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// REGISTER MIDDLEWARE HERE
// Configure the HTTP request pipeline.

app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
