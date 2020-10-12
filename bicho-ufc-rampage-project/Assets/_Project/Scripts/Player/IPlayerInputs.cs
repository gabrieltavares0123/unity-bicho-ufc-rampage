namespace Magrathea.BUFCR
{
    public interface IPlayerInputs
    {
        bool AnyKeyIsPressed();
        bool GetJumpInput();
        bool GetMoveInput();
        bool GetDashInput();
    }
}