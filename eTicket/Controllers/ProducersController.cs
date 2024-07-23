using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTicket.Models;
using eTicket.Data;
using Microsoft.EntityFrameworkCore;
using eTicket.Data.Services;

namespace eTicket.Controllers;


public class ProducersController : Controller
{
    private readonly IProducerService _service;
    public ProducersController(IProducerService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        var allProducers = await _service.GetAllAsync();
        return View(allProducers);
    }

// Get : Producers/Create
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create([Bind ("Name,ProfilePictureURL,Bio")]Producer producer)
    {
        if (!ModelState.IsValid)
        {
             return View(producer);
        }
            await _service.AddAsync(producer);
         return RedirectToAction(nameof(Index));
    }

    //Get: Producers/Details/id?
    public async Task<IActionResult> Details(int id)
    {
        var producerdetails = await _service.GetByIdAsync(id);
        return View(producerdetails);
    }

// Get : Producers/Create
    public async Task <IActionResult> Edit(int id)
    {
        var producerdetails = await _service.GetByIdAsync(id);
        if (producerdetails == null)
        {
            return View("NotFound");
        }
        return View(producerdetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id,[Bind ("Id,Name,ProfilePictureURL,Bio")] Producer producer)
    {
        if (!ModelState.IsValid)
        {
             return View(producer);
        }
        await _service.UpdateAsync(id, producer);
         return RedirectToAction(nameof(Index));
    }
    // Get : Producers/Delete
    public async Task <IActionResult> Delete(int id)
    {
        var producerdetails = await _service.GetByIdAsync(id);
        if (producerdetails == null)
        {
            return View("NotFound");
        }
         return View(producerdetails);
    }
    [HttpPost, ActionName ("Delete")]
    public async Task <IActionResult> DeleteConfirmed(int id)
    {
        var producerdetails = await _service.GetByIdAsync(id);
        if (producerdetails == null)
        {
            return View("NotFound");
        }
        await _service.DeleteAsync(id);
         return RedirectToAction(nameof(Index));
    }
}
