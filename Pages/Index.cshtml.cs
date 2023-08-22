using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MarineLocationViewer.Repositories;
using System.Collections.Generic; // For List<>
using System.Threading.Tasks; // For Task

namespace MarineLocationViewer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MarineDataRepository _repository;

        public string Message { get; set; }

        // Property to hold the coordinates
        public List<MarineData> Coordinates { get; set; } = new List<MarineData>();

        // Inject the MarineDataRepository
        public IndexModel(MarineDataRepository repository)
        {
            _repository = repository;
            Message = string.Empty;
        }

        public async Task OnGetAsync()
        {
            // Fetch all coordinates from the database
            Coordinates = await _repository.GetAll();
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

            // After saving, fetch all coordinates again to update the map
            Coordinates = await _repository.GetAll();
        }
    }
}
