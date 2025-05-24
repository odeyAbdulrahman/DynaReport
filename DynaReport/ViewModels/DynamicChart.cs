namespace DynaReport.ViewModels
{
    public class DynamicChart
    {
        public string ChartId { get; set; } = string.Empty;
        public string ChartType { get; set; } = "bar";
        public string Title { get; set; } = string.Empty;
        public Dictionary<string, float> Data { get; set; } = [];
        public int Width { get; set; } = 600;
        public int Height { get; set; } = 400;
        public string RenderedChart { get; set; } = string.Empty;
    }
}
