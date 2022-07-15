using Locadora.Data;
using Locadora.Models;
using Locadora.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppLocadoraContext>(
    o =>
    {
        o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    }
);
builder.Services.AddScoped<IRepository<Cliente>, ClientesRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmesRepository>(); 

var app = builder.Build();

app.MigrateDatabase().SeedData();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
