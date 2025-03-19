using Microsoft.AspNetCore.Mvc;
using Organizations.Contracts.Models;
using Organizations.Contracts.Services;
using Organizations.Domain.Organizations;

namespace Organizations.WebApi.Controllers;

[Route("api/organizations")]
[ApiController]
public class OrganizationsController : ClassifierBaseController<Organization, OrganizationTreeItem>
{
    private readonly IOrganizationService<Organization, OrganizationTreeItem> _service;
    private readonly IOrganizationMoveService _moveService;
    public OrganizationsController(IOrganizationService<Organization, OrganizationTreeItem> service, IOrganizationMoveService moveService) : base(service)
    {
        _service = service;
        _moveService = moveService;
    }

    [HttpGet("get-tree")]
    public async Task<IActionResult> GetTree()
    {
        var data = await _service.GetTreeAsync();
        return Ok(data);
    }

    [HttpPost("move")]
    public async Task<IActionResult> Move(OrganizationMoveDto moved)
    {
        await _moveService.MoveAsync(moved);
        return Ok();
    }
}
