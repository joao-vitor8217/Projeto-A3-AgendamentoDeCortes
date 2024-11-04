using Microsoft.EntityFrameworkCore;
using BarbeariaProjeto.Models;
using BarbeariaProjeto.Data;
using BarbeariaProjeto;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=BarbeariaProjeto.db"));

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapAgendamentoEndpoints();
app.MapPBarbeiroEndpoints();

app.Run();