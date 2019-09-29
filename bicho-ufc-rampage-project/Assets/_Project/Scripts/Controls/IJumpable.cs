
namespace Magrathea.BichoUFCRampage.Controls
{
    public interface IJumpable
    {
        float Force { get; set; }
        void JumpNow();
    }
}