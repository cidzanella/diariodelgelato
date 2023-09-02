using DiarioDelGelato.WebAPI.Startup;

var builder = WebApplication.CreateBuilder(args);

// REGISTER SERVICES HERE
// Extension class Add services to the container.
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// REGISTER MIDDLEWARE HERE
// Configure the HTTP request pipeline.

app.UseSwaggerExtension();

app.UseExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
