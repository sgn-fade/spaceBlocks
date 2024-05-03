using UnityEngine;

namespace Scenes.Player
{
    public class PlayerData
    {
        public int KillCount { get; set; } = 0;

        public double ShootRate { get; set; } = 0.1;
        public double Damage { get; set; } = 1;
        public int Hp { get; set; } = 1;
        protected void IncrementKillCount()
        {
            KillCount++;
        }
        
    }
}
