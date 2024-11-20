using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using static LAB5.Models.LAB6Models;

public class CarService
{
    private readonly HttpClient _httpClient;

    public CarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        try
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7280/api/cars");

            var cars = JsonConvert.DeserializeObject<List<Car>>(response);

            return cars;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Car>();
        }
    }
}
