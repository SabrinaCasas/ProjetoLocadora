namespace Locadora.Repositories;

public interface IRepository<T>
{
    List<T> GetAll();
    T? Get(int id);
    void Add(T entity); 
    void Update(T entity);
    void Delete(T entity);
}
