namespace Locadora.Controllers;

using Microsoft.AspNetCore.Mvc;
using Locadora.Models;
using Locadora.Repositories;

public class FilmesController : Controller
{
    private readonly IFilmeRepository _repository;

    public FilmesController(IFilmeRepository repository)
    {
        _repository = repository;
    }

    // GET: Filmes
    public IActionResult Index()
    {
        var filmes = _repository.GetAll();
        return View(filmes);
    }

    // GET: Filmes/Details/5
    public IActionResult Details(int id)
    {
        var filme = _repository.Get(id);
        if (filme is null) 
            return NotFound();

        return View(filme);
    }

    // GET: Filmes/Create
    public IActionResult Create()
    {
        ViewData["Generos"] = _repository.GetGeneroList();
        return View();
    }

    // POST: Filmes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Filme filme)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(filme);
            return RedirectToAction(nameof(Index));
        }
        return View(filme);
    }

    // GET: Filmes/Edit/5
    public IActionResult Edit(int id)
    {
        var filme = _repository.Get(id);
        if (filme is null)
            return NotFound();

        ViewData["Generos"] = _repository.GetGeneroList();
        return View(filme);
    }

    // POST: Filmes/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Filme filme)
    {
        if (id != filme.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _repository.Update(filme);
            return RedirectToAction(nameof(Index));
        }
        return View(filme);
    }

    // GET: Filmes/Delete/5
    public IActionResult Delete(int id)
    {
        var filme = _repository.Get(id);
        if (filme == null)
        {
            return NotFound();
        }

        return View(filme);
    }

    // POST: Filmes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var filme = _repository.Get(id);
        if (filme is null)
            return NotFound();

        _repository.Delete(filme);
        return RedirectToAction(nameof(Index));
    }
}
