using EF6SQLite_Roulette.Models;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLite_Roulette.Data
{
    public class RouletteDbContext: DbContext
    {


        public RouletteDbContext(DbContextOptions<RouletteDbContext> options) : base(options)
        {

        }
        public DbSet<WheelResult> wheelResults { get; set; }
        public DbSet<WheelBoard> wheelBoards { get; set; }


    }
}
