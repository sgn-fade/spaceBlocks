using UnityEngine;

namespace Scenes.BlockSpawner.Block
{
    public interface IBlockController
    {
        public void TakeDamage(int value);
        public void Move();
        public void UpdateHp(int value);
    }
}
