using ATSApi.Models;
using ATSApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATSApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly CandidatesService _candidatesService;

    public CandidatesController(CandidatesService candidatesService) =>
        _candidatesService = candidatesService;

    [HttpGet]
    public async Task<List<Candidate>> Get() =>
        await _candidatesService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Candidate>> Get(string id)
    {
        var candidate = await _candidatesService.GetAsync(id);

        if (candidate is null)
        {
            return NotFound();
        }

        return candidate;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Candidate newCandidate)
    {
        await _candidatesService.CreateAsync(newCandidate);

        return CreatedAtAction(nameof(Get), new { id = newCandidate.Id }, newCandidate);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Candidate updatedCandidate)
    {
        var candidate = await _candidatesService.GetAsync(id);

        if (candidate is null)
        {
            return NotFound();
        }

        updatedCandidate.Id = candidate.Id;

        await _candidatesService.UpdateAsync(id, updatedCandidate);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var candidate = await _candidatesService.GetAsync(id);

        if (candidate is null)
        {
            return NotFound();
        }

        await _candidatesService.RemoveAsync(id);

        return NoContent();
    }
}