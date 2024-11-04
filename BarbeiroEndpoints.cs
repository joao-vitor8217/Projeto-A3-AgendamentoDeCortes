using Microsoft.EntityFrameworkCore;
using BarbeariaProjeto.Data;
using BarbeariaProjeto.Models;
namespace BarbeariaProjeto;

public static class BarbeiroEndpoints
{
    public static void MapPBarbeiroEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/barbeiros").WithTags(nameof(Barbeiro));

        group.MapGet("/barbeiros/{id}", async (int id, AppDbContext db) =>
            await db.Barbeiro.FindAsync(id) is Barbeiro barbeiro ? Results.Ok(barbeiro) : Results.NotFound());

        group.MapPost("/barbeiros", async (Barbeiro barbeiro, AppDbContext db) =>
        {
            db.Barbeiro.Add(barbeiro);
            await db.SaveChangesAsync();
            return Results.Created($"/barbeiros/{barbeiro.BarbeiroId}", barbeiro);
        });

        group.MapPut("/barbeiros/{id}", async (int id, Barbeiro barbeiroupdate, AppDbContext db) =>
        {
            var barbeiro = await db.Barbeiro.FindAsync(id);
            if (barbeiro is null) return Results.NotFound();

            barbeiro.BarbeiroNome = barbeiroupdate.BarbeiroNome;
      
            await db.SaveChangesAsync();
            return Results.Ok(barbeiro);
        });

        group.MapDelete("/barbeiros/{id}", async (int id, AppDbContext db) =>
        {
            var barbeiro = await db.Barbeiro.FindAsync(id);
            if (barbeiro is null) return Results.NotFound();

            db.Barbeiro.Remove(barbeiro);
            await db.SaveChangesAsync();

            return Results.Ok();
        });
    }
}
