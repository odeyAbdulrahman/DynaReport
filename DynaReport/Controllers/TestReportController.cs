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
        public async Task<IActionResult> ListReportAsync(string lang)
        {
            try
            {
                var currentLang = LangEnum.Ar.GetEnumName().ToLower();
                _ = lang.ToLower();
                var items = new[]
                {
                    new {
                        Name = lang == currentLang ? "قسم الهندسة" : "Engineering Department",
                        Manager = lang == currentLang ? "جون دو" : "John Doe",
                        EmployeeCount = 50,
                        Location = lang == currentLang ? "المبنى أ" : "Building A"
                    },
                    new {
                        Name = lang == currentLang ? "قسم التسويق" : "Marketing Department",
                        Manager = lang == currentLang ? "جين سميث" : "Jane Smith",
                        EmployeeCount = 30,
                        Location = lang == currentLang ? "المبنى ب" : "Building B"
                    },
                    new {
                        Name = lang == currentLang ? "قسم المالية" : "Finance Department",
                        Manager = lang == currentLang ? "مايك جونسون" : "Mike Johnson",
                        EmployeeCount = 25,
                        Location = lang == currentLang ? "المبنى ج" : "Building C"
                    }
                };

                var viewModel = new ListReportViewModel
                {
                    ReportTitle = lang == currentLang ? "تقرير قائمة الأقسام" : "Departments List Report",
                    Headers = lang == currentLang 
                        ? new[] { "الاسم", "المدير", "عدد الموظفين", "الموقع" }
                        : new[] { "Name", "Manager", "EmployeeCount", "Location" },
                    Items = items,
                    Lang = lang
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
        public async Task<IActionResult> DetailsWithListReportAsync(string lang)
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

                var items = new[]
                {
                    new {
                        Name = lang == currentLang ? "مشروع ألفا" : "Project Alpha",
                        Status = lang == currentLang ? "قيد التنفيذ" : "In Progress",
                        TeamSize = 15,
                        Deadline = "2024-03-31"
                    },
                    new {
                        Name = "Project Beta",
                        Status = "Planning",
                        TeamSize = 8,
                        Deadline = "2024-04-15"
                    },
                    new {
                        Name = "Project Gamma",
                        Status = "Completed",
                        TeamSize = 12,
                        Deadline = "2024-02-28"
                    }
                };

                var viewModel = new DetailsWithListReportViewModel
                {
                    ReportTitle = lang == currentLang ? "نظرة عامة على قسم الهندسة" : "Engineering Department Overview",
                    ListLimit = 5,
                    Details = details,
                    Items = items,
                    Lang = currentLang
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