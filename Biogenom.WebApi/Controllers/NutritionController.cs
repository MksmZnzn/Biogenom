using Biogenom.Application.Interfaces;
using Biogenom.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom.WebApo.Controllers;

[ApiController]
[Route("api/nutrition")]
public class NutritionController : ControllerBase
{
    private readonly INutritionService _service;

    public NutritionController(INutritionService service)
    {
        _service = service;
    }

    [HttpGet("report")]
    public async Task<ActionResult<NutritionReportDto>> GetReport()
    {
        try
        {
            return Ok(await _service.GetNutritionReportAsync());
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}