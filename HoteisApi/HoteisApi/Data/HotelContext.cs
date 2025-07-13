using HoteisApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HoteisApi.Data;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options)
    {
    }
    
    public DbSet<Hotel> Hoteis { get; set; } // DbSet for the Hotel model
}