namespace Locadora.Models;

public class Genero
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;

    public override string ToString() => Nome;
}