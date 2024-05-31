
using UnityEngine;

namespace Scenes.Player
{
    public class PlayerModel : IPlayerModel
    {
        private int _hp;
        public double ShootRate { get; set; } = 0.5;
        public double Damage { get; set; } = 1;

        public int Hp
        {
            get => _hp;
            set => _hp = value > MaxHp ? MaxHp : value;
        }

        public int MaxHp { get; set; } = 10;
        public int Speed { get; set; } = 5;

        public PlayerModel()
        {
            Hp = MaxHp;
        }
    }
}
