using UnityEngine;

namespace Scenes.BlockSpawner.Block
{
    public class BlockModel : IBlockModel
    {
        public int Hp { get; set; }
        public int Cost { get; set; }
        public int DifficultMultiplier { get; set; }

        public BlockModel(int tier)
        {
            DifficultMultiplier = 1;
            Reset(tier);
        }
        public BlockModel()
        {
            DifficultMultiplier = 1;
            Reset(Random.Range(1, 5));
        }

        public void Reset(int tier)
        {
            Hp = tier * DifficultMultiplier;
            Cost = Hp * DifficultMultiplier;
        }
    }
}
