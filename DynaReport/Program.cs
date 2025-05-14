using DynaReport.Extensions;
using DynaReport.Utilities;

namespace DynaReport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileUtility.CopyDllToBinFolder();
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddReportServices();

            var app = builder.Build();
            app?.UseDefaultEndPoint(configuration: builder.Configuration);
            app?.UseEndpoints(endpoints =>
            {
                endpoints?.MapControllers();
            });
            app?.Run();
        }
    }
}
