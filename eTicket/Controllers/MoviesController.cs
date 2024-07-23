using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTicket.Models;
using eTicket.Data;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers;


public class MoviesController : Controller
{
    private readonly AppDbcontext _context;
    public MoviesController(AppDbcontext context)
    {
        _context = context;
    }
    public async Task <IActionResult> Index()
    {
        var allMovies = await _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
        return View(allMovies);
    }
}
