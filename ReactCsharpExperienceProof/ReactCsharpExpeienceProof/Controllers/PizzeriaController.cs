using Microsoft.AspNetCore.Mvc;
using ReactCsharpExperienceProof.Services.PizzeriaService;

namespace ReactCsharpExperienceProof.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzeriaController : ControllerBase
{
    private readonly IPizzeriaService _pizzeriaService;

    public PizzeriaController(IPizzeriaService pizzeriaService)
    {
        _pizzeriaService = pizzeriaService;
    }

    [HttpGet]
    [Route("GetPizzerias")]
    public async Task<IActionResult> GetPizzerias()
    {
        var result = await _pizzeriaService.GetPizzeriasList();
        return Ok(result.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetPizzeria(Guid Id)
    {
        var result = await _pizzeriaService.GetPizzeria(Id);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> AddPizzeria(string name, string location)
    {
        var result = await _pizzeriaService.AddPizzeria(name, location);

        return Ok(result.Data);
    }
}