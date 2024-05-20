using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.BlockSpawner.Block
{
    public class BlockView : MonoBehaviour, IBlockView
    {
        [SerializeField] private GameObject textUi;
        private Text _text;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            
            _text = textUi.GetComponent<Text>();
        }

        public void SetHpText(int value)
        {
            _text.text = value.ToString();
        }

        public void SetBlockColor(Color blockColor)
        {
            spriteRenderer.color = blockColor;
        }
    }
}
