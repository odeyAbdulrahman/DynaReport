using DynaReport.Contracts;
using DynaReport.ViewModels;
using Microcharts;
using SkiaSharp;

namespace DynaReport.Implementations
{
    public class ChartRenderer : IChartRenderer
    {
        public string RenderChart(DynamicChart chartConfig)
        {
            var entries = chartConfig.Data.Select(x => new ChartEntry(x.Value)
            {
                Label = x.Key,
                ValueLabel = x.Value.ToString("N1"),
                Color = GetColor(x.Key, chartConfig.Data.Count)
            }).ToList();

            Chart chart = chartConfig.ChartType.ToLower() switch
            {
                "pie" => new PieChart { Entries = entries },
                "line" => new LineChart { Entries = entries },
                _ => new BarChart { Entries = entries }
            };

            chart.LabelTextSize = 30;
            chart.BackgroundColor = SKColors.Transparent;

            return RenderChartImage(chart, chartConfig.Width, chartConfig.Height);
        }

        private static SKColor GetColor(string label, int totalItems)
        {
            var colors = new[]
            {
                SKColor.Parse("#3498db"), // Blue
                SKColor.Parse("#2ecc71"), // Green
                SKColor.Parse("#e74c3c"), // Red
                SKColor.Parse("#f39c12"), // Orange
                SKColor.Parse("#9b59b6")  // Purple
            };

            int index = Math.Abs(label.GetHashCode()) % colors.Length;
            return colors[index];
        }

        private static string RenderChartImage(Chart chart, int width, int height)
        {
            var imageInfo = new SKImageInfo(width, height);
            using var surface = SKSurface.Create(imageInfo);
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);
            chart.Draw(canvas, width, height);

            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return Convert.ToBase64String(data.ToArray());
        }
    }
}
