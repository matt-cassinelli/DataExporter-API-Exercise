using DataExporter.Dtos;
using DataExporter.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataExporter.Controllers;

[ApiController]
[Route("[controller]")]
public class PoliciesController : ControllerBase
{
    private PolicyService _policyService;

    public PoliciesController(PolicyService policyService) 
    { 
        _policyService = policyService;
    }

    [HttpPost]
    public async Task<IActionResult> PostPolicy([FromBody] CreatePolicyRequest createPolicyRequest)
    {
        var response = await _policyService.CreatePolicyAsync(createPolicyRequest);

        // TODO: Return ProblemDetails 404 or 422 if input was invalid

        return Created("", response);
    }

    [HttpGet]
    public async Task<IActionResult> GetPolicies()
    {
        var response = await _policyService.ReadPoliciesAsync();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPolicy(int id)
    {
        var response = await _policyService.ReadPolicyAsync(id);

        // TODO: If not found, return 404 ProblemDetails

        return Ok(response);
    }


    [HttpPost("export")]
    public async Task<IActionResult> ExportData([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var response = await _policyService.ExportDataAsync(startDate, endDate);

        return Ok(response);
    }
}
