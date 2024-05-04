using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.BlockSpawner.Block
{
    public class BlockView : MonoBehaviour, IBlockView
    {
        [SerializeField] private Text text;

        public void SetHpText(int value)
        {
            text.text = value.ToString();
        }

    }
}
