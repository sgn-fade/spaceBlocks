using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Scenes.Player.BulletManager.bullet
{
    public class BulletModelCriticalChance : IBulletModel
    {
        private float _critChance = 0.2f;
        private int _damage = 1;

        public int Damage
        {
            get
            {
                if (Random.value < _critChance)
                {
                    return _damage * 2;
                }

                return _damage;
            }
            set => _damage = value;
        }
    }
}