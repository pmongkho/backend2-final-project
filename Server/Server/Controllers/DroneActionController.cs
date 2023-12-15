using Microsoft.AspNetCore.Mvc;
using DotNetServer.Models;
using DotNetServer.Services;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class DroneActionController : ControllerBase
{
    private readonly DroneActionService _droneActionService;

    public DroneActionController(DroneActionService droneActionService)
    {
        _droneActionService = droneActionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _droneActionService.GetAllDroneActionsAsync());
    }

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> Get(string id)
    {
        var droneAction = await _droneActionService.GetDroneActionByIdAsync(id);
        if (droneAction == null) return NotFound();

        return Ok(droneAction);
    }

    [HttpPost]
    public async Task<IActionResult> Create(DroneAction droneAction)
    {
        await _droneActionService.CreateAsync(droneAction);
        return CreatedAtAction(nameof(Get), new { id = droneAction.Id }, droneAction);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, DroneAction droneAction)
    {
        await _droneActionService.UpdateAsync(id, droneAction);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _droneActionService.RemoveAsync(id);
        return NoContent();
    }
}
