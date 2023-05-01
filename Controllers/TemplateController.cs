using Microsoft.AspNetCore.Mvc;
using reports_app_backend.DAL.Models;
using reports_app_backend.Service;

namespace reports_app_backend.Controllers
{
    [ApiController]
    [Route("api/Template")]
    public class TemplateController : ControllerBase
    {
        private readonly TemplateService _templateService;

        public TemplateController(TemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet]
        [Route("/GetAllTemplates")]
        public ActionResult<IEnumerable<TemplateData>> GetAllTemplates()
        {
            var templates = _templateService.GetAllTemplates();
            return Ok(templates);
        }

        [HttpGet]
        [Route("/GetTemplate/{id}")]
        public ActionResult<TemplateData> GetTemplate(int id)
        {
            var templateData = _templateService.GetTemplateData(id);

            if (templateData == null)
            {
                return NotFound();
            }

            return Ok(templateData);
        }

        [HttpPost]
        [Route("/CreateTemplate")]
        public ActionResult<TemplateData> CreateTemplate(TemplateData templateData)
        {
            _templateService.CreateTemplate(templateData);
            return Ok(templateData);
        }

        [HttpPut]
        [Route("/EditTemplate/{id}")]
        public async Task<ActionResult<TemplateData>> EditTemplate(int id, [FromBody] EditTemplateRequest request)
        {
            var fields = request.Fields ?? new List<Dictionary<string, string>>();
            var template = await _templateService.EditTemplate(id, request.Name, request.Description, fields);
            return Ok(template);
        }

        [HttpDelete]
        [Route("/DeleteTemplate/{id}")]
        public ActionResult DeleteTemplate(int id)
        {
            try
            {
                _templateService.DeleteTemplate(id);
                return Ok();
            }
            catch (ArgumentException ex) 
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class EditTemplateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Dictionary<string, string>> Fields { get; set; }
    }
}
