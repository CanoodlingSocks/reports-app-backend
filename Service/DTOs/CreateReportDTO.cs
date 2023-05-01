namespace reports_app_backend.Service.DTOs
{
    public class CreateReportDTO
    {
        public int TemplateId { get; set; }
        public string Title { get; set; }
        public string ReportContent { get; set; }
        public TemplateDTO TemplateDTO { get; set; }
    }
}
