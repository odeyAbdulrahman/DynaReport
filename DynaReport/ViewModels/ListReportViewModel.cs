using DynaReport.Utilities;
using static DynaReport.Enumerations.TypeEnum;

namespace DynaReport.ViewModels
{
    public class ListReportViewModel
    {
        public string? ReportTitle { get; set; } = "List Report";
        public Dictionary<string, string> Headers { get; set; } = [];
        public IEnumerable<object> Items { get; set; } = [];
        public string? Lang { get; set; } = LangEnum.Ar.GetEnumName().ToLower();
    }
}
