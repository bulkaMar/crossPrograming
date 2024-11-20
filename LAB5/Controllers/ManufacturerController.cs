using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class ManufacturerController : Controller
{
    private readonly ManufacturerService _manufacturerService;

    // Впроваджуємо сервіс через DI
    public ManufacturerController(ManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }

    // Метод для показу списку виробників
    public async Task<IActionResult> Index()
    {
        var manufacturers = await _manufacturerService.GetManufacturersAsync();
        return View(manufacturers);
    }
}
