using DynaReport.ViewModels;

namespace DynaReport.Contracts
{
    public interface IReportGenerator
    {
        Task<ReportResponse> GenerateReportAsync<TModel>(ReportRequest<TModel> request);
    }
}
