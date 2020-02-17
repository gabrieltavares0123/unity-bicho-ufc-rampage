
namespace Magrathea.bufcr.Actions.Special
{
    public interface IDashController
    {
        bool CanDash();
        void IncrementCounter();
        void RestartCounter();
    }
}