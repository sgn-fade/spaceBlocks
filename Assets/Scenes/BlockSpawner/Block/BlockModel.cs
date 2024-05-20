using UnityEngine;

namespace Scenes.BlockSpawner.Block
{
    public class BlockModel : IBlockModel
    {
        public int Hp { get; set; }
        public int Cost { get; set; }
        public int CostMultiplier { get; set; }

        public BlockModel(int hp)
        {
            CostMultiplier = 1;
            Reset();
        }

        public void Reset()
        {
            Hp = Random.Range(1, 5);
            Cost = Hp * CostMultiplier;
        }
    }
}
