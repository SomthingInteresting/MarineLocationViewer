using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarineLocationViewer.Pages;

public class IndexModel : PageModel
{
    public string Message { get; set; }

    public void OnGet()
    {
    }

    public void OnPost(string latitude, string longitude)
    {
        Message = $"Received coordinates - Latitude: {latitude}, Longitude: {longitude}";
    }
}

