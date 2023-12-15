using Microsoft.AspNetCore.Mvc;
using DotNetServer.Models;
using DotNetServer.Services;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class DroneController : ControllerBase
{
    private readonly DroneService _droneService;

    public DroneController(DroneService droneService)
    {
        _droneService = droneService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _droneService.GetAllDronesAsync());
    }

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> Get(string id)
    {
        var drone = await _droneService.GetDroneByIdAsync(id);
        if (drone == null) return NotFound();

        return Ok(drone);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Drone drone)
    {
        await _droneService.CreateAsync(drone);
        return CreatedAtAction(nameof(Get), new { id = drone.Id }, drone);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Drone drone)
    {
        await _droneService.UpdateAsync(id, drone);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _droneService.RemoveAsync(id);
        return NoContent();
    }
}
