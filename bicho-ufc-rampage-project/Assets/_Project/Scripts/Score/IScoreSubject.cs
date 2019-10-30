
namespace Magrathea.BichoUFCRampage.Score
{
    public interface IScoreSubject
    { 
        void AttachObserver(IScoreObserver observer);
        void DetachObserver(IScoreObserver observer);
    }
}