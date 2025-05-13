using static DynaReport.Enumerations.TypeEnum;

namespace DynaReport.ViewModels;

public class ReportRequest<TModel>
{
    public TModel? Model { get; set; }
    public ReportType? ReportType { get; set; }
    public string? CustomTemplatePath { get; set; }
    public int? ListLimit { get; set; }
    public string? ReportTitle { get; set; }
    public string? FileName { get; set; }
}