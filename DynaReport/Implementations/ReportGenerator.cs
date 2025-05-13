using DinkToPdf;
using DinkToPdf.Contracts;
using DynaReport.Contracts;
using DynaReport.ViewModels;
using static DynaReport.Enumerations.TypeEnum;

namespace DynaReport.Implementations
{
    public class ReportGenerator : IReportGenerator
    {
        private readonly IConverter _pdfConverter;
        private readonly ITemplateRenderer _templateRenderer;
        public ReportGenerator(
            IConverter pdfConverter,
            ITemplateRenderer templateRenderer)
        {
            _pdfConverter = pdfConverter;
            _templateRenderer = templateRenderer;
        }

        public async Task<ReportResponse> GenerateReportAsync<TModel>(ReportRequest<TModel> request)
        {
            string templatePath = GetTemplatePath(request);
            string htmlContent = await _templateRenderer.RenderViewToStringAsync(templatePath, request.Model);
            var doc = new HtmlToPdfDocument
            {
                GlobalSettings = {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                    },
                Objects = {
                        new ObjectSettings {
                            PagesCount = true,
                            HtmlContent = htmlContent,
                            WebSettings = { DefaultEncoding = "utf-8" },
                            HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                            FooterSettings = { FontSize = 9, Right = $"Generated on {DateTime.Now:yyyy-MM-dd}" }
                        }
                    }
            };

            byte[] pdfBytes;
            pdfBytes = _pdfConverter.Convert(doc);
            doc?.Objects?.Clear();

            return new ReportResponse
            {
                Content = pdfBytes,
                FileName = string.IsNullOrEmpty(request.FileName)
                    ? $"Report-{DateTime.Now:yyyyMMddHHmmss}.pdf"
                    : request.FileName
            };
        }

        private static string GetTemplatePath<TModel>(ReportRequest<TModel> request)
        {
            if (!string.IsNullOrEmpty(request.CustomTemplatePath))
            {
                return request.CustomTemplatePath;
            }

            const string templateBasePath = "wwwroot/Templates";
            var templatePath = request.ReportType switch
            {
                ReportType.Details => $"{templateBasePath}/DetailsReport.cshtml",
                ReportType.DetailsWithList => $"{templateBasePath}/DetailsWithListReport.cshtml",
                ReportType.List => $"{templateBasePath}/ListReport.cshtml",
                _ => throw new ArgumentOutOfRangeException(nameof(request.ReportType), "Invalid report type specified.")
            };
            return templatePath;
        }
    }
}