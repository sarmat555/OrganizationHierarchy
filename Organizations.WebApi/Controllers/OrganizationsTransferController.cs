using Microsoft.AspNetCore.Mvc;
using Organizations.Contracts.Services;

namespace Organizations.WebApi.Controllers
{
    [Route("api/transfer")]
    [ApiController]
    public class OrganizationsTransferController : ControllerBase
    {
        private readonly IOrganizationExportService _exportService;
        private readonly IOrganizationImportService _importService;

        public OrganizationsTransferController(IOrganizationExportService exportService, IOrganizationImportService importService)
        {
            _exportService = exportService;
            _importService = importService;
        }

        [HttpGet("export")]
        public async Task<IActionResult> Export()
        {
            var data = await _exportService.ExportAsync();
            return Ok(data);
        }

        [HttpGet("import")]
        public async Task<IActionResult> Import(string data)
        {
            await _importService.ImportAsync(data);
            return Ok(data);
        }
    }
}
