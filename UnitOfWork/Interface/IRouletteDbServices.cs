using EF6SQLite_Roulette.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF6SQLite_Roulette.Logic.Interface
{
    public interface IRouletteDbServices
    {
        Task<IEnumerable<WheelBoard>> GetwheelBoards();

        Task<WheelBoard> GetWheelBoardByID(int id);

        Task InsertWheelBoard(WheelBoard WheelBoard);

        Task InsertWheelResult(int Number, string Colour); 

        Task DeleteWheelBoard(int WheelBoardID);

        void UpdateWheelBoard(WheelBoard WheelBoard);

        Task<ActionResult<List<WheelResult>>> GetAllPastSpins();

        Task Save();
    }
}
