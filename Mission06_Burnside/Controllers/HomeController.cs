using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using Mission06_Burnside.Models;

namespace Mission06_Burnside.Controllers;

public class HomeController : Controller
{

    private MoviesContext _context;

    public HomeController(MoviesContext temp) //Constructor
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EnterMovies()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View(new Movie());
    }

    [HttpPost]
    public IActionResult EnterMovies(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); //Add record to the database 
            _context.SaveChanges();
            return RedirectToAction("Success"); //Redirect to the success action
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            
            return View(response);
        }
        
    }

    public IActionResult Success()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult MovieCollection()
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movieToEdit = _context.Movies
            .FirstOrDefault(x => x.MovieId == id);

        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View("EnterMovies", movieToEdit);

    }

    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        if (updatedInfo.MovieId == 0)
        {
            return BadRequest("Invalid movie id");
        }

        Console.WriteLine($"Updated MovieId: {updatedInfo.MovieId}");

        var movieToEdit = _context.Movies
            .FirstOrDefault(x => x.MovieId == updatedInfo.MovieId);

        if (movieToEdit == null)
        {
            return NotFound();
        }

        // Update properties manually
        movieToEdit.Title = updatedInfo.Title;
        movieToEdit.Year = updatedInfo.Year;
        movieToEdit.Director = updatedInfo.Director;
        movieToEdit.CategoryId = updatedInfo.CategoryId;
        movieToEdit.Rating = updatedInfo.Rating;
        movieToEdit.Edited = updatedInfo.Edited;
        movieToEdit.LentTo = updatedInfo.LentTo;
        movieToEdit.CopiedToPlex = updatedInfo.CopiedToPlex;
        movieToEdit.Notes = updatedInfo.Notes;

        _context.SaveChanges();

        return RedirectToAction("MovieCollection");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movieToDelete = _context.Movies
            .FirstOrDefault(x => x.MovieId == id);

        return View(movieToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie movieToDelete)
    {
        _context.Movies.Remove(movieToDelete);
        _context.SaveChanges();
        
        return RedirectToAction("MovieCollection");
    }

}