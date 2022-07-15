namespace Locadora.Repositories;

using Locadora.Models;
using System.Collections.Generic;
using Locadora.Data;

public class ClientesRepository : IRepository<Cliente>
{
    private readonly AppLocadoraContext _dbContext;

    public ClientesRepository(AppLocadoraContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(Cliente entity)
    {
        _dbContext.Clientes.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(Cliente entity)
    {
        _dbContext.Clientes.Remove(entity);
        _dbContext.SaveChanges();
    }

    public Cliente? Get(int id)
    {
        return _dbContext.Clientes.Find(id);
    }

    public List<Cliente> GetAll()
    {
        return _dbContext.Clientes.ToList();
    }

    public void Update(Cliente entity)
    {
        _dbContext.Clientes.Update(entity);
        _dbContext.SaveChanges();
    }
}
