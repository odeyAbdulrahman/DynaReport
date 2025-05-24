
using DynaReport.ViewModels;

namespace DynaReport.Contracts
{
    public interface IChartRenderer
    {
        string RenderChart(DynamicChart chartConfig);
    }
}