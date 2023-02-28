using EF6SQLite_Roulette.Data;
using EF6SQLite_Roulette.Logic.Interface;
using EF6SQLite_Roulette.Models;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLite_Roulette.Logic.Services
{
    public class WheelBoardService: IWheelBaordServices
    {

       // private readonly RouletteDbContext dbContext;
        private readonly IRouletteDbServices _RouletteDb;

        public WheelBoardService( IRouletteDbServices RouletteDb)
        {
            _RouletteDb = RouletteDb;
        }


        public async Task<string> NumberPicked(int Number)
        {
            int Rndnumber = GenerateRandomNumber();

            var wbResults = await _RouletteDb.GetWheelBoardByID(Rndnumber);

            string message = string.Empty; 

            if (wbResults != null)
            {
                message = "Number Picked :" + Number + " The Spin Results Number landed on:" + wbResults.wbNumber + " Colour :" + wbResults.wbColour + "You WIN!";
                if (wbResults.wbNumber != Number)
                {
                    message = "Number Picked :" + Number + " The Spin Results Number landed on:" + wbResults.wbNumber + " Colour :" + wbResults.wbColour + "You Lose";
                }

                

                await _RouletteDb.InsertWheelResult(wbResults.wbNumber,wbResults.wbColour);
                await _RouletteDb.Save();

               return message;
            }

            return message;

        }

        public async Task<string> ColourPicked(string Colour)
        {
            List<string> ColourList = new List<string>
            {
                "Green",
                "Red",
                "Black"
            };

            int Rndnumber = GenerateRandomNumber();

            var wbResults = await _RouletteDb.GetWheelBoardByID(Rndnumber);
            string message = "Please Choose Vaild Colour:Green , Red ,Black";
            if (wbResults != null)
            {
                if (ColourList.Contains(Colour.Trim()))
                {
                    message = "Colour Picked :" + Colour + " The Spin Results Number landed on:" + wbResults.wbNumber + " Colour :" + wbResults.wbColour + " You WIN!";

                    if (wbResults.wbColour.ToUpper() != Colour.ToUpper())
                    {
                        message = "Colour Picked :" + Colour + " The Spin Results Number landed on:" + wbResults.wbNumber + " Colour :" + wbResults.wbColour + " You Lose";
                    }
                    await _RouletteDb.InsertWheelResult(wbResults.wbNumber, wbResults.wbColour);
                    await _RouletteDb.Save();
                }
               
                    return message;
            }

            return message;
        }

        public async Task<string> ODDorEvenPicked(string ODDorEven)
        {
            List<string> ODDorEvenList = new List<string>
            {
                "ODD",
                "EVEN"
            };
            int Rndnumber = GenerateRandomNumber();

            var wbResults = await _RouletteDb.GetWheelBoardByID(Rndnumber);

            string message = "Please Choose Vaild Outcome: Odd , Even";

            if (wbResults != null)
            {
                string ODDorEvenResults = (wbResults.wbNumber % 2 == 0) ? "EVEN" : "ODD";
                if (ODDorEvenList.Contains(ODDorEven.ToUpper().Trim()))
                {

                    message = "You Picked :" + ODDorEven + " The Spin Results Number landed on:" + wbResults.wbNumber + " Colour :" + wbResults.wbColour + "Result: " + ODDorEvenResults + ": You Loose!";

                    if (ODDorEvenResults == ODDorEven.ToUpper())
                    {
                        message = "You Picked :" + ODDorEven + " The Spin Results Number landed on:" + wbResults.wbNumber + " Colour :" + wbResults.wbColour + "Result: " + ODDorEvenResults + " You WIN";
                    }


                    await _RouletteDb.InsertWheelResult(wbResults.wbNumber, wbResults.wbColour);
                    await _RouletteDb.Save();

                }
                return message;

            }
           return message;
        }
        public static int GenerateRandomNumber()
        {
            Random rnd = new Random();
            int Rndnumber = rnd.Next(0, 36);


            return Rndnumber;
        }


    }
}
