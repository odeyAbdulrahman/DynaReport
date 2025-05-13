using DinkToPdf.Contracts;
using DinkToPdf;
using DynaReport.Contracts;
using DynaReport.Implementations;
using DynaReport.ViewModels;

namespace DynaReport.Extensions;
public static class CoreHelperExtension
{
    public static IServiceCollection AddReportServices(this IServiceCollection services)
    {
        services.AddControllersWithViews()
        .AddRazorRuntimeCompilation()
        .AddRazorOptions(options =>
        {
            options.ViewLocationFormats.Add("wwwroot/Templates/{0}.cshtml");
        });
        services.AddSingleton(serviceType: typeof(IConverter), implementationInstance: new SynchronizedConverter(new PdfTools()));
        services.AddScoped<ITemplateRenderer, TemplateRenderer>();
        services.AddScoped<IReportGenerator, ReportGenerator>();

        return services;
    }
}