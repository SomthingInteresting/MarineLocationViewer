using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
        return Ok(_repository.GetAll());
    }
    
    // Add endpoints for creating, updating, and deleting...
}
