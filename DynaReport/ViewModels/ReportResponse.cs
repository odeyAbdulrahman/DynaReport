namespace DynaReport.ViewModels;

public class ReportResponse
{
    public byte[]? Content { get; set; }
    public string ContentType { get; set; } = "application/pdf";
    public string? FileName { get; set; }
}