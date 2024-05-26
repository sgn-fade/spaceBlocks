
namespace Scenes.Player
{
    public interface IPlayerController
    {
        void Move();
        void SetShootRate(double value);
        void UpdateHp(int value);
        void UpgradeHp();
        void UpgradeDamage();
        int GetDamage();
    }
}
