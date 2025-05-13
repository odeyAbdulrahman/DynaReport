using DynaReport.Utilities;
using DynaReport.ViewModels;

namespace DynaReport.Extensions;
public static class EndPointExtension
{
    public static IApplicationBuilder UseDefaultEndPoint(this WebApplication app, IConfiguration configuration)
    {
        if (app.Environment.IsProduction())
        {
            app.UseHttpsRedirection();
            app.UseHsts();
        }
        else
        {
            // Ensure Swagger services are registered before using the middleware
            // This should be done in Program.cs or Startup.cs:
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}
