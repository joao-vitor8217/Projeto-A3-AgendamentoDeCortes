using BarbeariaProjeto.Data;
using BarbeariaProjeto.Models;
using Microsoft.EntityFrameworkCore;


public static class AgendamentoEndpoints
{
    public static void MapAgendamentoEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/agendamento").WithTags(nameof(Agendamento));


        group.MapGet("/agendamentos", async (AppDbContext db) => 
            await db.Agendamento.Include(c => c.Barbeiro).ToListAsync());


         group.MapGet("/agendamentos/{id}", async (int id, AppDbContext db) =>
         await db.Agendamento.Include(c => c.Barbeiro).FirstOrDefaultAsync(c => c.AgendamentoId == id)
         is Agendamento agendamento ? Results.Ok(agendamento) : Results.NotFound("ID não encontrado."));


        group.MapPost("/agendamentos", async (Agendamento agendamento, AppDbContext db) =>
        {
            db.Agendamento.Add(agendamento);
            await db.SaveChangesAsync();
            return Results.Created($"/agendamentos/{agendamento.AgendamentoId}", agendamento);
        });


       group.MapPut("/agendamentos/{id}", async (int id, Agendamento agendamentoupdate, AppDbContext db) =>
        {
            var agendamento = await db.Agendamento.FindAsync(id);
            if (agendamento is null) return Results.NotFound("ID não encontrado.");

            agendamento.Nome = agendamentoupdate.Nome;
            agendamento.TipoDeCorte = agendamentoupdate.TipoDeCorte;
            agendamento.Data = agendamentoupdate.Data;

            await db.SaveChangesAsync();

            return Results.Ok(agendamento);
        });

        group.MapDelete("/agendamentos/{id}", async (int id, AppDbContext db) =>
        {
            var agendamento = await db.Agendamento.FindAsync(id);
            if (agendamento is null) return Results.NotFound("ID não encontrado.");

            db.Agendamento.Remove(agendamento);
            await db.SaveChangesAsync();

            return Results.Ok();
        });


    }
}