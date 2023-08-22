using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MarineLocationViewer.Repositories;

namespace MarineLocationViewer.Pages;

public class IndexModel : PageModel
{
    private readonly MarineDataRepository _repository;

    public string Message { get; set; }

    // Inject the MarineDataRepository
    public IndexModel(MarineDataRepository repository)
    {
        _repository = repository;
        Message = string.Empty;
    }

    public void OnGet()
    {
    }

    public async Task OnPostAsync(string latitude, string longitude)
    {
        var marineData = new MarineData
        {
            Latitude = double.Parse(latitude),
            Longitude = double.Parse(longitude)
        };
        
        await _repository.Create(marineData);
        Message = "Coordinates saved successfully!";
    }
}
