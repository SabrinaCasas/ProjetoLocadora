namespace Locadora.Controllers;

using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Locadora.Repositories;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFilmeRepository _filmeRepository;

    public HomeController(ILogger<HomeController> logger, IFilmeRepository filmeRepository)
    {
        _logger = logger;
        _filmeRepository = filmeRepository;
    }

    public IActionResult Index()
    {
        ViewData["Filmes"] = _filmeRepository.GetAll();
        return View();
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
