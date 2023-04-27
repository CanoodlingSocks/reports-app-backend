using reports_app_backend.DAL.Models;

namespace reports_app_backend.Service.Interfaces
{
    public interface ITemplateService
    {
        //void CreateBugReportTemplate();
        TemplateData GetTemplateData(int id);
        IEnumerable<TemplateData> GetAllTemplates();
        void CreateTemplate(TemplateData templateData);
        Task<TemplateData> EditTemplate(int id, string name, string description, List<Dictionary<string, string>> fields);
        public void DeleteTemplate(int id);
    }
}
