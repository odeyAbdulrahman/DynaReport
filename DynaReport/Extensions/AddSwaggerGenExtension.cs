using DynaReport.ViewModels;
using Microsoft.OpenApi.Models;

namespace DynaReport.Extensions;
public static class AddSwaggerGenExtension
{
    public static void AddSwagger(this IServiceCollection services, SwaggerViewModel model)
    {
        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc(model.Name, new OpenApiInfo
            {
                Title = model.Title,
                Version = model.Version,
                Description = model.Description,
                TermsOfService = new Uri(model.TermsOfService ?? string.Empty),
                Contact = new OpenApiContact
                {
                    Name = model.ContactName,
                    Email = model.ContactEmail,
                },
            });
            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });
            x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                      new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                }
                });
        });
    }
}
