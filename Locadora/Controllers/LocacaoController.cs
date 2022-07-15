namespace Locadora.Controllers;

using Microsoft.AspNetCore.Mvc;
using Locadora.Commands;
using Locadora.Data;
using Locadora.Models;
using Locadora.Repositories;

public class LocacaoController : Controller
{
    private readonly IFilmeRepository _repository;
    private readonly AppLocadoraContext _dbContext;

    public LocacaoController(IFilmeRepository repository, AppLocadoraContext dbContext)
    {
        _repository = repository;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var locacoes = _dbContext.Locacoes.ToList();

        return View(locacoes);
    }
    
    // GET: Locacao/5
    public IActionResult Create(int id)
    {
        var filme = _repository.Get(id);
        if (filme == null)
            return NotFound();

        var novaLocacaoDto = new NovaLocacaoCommand()
        {
            FilmeId = filme.Id,
            FilmeNome = filme.Nome
        };

        return View(novaLocacaoDto);
    }

    [HttpPost]
    public IActionResult Create(NovaLocacaoCommand novaLocacao)
    {
        var cliente = _dbContext.Clientes.FirstOrDefault(c => c.Codigo == novaLocacao.CodigoCliente);
        if (cliente is null)
            return NotFound();
        
        var filme = _dbContext.Filmes.Find(novaLocacao.FilmeId);

        var locacao = new Locacao
        (
            cliente,
            filme!,
            DateTime.Now
        );
        
        _dbContext.Locacoes.Add(locacao);
        _dbContext.SaveChanges();
        
        return RedirectToAction(nameof(Index)); 
    }
}
