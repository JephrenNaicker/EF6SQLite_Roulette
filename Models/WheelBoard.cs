using System.ComponentModel.DataAnnotations;

namespace EF6SQLite_Roulette.Models
{
    public class WheelBoard
    {

        [Key]
        public int wbId { get; set; }
        public int wbNumber { get; set; }
        public string wbColour { get; set; } = string.Empty;
    }
}
