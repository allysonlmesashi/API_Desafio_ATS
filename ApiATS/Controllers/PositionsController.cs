using ATSApi.Models;
using ATSApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATSApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PositionsController : ControllerBase
{
    private readonly PositionsService _positionsService;

    public PositionsController(PositionsService positionsService) =>
        _positionsService = positionsService;

    [HttpGet]
    public async Task<List<Position>> Get() =>
        await _positionsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Position>> Get(string id)
    {
        var position = await _positionsService.GetAsync(id);

        if (position is null)
        {
            return NotFound();
        }

        return position;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Position newPosition)
    {
        await _positionsService.CreateAsync(newPosition);

        return CreatedAtAction(nameof(Get), new { id = newPosition.Id }, newPosition);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Position updatedPosition)
    {
        var position = await _positionsService.GetAsync(id);

        if (position is null)
        {
            return NotFound();
        }

        updatedPosition.Id = position.Id;

        await _positionsService.UpdateAsync(id, updatedPosition);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var position = await _positionsService.GetAsync(id);

        if (position is null)
        {
            return NotFound();
        }

        await _positionsService.RemoveAsync(id);

        return NoContent();
    }
}