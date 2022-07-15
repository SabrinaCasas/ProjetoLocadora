namespace Locadora.Repositories;

using Locadora.Models;

public interface IFilmeRepository : IRepository<Filme>
{
    List<Genero> GetGeneroList();
}
