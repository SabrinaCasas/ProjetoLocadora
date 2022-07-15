namespace Locadora.Repositories;

using Locadora.Data;
using Locadora.Models;

public class FilmesRepository : IFilmeRepository
{
    private readonly AppLocadoraContext _dbContext;

    public FilmesRepository(AppLocadoraContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<Filme> GetAll()
    {
        return _dbContext.Filmes.ToList();
    }

    public Filme? Get(int id)
    {
        return _dbContext.Filmes.Find(id);
    }

    public void Add(Filme entity)
    {
        _dbContext.Filmes.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Update(Filme entity)
    {
        _dbContext.Filmes.Update(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(Filme entity)
    {
        _dbContext.Filmes.Remove(entity);
        _dbContext.SaveChanges();
    }

    public List<Genero> GetGeneroList()
    {
        return _dbContext.Generos.ToList();
    }
}
