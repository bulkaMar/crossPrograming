using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using static LAB5.Models.LAB6Models; 

public class CustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Customer>> GetCustomersAsync() 
    {
        try
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7280/api/customers");

            var customers = JsonConvert.DeserializeObject<List<Customer>>(response);

            return customers;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Customer>(); 
        }
    }
}
