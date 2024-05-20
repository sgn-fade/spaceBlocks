namespace Scenes.Player
{
    public interface IPlayerModel
    {
        int KillCount { get; set; }
        double ShootRate { get; set; }
        double Damage { get; set; }
        int Hp { get; set; }
        int Speed { get; set; }
        void IncrementKillCount();
    }
}
