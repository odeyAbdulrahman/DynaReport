using DynaReport.Utilities;
using static DynaReport.Enumerations.TypeEnum;

namespace DynaReport.ViewModels;

public class DetailsWithListReportViewModel
{
    public string ReportTitle { get; set; } = "Details with List Report";
    public int ListLimit { get; set; } = 5;
    public List<DetailItem> Details { get; set; } = new List<DetailItem>();
    public IEnumerable<object> Items { get; set; } = new List<object>();
    public string Lang { get; set; } = LangEnum.Ar.GetEnumName();
}