using CountryDictionaryApiApp;
using CountryDictionaryApiApp.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("/", () => new { Message="server is running" });

app.MapGet("/ping", () => new { Message = "pong" });

app.MapGet("/country", async (ApplicationDbContext db) => await db.Countries.ToListAsync());

app.MapPost("/country", async (Country country, ApplicationDbContext db) =>
{
    await db.Countries.AddAsync(country);
    await db.SaveChangesAsync();
    return country;
});


//получение по айди
app.MapGet("/country/{id:int}", async (ApplicationDbContext db, int id) =>
{
    return await db.Countries.FirstOrDefaultAsync(x => x.Id == id);
});

//редактирование данных о стране
app.MapPost("/country/{id:int}", async (Country country, ApplicationDbContext db, int id) =>
{
    Country? updated = await db.Countries.FirstOrDefaultAsync(x => x.Id == id);
    if (updated != null)
    {
        updated.Name = country.Name;
        updated.ISO31661NumericCode = country.ISO31661NumericCode;
        updated.ISO31661Alpha2Code = country.ISO31661Alpha2Code;
        updated.ISO31661Alpha3Code = country.ISO31661Alpha3Code;
        await db.SaveChangesAsync();
    }
    return updated;
});


app.Run();
