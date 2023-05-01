using reports_app_backend.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace reports_app_backend.Service.DTOs
{
    public class TemplateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Dictionary<string, string>> Fields { get; set; }
    }
}
