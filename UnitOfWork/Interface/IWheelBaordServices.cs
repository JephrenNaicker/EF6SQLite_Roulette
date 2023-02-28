namespace EF6SQLite_Roulette.Logic.Interface
{
    public interface IWheelBaordServices
    {
        Task<string> NumberPicked(int Number);

        Task<string> ColourPicked(string Colour);

        Task<string> ODDorEvenPicked(string ODDorEven);
    }
}
