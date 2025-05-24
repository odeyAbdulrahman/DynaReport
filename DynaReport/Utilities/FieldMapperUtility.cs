using static DynaReport.Enumerations.TypeEnum;

namespace DynaReport.Utilities
{
    public static class FieldMapperUtility
    {
        public static string ReportField(this string key, LangEnum currentLang)
        {
            return currentLang == LangEnum.Ar
                ? key switch
                {
                    "EmployeeCompletionReport" => "تقرير إنجاز الموظفين",
                    "EmployeeKPIReport" => "تقرير مؤشرات الأداء للموظف",
                    "TicketDistribution" => "توزيع التذاكر",

                    "TotalEmployees" => "إجمالي الموظفين",
                    "NoDataAvailable" => "لا توجد بيانات متاحة",
                    "AverageCompletionRate" => "متوسط معدل الإنجاز",
                    "AverageRating" => "متوسط التقييم",
                    "AverageCompletionTime" => "متوسط وقت الإنجاز",
                    "TotalTickets" => "إجمالي التذاكر",
                    "EmployeeName" => "اسم الموظف",
                    "Department" => "القسم",
                    "TotalTicketsHeader" => "إجمالي التذاكر",
                    "CompletedTickets" => "التذاكر المكتملة",
                    "InProgressTickets" => "التذاكر قيد التنفيذ",
                    "PendingTickets" => "التذاكر المعلقة",
                    "CompletionRate" => "معدل الإنجاز",
                    "AverageRatingHeader" => "متوسط التقييم",
                    "AverageTime" => "متوسط الوقت",
                    "Hours" => "ساعة",
                    "TicketId" => "رقم التذكرة",
                    "TicketType" => "نوع التذكرة",
                    "CreatedDate" => "تاريخ الإنشاء",
                    "Status" => "الحالة",
                    "Rating" => "التقييم",
                    "CompletionTime" => "وقت الإنجاز",
                    "AverageResponseTime" => "متوسط وقت الاستجابة",
                    "HighRatingTickets" => "التذاكر ذات التقييم العالي",
                    "MediumRatingTickets" => "التذاكر ذات التقييم المتوسط",
                    "LowRatingTickets" => "التذاكر ذات التقييم المنخفض",
                    "FastCompletionTickets" => "التذاكر المكتملة بسرعة",
                    "MediumCompletionTickets" => "التذاكر المكتملة بوقت متوسط",
                    "SlowCompletionTickets" => "التذاكر المكتملة ببطء",
                    "PerformanceMetrics" => "مؤشرات الأداء",
                    "RatingDistribution" => "توزيع التقييمات",
                    "CompletionTimeDistribution" => "توزيع أوقات الإنجاز",
                    _ => key
                }
                : key switch
                {
                    "EmployeeCompletionReport" => "Employee Completion Report",
                    "EmployeeKPIReport" => "Employee KPI Report",
                    "TicketDistribution" => "Ticket Distribution",

                    "TotalEmployees" => "Total Employees",
                    "NoDataAvailable" => "No data available",
                    "AverageCompletionRate" => "Average Completion Rate",
                    "AverageRating" => "Average Rating",
                    "AverageCompletionTime" => "Average Completion Time",
                    "TotalTickets" => "Total Tickets",
                    "EmployeeName" => "Employee Name",
                    "Department" => "Department",
                    "TotalTicketsHeader" => "Total Tickets",
                    "CompletedTickets" => "Completed Tickets",
                    "InProgressTickets" => "In Progress Tickets",
                    "PendingTickets" => "Pending Tickets",
                    "CompletionRate" => "Completion Rate",
                    "AverageRatingHeader" => "Average Rating",
                    "AverageTime" => "Average Time",
                    "Hours" => "hours",
                    "TicketId" => "Ticket ID",
                    "TicketType" => "Ticket Type",
                    "CreatedDate" => "Created Date",
                    "Status" => "Status",
                    "Rating" => "Rating",
                    "CompletionTime" => "Completion Time",
                    "AverageResponseTime" => "Average Response Time",
                    "HighRatingTickets" => "High Rating Tickets",
                    "MediumRatingTickets" => "Medium Rating Tickets",
                    "LowRatingTickets" => "Low Rating Tickets",
                    "FastCompletionTickets" => "Fast Completion Tickets",
                    "MediumCompletionTickets" => "Medium Completion Tickets",
                    "SlowCompletionTickets" => "Slow Completion Tickets",
                    "PerformanceMetrics" => "Performance Metrics",
                    "RatingDistribution" => "Rating Distribution",
                    "CompletionTimeDistribution" => "Completion Time Distribution",
                    _ => key
                };
        }
    }
}
