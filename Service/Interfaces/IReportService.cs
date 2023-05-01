using reports_app_backend.DAL.Models;
using reports_app_backend.Service.DTOs;

namespace reports_app_backend.Service.Interfaces
{
    public interface IReportService
    {
        IEnumerable<Report> GetAllReports();
        Report GetReport(int reportId);
        Task<Report> CreateReport(int templateId, string reportName, string reportDescription);
        Task<bool> DeleteReport(int reportId);

    }
}
