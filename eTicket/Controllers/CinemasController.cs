using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTicket.Models;
using eTicket.Data;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers;


public class CinemasController : Controller
{
    private readonly AppDbcontext _context;
    public CinemasController(AppDbcontext context)
    {
        _context = context;
    }
    public async Task <IActionResult> Index()
    {
        var allCinemas = await _context.Cinemas.ToListAsync();
        return View(allCinemas);
    }
}
