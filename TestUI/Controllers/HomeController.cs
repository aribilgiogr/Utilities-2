using Microsoft.AspNetCore.Mvc;
using TestUI.Models;
using Utilities.Generics;
using System.Linq;
using System.Diagnostics;

namespace TestUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(int page = 1, int pageSize = 6)
    {
        var items = Item.GetDemoData();
        var paginatedItems = PaginatedList<Item>.Create(items, page, pageSize);
        return View(paginatedItems);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
