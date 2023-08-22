using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarineLocationViewer.Repositories;

[ApiController]
[Route("[controller]")]
public class MarineDataController : ControllerBase
{
    private readonly MarineDataRepository _repository;

    public MarineDataController(MarineDataRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var marineData = await _repository.GetAll();
        return Ok(marineData);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(string id)
    {
        var marineDatum = await _repository.Get(id);
        if (marineDatum == null) return NotFound();
        return Ok(marineDatum);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MarineData marineData)
    {
        await _repository.Create(marineData);
        return CreatedAtAction(nameof(GetOne), new { id = marineData.Id }, marineData);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] MarineData marineData)
    {
        var existingMarineDatum = await _repository.Get(id);
        if (existingMarineDatum == null) return NotFound();

        var updateResult = await _repository.Update(id, marineData);
        
        // Log or print the update result
        Console.WriteLine($"Matched: {updateResult.MatchedCount}, Modified: {updateResult.ModifiedCount}");

        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var marineDatumToDelete = await _repository.Get(id);
        if (marineDatumToDelete == null) return NotFound();

        await _repository.Delete(id);
        return NoContent();
    }

}
