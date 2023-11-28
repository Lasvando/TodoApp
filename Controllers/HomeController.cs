using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TodoApp.Models;
using TodoApp.Services.Interfaces;

namespace TodoApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IItemService _itemService;

    public HomeController(ILogger<HomeController> logger, IItemService itemService)
    {
        _itemService = itemService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _itemService.GetAll();

        return View(items);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await _itemService.Get(id);

        if (item == null) return NotFound();

        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Item updatedItem)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var item = await _itemService.Update(updatedItem);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var items = await _itemService.Delete(id);

        if (items == null) return NotFound();

        return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        var newItem = await _itemService.Create(item);

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Check(int id)
    {
        var item = await _itemService.Check(id);
        if (item == null) return NotFound();

        TempData["success"] = "Item aggiornato";
        
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
