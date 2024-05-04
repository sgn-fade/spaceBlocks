
namespace Scenes.Player
{
    public interface IPlayerController
    {
        void Move();
        void SetShootRate(double value);
        void SetDamage(int value);
        void UpdateHp(int value);
    }
}
