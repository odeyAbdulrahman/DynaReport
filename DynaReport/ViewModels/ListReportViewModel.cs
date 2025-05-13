using DynaReport.Utilities;
using static DynaReport.Enumerations.TypeEnum;

namespace DynaReport.ViewModels
{
    public class ListReportViewModel
    {
        public string ReportTitle { get; set; } = "List Report";
        public IEnumerable<string> Headers { get; set; } = new List<string>();
        public IEnumerable<object> Items { get; set; } = new List<object>();
        public string Lang { get; set; } = LangEnum.Ar.GetEnumName().ToLower();
    }
}
