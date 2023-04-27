using reports_app_backend.DAL.Models;

namespace reports_app_backend.Service.Interfaces
{
    public interface ITemplateService
    {
        //void CreateBugReportTemplate();
        TemplateData GetTemplateData(int id);
        IEnumerable<TemplateData> GetAllTemplates();
    }
}
