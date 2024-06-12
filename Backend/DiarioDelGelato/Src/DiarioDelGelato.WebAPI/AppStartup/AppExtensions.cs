using DiarioDelGelato.WebAPI.Infrastructure.Middlewares;

namespace DiarioDelGelato.WebAPI.AppStartup
{
    //contains extension methods for configuring the middleware pipeline
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DiarioDelGelato API V1.0");
            });
        }
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<HttpExceptionHandlerMiddleware>();
        }
    }
}
