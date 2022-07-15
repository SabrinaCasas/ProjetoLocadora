namespace Locadora.Data;

using Locadora.Models;
using Microsoft.EntityFrameworkCore;

public class AppLocadoraContext : DbContext
{
    public AppLocadoraContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Filme> Filmes { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Genero> Generos { get; set; } = null!;
    public DbSet<Locacao> Locacoes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Filme>(f =>
        {
            f.Property(nameof(Filme.Nome)).HasMaxLength(100).IsRequired();
            f.Property(nameof(Filme.Imagem)).HasMaxLength(250).IsRequired();
            f.HasOne(x => x.Genero).WithMany();
            f.Navigation(x => x.Genero).AutoInclude();
        });

        modelBuilder.Entity<Locacao>().Navigation(f => f.Filme).AutoInclude();
        modelBuilder.Entity<Locacao>().Navigation(f => f.Cliente).AutoInclude();
        modelBuilder.Entity<Locacao>().Navigation(f => f.Usuario).AutoInclude();
        
        modelBuilder.Entity<Genero>(g =>
        {
            g.Property(nameof(Genero.Id)).ValueGeneratedNever();
        });
    }
}

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        using var appContext = scope.ServiceProvider.GetRequiredService<AppLocadoraContext>();
        appContext.Database.Migrate();

        return host;
    }

    public static void SeedData(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        using var appContext = scope.ServiceProvider.GetRequiredService<AppLocadoraContext>();
        appContext.Generos.RemoveRange(appContext.Generos.ToList());
        var generos = new List<Genero>()
        {
            new() { Id = 1, Nome = "Ação" },
            new() { Id = 2, Nome = "Animação" },
            new() { Id = 3, Nome = "Comédia" },
            new() { Id = 4, Nome = "Drama" },
            new() { Id = 5, Nome = "Terror" },
            new() { Id = 6, Nome = "Policial" }


        };
        appContext.AddRange(generos);
        appContext.SaveChanges();
    }
}
