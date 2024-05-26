namespace Scenes.Player
{
    public interface IPlayerModel
    {
        double ShootRate { get; set; }
        double Damage { get; set; }
        int Hp { get; set; }
        int MaxHp { get; set; }
        int Speed { get; set; }
    }
}
