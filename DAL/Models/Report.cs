using reports_app_backend.Service.DTOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace reports_app_backend.DAL.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReportContent { get; set; }
        public int TemplateDataId { get; set; } // add TemplateDataId property
        public TemplateData Template { get; set; }
    }
}
