using Microsoft.AspNetCore.Mvc;
using reports_app_backend.DAL.Models;
using reports_app_backend.Service;

namespace reports_app_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ControllerBase
    {
        private readonly TemplateService _templateService;

        public TemplateController(TemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TemplateData>> GetAllTemplates()
        {
            var templates = _templateService.GetAllTemplates();
            return Ok(templates);
        }
    }
}
