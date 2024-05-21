using UnityEngine;

namespace Scenes.BlockSpawner.Block
{
    public interface IBlockView
    {
        void SetHpText(int value);
        void SetBlockColor(Color value);
    }
}
