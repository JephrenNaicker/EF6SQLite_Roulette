using EF6SQLite_Roulette.Data;
using EF6SQLite_Roulette.Logic.Interface;
using EF6SQLite_Roulette.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLite_Roulette.Logic.Services
{
    public class RouletteDbServices: IRouletteDbServices,IDisposable
    {
        private readonly RouletteDbContext context;

        public RouletteDbServices(RouletteDbContext dbContext) 
        {
            context = dbContext;
        }

        public async Task<IEnumerable<WheelBoard>> GetwheelBoards()
        {
            return await context.wheelBoards.ToListAsync();
        }

        public async Task<WheelBoard> GetWheelBoardByID(int id)
        {
            return await context.wheelBoards.FindAsync(id);
        }

        public async Task InsertWheelBoard(WheelBoard WheelBoard)
        {
            await context.wheelBoards.AddAsync(WheelBoard);
        }

        public async Task InsertWheelResult(int Number,string Colour)
        {
            WheelResult wheelResult = new WheelResult { wrNumber = Number, wrColour = Colour };
            await context.wheelResults.AddAsync(wheelResult);
        }

        public async Task<ActionResult<List<WheelResult>>> GetAllPastSpins()
        {
           return await context.wheelResults.ToListAsync();
        }

        public async Task DeleteWheelBoard(int WheelBoardID)
        {
            WheelBoard WheelBoard = await context.wheelBoards.FindAsync(WheelBoardID);
            context.wheelBoards.Remove(WheelBoard);
        }

        public void UpdateWheelBoard(WheelBoard WheelBoard)
        {
            context.Entry(WheelBoard).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
