
namespace Magrathea.BichoUFCRampage.Dash
{
    public interface IDashCounter
    {
        bool CanDash();
        void IncrementCounter();
        void RestartCounter();
    }
}