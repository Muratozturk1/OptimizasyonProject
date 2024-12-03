using Microsoft.AspNetCore.Mvc;
using Optimizasyon.Core.Application.Services;
using Optimizasyon.Core.Domain.Entities;
namespace Optimizasyon.Presentation.WebAPI.Controller;


   [Route("api/[controller]")]
[ApiController]
public class MarangozController : ControllerBase
{
    private readonly IMarangozOptimizationService _optimizationService;

    public MarangozController(IMarangozOptimizationService optimizationService)
    {
        _optimizationService = optimizationService;
    }

    [HttpPost("optimize")]
    public ActionResult<OptimizationResult> Optimize([FromBody] MarangozModel model)
    {
        var result = _optimizationService.Optimize(model);
        
       
        return Ok(result);
    }
}



