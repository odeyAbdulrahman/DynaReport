namespace DynaReport.ViewModels;

public class DetailItem
{
    public string? Key { get; set; }
    public object? Value { get; set; }
    public int Col { get; set; } = 12;
}

public class DetailsReportViewModel
{
    public string? ReportTitle { get; set; }
    public string? Lang { get; set; }
    public List<DetailItem> Details { get; set; } = new List<DetailItem>();
}