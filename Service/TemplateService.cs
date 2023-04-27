using Microsoft.AspNetCore.Http.HttpResults;
using reports_app_backend.DAL;
using reports_app_backend.DAL.Models;
using reports_app_backend.Service.Interfaces;
using System.Text.Json;

namespace reports_app_backend.Service
{
    public class TemplateService : ITemplateService
    {
        private readonly ReportsDBContext _dbContext;
        public TemplateService(ReportsDBContext context)
        {
            _dbContext = context;
        }

        //Test creation of a Bug Report Template

        //public void CreateBugReportTemplate()
        //{
        //    var fields = new List<Dictionary<string, string>>()
        //    {
        //        new Dictionary<string, string>()
        //        {
        //            {"Name", "Bug Id" },
        //            {"Type", "Number" },
        //            {"Required", "True" }
        //        },
        //        new Dictionary<string, string>()
        //        {
        //            {"Description", "Description" },
        //            {"Type", "Text" },
        //            {"Required", "False" }
        //        }
        //    };

        //    var fieldsJson = JsonSerializer.Serialize(fields);

        //    var templateData = new TemplateData
        //    {
        //        Name = "Bug Report",
        //        Description = "This is a bug report template",
        //        Fields = fieldsJson
        //    };
        //    _dbContext.TemplateDatas.Add(templateData);
        //    _dbContext.SaveChanges();
        //}

        public IEnumerable<TemplateData> GetAllTemplates()
        {
            var templates = _dbContext.TemplateDatas.ToList();
            return templates;
        }
        public TemplateData GetTemplateData(int templateId)
        {
            return _dbContext.TemplateDatas.FirstOrDefault(i => i.Id == templateId);
        }
    }
}
