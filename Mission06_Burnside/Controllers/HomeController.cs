using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        return View();
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
       
        return View(response);
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
}