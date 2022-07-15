namespace Locadora.Models;

public class Locacao
{
    public int Id { get; private set; }
    public Cliente Cliente { get; private set; } = null!;
    public Filme Filme { get; private set; } = null!;
    public Usuario? Usuario { get; private set; } = null!;
    public DateTime Data { get; private set; }

    private Locacao()
    {
    }

    public Locacao(Cliente cliente, Filme filme, DateTime data) : this()
    {
        Cliente = cliente;
        Filme = filme;
        Data = data;
    }
}