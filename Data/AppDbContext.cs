using BarbeariaProjeto.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaProjeto.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Agendamento> Agendamento { get; set; }
    public DbSet<Barbeiro> Barbeiro { get; set; } = default!;

      }
    }