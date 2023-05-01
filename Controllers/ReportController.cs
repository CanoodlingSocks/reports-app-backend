using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reports_app_backend.DAL.Models;
using reports_app_backend.Service;
using reports_app_backend.Service.DTOs;
using reports_app_backend.Service.Interfaces;

namespace reports_app_backend.Controllers
{
    [ApiController]
    [Route("api/Report")]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("/GetAllReports")]
        public ActionResult<IEnumerable<Report>> GetAllReports()
        {
            var reports = _reportService.GetAllReports();
            return Ok(reports);
        }

        [HttpGet]
        [Route("/GetReport/{reportId}")]
        public ActionResult<Report> GetReport(int reportId)
        {
            var report = _reportService.GetReport(reportId);

            if (report == null)
            {
                return NotFound($"Report with Id {reportId} was not found");
            }

            return Ok(report);
        }

        //Gives me an error 500 but still manages to create new reports from the existing templates
        [HttpPost]
        [Route("/CreateReport/{templateId}")]
        public async Task<ActionResult<Report>> CreateReport(int templateId, string reportName, string reportDescription)
        {
            var createdReport = await _reportService.CreateReport(templateId, reportName, reportDescription);

            if (createdReport == null)
            {
                return BadRequest("Report creation failed.");
            }

            try
            {
                //After googling, this seems to be the root of the issue
                return CreatedAtAction(nameof(CreateReport), new { id = createdReport.Id }, createdReport);
                //return CreatedAtAction("CreateReport", new { createdReport.Id }, createdReport);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("An error occurred while processing the request: " + ex.Message);
            }
        }


        [HttpDelete]
        [Route("/DeleteReport/{reportId}")]
        public async Task<IActionResult> DeleteReport(int reportId)
        {
            var result = await _reportService.DeleteReport(reportId);

            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}







