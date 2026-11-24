using DeliveryRoundsApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryRoundsApi.Controllers;

[ApiController]
[Route("stops")]
public class StopsController : ControllerBase
{
    private readonly IRoundService _service;

    public StopsController(IRoundService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteStopAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
