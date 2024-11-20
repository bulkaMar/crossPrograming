using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json; 
using System.Collections.Generic;
using static LAB5.Models.LAB6Models;

public class ManufacturerService
{
    private readonly HttpClient _httpClient;
    public ManufacturerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Manufacturer>> GetManufacturersAsync()
    {
        try { 

            var response = await _httpClient.GetStringAsync("https://localhost:7280/api/manufacturers");

            var manufacturers = JsonConvert.DeserializeObject<List<Manufacturer>>(response);

            return manufacturers;
        }
        catch (Exception ex)
        {
            // Обробка помилок
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Manufacturer>();
        }
    }
}
