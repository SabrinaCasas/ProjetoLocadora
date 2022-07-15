#nullable disable
using Microsoft.AspNetCore.Mvc;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Controllers;

public class ClientesController : Controller
{
    private readonly IRepository<Cliente> _repository;

    public ClientesController(IRepository<Cliente> repository)
    {
        _repository = repository;
    }

    // GET: Clientes
    public IActionResult Index()
    {
        return View(_repository.GetAll());
    }

    // GET: Clientes/Details/5
    public IActionResult Details(int id)
    {
        var cliente = _repository.Get(id);
        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    // GET: Clientes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Clientes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(cliente);
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    // GET: Clientes/Edit/5
    public IActionResult Edit(int id)
    {
        var cliente = _repository.Get(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    // POST: Clientes/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _repository.Update(cliente);
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    // GET: Clientes/Delete/5
    public IActionResult Delete(int id)
    {
        var cliente = _repository.Get(id);
        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    // POST: Clientes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var cliente = _repository.Get(id);
        _repository.Delete(cliente);
        return RedirectToAction(nameof(Index));
    }
}
