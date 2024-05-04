
namespace Scenes.Player
{
    public class PlayerModel : IPlayerModel
    {
        public int KillCount { get; set; }
        public double ShootRate { get; set; } = 0.5;
        public double Damage { get; set; } = 1;
        public int Hp { get; set; } = 10;
        public void IncrementKillCount()
        {
            KillCount++;
        }
        
    }
}
