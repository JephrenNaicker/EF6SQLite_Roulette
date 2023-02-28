using EF6SQLite_Roulette.Data;
using EF6SQLite_Roulette.Logic.Interface;
using EF6SQLite_Roulette.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EF6SQLite_Roulette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WheelController : ControllerBase
    {
       // private readonly RouletteDbContext dbContext;
        private readonly IRouletteDbServices _RoulettedbServices;
        private readonly IWheelBaordServices _IwheelServices;



        //[HttpGet("Test")]
        //public Task<List<WheelBoard>> Get() => dbContext.wheelBoards.FindAsync(1);

        //wheel board UOW
        //Wheel Res UOW

        public WheelController(IWheelBaordServices wheelServices, IRouletteDbServices RouletteDb)
        {
            // dbContext = rouletteDb;
            _IwheelServices = wheelServices;
            _RoulettedbServices = RouletteDb;
        }

        //GET: api/<WheelController>
        [HttpGet("GetAllWheelBoard")]
        public async Task<ActionResult<List<WheelBoard>>> GetAllWheelBoard()
        {
            return Ok(await _RoulettedbServices.GetwheelBoards());
        }

        // GET: api/<WheelController>
        [HttpGet("GetAllPastSpin")]
        public async Task<ActionResult<List<WheelResult>>> GetAllPastSpins()
        {
            return Ok(await _RoulettedbServices.GetAllPastSpins());
        }


        [HttpGet("NumberPicked{Number}")]
        public async Task<ActionResult<string>> NumberPicked(int Number)
        {

            try
            {
                if (Number < 36)
                {
                    var NumPick = await _IwheelServices.NumberPicked(Number);

                    return Ok(NumPick);
                }
                else
                {
                    return BadRequest("Invaided Number: Please Pick Number from 0 - 36");
                }
            }
            catch (Exception e)
            {

                return BadRequest();
            }

        }


        [HttpGet("ColourPicked{Colour}")]
        public async Task<ActionResult<string>> ColourPicked(string Colour)
        {
            try
            {
                var NumPick = await _IwheelServices.ColourPicked(Colour);

                return Ok(NumPick);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        [HttpGet("ODDorEven{ODDorEven}")]
        public async Task<ActionResult<string>> ODDorEvenPicked(string ODDorEven)
        {
            try
            {
                var NumPick = await _IwheelServices.ODDorEvenPicked(ODDorEven);

                return Ok(NumPick);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        [HttpGet("Test Error")]
        public async Task<ActionResult<string>> test()
        {

            try
            {
                //return BadRequest(throw new Exception("Global Error is working"));
                throw new Exception("Global Error is working");
                var NumPick = await _IwheelServices.ODDorEvenPicked("Fake");

                return Ok(NumPick);
            }
            catch (Exception e)
            {
                throw new Exception("Global Error is working");
            }

        }


    }
}
