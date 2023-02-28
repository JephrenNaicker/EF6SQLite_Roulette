using System.ComponentModel.DataAnnotations;

namespace EF6SQLite_Roulette.Models
{
    public class WheelResult
    {
        [Key]
        public int wrId { get; set; }
        public int wrNumber { get; set; }
        public string wrColour { get; set; } = string.Empty;
    }
}
