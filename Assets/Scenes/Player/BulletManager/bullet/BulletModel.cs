using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Scenes.Player.BulletManager.bullet
{
    public class BulletModel : IBulletModel
    {
        private float _critChance;
        private int _damage;

        public int Damage
        {
            get
            {
                if(System.Random(0,1))
            }
            set
            {

            }
        }
    }
}