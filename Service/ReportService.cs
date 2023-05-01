using Microsoft.EntityFrameworkCore;
using reports_app_backend.DAL;
using reports_app_backend.DAL.Models;
using reports_app_backend.Service.DTOs;
using reports_app_backend.Service.Interfaces;
using System.Text.Json;

namespace reports_app_backend.Service
{
    public class ReportService : IReportService
    {
        private readonly ReportsDBContext _dbContext;
        public ReportService(ReportsDBContext context)
        {
            _dbContext = context;
        }
        public IEnumerable<Report> GetAllReports()
        {
            var reports = _dbContext.Reports.ToList();
            return reports;
        }
        //public async Task<List<Report>> GetAllReports()
        //{
        //    return await _dbContext.Reports.ToListAsync();
        //}

        public Report GetReport(int reportId)
        {
            return _dbContext.Reports.FirstOrDefault(i => i.Id == reportId);
        }

        //public void CreateReport(TemplateDTO templateDTO, string title, string reportContent, int templateId)
        //{
        //    var templateData = _dbContext.TemplateDatas.FirstOrDefault( t => t.Id == templateId);
        //    if (templateData == null)
        //    {
        //        throw new ArgumentException($"Template with id {templateId} was not found");
        //    }

        //    var templateContentsJson = JsonSerializer.Serialize(templateData.Fields);

        //    ////Populate the report with the template contents
        //    //var reportContents = new List<Dictionary<string, string>>();
        //    //foreach (var content in templateContents)
        //    //{
        //    //    var templateContent = new Dictionary<string, string>
        //    //    {
        //    //        { "Name", content["Name"] },
        //    //        { "Description", content["Description"] },
        //    //        { "Fields", content["Fields"] }
        //    //    };
        //    //    reportContents.Add(templateContent);
        //    //}

        //    //var report = new Report
        //    //{
        //    //    Title = title,
        //    //    Content = reportContent,
        //    //    DateCreated = DateTime.Now,
        //    //    DateModified = DateTime.Now,
        //    //    TemplateId = templateId,
        //    //    TemplateData = new TemplateData
        //    //    {
        //    //        Id = templateData.Id,
        //    //        Name = templateData.Name,
        //    //        Description = templateData.Description,
        //    //        Fields = templateContentsJson
        //    //    }
        //    //};

        //    var report = new Report
        //    {
        //        Title = title,
        //        Content = reportContent,
        //        TemplateId = templateId,
        //        TemplateDTO = templateDTO
        //    };

        //    _dbContext.Reports.Add(report);
        //    _dbContext.SaveChanges();
        //}

        public async Task<Report> CreateReport(int templateId, string reportName, string reportDescription)
        {
            var templateData = await _dbContext.TemplateDatas.FindAsync(templateId);

            if (templateData == null)
            {
                throw new ArgumentException("Template not found.");
            }

            //var newReport = new Report
            //{
            //    Title = report.Title,
            //    Description = report.Description,
            //    ReportContent = report.ReportContent,
            //    Template = templateData
            //};
            var newReport = new Report
            {
                Title = reportName,
                Description = reportDescription,
                TemplateDataId = templateData.Id,
                ReportContent = "",
                Template = templateData
            };

            _dbContext.Reports.Add(newReport);
            await _dbContext.SaveChangesAsync();

            return newReport;
        }

        public async Task<bool> DeleteReport(int reportId)
        {
            var report = await _dbContext.Reports.FindAsync(reportId);
            if (report == null)
            {
                return false;
            }

            _dbContext.Remove(report);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

