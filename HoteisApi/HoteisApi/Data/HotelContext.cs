using HoteisApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HoteisApi.Data;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options)
    {
    }
    
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Hotel> Hoteis { get; set; }
    public DbSet<Quarto> Quartos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().OwnsOne(h => h.Endereco); // Composição de tabela via Owned Type
        modelBuilder.Entity<Avaliacao>().Property(a => a.Data).HasDefaultValueSql("NOW()"); // Gera a data na hora que o dado for inserido, padrão Postgres
    }
}