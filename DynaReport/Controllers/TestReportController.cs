using DynaReport.Contracts;
using DynaReport.Utilities;
using DynaReport.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DynaReport.Enumerations.TypeEnum;

namespace DynaReport.Controllers
{
    public class TestReportController : BaseController
    {
        private readonly IReportGenerator _reportGenerator;
        public TestReportController(IReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
        }

        [AllowAnonymous]
        [HttpPost("details-report")]
        public async Task<IActionResult> DetailsReportAsync(string lang)
        {
            try
            {
                var currentLang = LangEnum.Ar.GetEnumName().ToLower();
                _ = lang.ToLower();

                var details = new List<DetailItem>
                {
                    new DetailItem {
                        Key = lang == currentLang ? "اسم القسم" : "Department Name",
                        Value = lang == currentLang ? "قسم الهندسة" : "Engineering Department",
                        Col = 12
                    },
                    new DetailItem {
                        Key = lang == currentLang ? "المدير" : "Manager",
                        Value = "John Doe",
                        Col = 6
                    },
                    new DetailItem {
                        Key = lang == currentLang ? "عدد الموظفين" : "Employee Count",
                        Value = 50,
                        Col = 6
                    },
                    new DetailItem {
                        Key = lang == currentLang ? "الموقع" : "Location",
                        Value = lang == currentLang ? "المبنى أ" : "Building A",
                        Col = 4
                    },
                    new DetailItem {
                        Key = lang == currentLang ? "الميزانية" : "Budget",
                        Value = "$1,000,000",
                        Col = 4
                    },
                    new DetailItem {
                        Key = lang == currentLang ? "الحالة" : "Status",
                        Value = lang == currentLang ? "نشط" : "Active",
                        Col = 4
                    }
                };

                var viewModel = new DetailsReportViewModel
                {
                    ReportTitle = lang == currentLang ? "تقرير تفاصيل القسم" : "Department Details Report",
                    Details = details,
                    Lang = lang
                };

                var request = new ReportRequest<DetailsReportViewModel>
                {
                    ReportType = ReportType.Details,
                    Model = viewModel,
                    ReportTitle = viewModel.ReportTitle,
                    FileName = "DepartmentReport.pdf"
                };

                var response = await _reportGenerator.GenerateReportAsync(request);
                return File(response.Content!, response.ContentType, response.FileName);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error generating report: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPost("list-report")]
        public async Task<IActionResult> ListReportAsync(LangEnum currentLang)
        {
            try
            {
                var headers = new Dictionary<string, string>
                {
                    { "EmployeeName", "EmployeeName".ReportField(currentLang) },
                    { "Department", "Department".ReportField(currentLang) },
                    { "TotalTickets", "TotalTickets".ReportField(currentLang) },
                    { "CompletedTickets", "CompletedTickets".ReportField(currentLang) }
                };

                var items = new[]
                {
                    new Dictionary<string, object>
                    {
                        { "EmployeeName", "Project Alpha" },
                        { "Department", "InProgress".ReportField(currentLang) },
                        { "TotalTickets", 15 },
                        { "CompletedTickets", "2024-03-31" }
                    },
                    new Dictionary<string, object>
                    {
                        { "EmployeeName", "Project Beta" },
                        { "Department", "Planning".ReportField(currentLang) },
                        { "TotalTickets", 8 },
                        { "CompletedTickets", "2024-04-15" }
                    },
                    new Dictionary<string, object>
                    {
                        { "EmployeeName", "Project Gamma" },
                        { "Department", "Completed".ReportField(currentLang) },
                        { "TotalTickets", 12 },
                        { "CompletedTickets", "2024-02-28" }
                    }
                };


                var viewModel = new ListReportViewModel
                {
                    ReportTitle = "EmployeeCompletionReport".ReportField(currentLang),
                    Headers = headers,
                    Items = items,
                    Lang = currentLang.GetEnumNameWithoutReplace().ToLower()
                };

                var request = new ReportRequest<ListReportViewModel>
                {
                    ReportType = ReportType.List,
                    Model = viewModel,
                    ReportTitle = viewModel.ReportTitle,
                    FileName = "DepartmentsList.pdf"
                };

                var response = await _reportGenerator.GenerateReportAsync(request);
                return File(response.Content!, response.ContentType, response.FileName);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error generating report: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPost("details-with-list-report")]
        public async Task<IActionResult> DetailsWithListReportAsync(LangEnum currentLang)
        {
            try
            {

                var details = new List<DetailItem>
                {
                    new() { Key = "DepartmentName".ReportField(currentLang), Value = "Engineering Department", Col = 12 },
                    new() { Key = "Manager".ReportField(currentLang), Value = "John Doe", Col = 6 },
                    new() { Key = "EmployeeCount".ReportField(currentLang), Value = 50, Col = 6 },
                    new() { Key = "Location".ReportField(currentLang), Value = "Building A", Col = 4 },
                    new() { Key = "Budget".ReportField(currentLang), Value = "$1,000,000", Col = 4 },
                    new() { Key = "Status".ReportField(currentLang), Value = "Active", Col = 4 }
                };

                var headers = new Dictionary<string, string>
                {
                    { "Name", "ProjectName".ReportField(currentLang) },
                    { "Status", "ProjectStatus".ReportField(currentLang) },
                    { "TeamSize", "TeamSize".ReportField(currentLang) },
                    { "Deadline", "Deadline".ReportField(currentLang) }
                };

                var items = new[]
                {
                    new Dictionary<string, object>
                    {
                        { "Name", "Project Alpha" },
                        { "Status", "InProgress".ReportField(currentLang) },
                        { "TeamSize", 15 },
                        { "Deadline", "2024-03-31" }
                    },
                    new Dictionary<string, object>
                    {
                        { "Name", "Project Beta" },
                        { "Status", "Planning".ReportField(currentLang) },
                        { "TeamSize", 8 },
                        { "Deadline", "2024-04-15" }
                    },
                    new Dictionary<string, object>
                    {
                        { "Name", "Project Gamma" },
                        { "Status", "Completed".ReportField(currentLang) },
                        { "TeamSize", 12 },
                        { "Deadline", "2024-02-28" }
                    }
                };

                var viewModel = new DetailsWithListReportViewModel
                {
                    ReportTitle = "EmployeeCompletionReport".ReportField(currentLang),
                    ListLimit = 5,
                    Details = details,
                    Headers = headers,
                    Items = items,
                    Lang = currentLang.GetEnumNameWithoutReplace().ToLower()
                };

                var request = new ReportRequest<DetailsWithListReportViewModel>
                {
                    ReportType = ReportType.DetailsWithList,
                    Model = viewModel,
                    ReportTitle = viewModel.ReportTitle,
                    FileName = "DepartmentOverview.pdf"
                };

                var response = await _reportGenerator.GenerateReportAsync(request);
                return File(response.Content!, response.ContentType, response.FileName);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error generating report: {ex.Message}");
            }
        }
    }
}