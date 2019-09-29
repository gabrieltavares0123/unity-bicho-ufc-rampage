
using System.Collections;

namespace Magrathea.BichoUFCRampage.Controls
{
    public interface IMovableRight
    {
        float Speed { get; set; }
        void GoRight();
    }
}