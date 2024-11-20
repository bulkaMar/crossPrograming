using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using static LAB5.Models.LAB6Models;

public class ServiceBookingService
{
    private readonly HttpClient _httpClient;

    public ServiceBookingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ServiceBooking>> GetBookingAsync()
    {
        try
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7280/api/servicebookings");

            // Ось тут була помилка — неправильно закрита дужка
            var bookings = JsonConvert.DeserializeObject<List<ServiceBooking>>(response);

            return bookings;
        }
        catch (Exception ex)
        {
            // Обробка помилок
            Console.WriteLine($"Error: {ex.Message}");
            return new List<ServiceBooking>();
        }
    }
}
