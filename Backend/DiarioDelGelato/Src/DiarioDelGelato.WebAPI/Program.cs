using DiarioDelGelato.Application.Interfaces.Services;
using DiarioDelGelato.WebAPI.AppStartup;

var builder = WebApplication.CreateBuilder(args);

// REGISTER SERVICES HERE
// Extension class Add services to the container. Configuration parameters comes from appsettings.json.
// ServiceExtensions class contains extension methods for registering services.
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Seed database before starting the application
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
    seeder.Seed();
}

// REGISTER MIDDLEWARE HERE
// Configure the HTTP request pipeline. 
// AppExtesions class contains extension methods for configuring the middleware pipeline.

app.UseSwaggerExtension();

app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4210")); //angular.json

app.UseExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
