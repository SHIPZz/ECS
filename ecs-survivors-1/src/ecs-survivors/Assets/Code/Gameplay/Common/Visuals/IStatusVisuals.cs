namespace Code.Gameplay.Common.Visuals
{
    public interface IStatusVisuals
    {
        void ApplyFreeze();
        void UnapplyFreeze();
        void ApplyPoison();
        void UnapplyPoison();
    }
}