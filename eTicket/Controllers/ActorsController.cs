using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTicket.Models;
using eTicket.Data;
using eTicket.Data.Services;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTicket.Controllers;


public class ActorsController : Controller
{
    private readonly IActorsService _service;
    public ActorsController(IActorsService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        var allActors = await _service.GetAllAsync();
        return View(allActors);
    }

// Get : Actors/Create
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create([Bind ("Name,ProfilePictureURL,Bio")]Actor actor)
    {
        if (!ModelState.IsValid)
        {
             return View(actor);
        }
            await _service.AddAsync(actor);
         return RedirectToAction(nameof(Index));
    }

    //Get: Actors/Details/id?
    public async Task<IActionResult> Details(int id)
    {
        var actordetails = await _service.GetByIdAsync(id);
        return View(actordetails);
    }

// Get : Actors/Create
    public async Task <IActionResult> Edit(int id)
    {
        var actordetails = await _service.GetByIdAsync(id);
        if (actordetails == null)
        {
            return View("NotFound");
        }
        return View(actordetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id,[Bind ("Id,Name,ProfilePictureURL,Bio")] Actor actor)
    {
        if (!ModelState.IsValid)
        {
             return View(actor);
        }
        await _service.UpdateAsync(id, actor);
         return RedirectToAction(nameof(Index));
    }
    // Get : Actors/Delete
    public async Task <IActionResult> Delete(int id)
    {
        var actordetails = await _service.GetByIdAsync(id);
        if (actordetails == null)
        {
            return View("NotFound");
        }
         return View(actordetails);
    }
    [HttpPost, ActionName ("Delete")]
    public async Task <IActionResult> DeleteConfirmed(int id)
    {
        var actordetails = await _service.GetByIdAsync(id);
        if (actordetails == null)
        {
            return View("NotFound");
        }
        await _service.DeleteAsync(id);
         return RedirectToAction(nameof(Index));
    }


}
