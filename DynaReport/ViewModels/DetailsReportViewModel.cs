namespace DynaReport.ViewModels;

public class DetailsReportViewModel
{
    public string? ReferenceNumber { get; set; } = "R-DMA-0000000001";
    public string? ReportTitle { get; set; }
    public string? Lang { get; set; }
    public List<DetailItem> Details { get; set; } = [];

    public List<DynamicChart> Charts { get; set; } = [];
    public void AddChart(string chartId, string chartType, string title, Dictionary<string, float> data)
    {
        Charts.Add(new DynamicChart
        {
            ChartId = chartId,
            ChartType = chartType,
            Title = title,
            Data = data
        });
    }
}

public class DetailItem
{
    public string? Key { get; set; }
    public object? Value { get; set; }
    public int Col { get; set; } = 12;
    public bool IsImportant { get; set; } = false;
    public bool IsStatus { get; set; } = false;
}